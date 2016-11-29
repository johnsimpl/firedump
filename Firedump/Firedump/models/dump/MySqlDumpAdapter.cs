
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
        private DumpCredentialsConfig credentialsConfigInstance;
        private List<string> tableList;

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
        public void startDump(DumpCredentialsConfig credentialsConfigInstance, IDumpProgressListener listener)
        {
            this.listener = listener;
            listener.onProgress("mysql dump started!");//+options.getHost());

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
                DumpResultSet dumpresult = null;
                try
                {
                     dumpresult = await result;
                } catch(NullReferenceException ex)
                {

                }
                
                if (listener != null)
                {
                    listener.onCompleted(dumpresult);
                }
                mydump = null;
            } else
            {
                if(listener != null)
                {
                    //we need enumaration classes for all kind of different erros
                    //..We still need enumaration class for all kind of dif erros
                    listener.onError(-1);
                }
                mydump = null;
            }
            

        }


        internal void cancelDump()
        {
            if(mydump != null)
            {
                mydump.cancelMysqlDumpProcess();
                mydump = null;              
            }
        }

        public bool isDumpRunning()
        {
            return mydump != null;
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
            bool success = con.testConnection().wasSuccessful;
            if(success)
            {

                //return con.getTables(database);
                return tableList;
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

        public void tableRowCount(int rowcount)
        {
            if(listener != null)
            {
                listener.tableRowCount(rowcount);
            }
        }

        public void compressProgress(int progress)
        {
            if(listener != null)
            {
                listener.compressProgress(progress);
            }
        }

        public void onCompressStart()
        {
            if(listener != null)
            {
                listener.onCompressStart();
            }
        }

        internal void setTableList(List<string> tableList)
        {
            this.tableList = tableList;
        }
    }
    

}
