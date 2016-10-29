using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.db;

namespace FiredumpTest
{
    [TestClass]
    public class TestInitDb
    {

        /// <summary>
        /// output testdb is on FiredumpTest\bin\Debug
        /// </summary>
        [TestMethod]
        public void TestCreateDb()
        {
            InitDb db = new InitDb();
            db.createDbTables();

            //more tests tommorow

        }


    }
}
