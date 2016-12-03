using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationAdapterManager : ILocationListener 
    {
        private ILocationManagerListener listener;
        private List<ILocation> locations;
        private List<LocationResultSet> results;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_adapter; //malon tha xreiastei adapter pou tha einai join pinakwn tha doume
        private int currentProgress = 0;
        private LocationAdapterManager() { }
        public LocationAdapterManager(ILocationManagerListener listener, List<ILocation> locations)
        {
            this.listener = listener;
            this.locations = locations;
            init();
        }
        private void init()
        {
            results = new List<LocationResultSet>();
            listener.onSaveInit(locations.Count * 100); //set to max progress px gia 2 locations 200
        }
        private void setupForNewSave()
        {
            currentProgress += 100;
            if (locations.Count > 0)
            {
                locations.RemoveAt(0);
            }
        }
        public void startSave() //thelei douleia afti
        {
            LocationCredentialsConfig config = new LocationCredentialsConfig();
            

            int type = 0;
            LocationAdapter adapter = new LocationAdapter(this);
            switch (type) //edw gemizei to config apo to database prepei na kanei diaforetiko query gia kathe diaforetiko type kai na gemisei to config prin to settarei ston adapter
            {              
                case 0: //file system
                    adapter.setLocalLocation(config);
                    break;
                case 1: //FTP
                    adapter.setFtpLocation(config);
                    break;
                case 2: //Dropbox
                    adapter.setCloudBoxLocation(config);
                    break;
                case 3: //Google drive
                    adapter.setCloudDriveLocation(config);
                    break;
                default:
                    LocationResultSet result = new LocationResultSet();
                    result.wasSuccessful = false;
                    result.errorMessage = "Location type uknown";
                    results.Add(result);
                    setupForNewSave();
                    return;
            }

            Task managersendtask = new Task(adapter.sendFile);
            managersendtask.Start();
        }
       
        public void onSaveComplete(LocationResultSet result)
        {
            results.Add(result);
            setupForNewSave();
            if (locations.Count > 0)
            {
                startSave();
            }
            else
            {
                listener.onSaveComplete(results);
            }
        }

        public void onSaveError(string message)
        {
            LocationResultSet result = new LocationResultSet();
            result.wasSuccessful = false;
            result.errorMessage = message;
            results.Add(result);
            setupForNewSave();
        }

        public void onSaveInit()
        {
            throw new NotImplementedException();
        }

        public void setSaveProgress(int progress)
        {
            listener.setSaveProgress(currentProgress+progress);
        }
    }
}
