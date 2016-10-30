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

        private static string password = "password";

        [TestMethod]
        public void TestTestConnection()
        {
            
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);

            connection.Host = "localhost";
            connection.username = "root";
            connection.password = password;

            Assert.IsTrue(connection.testConnection());

            connection.Host = "localhost";
            connection.username = "invaliduser";
            connection.password = "passwd";

            Assert.IsFalse(connection.testConnection());
            
        }

       

        [TestMethod]
        public void TestGetDatabases()
        {
            
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);

            connection.Host = "localhost";
            connection.username = "root";
            connection.password = password;

            Assert.IsFalse(connection.getDatabases().Count == 0);
            
        }

        [TestMethod]
        public void TestGetTables()
        {
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);

            connection.Host = "localhost";
            connection.username = "root";
            connection.password = password;

            //may not always pass!
            //depends on the mysql user privilages,if it has read permissions for information_schema and mysql databases
            Assert.IsFalse(connection.getTables("information_schema").Count == 0);
            Assert.IsFalse(connection.getTables("mysql").Count == 0);
        }
    }
}
