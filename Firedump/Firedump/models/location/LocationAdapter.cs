using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationAdapter : ILocationProgressListener
    {

        private ILocation location;
        private ILocationListener listener;

        public LocationAdapter() { }

        public LocationAdapter(ILocationListener listener)
        {
            this.listener = listener;
        }

        public void setLocalLocation()
        {
            this.location = new LocationLocal(this);
        }

        public void setFtpLocation(LocationCredentialsConfig config)
        {
            this.location = new LocationFtp(this);
            ((LocationFtp)this.location).config = config;
        }

        public void sendFile()
        {
            if (this.location == null)
            {
                listener.onSaveError("Location type not set. Aborting...");
                return;
            }

            Task sendtask = new Task(sendFileTaskExecutor);
            sendtask.Start();
        }

        public void getFile()
        {
            if (this.location == null)
            {
                listener.onSaveError("Location type not set. Aborting...");
                return;
            }

            Task gettask = new Task(getFileTaskExecutor);
            gettask.Start();
        }

        private async void sendFileTaskExecutor()
        {
            Task<LocationResultSet> innersendtask = new Task<LocationResultSet>(location.send);
            LocationResultSet res;
            try
            {
                res = await innersendtask;
            }
            catch (NullReferenceException) { }

        }

        private async void getFileTaskExecutor()
        {
            Task<LocationResultSet> innergettask = new Task<LocationResultSet>(location.getFile);//getFileTask();
            LocationResultSet res;
            try
            {
                res = await innergettask;
            }
            catch (NullReferenceException) { }
        }

        public void setProgress(int progress)
        {
            throw new NotImplementedException();
        }
    }
}
