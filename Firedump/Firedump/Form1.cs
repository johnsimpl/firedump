using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;
using Firedump.models;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.dump;
using Firedump.mysql;

namespace Firedump
{
    public partial class Form1 : Form, IDumpProgressListener
    {
        /// <summary>
        /// delegate methods
        /// used for event callbacks
        /// </summary>
        /// <param name="text"></param>
        delegate void SetTextCallback(string text);
        delegate void InitProgressBar(List<string> tables,int max);
        delegate void InreaseProgressBarStep();
        delegate void SetProgressValue(int progress);
        delegate void MaximizeProgressBar();
        delegate void StartCompressProgressBar();
        delegate void ResetPBar();
        delegate void TableRowCount(int tablerowcount);

        private MySqlDumpAdapter adapter;


        private string savepath = "";
        public Form1()
        {
            InitializeComponent();
            adapter = new MySqlDumpAdapter();
        }

        
        //comment 

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// execute dump button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                CredentialsConfig credentialsConfigInstance = new CredentialsConfig();
                credentialsConfigInstance.host = host;
                credentialsConfigInstance.port = port;
                credentialsConfigInstance.username = username;
                credentialsConfigInstance.password = password;
                credentialsConfigInstance.database = database;

                //start async dump and register a listener for callbacks
                adapter.startDump(credentialsConfigInstance,this);
            }
            
        }

        /// <summary>
        /// not used anymore
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                savepath = fbd.SelectedPath;
            }
            
        }

        /// <summary>      
        /// the implemented interface methods for the statdump callbacks----------------start--------------------
        /// update some progress bar or something
        /// </summary>
        /// <param name="implemented methods"></param>       
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

        public void onCompleted(DumpResultSet resultSet)
        {
            if(resultSet != null)
            {
                setOutputLabelText("Completed");
                Console.WriteLine(resultSet.ToString());
                maximizeProgressBar();
                if (resultSet.wasSuccessful)
                {
                    MessageBox.Show("Dump was completed successfully.", "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dump was unsuccessful.", "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        public void onTableDumpStart(string table)
        {
            setOutputLabelText("dumping table "+table);
            inreaseProgressBarStep();
        }

        public void initDumpTables(List<string> tables)
        {                   
            initProgressBar(tables,0);
        }

        /// <summary>
        /// updates talbe rows:+rowcount label
        /// or sets to "" if rowcount is -1
        /// </summary>
        /// <param name="rowcount"></param>
        public void tableRowCount(int rowcount)
        {
            if (this.ltablerow.InvokeRequired)
            {
                TableRowCount d = new TableRowCount(tableRowCount);
                this.Invoke(d,rowcount);
            }
            else
            {
                if(rowcount == -1)
                {
                    ltablerow.Text = "";
                } else
                {
                    ltablerow.Text = "Table rows:" + rowcount;
                }
                
            }
        }

        public void compressProgress(int progress)
        {
            setProgressValue(progress);
        }

        public void onCompressStart()
        {
            setOutputLabelText("Compressing...");
            initProgressBar(null,100);
            tableRowCount(-1);
        }
        //the implemented interface methods----------------END--------------------


        private void setProgressValue(int progress)
        {
            if(this.pbDumpprogress.InvokeRequired)
            {
                SetProgressValue d = new SetProgressValue(setProgressValue);
                this.Invoke(d,progress);
            } else
            {
                pbDumpprogress.Value = progress;
            }
        }

        /// <summary>
        /// either list tables size as max or int max 
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="max"></param>
        private void initProgressBar(List<string> tables,int max)
        {
            if(this.pbDumpprogress.InvokeRequired)
            {
                InitProgressBar d = new InitProgressBar(initProgressBar);
                if(tables != null)
                {
                    this.Invoke(d, tables,0);
                } else
                {
                    this.Invoke(d, null,max);
                }
                
            } else
            {
                pbDumpprogress.Minimum = 0;
                if(tables != null)
                {
                    pbDumpprogress.Maximum = (tables.Count + 1);
                } else
                {
                    pbDumpprogress.Maximum = max;
                }
                
                pbDumpprogress.Step = 1;
            }
        }


        private void inreaseProgressBarStep()
        {
            if (this.pbDumpprogress.InvokeRequired)
            {
                InreaseProgressBarStep d = new InreaseProgressBarStep(inreaseProgressBarStep);
                this.Invoke(d);
            }
            else
            {
                pbDumpprogress.PerformStep();
            }          
        }

        private void maximizeProgressBar()
        {
            if(this.pbDumpprogress.InvokeRequired)
            {
                MaximizeProgressBar d = new MaximizeProgressBar(maximizeProgressBar);
            } else
            {
                pbDumpprogress.Value = pbDumpprogress.Maximum;
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
                pbDumpprogress.Refresh();
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


        /// <summary>
        /// cancel current running task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelDUmpTaskClickListener(object sender, EventArgs e)
        {
            adapter.cancelDump();
            Task task = new Task(resetProgressBarAfterCancel);
            task.Start();
        }


        /// <summary>
        /// Callbacks are still comming from compress and process.
        /// We cant stop them because its exe
        /// so just wait a second after proc kill for all callbacks to come and then reset the progressbar
        /// </summary>
        async void resetProgressBarAfterCancel()
        {
            Thread.Sleep(1000);
            if(pbDumpprogress != null)
            {
                resetPbarValue();
            }          
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
                   
                    for (int i =0; i < databases.Count; i++)
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
