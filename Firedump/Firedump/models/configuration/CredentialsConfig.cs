using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace Firedump.models.configuration
{
    class CredentialsConfig : ConfigurationClass
    {
        private readonly string jsonFilePath = "./config/CredentialsConfig.json";
        //<!configuration fields section>
        /// <summary>
        /// mysql server ip or domain name
        /// </summary>
        public string host { set; get; }
        /// <summary>
        /// mysql port number
        /// </summary>
        public int port { set; get; } = 3306;
        /// <summary>
        /// user's username
        /// </summary>
        public string username { set; get; }
        /// <summary>
        /// user's password (leave null or empty to attemp a connection without password)
        /// </summary>
        public string password { set; get; }
        //</configuration fields section>

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
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                //<Field initialization>
                this.host = jsonObj["host"];
                this.port = jsonObj["port"];
                this.username = jsonObj["username"];
                this.password = jsonObj["password"];
                //</Field initialization>
            }
            catch (Exception ex)
            {
                createConfig();
                initializeConfig();
                if (!(ex is FileNotFoundException || ex is JsonException || ex is RuntimeBinderException))
                {
                    Console.WriteLine("CredentialsConfig.initializeConfig(): " + ex.ToString());
                }
            }
        }

        public void createConfig()
        {
            string jsonOutput = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, jsonOutput);
        }

        public void saveConfig()
        {
            string jsonOutput = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, jsonOutput);
        }
    }
}
