
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Firedump.models
{
    public class MySqlDumpAdapter 
    {
        private IDumpProgressListener listener;             
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
        public void startDump(MySqlDumpConfig options, IDumpProgressListener listener)
        {
            this.listener = listener;
            listener.onProgress("mysql dump started!from server:"+options.getHost());

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
            
            Task<bool> isConnected = connect();
            //if the form closes listener will be null
            if(listener != null)
            {
                listener.onProgress("connecting...");
            }

            bool successCon = await isConnected;

            Task<bool> getData = gettingData();
            listener.onProgress("fetching data...");
            bool successGet = await getData;

            Task<bool> save = saveData();
            listener.onProgress("saving data...");
            bool successSave = await save;



            if(successCon && successGet && successSave)
            {
                listener.onCompleted("completed");
            } else
            {
                listener.onError(1);
            }
            
            
        }




        static async Task<bool> connect()
        {
            //test connection or connect or whatever
            return true;
        }


        private async Task<bool> gettingData()
        {
            return true;
        }

       
        public async Task<bool> saveData()
        {
            return true;
        }



    }
    

}
