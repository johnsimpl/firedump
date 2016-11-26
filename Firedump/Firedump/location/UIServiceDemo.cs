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
            LocationAdapter adapter = new LocationAdapter();
            adapter.setFtpLocation(new LocationFtp());            
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
