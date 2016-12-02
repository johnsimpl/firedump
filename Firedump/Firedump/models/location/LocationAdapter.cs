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

        private LocationAdapter() { }

        public LocationAdapter(ILocationListener listener)
        {
            this.listener = listener;
        }

        public void setLocalLocation(LocationCredentialsConfig config) //auta na kanoun try catch gia to cast kai na kaloun onError se fail
        {
            this.location = new LocationLocal(this);
            ((LocationLocal)this.location).config = config;
        }

        public void setFtpLocation(LocationCredentialsConfig config)
        {
            this.location = new LocationFtp(this);
            ((LocationFtp)this.location).config = config;
        }
        public void setCloudBoxLocation(LocationCredentialsConfig config)
        {
            this.location = new LocationCloudBox(this);
            ((LocationCloudBox)this.location).config = config;
        }
        public void setCloudDriveLocation(LocationCredentialsConfig config)
        {
            this.location = new LocationCloudDrive(this);
            ((LocationCloudDrive)this.location).config = config;
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
