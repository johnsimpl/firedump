using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data;
using MySql.Data.MySqlClient;
using Firedump.mysql;

namespace FiredumpTest
{
    /// <summary>
    /// this tests need real mysql server database
    /// </summary>
    [TestClass]
    public class TestDbConnection
    {
        [TestMethod]
        public void TesttestConnection()
        {
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);
        }

        [TestMethod]
        public void TestGetDatabases()
        {

        }

        [TestMethod]
        public void TestGetTables()
        {

        }
    }
}
