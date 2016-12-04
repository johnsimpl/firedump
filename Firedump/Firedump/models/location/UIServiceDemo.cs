using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class UIServiceDemo : ILocationManagerListener,IFTPListener
    {

        public UIServiceDemo() { }
        public void demo()
        {
            /*
            LocationCredentialsConfig config = new LocationCredentialsConfig();
            config.sourcePath = "K:\\MyStuff\\summer season 2015 checkout\\[Ajin2.com] Ajin Season 2 Episode 4 [720p].mkv";
            config.locationPath = "K:\\MyStuff\\thefile";*/
            /* test to location apefthias
            LocationLocal loc = new LocationLocal(this);
            loc.config = config;
            loc.send();*/
            /*
            LocationAdapter adapter = new LocationAdapter(this);
            adapter.setLocalLocation(config);
            adapter.sendFile();*/
            LocationAdapterManager adapter = new LocationAdapterManager(this,new List<int> { 2,3,4,5}, "K:\\MyStuff\\summer season 2015 checkout\\[Ajin2.com] Ajin Season 2 Episode 4 [720p].mkv");
            adapter.startSave();
        }

        public void demoFTP()
        {
            FTPCredentialsConfig config = new FTPCredentialsConfig();
            config.host = "cspeitch.com";
            config.port = 22;
            config.username = "";
            config.password = "";
            config.sourcePath = "D:\\MyStuff\\DSC_0133.JPG";
            config.locationPath = "/home/cspeitch/eikona";
            config.useSFTP = true;

            FTPUtils ftp = new FTPUtils(config,this);
            /*
            FTPConnectionResultSet res = ftp.testConnection();
            Console.WriteLine("Was Succesful: "+res.wasSuccessful);
            Console.WriteLine("Error Message: " + res.errorMessage);
            Console.WriteLine("SSH fingerprint: "+res.sshHostKeyFingerprint);*/

            ftp.sendFile();


        }

        public void onInnerSaveInit(string location)
        {
            Console.WriteLine("Inner save init: "+location);
        }

        public void onProgress(int progress, int speed)
        {
            Console.WriteLine(progress + " " + speed);
        }

        public void onSaveComplete(List<LocationResultSet> results)
        {

            Console.WriteLine("Save Completed!");
            Console.WriteLine("Results:");
            foreach(LocationResultSet result in results)
            {
                Console.WriteLine(result.wasSuccessful);
                if(!result.wasSuccessful)
                Console.WriteLine(result.errorMessage);
            }
        }

        public void onSaveComplete(LocationResultSet result)
        {
            Console.WriteLine("Save Completed!");
        }

        public void onSaveError(string message)
        {
            Console.WriteLine("Save Error: "+message);
        }

        public void onSaveInit()
        {
            Console.WriteLine("Save Init");
        }

        public void onSaveInit(int maxprogress)
        {
            Console.WriteLine("Setting max progress to: "+maxprogress);
        }

        public void onTransferComplete()
        {
            Console.WriteLine("Transfer complete");
        }

        public void onTransferError(string message)
        {
            Console.WriteLine("Transfer error: "+message);
        }

        public void setSaveProgress(int progress)
        {
            Console.WriteLine(progress);
            //throw new NotImplementedException();
        }
    }
}
