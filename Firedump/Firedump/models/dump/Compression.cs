using Firedump.models.configuration.jsonconfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class Compression
    {
        ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
        private Process proc;
        /// <summary>
        /// Absolute path of the file to compress
        /// </summary>
        public string absolutePath { set; get; }

        public Compression() { }

        public Compression(string absolutePath)
        {
            this.absolutePath = absolutePath;
        }

        public string doCompress7z()
        {
            string resultAbsPath = "";
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "resources\\7z\\7z.exe",//AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe") ,
                    Arguments = "a -tzip asd.zip asd.avi",
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            Console.WriteLine("MySqlDump: Dump starting now");
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {

                string line = proc.StandardOutput.ReadLine();
                Console.WriteLine(line);


            }





            return resultAbsPath;
        }
    }
}
