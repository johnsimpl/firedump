using Firedump.models.configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firedump.models.configuration.jsonconfig;

namespace Firedump
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //configuration initialization
            ConfigurationManager.getInstance().initializeConfig();

            Application.Run(new MainForm());
            
            
        }
    }
}
