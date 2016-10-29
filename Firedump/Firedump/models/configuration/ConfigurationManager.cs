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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a ConfigurationManager instance with all configuration class instances set as fields of this instance</returns>
        public static ConfigurationManager getInstance()
        {
            if (configurationManagerInstance == null)
            {
                configurationManagerInstance = new ConfigurationManager();
            }
            return configurationManagerInstance;
        }

        /// <summary>
        /// Calls the initiallize methods of every configuration class.
        /// </summary>
        public void initializeConfig()
        {
            this.mysqlDumpConfigInstance.initializeConfig();
            this.credentialsConfigInstance.initializeConfig();
            this.compressConfigInstance.initializeConfig();
            this.outputConfigInstance.initializeConfig();
        }

        /// <summary>
        /// Calls the save methods of every configuration class.
        /// IMPORTANT: initializeConfig must be called at least once before this method is called.
        /// </summary>
        public void saveConfig()
        {
            this.mysqlDumpConfigInstance.saveConfig();
            this.credentialsConfigInstance.saveConfig();
            this.compressConfigInstance.saveConfig();
            this.outputConfigInstance.saveConfig();
        }
    }
}
