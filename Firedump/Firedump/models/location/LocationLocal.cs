using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationLocal : Location,ILocation
    {
        public LocationCredentialsConfig config { set; get; }
        private ILocationProgressListener listener;
        private LocationLocal() { }
        public LocationLocal(ILocationProgressListener listener)
        {
            this.listener = listener;
        }
        public void connect()
        {
            throw new NotImplementedException();
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
            LocationResultSet result = new LocationResultSet();
            result.path = config.locationPath;
            try
            {
                string[] path = config.sourcePath.Split('\\');
                string filename = path[path.Length - 1];
                string[] temp = filename.Split('.'); //pernei to extension apo to sourcepath kai na to kanei append sto location
                File.Move(config.sourcePath, config.locationPath+temp[temp.Length-1]);
                result.wasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = ex.Message;
            }

            return result;
        }

        public void setListener(ICallBack callback)
        {
            throw new NotImplementedException();
        }
    }
}
