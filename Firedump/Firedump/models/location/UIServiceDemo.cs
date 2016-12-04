using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class UIServiceDemo : ILocationManagerListener
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

        public void onInnerSaveInit(string location)
        {
            Console.WriteLine("Inner save init: "+location);
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

        public void setSaveProgress(int progress)
        {
            Console.WriteLine(progress);
            //throw new NotImplementedException();
        }
    }
}
