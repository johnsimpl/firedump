

using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace Firedump.models.configuration
{
    public class MySqlDumpConfig : ConfigurationClass
    {
        private readonly string jsonFilePath = "./config/MySqlDumpConfig.json";

        //<!configuration fields section>
        /// <summary>
        /// temporal save path for dump files before saving to intended location
        /// </summary>
        public string tempSavePath { set; get; }
        /// <summary>
        /// the maximum wait time for dump completion before aborting
        /// </summary>
        public int databaseTimeout { set; get; } = 10000;
        /// <summary>
        /// whether to include create schema sql in the dump file
        /// </summary>
        public bool includeCreateSchema { set; get; } = true;
        /// <summary>
        /// whether to include table data in the dump file
        /// </summary>
        public bool includeData { set; get; } = true;
        /// <summary>
        /// wether to include comments in dump file
        /// </summary>
        public bool includeComments { set; get; } = true;
        /// <summary>
        /// wether to execute the dump in a single transaction
        /// </summary>
        public bool singleTransaction { set; get; } 
        /// <summary>
        /// wether to disable foreign key checks in dump file (makes importing the dump file faster because the indexes are created after all rows are inserted)
        /// </summary>
        public bool disableForeignKeyChecks { set; get; } 
        /// <summary>
        /// wether to add drop database in the dump file
        /// </summary>
        public bool addDropDatabase { set; get; }
        /// <summary>
        /// wether to add create database in the dump file
        /// </summary>
        public bool createDatabase { set; get; } = true;
        /// <summary>
        /// custom comment to add in the header of the dump file leave empty or null for no comment
        /// </summary>
        public string addCustomCommentInHeader { set; get; } = "";
        /// <summary>
        /// default character set of the dump file
        /// </summary>
        public string characterSet { set; get; } = "utf-8";

        //structure
        /// <summary>
        /// wether to add drop table/view/procedure/function in the dump file
        /// </summary>
        public bool addDropTable { set; get; }
        /// <summary>
        /// wether to add if not exists sql in the dump file
        /// </summary>
        public bool addIfNotExists { set; get; } = true;
        /// <summary>
        /// wether to add auto increment values in the dump file
        /// </summary>
        public bool addAutoIncrementValue { set; get; } = true;
        /// <summary>
        /// wether to enclose table and field names in backquotes in the dump file
        /// </summary>
        public bool encloseWithBackquotes { set; get; } = true;
        /// <summary>
        /// wether to add create procedure and function statements in the sql file
        /// </summary>
        public bool addCreateProcedureFunction { set; get; }
        /// <summary>
        /// wether to add info comments (creation/update/check dates)
        /// </summary>
        public bool addInfoComments { set; get; }

        //data
        /// <summary>
        /// use complete insert statements that include column names (larger dump file but durable to database structure changes)
        /// </summary>
        public bool completeInsertStatements { set; get; } = true;
        /// <summary>
        /// use multiple-row INSERT syntax that include serveral VALUES lists
        /// </summary>
        public bool extendedInsertStatements { set; get; } = true;
        /// <summary>
        /// maximum length of insert query. If query exceeds the specified length it is split into smaller queries.
        /// </summary>
        public int maximumLengthOfQuery { set; get; } = 50000;
        /// <summary>
        /// the maximum packet length to send or recieve from the server (in MB)
        /// </summary>
        public int maximumPacketLength { set; get; } = 1024;
        /// <summary>
        /// write INSERT DELAYED statements rather than INSERT statements
        /// </summary>
        public bool useDelayedInserts { set; get; }
        /// <summary>
        /// write INSERT IGNORE statements rather than INSERT statements
        /// </summary>
        public bool useIgnoreInserts { set; get; }
        /// <summary>
        /// dump binary columns using hexadecimal notation for example 'abc' becomes 0x616263)
        /// </summary>
        public bool useHexadecimal { set; get; } = true;
        /// <summary>
        /// 0 - INSERT statements
        /// 1 - UPDATE statements
        /// 2 - REPLACE statements
        /// </summary>
        public int exportType { set; get; } = 0;
        /// <summary>
        /// the database name to dump (leave null or empty to dump all databases in the server)
        /// </summary>
        public string database { set; get; }
        /// <summary>
        /// string array with all the database names to dump (leave it null to disregard this field)
        /// </summary>
        public string[] databases { set; get; }
        /// <summary>
        /// each element in this array is a string of table names from a database seperated with commas.
        /// For example if database Foo contains tables Table1 Table2 and Table3 and 1,2 are excluded the
        /// table names must be placed in this format Table1,Table2 at the exact index of the database for the databases array.
        /// If there are more than one databases in the databases array fill all other indexes of this array with empty strings.
        /// This array must always have the same length as the databases array in order to be used. Leave it null to exclude
        /// no tables. If the length of databases and this array differs this option is disregarded and no tables are excluded.
        /// </summary>
        public string[] excludeTables { set; get; }

        //</configuration fields section>

        private static MySqlDumpConfig mysqlDumpConfigInstance;

        private MySqlDumpConfig() { }
        public static MySqlDumpConfig getInstance()
        {
            if (mysqlDumpConfigInstance == null)
            {
                mysqlDumpConfigInstance = new MySqlDumpConfig();
            }
            return mysqlDumpConfigInstance;
        }

        public void initializeConfig()
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                //<Field initialization>
                this.tempSavePath = jsonObj["tempSavePath"];
                this.databaseTimeout = jsonObj["databaseTimeout"];
                this.includeCreateSchema = jsonObj["includeCreateSchema"];
                this.includeData = jsonObj["includeData"];
                this.includeComments = jsonObj["includeComments"];
                this.singleTransaction = jsonObj["singleTransaction"];
                this.disableForeignKeyChecks = jsonObj["disableForeignKeyChecks"];
                this.addDropDatabase = jsonObj["addDropDatabase"];
                this.createDatabase = jsonObj["createDatabase"];
                this.addCustomCommentInHeader = jsonObj["addCustomCommentInHeader"];
                this.characterSet = jsonObj["characterSet"];
                this.addDropTable = jsonObj["addDropTable"];
                this.addIfNotExists = jsonObj["addIfNotExists"];
                this.addAutoIncrementValue = jsonObj["addAutoIncrementValue"];
                this.encloseWithBackquotes = jsonObj["encloseWithBackquotes"];
                this.addCreateProcedureFunction = jsonObj["addCreateProcedureFunction"];
                this.addInfoComments = jsonObj["addInfoComments"];
                this.completeInsertStatements = jsonObj["completeInsertStatements"];
                this.extendedInsertStatements = jsonObj["extendedInsertStatements"];
                this.maximumLengthOfQuery = jsonObj["maximumLengthOfQuery"];
                this.maximumPacketLength = jsonObj["maximumPacketLength"];
                this.useDelayedInserts = jsonObj["useDelayedInserts"];
                this.useIgnoreInserts = jsonObj["useIgnoreInserts"];
                this.useHexadecimal = jsonObj["useHexadecimal"];
                this.exportType = jsonObj["exportType"];
                this.database = jsonObj["database"];
                this.databases = jsonObj["databases"];
                this.excludeTables = jsonObj["excludeTables"];
                //</Field initialization>
            }
            catch (Exception ex)
            {
                createConfig();
                initializeConfig();
                if (!(ex is FileNotFoundException || ex is JsonException || ex is RuntimeBinderException))
                {
                    Console.WriteLine("MySqlDumpConfig.initializeConfig(): "+ex.ToString());
                }
            }
        }

        public void createConfig()
        {
            this.tempSavePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\AppData\\roaming\\Firedump\\";
            string jsonOutput = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, jsonOutput);
        }

        public void saveConfig()
        {
            string jsonOutput = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, jsonOutput);
        }
    }
}