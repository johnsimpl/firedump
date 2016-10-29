using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    class ConfigurationManager : ConfigurationClass
    {
        public MySqlDumpConfig mysqlDumpConfigInstance { get; }
        public CredentialsConfig credentialsConfigInstance { get; }
        public CompressConfig compressConfigInstance { get; }
        public OutputConfig outputConfigInstance { get; }
        private static ConfigurationManager configurationManagerInstance;
        private ConfigurationManager()
        {
            this.mysqlDumpConfigInstance = MySqlDumpConfig.getInstance();
            this.credentialsConfigInstance = CredentialsConfig.getInstance();
            this.compressConfigInstance = CompressConfig.getInstance();
            this.outputConfigInstance = OutputConfig.getInstance();
        }
        public static ConfigurationManager getInstance()
        {
            if (configurationManagerInstance == null)
            {
                configurationManagerInstance = new ConfigurationManager();
            }
            return configurationManagerInstance;
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
