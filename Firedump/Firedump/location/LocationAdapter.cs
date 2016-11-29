using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    public class LocationAdapter
    {
        private ILocation ilocation;
        private Queue<ILocation> queue;

        public LocationAdapter()
        {
        }

        public LocationAdapter(object o)
        {
            //
        }


        public void startFtp(object o)
        {
            ilocation = new LocationFtp();
        }

        public void startLocal(object o)
        {
            ilocation = new LocationLocal();
        }

        public void startCloud(object t)
        {          
            //t == Type.Drive
            if (t.ToString() == "drive"){
                ilocation = new LocationCloudDrive();
                ((ILocationCloud)ilocation).setExrtaCredentials();
            }
            else
            {
                ilocation = new LocationDropBox();
                ((ILocationCloud)ilocation).setExrtaCredentials();
            }
        }

        public void registerCallBack(object o)
        {

        }

        private void queueManager()
        {

        }


    }
}
