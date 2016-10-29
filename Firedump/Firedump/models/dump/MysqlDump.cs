using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Firedump
{
    class MysqlDump
    {

        //credentials
        public String host { set; get; }
        public String port { set; get; }
        public String username { set; get; }
        public String password { set; get; }
        public String database { set; get; }

        //MySqlDumpConfig
        public String tempSavePath { set; get; }

        public MysqlDump(){}
        public String executeDump()
        {
            StringBuilder output = new StringBuilder();
            StringBuilder arguments = new StringBuilder();

            if (!String.IsNullOrEmpty(host))
            {
                arguments.Append("--host " + host + " ");
            }
            if (!String.IsNullOrEmpty(port))
            {
                arguments.Append("--port=" + port + " ");
            }
            
            if (!String.IsNullOrEmpty(username))
            {
                arguments.Append("--user " + username + " ");
            }
            if (!String.IsNullOrEmpty(password))
            {
                arguments.Append("--password=" + password + " ");
            }
            if (!String.IsNullOrEmpty(database))
            {
                arguments.Append(database);
            }else
            {
                arguments.Append("--all-databases");
            }

            Console.WriteLine(arguments.ToString());

            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "mysqldump.exe",//AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe") ,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            Console.WriteLine("asdasdas");
            proc.Start();


            if (String.IsNullOrEmpty(tempSavePath))
            {
                while (!proc.StandardOutput.EndOfStream)
                {
                    //xeirismos output edw 
                    output.Append(proc.StandardOutput.ReadLine());
                }
            }else
            {
                String filename="unknown.sql";
                if (!String.IsNullOrEmpty(database))
                {
                    filename = tempSavePath + "\\" + database + ".sql";
                }else
                {
                    filename = tempSavePath + "\\AllDatabases.sql";
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filename))
                {
                    while (!proc.StandardOutput.EndOfStream)
                    {
                        file.WriteLine(proc.StandardOutput.ReadLine());
                    }
                }
                    
            }

            Console.WriteLine(output.ToString());

            while (!proc.StandardError.EndOfStream)
            {
                Console.WriteLine(proc.StandardError.ReadLine());
            }

            return "";
        }
    }
}
