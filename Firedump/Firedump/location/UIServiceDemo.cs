using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    class UIServiceDemo : ICallBack
    {


        public void demo()
        {
            //ex 1 ftp
            ILocation location = new LocationFtp();
            location.connect();
            location.send();


            //ex2
            ILocation locationDrive = new LocationCloudDrive();
            locationDrive.connect();
            ((ILocationCloud)locationDrive).doExtraStuff();

            //set ui listener
            locationDrive.setListener(this);

        }




        public void onCompleted(object o)
        {
            throw new NotImplementedException();
        }

        public void onError()
        {
            throw new NotImplementedException();
        }
    }
}
