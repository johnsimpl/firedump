using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.models.dump;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;

namespace FiredumpTest
{
    [TestClass]
    public class TestMysqlDump
    {
        [TestMethod]
        public void TestExecuteDump()
        {
            ConfigurationManager.getInstance().initializeConfig();

            MysqlDump mysqldump = new MysqlDump(null);
            CredentialsConfig creconfig = new CredentialsConfig();
            creconfig.host = "localhost";
            creconfig.port = 3306;
            creconfig.username = "root";
            creconfig.password = "password";
            creconfig.database = "your database";

            mysqldump.credentialsConfigInstance = creconfig;
            DumpResultSet dumpresult = mysqldump.executeDump();

            Console.WriteLine(dumpresult.ToString());
            Assert.IsTrue(dumpresult.wasSuccessful);
            //more test todo
        }
    }
}
