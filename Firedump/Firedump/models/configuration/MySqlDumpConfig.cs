

using System;

namespace Firedump.models.configuration
{
    public class MySqlDumpConfig : ConfigurationClass
    {
        private static MySqlDumpConfig mysqlDumpConfigInstance;

        private MySqlDumpConfig() { }
        public static MySqlDumpConfig getInstance()
        {
            if (mysqlDumpConfigInstance == null)
            {
                mysqlDumpConfigInstance = new MySqlDumpConfig();
            }
            return mysqlDumpConfigInstance;
        }

        public void initializeConfig()
        {
            Console.WriteLine("foo");
        }

        public void saveConfig()
        {
            
        }
    }
}