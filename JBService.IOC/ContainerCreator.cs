using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace JBService.IOC
{
    public class ContainerCreator
    {
        public ContainerBuilder builder;
        List<AssemblyImplementInfo> _assemblyImpInfos;
        List<AssemblyInfo> assemblyInfos;
        IContainer container;

        public void CreateBuilder()
        {
            builder = new ContainerBuilder();
        }

        public void LoadLibrary(string path = @"\plugin", string searchPattern = "*.dll")
        {
            assemblyInfos = new List<AssemblyInfo>();
            string dir = Directory.GetCurrentDirectory() + path;
            var files = Directory.GetFiles(dir, searchPattern, SearchOption.TopDirectoryOnly).Select(Assembly.LoadFrom);
            foreach (var assembly in files)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var info = new AssemblyInfo
                    {
                        ClassName = type.FullName,
                        Path = assembly.Location
                    };
                    assemblyInfos.Add(info);
                }
            }
        }


        public void RegisterAssemblyFromInfo(AssemblyImplementInfo assemblyImpInfo)
        {
            List<AssemblyImplementInfo> assemblyImpInfos = new List<AssemblyImplementInfo>();
            assemblyImpInfos.Add(assemblyImpInfo);
            RegisterAssemblyFromInfo(assemblyImpInfos);
        }
        public void RegisterAssemblyFromInfo(List<AssemblyImplementInfo> assemblyImpInfos)
        {
            _assemblyImpInfos = assemblyImpInfos;
            if (builder == null)
            {
                return;
            }
            foreach (var info in _assemblyImpInfos)
            {
                var assembly = Assembly.LoadFrom(info.ImplementClassInfo.Path);
                var typeImplement = assembly.GetType(info.ImplementClassInfo.ClassName);
                assembly = Assembly.LoadFrom(info.InterfaceInfo.Path);
                var typeInterface = assembly.GetType(info.InterfaceInfo.ClassName);
                builder.RegisterType(typeImplement).As(typeInterface);
            }
        }


        public void RegisterModulesFromPath(string path, string searchPattern = "*.dll")
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                return;
            }

            //  Gets all compiled assemblies.
            //  This is particularly useful when extending applications functionality from 3rd parties,
            //  if there are interfaces within the modules.
            var assemblies = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly)
                                      .Select(Assembly.LoadFrom);

            foreach (var assembly in assemblies)
            {
                //  Gets the all modules from each assembly to be registered.
                //  Make sure that each module **MUST** have a parameterless constructor.
                var modules = assembly.GetTypes()
                                      .Where(p => typeof(IModule).IsAssignableFrom(p)
                                                  && !p.IsAbstract)
                                      .Select(p => (IModule)Activator.CreateInstance(p));

                //  Regsiters each module.
                foreach (var module in modules)
                {
                    builder.RegisterModule(module);
                }
            }
        }

        public IContainer BuilderContainer()
        {
            container = builder.Build();
            return container;
        }


        public T GetService<T>()
        {
            if (container == null)
            {
                return default(T);
            }
            var service = container.Resolve<T>();
            return service;
        }


        private IContainer Create()
        {
            CreateBuilder();
            LoadLibrary();
            return BuilderContainer();
        }
    }
}
