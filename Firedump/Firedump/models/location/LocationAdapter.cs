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
        private Task<LocationConnectionResultSet> innerconnectiontask;
        private Task<LocationResultSet> innersendtask;
        private Task<LocationResultSet> innergettask;

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
        /// <summary>
        /// Prosoxi den einai ilopoihmeni padou mporei na petaksei not implemented exception
        /// ama kalestei gia LocationLocal px
        /// </summary>
        public void testConnection()
        {
            if (this.location == null)
            {
                listener.onSaveError("Location type not set. Aborting...");
                return;
            }
            

            Task testcontask = new Task(testConnectionExecutor);
            testcontask.Start();
        }
        private async void testConnectionExecutor()
        {
            if (innerconnectiontask != null && !innerconnectiontask.IsCompleted) //ama spammarei test connection tha stamataei edw
            {
                listener.onSaveError("Another test connection is running please wait");
                return;
            }
            innerconnectiontask = new Task<LocationConnectionResultSet>(location.connect);
            LocationConnectionResultSet res;
            innerconnectiontask.Start();

            try
            {
                res = await innerconnectiontask;
                listener.onTestConnectionComplete(res);
            }
            catch (NullReferenceException) { }
        }
        public void sendFile()
        {
            if (this.location == null)
            {
                listener.onSaveError("Location type not set. Aborting...");
                return;
            }

            Task task = new Task(sendFileTaskExecutor);
            task.Start();
        }

        public void getFile()
        {
            if (this.location == null)
            {
                listener.onSaveError("Location type not set. Aborting...");
                return;
            }

            Task task = new Task(getFileTaskExecutor);
            task.Start();
        }

        private async void sendFileTaskExecutor()
        {
            if (innersendtask != null && !innersendtask.IsCompleted)
            {
                listener.onSaveError("Another task is running. Aborting...");
                return;
            }

            innersendtask = new Task<LocationResultSet>(location.send);
            LocationResultSet res;
            innersendtask.Start();  
                    
            try
            {
                res = await innersendtask;
                listener.onSaveComplete(res);
            }
            catch (NullReferenceException) { }

        }

        private async void getFileTaskExecutor()
        {
            if (innergettask != null && !innergettask.IsCompleted)
            {
                listener.onSaveError("Another task is running. Aborting...");
                return;
            }

            innergettask = new Task<LocationResultSet>(location.getFile);
            LocationResultSet res;
            innergettask.Start();
            try
            {
                res = await innergettask;
                listener.onSaveComplete(res);
            }
            catch (NullReferenceException) { }
        }

        public void setProgress(int progress, int speed)
        {
            listener.setSaveProgress(progress,speed);
        }
    }
}
