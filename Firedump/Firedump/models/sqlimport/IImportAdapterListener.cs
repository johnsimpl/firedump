using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.sqlimport
{
    interface IImportAdapterListener
    {
        void onImportInit(int maxprogress);
        void onImportProgress(int progress);
        void onImportComplete(ImportResultSet result);
        /// <summary>
        /// Gia errors se epipedo adapter oxi execution
        /// </summary>
        /// <param name="message"></param>
        void onImportError(string message);
    }
}
