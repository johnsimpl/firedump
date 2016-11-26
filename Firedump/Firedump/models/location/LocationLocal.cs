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
            result.path = base.locationPath;
            try
            {
                File.Move(base.localPath,base.locationPath);
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
