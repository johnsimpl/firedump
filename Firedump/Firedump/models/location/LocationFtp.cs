using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationFtp : Location,ILocation
    {
        public LocationCredentialsConfig config { set; get; }
        private ILocationProgressListener listener;
        private LocationFtp() { }
        public LocationFtp(ILocationProgressListener listener)
        {
            this.listener = listener;
        }
        public void connect()
        {
            throw new NotImplementedException();
        }

        void test()
        {
        }

        public void connect(object o)
        {
            throw new NotImplementedException();
        }

        public LocationResultSet getFile()
        {
            throw new NotImplementedException();
        }

        public LocationResultSet send()
        {
            throw new NotImplementedException();
        }
       
    }
}
