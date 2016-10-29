using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    class OutputConfig : ConfigurationClass
    {
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
            throw new NotImplementedException();
        }

        public void saveConfig()
        {
            throw new NotImplementedException();
        }
    }
}
