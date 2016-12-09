using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firedump.models.configuration.dynamicconfig;
using MySql.Data.MySqlClient;
using Firedump.utils;

namespace Firedump.models.sqlimport
{
    class SQLImport
    {
        public string script { set; get; }
        public ImportCredentialsConfig config { get; }
        private ISQLImportListener listener;
        private int commandCounter = 0;
        private string connectionString;
        private SQLImport() { }
        public SQLImport(ImportCredentialsConfig config, ISQLImportListener listener)
        {
            this.config = config;
            this.listener = listener;
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
            if (string.IsNullOrWhiteSpace(this.script))
            {
                result.wasSuccessful = false;
                result.errorMessage = "Script not set";
                return result;
            }
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();

                MySqlScript script = new MySqlScript(con, this.script);
                script.StatementExecuted += scriptStatementExecuted;
                script.Execute();

                result.wasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = ex.Message;
            }

            return result;
        }

        private void scriptStatementExecuted(object sender, MySqlScriptEventArgs e)
        {
            commandCounter += StringUtils.countOccurances(e.StatementText, config.scriptDelimeter); 
            listener.onProgress(commandCounter);
        }
        
    }
}
