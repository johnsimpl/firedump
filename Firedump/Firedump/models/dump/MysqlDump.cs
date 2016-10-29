using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Firedump.models.configuration;
using Firedump.models.dump;
using System.IO;

namespace Firedump
{
    class MysqlDump
    {
        ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
        public MysqlDump(){}
        public DumpResultSet executeDump()
        {
            DumpResultSet resultObj = new DumpResultSet();
            StringBuilder arguments = new StringBuilder();

            //<ConfigurationSection>

            arguments.Append("--protocol=tcp ");

            //Credentials

            //host
            if (!String.IsNullOrEmpty(configurationManagerInstance.credentialsConfigInstance.host))
            {
                arguments.Append("--host " + configurationManagerInstance.credentialsConfigInstance.host + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.mysqlErrorNumber = -1;
                resultObj.mysqlErrorMessage = "Host not set";
                return resultObj;
            }

            //port
            if (configurationManagerInstance.credentialsConfigInstance.port<1 || configurationManagerInstance.credentialsConfigInstance.port>65535)
            {
                resultObj.wasSuccessful = false;
                resultObj.mysqlErrorNumber = -1;
                resultObj.mysqlErrorMessage = "Invalid port number: " + configurationManagerInstance.credentialsConfigInstance.port;
                return resultObj;
            }
            else
            {
                arguments.Append("--port=" + configurationManagerInstance.credentialsConfigInstance.port + " ");
            }
            
            //username
            if (!String.IsNullOrEmpty(configurationManagerInstance.credentialsConfigInstance.username))
            {
                arguments.Append("--user " + configurationManagerInstance.credentialsConfigInstance.username + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.mysqlErrorNumber = -1;
                resultObj.mysqlErrorMessage = "Username not set";
                return resultObj;
            }

            //pasword
            if (!String.IsNullOrEmpty(configurationManagerInstance.credentialsConfigInstance.password))
            {
                arguments.Append("--password=" + configurationManagerInstance.credentialsConfigInstance.password + " ");
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

            //exportType
            switch (configurationManagerInstance.mysqlDumpConfigInstance.exportType)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    arguments.Append("--replace ");
                    break;
                default:
                    break;         
            }

            //database choice
            if (configurationManagerInstance.mysqlDumpConfigInstance.databases == null)
            {
                if (string.IsNullOrEmpty(configurationManagerInstance.mysqlDumpConfigInstance.database))
                {
                    arguments.Append("--all-databases ");
                }
                else
                {
                    arguments.Append("--databases "+ configurationManagerInstance.mysqlDumpConfigInstance.database);
                    if (configurationManagerInstance.mysqlDumpConfigInstance.excludeTablesSingleDatabase!=null)
                    {
                        arguments.Append(" ");
                        string[] tables = configurationManagerInstance.mysqlDumpConfigInstance.excludeTablesSingleDatabase.Split(',');
                        foreach (string table in tables)
                        {
                            arguments.Append("--ignore-table=" + configurationManagerInstance.mysqlDumpConfigInstance.database + "." + table + " ");
                        }
                    }
                }
            }
            else
            {
                arguments.Append("--databases ");
                foreach (string database in configurationManagerInstance.mysqlDumpConfigInstance.databases)
                {
                    arguments.Append(database+" ");
                }
                if (configurationManagerInstance.mysqlDumpConfigInstance.excludeTables != null)
                {
                    for(int i=0; i< configurationManagerInstance.mysqlDumpConfigInstance.excludeTables.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(configurationManagerInstance.mysqlDumpConfigInstance.excludeTables[i]))
                        {
                            string[] tables = configurationManagerInstance.mysqlDumpConfigInstance.excludeTables[i].Split(',');
                            foreach (string table in tables)
                            {
                                arguments.Append("--ignore-table=" + configurationManagerInstance.mysqlDumpConfigInstance.databases[i] + "." + table + " ");
                            }
                        }
                    }
                }
            }

            //</ConfigurationSection>


            //dump execution
            Console.WriteLine(arguments.ToString());

            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "mysqldump.exe",//AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe") ,
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
            String filename = "dump" + rnd.Next(1000000, 9999999) + ".sql";

            Directory.CreateDirectory(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename))
            {
                //addCustomCommentInHeader
                if (!string.IsNullOrEmpty(configurationManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader))
                {
                    file.WriteLine("-- Custom comment: " + configurationManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader);
                }

                while (!proc.StandardOutput.EndOfStream)
                {
                    file.WriteLine(proc.StandardOutput.ReadLine());
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
                resultObj.mysqlErrorNumber = -2;
                //File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
                Console.WriteLine();
            }
            else
            {
                resultObj.wasSuccessful = true;
                resultObj.fileAbsPath = configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename;
            }
                    
            return resultObj;
        }
    }
}
