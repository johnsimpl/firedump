using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    class CompressConfig : ConfigurationClass
    {
        //<!configuration fields section>

        //</configuration fields section>

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
            Console.WriteLine("foo");
        }

        public void saveConfig()
        {
            throw new NotImplementedException();
        }
    }
}
