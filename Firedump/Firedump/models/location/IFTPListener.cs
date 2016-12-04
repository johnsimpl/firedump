using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    interface IFTPListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="speed">Speed in B/s</param>
        void onProgress(int progress, int speed);
        void onTransferError(string message);
        void onTransferComplete();
    }
}
