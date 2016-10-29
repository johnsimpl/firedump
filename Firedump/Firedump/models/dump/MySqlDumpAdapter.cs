
using Firedump.models.configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Firedump.models.dump;
using Firedump.mysql;
using System.Collections.Generic;

namespace Firedump.models
{
    public class MySqlDumpAdapter : IAdapterListener
    {
        private IDumpProgressListener listener;
        private MysqlDump mydump;



        public MySqlDumpAdapter() {           
        }


        /// <summary>
        /// start mysql dump/backup
        /// usualy gets called from the user
        /// </summary>
        /// <param name="options">mysql options</param>
        /// <param name="listener">the listener interface for the notifications status of the whole job \n
        ///                       IDumpProgressListener to notify the user about the job status 
        /// </param>
        public void startDump(IDumpProgressListener listener)
        {
            this.listener = listener;
            listener.onProgress("mysql dump started!from server:");//+options.getHost());

            Task mysqldumpTask = new Task(DumpMysqlTaskExecutor);
            mysqldumpTask.Start();         
        }
        

        /// <summary>
        /// main mysql dump executor task
        /// start/running in ASYNC mode.
        /// internal its calling other task/jobs and waits for completion.
        /// with every task completed its firing notification events(listener)
        /// --BASIC FLOW--
        /// </summary>
        async void DumpMysqlTaskExecutor()
        {
            Task<List<string>> testConnectionTask = testCon();
            List<string> tables = await testConnectionTask;
            if(tables != null)
            {
                if (listener != null)
                {
                    listener.onProgress("connected");
                    listener.initDumpTables(tables);
                }

                mydump = new MysqlDump(this);
                Task<DumpResultSet> result = dumptask(mydump);
                DumpResultSet dumpresult = await result;

                if (listener != null)
                {
                    listener.onCompleted(dumpresult);
                }
            } else
            {
                if(listener != null)
                {
                    //we need enumaration classes for all kind of different erros
                    listener.onError(-1);
                }
            }
            

        }


        internal void cancelDump()
        {
            if(mydump != null)
            {
                mydump.cancelMysqlDumpProcess();
            }
        }


        static async Task<List<string>>  testCon()
        {
            ConfigurationManager manager = ConfigurationManager.getInstance();
            string host = manager.credentialsConfigInstance.host;
            string username = manager.credentialsConfigInstance.username;
            string password = manager.credentialsConfigInstance.password;
            string database = manager.mysqlDumpConfigInstance.database;
            int port = manager.credentialsConfigInstance.port;
            DbConnection con = DbConnection.Instance();
            con.Host = host;
            con.username = username;
            con.password = password;
            con.database = database;
            //con.port = port;
            bool success = con.testConnection();
            if(success)
            {
                return con.getTables(database);
            }
            return null;
        }


        static async Task<DumpResultSet> dumptask(MysqlDump mydump)
        {
            return mydump.executeDump();
        }

        
        public void onTableStartDump(string table)
        {
            if(listener != null)
            {
                listener.onTableDumpStart(table);
            }
        }

       
    }
    

}
