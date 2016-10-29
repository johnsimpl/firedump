using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    class CredentialsConfig : ConfigurationClass
    {
        private static CredentialsConfig credentialsConfigInstance;
        private CredentialsConfig() { }
        public static CredentialsConfig getInstance()
        {
            if (credentialsConfigInstance == null)
            {
                credentialsConfigInstance = new CredentialsConfig();
            }
            return credentialsConfigInstance;
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
