using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Firedump.mysql
{
    class DbConnection
    {

        private DbConnection() { }

        private static DbConnection instance = null;
        public static DbConnection Instance()
        {
            if(instance == null)
            {
                instance = new DbConnection();
            }
            return instance;
        }
        
        public string Host
        {
            get; set;
        }

        public string username { get; set; }

        public string password { get; set; }

        public string database { get; set; }

        private MySqlConnection connection;

        public MySqlConnection Connection { get; }

        public bool IsConnect()
        {
            if(connection == null)
            {
                string connectionString;
                if(!String.IsNullOrEmpty(database))
                {
                    connectionString = string.Format("Server=" + Host + "database={0};UID=" + username + ";password=" + password,database);
                } else
                {
                    connectionString = "Server=" + Host + ";UID=" + username + ";password=" + password;
                }              
                connection = new MySqlConnection(connectionString);
                connection.Open();
                return true;
            }
            return false;
        }

        public List<string> getDatabases()
        {
            List<string> databases = new List<string>();

            string query = "show databases;";
            MySqlCommand command = new MySqlCommand(query,connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                databases.Add(reader.GetString(0));
            }

            return databases;
        }

        //before IsConnect database name must been set
        public List<string> getTables()
        {
            List<string> tables = new List<string>();

            string query = "show tables;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                tables.Add(reader.GetString(0));
            }

            return tables;
        }

        public void Close()
        {
            connection.Close();
        }

    }
}
