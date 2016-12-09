using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firedump.models.configuration.dynamicconfig;
using MySql.Data.MySqlClient;
using System.IO;

namespace Firedump.models.sqlimport
{
    class SQLImport
    {
        private ImportCredentialsConfig config;
        private string connectionString;
        private SQLImport() { }
        public SQLImport(ImportCredentialsConfig config)
        {
            this.config = config;
            conStringBuilder();
        }

        private void conStringBuilder()
        {
            connectionString = "Server=" + config.host + ";UID=" + config.username;
            if (!string.IsNullOrWhiteSpace(config.password))
            {
                connectionString += ";password=" + config.password;
            }
            if (!string.IsNullOrWhiteSpace(config.database))
            {
                connectionString += ";database=" + config.database;
            }
        }

        public ImportResultSet executeScript()
        {
            ImportResultSet result = new ImportResultSet();
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();

                //MySqlScript script = new MySqlScript(con, File.ReadAllText())
            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = ex.Message;
            }

            return result;
        }
        
    }
}
