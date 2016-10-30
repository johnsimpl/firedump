using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Firedump.mysql
{
    class DbConnection
    {

        private DbConnection() {
            port = 3306;
        }

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

        public int port { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string database { get; set; }

        private MySqlConnection connection;

        public MySqlConnection Connection { get; }

        public bool testConnection()
        {
            string connectionString;
            if (!String.IsNullOrEmpty(database))
            {
                connectionString = string.Format("Server=" + Host + ";database={0};UID=" + username + ";password=" + password, database);
            }
            else
            {
                connectionString = "Server=" + Host + ";UID=" + username + ";password=" + password;
            }
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch(ArgumentException a_ex)
            {
                Console.WriteLine("Check the connection string");
                Console.WriteLine(a_ex.Message);
                Console.WriteLine(a_ex.ToString());
                return false;
            }
            catch(MySqlException ex)
            {
                string sqlErrorMessage = "Message: " + ex.Message + "\n" +"Source: " + ex.Source + "\n" +"Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042: 
                        Console.WriteLine("Unable to connect to any of the specified MySQL hosts (Check Server,Port)");
                        break;
                    case 0: // 
                        Console.WriteLine("Access denied (Check DB name,username,password)");
                        break;
                    default:
                        break;
                }
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Must be connected to a server and not to a database
        /// </summary>
        /// <returns></returns>
        public List<string> getDatabases()
        {
            connection.Open();
            List<string> databases = new List<string>();

            string query = "show databases;";
            MySqlCommand command = new MySqlCommand(query,connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                databases.Add(reader.GetString(0));
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return databases;
        }

        /// <summary>
        /// Must be connected to a server and not to a database
        /// </summary>
        /// <param name="database">The database name</param>
        /// <returns>A list of the tables in the database</returns>
        public List<string> getTables(String database)
        {
            connection.Open();
            List<string> tables = new List<string>();

            string query = "show tables from "+database+";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                tables.Add(reader.GetString(0));
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return tables;
        }

        /// <summary>
        ///  Must be connected to database and not to server
        /// </summary>
        /// <returns>A list of the tables in the database</returns>
        public List<string> getTables()
        {
            connection.Open();
            List<string> tables = new List<string>();

            string query = "show tables;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tables.Add(reader.GetString(0));
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return tables;
        }

        public void Close()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
