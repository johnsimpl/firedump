using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Firedump.models;

namespace Firedump
{
    public partial class Form1 : Form, IDumpProgressListener
    {

        delegate void SetTextCallback(string text);


        private string savepath = "";
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            //FiredumpContext f = new FiredumpContext();
            //List<mysql_servers> s = f.getAllMySqlServers();
            //string newdpath = Environment.GetFolderPath(Environment.SpecialFolder.Da);
            //Console.WriteLine(s.Count);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            Console.WriteLine("yo");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe"));*/
            /*
            MysqlDump mysqldump = new MysqlDump();
            mysqldump.host = txtHost.Text;
            mysqldump.port = txtPort.Text;
            mysqldump.username = txtUsername.Text;
            mysqldump.password = txtPassword.Text;
            mysqldump.database = txtDatabase.Text;
            if (!string.IsNullOrEmpty(savepath))
            {
                mysqldump.savepath = savepath;
            }
            mysqldump.executeDump();
            */
            
            //or rename to MySqlDumpWorker..or something else
            MySqlDumpAdapter dumpAdapter = new MySqlDumpAdapter();
            MySqlDumpOptions options = new MySqlDumpOptions();
            //set options ex zip or not ...
            
            //start async dump and register a listener for callbacks
            dumpAdapter.startDump(options,this);
        
        }


        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                savepath = fbd.SelectedPath;
            }
            
        }


        //the implemented interface methods for the statdump callbacks
        //update some progress bar or something
        public void onProgress(string progress)
        {
            setOutputLabelText(progress);
        }
        
        public void onError(int error)
        {
            setOutputLabelText(error);
        }

        public void onCancelled()
        {
            setOutputLabelText("Cancelled");
        }

        public void onCompleted(string status)
        {
            setOutputLabelText(status);
        }




        /// <summary>
        /// like java cant call form components from other threads.
        /// quick solution just reinvoke the method from UI.
        /// </summary>
        /// <param name="text"></param>
        private void setOutputLabelText(object text)
        {
            if(this.outputLable.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setOutputLabelText);
                this.Invoke(d,new object[] { text.ToString()});
            } else
            {
                this.outputLable.Text = text.ToString();
            }
        }



    }
}
