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
                ImplementClassInfo = new AssemblyInfo { ClassName = "JBHRIS.HRM.ABSENT.SERVICE.AbsentService", Path = @"JBHRIS.HRM.ABSENT.SERVICE.dll" },
                InterfaceInfo = new AssemblyInfo { ClassName = "JBHRIS.HRM.ABSENT.IAbsentService", Path = @"JBHRIS.HRM.ABSENT.dll" },
            });
            assemblyInfoList.Add(new AssemblyImplementInfo
            {
                ImplementClassInfo = new AssemblyInfo { ClassName = "JBHRIS.HRM.ABSENT.DAL.AbsentServiceRepository", Path = @"JBHRIS.HRM.ABSENT.DAL.dll" },
                InterfaceInfo = new AssemblyInfo { ClassName = "JBHRIS.HRM.ABSENT.SERVICE.IAbsentServiceRepository", Path = @"JBHRIS.HRM.ABSENT.SERVICE.dll" },
            });
            assemblyInfoList.Add(new AssemblyImplementInfo
            {
                ImplementClassInfo = new AssemblyInfo { ClassName = "JBHRIS.HRM.ABSENT.DAL.TestAbsentServiceBll", Path = @"JBHRIS.HRM.ABSENT.DAL.dll" },
                InterfaceInfo = new AssemblyInfo { ClassName = "JBHRIS.HRM.ABSENT.SERVICE.IAbsentServiceBll", Path = @"JBHRIS.HRM.ABSENT.SERVICE.dll" },
            });
            var helper = new JBService.IOC.ConnectionHelper(Properties.Settings.Default.MyConnectionString);
            containerCreator.builder.Register<JBService.IOC.ConnectionHelper>(p=>helper).As<JBService.IOC.ConnectionHelper>();
            containerCreator.RegisterAssemblyFromInfo(assemblyInfoList);//選擇模組

            //手動指定選擇的contructor
            //containerCreator.builder.Register<ClassLibrary1.InterfaceB>(containner => new ImplementA.ImpB(containner.Resolve<ClassLibrary1.InterfaceC>()));

            var container = containerCreator.BuilderContainer();//建立類別容器
            var repo = containerCreator.GetService<JBService.IOC.ConnectionHelper>();
            var service = containerCreator.GetService<JBHRIS.HRM.ABSENT.IAbsentService>();//注入
            var data = service.GetEntitles("110406", "W", new DateTime(2018, 12, 31), new DateTime(2018, 12, 31));
            //service.RunA();//叫用

            //var serviceB = containerCreator.GetService<ClassLibrary1.InterfaceB>();
            //serviceB.RunB();


            Console.Read();
        }
    }
}
