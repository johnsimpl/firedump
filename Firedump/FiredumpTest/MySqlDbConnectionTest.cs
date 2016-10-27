using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FiredumpTest
{
    [TestClass]
    public class MySqlDbConnectionTest
    {
        [TestMethod]
        public void TestDbConnection()
        {
            MySqlConnection con = new MySqlConnection("Server=192.168.2.5;UID=newroot;password=1zeronerone");
            con.Open();
            
            Console.WriteLine(con.ServerVersion);
            Console.WriteLine(con.State);
            MySqlCommand com = new MySqlCommand("show databases;", con);
            MySqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }


        }
    }
}
