using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firedump.models.dump;

namespace Firedump.models.dump
{
    public interface IDumpProgressListener
    {

        void onProgress(string progress);

        void onError(int error);

        void onCancelled();

        void onCompleted(DumpResultSet status);

        void onTableDumpStart(string table);

        void initDumpTables(List<string> tables);

        void tableRowCount(int rowcount);
    }
    
}
