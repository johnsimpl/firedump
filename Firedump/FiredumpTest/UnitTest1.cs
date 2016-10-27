using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump;
using Firedump.tests;
using System.Collections.Generic;

namespace FiredumpTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Firedump.tests.TestContext context = new Firedump.tests.TestContext();
            FiredumpContextTest service = new FiredumpContextTest(context);

            for (int i = 0; i <= 100; i++)
            {
                mysql_servers server = new mysql_servers();
                server.port = -10000 + i;
                server.host = "HOST"+i;
                server.name = "N"+i;
                server.password = "*"+i;
                server.username = "U" + i;

                server.id = i;
                service.saveMysqlServer(server);             
            }

            List<mysql_servers> servers = service.getAllMySqlServers();

            for(int i =0; i < servers.Count; i++)
            {
                Console.WriteLine(servers[i].id);
            }
            //xriazete kiala tests

        }
    }
}
