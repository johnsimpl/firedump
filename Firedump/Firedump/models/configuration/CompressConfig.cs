using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    class CompressConfig : ConfigurationClass
    {
        private static CompressConfig compressConfigInstance;
        private CompressConfig() { }
        public static CompressConfig getInstance()
        {
            if (compressConfigInstance == null)
            {
                compressConfigInstance = new CompressConfig();
            }
            return compressConfigInstance;
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
