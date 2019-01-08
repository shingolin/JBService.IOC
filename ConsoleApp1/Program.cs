using JBService.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerCreator containerCreator = new ContainerCreator();//建立Creator
            containerCreator.CreateBuilder();//建立Builder
            containerCreator.LoadLibrary();//載入dll=>class,interface
            var assemblyInfoList = new List<JBService.IOC.AssemblyImplementInfo>();//設定要註冊的interface及其對應實作
            assemblyInfoList.Add(new AssemblyImplementInfo
            {
                ImplementClassInfo = new AssemblyInfo { ClassName = "ImplementA.ImpA1", Path = @"ImplementA.dll" },
                InterfaceInfo = new AssemblyInfo { ClassName = "ClassLibrary1.InterfaceA", Path = @"ClassLibrary1.dll" },
            });
            assemblyInfoList.Add(new AssemblyImplementInfo
            {
                ImplementClassInfo = new AssemblyInfo { ClassName = "ImplementA.ImpB", Path = @"ImplementA.dll" },
                InterfaceInfo = new AssemblyInfo { ClassName = "ClassLibrary1.InterfaceB", Path = @"ClassLibrary1.dll" },
            });
            assemblyInfoList.Add(new AssemblyImplementInfo
            {
                ImplementClassInfo = new AssemblyInfo { ClassName = "ImpTest2.Imp3", Path = @"ImpTest2.dll" },
                InterfaceInfo = new AssemblyInfo { ClassName = "ClassLibrary1.InterfaceC", Path = @"ClassLibrary1.dll" },
            });
            containerCreator.RegisterAssemblyFromInfo(assemblyInfoList);//選擇模組

            //手動指定選擇的contructor
            //containerCreator.builder.Register<ClassLibrary1.InterfaceB>(containner => new ImplementA.ImpB(containner.Resolve<ClassLibrary1.InterfaceC>()));

            //var container = containerCreator.BuilderContainer();//建立類別容器

            //var service = containerCreator.GetService<ClassLibrary1.InterfaceA>();//注入

            //service.RunA();//叫用

            //var serviceB = containerCreator.GetService<ClassLibrary1.InterfaceB>();
            //serviceB.RunB();

            Console.Read();
        }
    }
}
