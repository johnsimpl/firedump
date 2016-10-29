using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    class OutputConfig : ConfigurationClass
    {
        //<!configuration fields section>

        //</configuration fields section>

        private static OutputConfig outputConfigInstance;
        private OutputConfig() { }
        public static OutputConfig getInstance()
        {
            if (outputConfigInstance == null)
            {
                outputConfigInstance = new OutputConfig();
            }
            return outputConfigInstance;
        }

        public void initializeConfig()
        {
            Console.WriteLine("foo");
        }

        public void createConfig()
        {
            throw new NotImplementedException();
        }

        public void saveConfig()
        {
            throw new NotImplementedException();
        }
    }
}
