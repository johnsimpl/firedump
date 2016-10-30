
using Firedump.models.configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Firedump.models.dump;
using Firedump.mysql;
using System.Collections.Generic;
using Firedump.models.configuration.dynamicconfig;

namespace Firedump.models.dump
{
    public class MySqlDumpAdapter : IAdapterListener
    {
        private IDumpProgressListener listener;
        private MysqlDump mydump;
        private CredentialsConfig credentialsConfigInstance;

        public MySqlDumpAdapter() {           
        }


        /// <summary>
        /// start mysql dump/backup
        /// usualy gets called from the user
        /// </summary>
        /// <param name="credentialsConfigInstance">Instance of class CredentialsConfig with set credentials for dump</param>
        /// <param name="listener">the listener interface for the notifications status of the whole job \n
        ///                       IDumpProgressListener to notify the user about the job status 
        /// </param>
        public void startDump(CredentialsConfig credentialsConfigInstance, IDumpProgressListener listener)
        {
            this.listener = listener;
            listener.onProgress("mysql dump started!from server:");//+options.getHost());

            this.credentialsConfigInstance = credentialsConfigInstance;

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
                mydump.credentialsConfigInstance = credentialsConfigInstance;

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


        async Task<List<string>>  testCon()
        {
            string host = this.credentialsConfigInstance.host;
            int port = this.credentialsConfigInstance.port;
            string username = this.credentialsConfigInstance.username;
            string password = this.credentialsConfigInstance.password;
            string database = this.credentialsConfigInstance.database;
            DbConnection con = DbConnection.Instance();
            con.Host = host;
            con.username = username;
            con.password = password;
            con.database = database;
            con.port = port;
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
