using System;
using System.Data.SqlClient;
using System.Linq;
using JBHRIS.HRM.ABSENT.DAL;
using JBService.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service_UnitTestProject
{
    [TestClass]
    public class AbsentService_Dal_UnitTest
    {
        [TestMethod]
        public void AbsentServiceRepository_GetEntitles_Test()
        {
            //SqlConnection conn=new SqlConnection(Properties.Settings.Default.TestConnectionString)

            AbsentServiceRepository absentServiceRepository = new AbsentServiceRepository(new ConnectionHelper(Properties.Settings.Default.TestConnectionString));
            var entitles=absentServiceRepository.GetEntitles("110406", "W", new DateTime(2018, 12, 1), new DateTime(2018, 12, 31));
            Assert.AreEqual(true, entitles.Any());
        }
    }
}
