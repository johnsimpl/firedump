using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.sqlimport
{
    interface IImportAdapterManagerListener
    {
        void onInnerProccessInit(int proc_type, int maxprogress);
        void onImportInit();
        void onImportComplete(ImportResultSet result);
        void onImportProgress(int progress, int speed);
        void onImportError(string message);
    }
}
