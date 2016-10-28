using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models
{
    public interface IDumpProgressListener
    {

        void onProgress(string progress);

        void onError(int error);

        void onCancelled();

        void onCompleted(string status);

    }
    
}
