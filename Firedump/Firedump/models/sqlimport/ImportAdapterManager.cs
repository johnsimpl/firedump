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
        private string path;
        private string filename;
        private DataRow locationdata;
        private bool isLocal;
        private bool isCompressed;
        private bool isEncrypted;
        private string password;
        private IImportAdapterManagerListener listener;
        private LocationAdapter locationadapter;
        //edw compression adapter pou den iparxei
        private ImportAdapter importadapter;
        private ImportAdapterManager() { }
        public ImportAdapterManager(IImportAdapterManagerListener listener, string path, bool isLocal, bool isCompressed,bool isEncrypted, string password, DataRow locationdata)
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
