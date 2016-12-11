using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationFtp : Location,ILocation,IFTPListener
    {
        public LocationCredentialsConfig config { set; get; }
        private ILocationProgressListener listener;
        private LocationFtp() { }
        public LocationFtp(ILocationProgressListener listener)
        {
            this.listener = listener;
        }
        public LocationConnectionResultSet connect()
        {
            FTPUtils ftputils = new FTPUtils((FTPCredentialsConfig)config, this);
            LocationConnectionResultSet result = ftputils.testConnection();
            return result;
        }

        public LocationConnectionResultSet connect(object o)
        {
            throw new NotImplementedException();
        }

        public LocationResultSet getFile()
        {
            FTPUtils ftputils = new FTPUtils((FTPCredentialsConfig)config, this);
            LocationResultSet result = ftputils.getFile();
            return result;
        }

        public LocationResultSet send()
        {
            FTPUtils ftputils = new FTPUtils((FTPCredentialsConfig)config,this);
            LocationResultSet result = ftputils.sendFile();
            return result;
        }

        public void onProgress(int progress, int speed) //den xrisimopoiw to speed
        {
            listener.setProgress(progress, speed);          
        }
    }
}
