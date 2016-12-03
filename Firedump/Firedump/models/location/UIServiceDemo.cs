using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class UIServiceDemo : ILocationListener
    {

        public UIServiceDemo() { }
        public void demo()
        {
            LocationCredentialsConfig config = new LocationCredentialsConfig();
            config.sourcePath = "K:\\MyStuff\\summer season 2015 checkout\\[Ajin2.com] Ajin Season 2 Episode 4 [720p].mkv";
            config.locationPath = "K:\\MyStuff\\thefile";
            /* test to location apefthias
            LocationLocal loc = new LocationLocal(this);
            loc.config = config;
            loc.send();*/
            LocationAdapter adapter = new LocationAdapter(this);
            adapter.setLocalLocation(config);
            adapter.sendFile();
        }

        public void onSaveComplete(LocationResultSet result)
        {
            //throw new NotImplementedException();
        }

        public void onSaveError(string message)
        {
            //throw new NotImplementedException();
        }

        public void onSaveInit()
        {
            //throw new NotImplementedException();
        }


        public void setSaveProgress(int progress)
        {
            Console.WriteLine(progress);
            //throw new NotImplementedException();
        }
    }
}
