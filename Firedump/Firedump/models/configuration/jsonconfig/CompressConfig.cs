using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.jsonconfig
{
    public class CompressConfig : ConfigurationClass
    {
        private readonly string jsonFilePath = "./config/CompressConfig.json";

        //<!configuration fields section>
        /// <summary>
        /// Enables compression after dump
        /// </summary>
        public bool enableCompression { set; get; }
        /// <summary>
        /// false - use .NET 4.5 native compression
        /// true - use 7zip
        /// </summary>
        public bool use7zip { set; get; } = true;

        //<7zip configuration>

        /// <summary>
        /// 0 - -mx1 : Low compression faster proccess
        /// 1 - -mx3 : Fast compression mode
        /// 2 - -mx5 : Normal compression mode
        /// 3 - -mx7 : Maximum compression mode
        /// 4 - -mx9 : Ultra compression mode
        /// </summary>
        public int compressionLevel { set; get; } = 4;
        /// <summary>
        /// Uses multithreading to zip faster (use if you have quad core procressor) -mmt
        /// </summary>
        public bool useMultithreading { set; get; } = true;
        /// <summary>
        /// 0 - -t7z : file.7z
        /// 1 - -tgzip : file.gzip
        /// 2 - -tzip : file.zip
        /// 3 - -tbzip2 : file.bzip2
        /// 4 - -ttar : file.tar (UNIX and LINUX)
        /// 5 - -tiso : file.iso
        /// 6 - -tudf : file.udf
        /// </summary>
        public int fileType { set; get; } = 2;

        //</7zip configuration>

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
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                //<Field initialization>
                this.enableCompression = jsonObj["enableCompression"];
                this.use7zip = jsonObj["use7zip"];
                this.compressionLevel = jsonObj["compressionLevel"];
                this.useMultithreading = jsonObj["useMultithreading"];
                this.fileType = jsonObj["fileType"];
                //</Field initialization>
            }
            catch (Exception ex)
            {
                compressConfigInstance = new CompressConfig(); //resetarei sta default options giati mporei apo panw na exoun allaksei kapoia se periptwsi corrupted data
                compressConfigInstance.saveConfig();
                compressConfigInstance.initializeConfig();
                if (!(ex is FileNotFoundException || ex is JsonException || ex is RuntimeBinderException))
                {
                    Console.WriteLine("MySqlDumpConfig.initializeConfig(): " + ex.ToString());
                }
            }
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
