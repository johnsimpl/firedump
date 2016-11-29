using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    interface ILocationListener
    {
        void setProgress(int progress);
        void onInit();
        void onComplete(LocationResultSet result);
        /// <summary>
        /// Gia errors se epipedo adapter oxi se epipedo task ama ginei error ekei paei sto on complete
        /// </summary>
        void onError(string message);
    }
}
