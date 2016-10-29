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
using Firedump.models.configuration;
using Firedump.models.dump;
using Firedump.mysql;

namespace Firedump
{
    public partial class Form1 : Form, IDumpProgressListener
    {

        delegate void SetTextCallback(string text);
        delegate void InitProgressBar(List<string> tables);
        delegate void InreaseProgressBarStep();
        delegate void ResetPBar();

        private MySqlDumpAdapter adapter;


        private string savepath = "";
        public Form1()
        {
            InitializeComponent();
            adapter = new MySqlDumpAdapter();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            pbDumpprogress.Value = 0;
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (cbDatabases.SelectedItem == null)
            {
                return;
            }
            string database = cbDatabases.SelectedItem.ToString();

            int port;
            if (int.TryParse(txtPort.Text, out port))
            {

                ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
                configurationManagerInstance.initializeConfig();
                configurationManagerInstance.credentialsConfigInstance.host = host;
                configurationManagerInstance.credentialsConfigInstance.port = port;
                configurationManagerInstance.credentialsConfigInstance.username = username;
                configurationManagerInstance.credentialsConfigInstance.password = password;
                configurationManagerInstance.credentialsConfigInstance.saveConfig();
                configurationManagerInstance.mysqlDumpConfigInstance.database = database;
                //utf-8 gives me an error coming from mysql
                configurationManagerInstance.mysqlDumpConfigInstance.characterSet = "utf8";
                configurationManagerInstance.mysqlDumpConfigInstance.saveConfig();

                //start async dump and register a listener for callbacks
                adapter.startDump(this);

            }



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
            resetPbarValue();
        }

        public void onCancelled()
        {
            setOutputLabelText("Cancelled");
            MessageBox.Show("Cancelled");
            resetPbarValue();
        }

        public void onCompleted(DumpResultSet status)
        {
            //setOutputLabelText(status);
            setOutputLabelText("completed");
            MessageBox.Show(status.ToString());
        }

        public void onTableDumpStart(string table)
        {
            setOutputLabelText("dumping table "+table);
            inreaseProgressBarStep();
        }

        public void initDumpTables(List<string> tables)
        {                   
            initProgressBar(tables);
        }


        private void initProgressBar(List<string> tables)
        {
            if(this.pbDumpprogress.InvokeRequired)
            {
                InitProgressBar d = new InitProgressBar(initProgressBar);
                this.Invoke(d, tables);
            } else
            {
                pbDumpprogress.Minimum = 0;
                pbDumpprogress.Maximum = tables.Count;
                pbDumpprogress.Step = 1;
            }
        }

        private void inreaseProgressBarStep()
        {
            Console.WriteLine("inreaseProgressBarStep1");
            if (this.pbDumpprogress.InvokeRequired)
            {
                Console.WriteLine("inreaseProgressBarStep2");
                InreaseProgressBarStep d = new InreaseProgressBarStep(inreaseProgressBarStep);
                this.Invoke(d);
            }
            else
            {
                Console.WriteLine("inreaseProgressBarStep3");
                pbDumpprogress.PerformStep();
            }          
        }

        private void resetPbarValue()
        {
            if(this.pbDumpprogress.InvokeRequired)
            {
                ResetPBar d = new ResetPBar(resetPbarValue);
                this.Invoke(d);
            } else
            {
                pbDumpprogress.Value = 0;
            }
        }


        /// <summary>
        /// like java cant call form components from other threads.
        /// quick solution just reinvoke the method from UI.
        /// </summary>
        /// <param name="text"></param>
        private void setOutputLabelText(object text)
        {
            
            if(this.lStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setOutputLabelText);
                this.Invoke(d,new object[] { text.ToString()});
            } else
            {
                this.lStatus.Text = text.ToString();
            }
            
        }

        private void cancelDUmpTaskClickListener(object sender, EventArgs e)
        {
            adapter.cancelDump();
        }

        private void btnRefreshDatabasesClickListener(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            int port;
            if(int.TryParse(txtPort.Text,out port))
            {

                DbConnection con = DbConnection.Instance();
                con.Host = host;
                con.username = username;
                con.password = password;
                con.port = port;
                con.database = "";

                if(con.testConnection())
                {
                    cbDatabases.Items.Clear();
                    List<string> databases = con.getDatabases();
                    for(int i =0; i < databases.Count; i++)
                    {
                        cbDatabases.Items.Add(databases[i].ToString());
                    }
                    cbDatabases.SelectedIndex = 1;
                }
               

            }
            
        }


        private void test_con_clickListener(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            int port;
            if (int.TryParse(txtPort.Text, out port))
            {
                DbConnection con = DbConnection.Instance();
                con.Host = host;
                con.username = username;
                con.password = password;
                con.port = port;

                if (con.testConnection())
                {
                    lStatus.Text = "connection is successfull!";
                } else
                {
                    lStatus.Text = "Error try connecting to server!";
                }
            }
            
        }




    }
}
