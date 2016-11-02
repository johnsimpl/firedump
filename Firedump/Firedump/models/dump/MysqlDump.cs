using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using Firedump.models.dump;
using System.IO;
using System.Text.RegularExpressions;
using Firedump.mysql;

namespace Firedump.models.dump
{
    public class MysqlDump
    {
        ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
        /// <summary>
        /// Create a new credentials instance and set it before executing mysqldump
        /// </summary>
        public CredentialsConfig credentialsConfigInstance { set; get; }

        private IAdapterListener listener;
        private Process proc;
        private Compression comp;
        private string tempTableName = "";

        public MysqlDump(IAdapterListener listener)
        {
            this.listener = listener;
        }


        public DumpResultSet executeDump()
        {          
            DumpResultSet resultObj = new DumpResultSet();
            StringBuilder arguments = new StringBuilder();

            //<ConfigurationSection>

            arguments.Append("--protocol=tcp ");

            //Credentials

            //host
            if (!String.IsNullOrEmpty(credentialsConfigInstance.host))
            {
                arguments.Append("--host " + credentialsConfigInstance.host + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Host not set";
                return resultObj;
            }

            //port
            if (credentialsConfigInstance.port<1 || credentialsConfigInstance.port>65535)
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Invalid port number: " + credentialsConfigInstance.port;
                return resultObj; 
            }
            else
            {
                arguments.Append("--port=" + credentialsConfigInstance.port + " ");
            }
            
            //username
            if (!String.IsNullOrEmpty(credentialsConfigInstance.username))
            {
                arguments.Append("--user " + credentialsConfigInstance.username + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Username not set";
                return resultObj;
            }

            //pasword
            if (!String.IsNullOrEmpty(credentialsConfigInstance.password))
            {
                arguments.Append("--password=" + credentialsConfigInstance.password + " ");
            }

            //MySqlDumpConfiguration

            //includeCreateSchema
            if (!configurationManagerInstance.mysqlDumpConfigInstance.includeCreateSchema)
            {
                arguments.Append("--no-create-info ");
            }

            //includeData
            if (!configurationManagerInstance.mysqlDumpConfigInstance.includeData)
            {
                arguments.Append("--no-data ");
            }

            //includeComments
            if (!configurationManagerInstance.mysqlDumpConfigInstance.includeComments)
            {
                arguments.Append("--skip-comments ");
            }

            //singleTransaction
            if (configurationManagerInstance.mysqlDumpConfigInstance.singleTransaction)
            {
                arguments.Append("--single-transaction ");
            }

            //disableForeignKeyChecks
            if (configurationManagerInstance.mysqlDumpConfigInstance.disableForeignKeyChecks)
            {
                arguments.Append("--disable-keys ");
            }

            //addDropDatabase
            if (configurationManagerInstance.mysqlDumpConfigInstance.addDropDatabase)
            {
                arguments.Append("--add-drop-database ");
            }

            //createDatabase
            if (!configurationManagerInstance.mysqlDumpConfigInstance.createDatabase)
            {
                arguments.Append("--no-create-db ");
            }

            //moreCompatible
            if (configurationManagerInstance.mysqlDumpConfigInstance.moreCompatible)
            {
                arguments.Append("--compatible ");
            }

            //characterSet
            if (configurationManagerInstance.mysqlDumpConfigInstance.characterSet!="utf8")
            {
                string charSetPath = "\""+AppDomain.CurrentDomain.BaseDirectory + "resources\\mysqldump\\charsets\"";
                arguments.Append("--character-sets-dir="+charSetPath+" ");
                arguments.Append("--default-character-set="+ configurationManagerInstance.mysqlDumpConfigInstance.characterSet + " ");
            }

            //addDropTable
            if (configurationManagerInstance.mysqlDumpConfigInstance.addDropTable)
            {
                arguments.Append("--add-drop-table ");
            }
            else
            {
                arguments.Append("--skip-add-drop-table ");
            }

            //addLocks
            if (configurationManagerInstance.mysqlDumpConfigInstance.addLocks)
            {
                arguments.Append("--add-locks ");
            }

            //noAutocommit
            if (configurationManagerInstance.mysqlDumpConfigInstance.noAutocommit)
            {
                arguments.Append("--no-autocommit ");
            }

            //encloseWithBackquotes
            if (!configurationManagerInstance.mysqlDumpConfigInstance.encloseWithBackquotes)
            {
                arguments.Append("--skip-quote-names ");
            }

            //addCreateProcedureFunction
            if (configurationManagerInstance.mysqlDumpConfigInstance.addCreateProcedureFunction)
            {
                arguments.Append(" --routines ");
            }

            //addInfoComments
            if (configurationManagerInstance.mysqlDumpConfigInstance.addInfoComments)
            {
                arguments.Append("--dump-date ");
            }

            //completeInsertStatements
            if (configurationManagerInstance.mysqlDumpConfigInstance.completeInsertStatements)
            {
                arguments.Append("--complete-insert ");
            }

            //extendedInsertStatements
            if (configurationManagerInstance.mysqlDumpConfigInstance.completeInsertStatements)
            {
                arguments.Append("--extended-insert ");
            }

            //maximumLengthOfQuery
            arguments.Append("--net-buffer-length " + configurationManagerInstance.mysqlDumpConfigInstance.maximumLengthOfQuery + " ");

            //maximumPacketLength
            arguments.Append("--max_allowed_packet="+ configurationManagerInstance.mysqlDumpConfigInstance.maximumPacketLength + "M ");

            //useIgnoreInserts
            if (configurationManagerInstance.mysqlDumpConfigInstance.useIgnoreInserts)
            {
                arguments.Append("--insert-ignore ");
            }

            //useHexadecimal
            if (configurationManagerInstance.mysqlDumpConfigInstance.useHexadecimal)
            {
                arguments.Append("--hex-blob ");
            }

            //dumpTriggers
            if (!configurationManagerInstance.mysqlDumpConfigInstance.dumpTriggers)
            {
                arguments.Append("--skip-triggers ");
            }

            //dumpEvents
            if (configurationManagerInstance.mysqlDumpConfigInstance.dumpEvents)
            {
                arguments.Append("--events ");
            }

            //xml
            if (configurationManagerInstance.mysqlDumpConfigInstance.xml)
            {
                arguments.Append("--xml ");
            }

            //exportType
            switch (configurationManagerInstance.mysqlDumpConfigInstance.exportType)
            {
                case 0:
                    break;
                case 1:
                    arguments.Append("--replace ");
                    break;
                default:
                    break;         
            }

            //database choice
            if (credentialsConfigInstance.databases == null)
            {
                if (string.IsNullOrEmpty(credentialsConfigInstance.database))
                {
                    arguments.Append("--all-databases ");
                }
                else
                {
                    arguments.Append("--databases "+ credentialsConfigInstance.database);
                    if (credentialsConfigInstance.excludeTablesSingleDatabase!=null)
                    {
                        arguments.Append(" ");
                        string[] tables = credentialsConfigInstance.excludeTablesSingleDatabase.Split(',');
                        foreach (string table in tables)
                        {
                            arguments.Append("--ignore-table=" + credentialsConfigInstance.database + "." + table + " ");
                        }
                    }
                }
            }
            else
            {
                arguments.Append("--databases ");
                foreach (string database in credentialsConfigInstance.databases)
                {
                    arguments.Append(database+" ");
                }
                if (credentialsConfigInstance.excludeTables != null)
                {
                    for(int i=0; i< credentialsConfigInstance.excludeTables.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(credentialsConfigInstance.excludeTables[i]))
                        {
                            string[] tables = credentialsConfigInstance.excludeTables[i].Split(',');
                            foreach (string table in tables)
                            {
                                arguments.Append("--ignore-table=" + credentialsConfigInstance.databases[i] + "." + table + " ");
                            }
                        }
                    }
                }
            }

            //</ConfigurationSection>


            //dump execution
            Console.WriteLine(arguments.ToString());

            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "resources\\mysqldump\\mysqldump.exe",//AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe") ,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            Console.WriteLine("MySqlDump: Dump starting now");
            proc.Start();

            Random rnd = new Random();
            string fileExt;
            if (configurationManagerInstance.mysqlDumpConfigInstance.xml)
            {
                fileExt = ".xml";
            }
            else
            {
                fileExt = ".sql";
            }
            String filename = "dump" + rnd.Next(1000000, 9999999) + fileExt;

            Directory.CreateDirectory(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath);
           

            //checking if file exists
            while (File.Exists(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename)){
                filename = "Dump" + rnd.Next(10000000, 99999999) + fileExt;
            }


            bool includeCreateSchema = ConfigurationManager.getInstance().mysqlDumpConfigInstance.includeCreateSchema;
            bool ignoreInsert = ConfigurationManager.getInstance().mysqlDumpConfigInstance.useIgnoreInserts;
            int insertReplace = ConfigurationManager.getInstance().mysqlDumpConfigInstance.exportType; 

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename))
            {
                //addCustomCommentInHeader
                if (!string.IsNullOrEmpty(configurationManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader))
                {
                    file.WriteLine("-- Custom comment: " + configurationManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader);
                }

               
                while (!proc.StandardOutput.EndOfStream)
                {              
                    string line = proc.StandardOutput.ReadLine();
                    file.WriteLine(line);                  
                    handleLineOutput(line,includeCreateSchema,ignoreInsert,insertReplace);                   
                }
                
            }

            
            resultObj.mysqldumpexeStandardError = "";
            while (!proc.StandardError.EndOfStream)
            {
               resultObj.mysqldumpexeStandardError += proc.StandardError.ReadLine()+"\n";
            }

            Console.WriteLine(resultObj.mysqldumpexeStandardError); //for testing

            proc.WaitForExit();

            if (proc.ExitCode != 0)
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -2;
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
            }
            else
            {
                resultObj.wasSuccessful = true;
                resultObj.fileAbsPath = configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename;

                //compression
                if (configurationManagerInstance.compressConfigInstance.enableCompression)
                {
                    comp = new Compression(listener);
                    comp.absolutePath = resultObj.fileAbsPath;
                   
                    CompressionResultSet compResult = comp.doCompress7z(); //edw kaleitai to compression

                    if (!compResult.wasSucessful)
                    {
                        resultObj.wasSuccessful = false;
                        resultObj.errorNumber = -3;
                        resultObj.mysqldumpexeStandardError = compResult.standardError;
                    }
                    File.Delete(resultObj.fileAbsPath); //delete to sketo .sql
                    resultObj.fileAbsPath = compResult.resultAbsPath;
                }
            }
                    
            return resultObj;
        }


        public void cancelMysqlDumpProcess()
        {        
                try
                {
                    comp.KillProc();
                    proc.Kill();
                    proc = null;                   
                }catch(Exception ex)
                {
                }
                 
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="createschema"></param>
        private void handleLineOutput(string line,bool createschema,bool ignoreInsert,int insertReplace)
        {
            
            string insertStartsWith = "";
            if(insertReplace == 1 && ignoreInsert == true)
            {
                insertStartsWith = "REPLACE  IGNORE INTO `";
            } else if(insertReplace == 1)
            {
                insertStartsWith = "REPLACE INTO `";
            } else if(ignoreInsert)
            {
                insertStartsWith = "INSERT  IGNORE INTO `";
            } else
            {
                insertStartsWith = "INSERT INTO `";
            }

            //Console.WriteLine(insertStartsWith);

            if (createschema)
            {
                if (line.StartsWith("CREATE TABLE `"))
                {
                    string tablename = line.Split('`', '`')[1];
                    Console.WriteLine(tablename);
                    int rowcount = getTableRowsCount(tablename);
                    if (listener != null)
                    {   //fire event
                        listener.onTableStartDump(tablename);
                        listener.tableRowCount(rowcount);
                    }
                }
                
            }
            else
            {               
                if (line.StartsWith(insertStartsWith))
                {
                    string tablename = line.Split('`', '`')[1];
                    if(tablename == tempTableName)
                    {

                    } else
                    {
                        tempTableName = tablename;
                        int rowcount = getTableRowsCount(tablename);
                        Console.WriteLine(tablename);
                        if (listener != null)
                        {   //fire event
                            listener.onTableStartDump(tablename);
                            listener.tableRowCount(rowcount);
                        }
                    }
                    
                }
            }
        }


        private int getTableRowsCount(string tableName)
        {
            string host = credentialsConfigInstance.host;
            string database = credentialsConfigInstance.database;
            string password = credentialsConfigInstance.password;
            string username = credentialsConfigInstance.username;

            string constring = DbConnection.conStringBuilder(host,username,password,database);
            return DbConnection.Instance().getTableRowsCount(tableName,constring);
        }


    }
}
