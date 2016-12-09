using Firedump.models.configuration.dynamicconfig;
using Firedump.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.sqlimport
{
    class ImportAdapter : ISQLImportListener
    {
        private IImportAdapterListener listener;
        private SQLImport sqlimportInstance;
        private Task<ImportResultSet> innertask;
        private ImportAdapter() { }
        public ImportAdapter(IImportAdapterListener listener, ImportCredentialsConfig config)
        {
            this.listener = listener;
            sqlimportInstance = new SQLImport(config, this);
        }

        public void executeScript()
        {
            if(innertask != null && !innertask.IsCompleted)
            {
                listener.onImportError("Another import is running.");
                return;
            }

            Task task = new Task(scriptExecutor);
            task.Start();         
        }

        private async void scriptExecutor()
        {
            try
            {
                sqlimportInstance.script = File.ReadAllText(sqlimportInstance.config.scriptPath);
                int commandsCount = StringUtils.countOccurances(sqlimportInstance.script, sqlimportInstance.config.scriptDelimeter);
                if (commandsCount == 0) commandsCount = 1;
                listener.onImportInit(commandsCount);

                innertask = new Task<ImportResultSet>(sqlimportInstance.executeScript);
                ImportResultSet result;
                innertask.Start();
                result = await innertask;

                listener.onImportProgress(commandsCount);
                listener.onImportComplete(result);
            }
            catch (Exception ex)
            {
                listener.onImportError("Script import failed:\n" + ex.Message);
            }
        }

        public void onProgress(int progress)
        {
            listener.onImportProgress(progress);
        }
    }
}
