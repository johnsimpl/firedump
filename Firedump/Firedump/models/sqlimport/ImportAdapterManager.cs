using Firedump.models.location;
using Firedump.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.sqlimport
{
    class ImportAdapterManager
    {
        //<events>

        //onInnerProccessInit
        public delegate void innerProccessInit(int proc_type, int maxprogress);
        public event innerProccessInit InnerProccessInit;
        private void onInnerProccessInit(int proc_type, int maxprogress)
        {
            InnerProccessInit?.Invoke(proc_type,maxprogress);
        }

        //onImportProgress
        public delegate void importProgress(int progress, int speed);
        public event importProgress ImportProgress;
        private void onImportProgress(int progress, int speed)
        {
            ImportProgress?.Invoke(progress, speed);
        }

        //onImportInit
        public delegate void importInit(int maxprogress);
        public event importInit ImportInit;
        private void onImportInit(int maxprogress)
        {
            ImportInit?.Invoke(maxprogress);
        }

        //onImportComplete
        public delegate void importComplete(ImportResultSet result);
        public event importComplete ImportComplete;
        private void onImportComplete(ImportResultSet result)
        {
            ImportComplete?.Invoke(result);
        }

        //onImportError
        public delegate void importError(string message);
        public event importError ImportError;
        private void onImportError(string message)
        {
            ImportError?.Invoke(message);
        }

        //</events>
        private string path;
        private string filename;
        private DataRow locationdata;
        private bool isLocal;
        private bool isCompressed;
        private bool isEncrypted;
        private string password;
        private LocationAdapter locationadapter;
        //edw compression adapter pou den iparxei
        private ImportAdapter importadapter;
        private ImportAdapterManager() { }
        public ImportAdapterManager(string path, bool isLocal, bool isCompressed,bool isEncrypted, string password, DataRow locationdata)
        {
            string[] splitpath = StringUtils.splitPath(path);
            this.path = splitpath[0];
            this.filename = splitpath[1];
            this.isLocal = isLocal;
            this.isCompressed = isCompressed;
            this.isEncrypted = isEncrypted;
            this.password = password;
            this.locationdata = locationdata;
        }

        public void startImport()
        {
            //edw oloi oi elenxoi kai oi leitourgies
            /* afto tha ksekinaei apo callback logika
            Task task = new Task(importTaskExecutor);
            task.Start();*/
        }

        private async void importTaskExecutor()
        {

        }

        public void cancel()
        {

        }
    }
}
