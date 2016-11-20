using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using Firedump.models.dump;
using Firedump.mysql;
using Firedump.sqlviewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump
{
    public partial class Home : Form , IDumpProgressListener
    {
        private firedumpdbDataSet.mysql_serversDataTable serverData;
        private firedumpdbDataSetTableAdapters.mysql_serversTableAdapter mysql_serversAdapter;
        private MySqlDumpAdapter adapter;
        private List<string> databaseList;
        private bool hideSystemDatabases = true;
        //form instances
        private static GeneralConfiguration genConfig;
        private GeneralConfiguration getGenConfigInstance()
        {
            if(genConfig == null)
            {
                genConfig = new GeneralConfiguration();
            }
            return genConfig;
        }

        private static NewMySQLServer newMysqlServer;
        private NewMySQLServer getNewMysqlServerInstance()
        {
            if (newMysqlServer == null)
            {
                newMysqlServer = new NewMySQLServer();
            }
            return newMysqlServer;
        }

        public Home()
        {
            InitializeComponent();       
            adapter = new MySqlDumpAdapter();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void btAddDestClick(object sender, EventArgs e)
        {

        }

        private void miConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                getGenConfigInstance().Show();
            }
            catch (ObjectDisposedException ex)
            {
                genConfig = new GeneralConfiguration();
                miConfiguration_Click(null,null);
            }
        }

        private void bAddServer_Click(object sender, EventArgs e)
        {
            try
            {
                getNewMysqlServerInstance().Show();
            }
            catch (ObjectDisposedException ex)
            {
                newMysqlServer = new NewMySQLServer();
                bAddServer_Click(null, null);
            }
        }

        private void loadServerData()
        {
            serverData = new firedumpdbDataSet.mysql_serversDataTable();
            mysql_serversAdapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
            mysql_serversAdapter.Fill(serverData);
            cmbServers.DataSource = serverData;           
            cmbServers.DisplayMember = "name";
            cmbServers.ValueMember = "id";
            cmbServers.SelectedIndex = 0;
        }

        private void fillTreeView()
        {
           
            if (cmbServers.Items.Count == 0) { return; } //ama den iparxei kanenas server den to kanei
            DbConnection con = new DbConnection();

            this.Invoke((MethodInvoker)delegate ()
            {
                con.Host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
                con.port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
                con.username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
                con.password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];
            });
          
            //edw prepei na bei to database kai mia if then else apo katw analoga ama kanei connect se server i se database
            ConnectionResultSet result = con.testConnection();
            if (result.wasSuccessful)
            {
                List<string> databases = con.getDatabases();
                if (hideSystemDatabases)
                {
                    databases.Remove("information_schema");
                    databases.Remove("mysql");
                    databases.Remove("performance_schema");
                }              
                foreach (string database in databases)
                {
                    this.Invoke((MethodInvoker)delegate () {
                        TreeNode node = new TreeNode(database);
                        List<string> tables = con.getTables(database);
                        foreach (string table in tables)
                        {
                            node.Nodes.Add(table);
                        }
                        tvDatabases.Nodes.Add(node);
                    });                   
                }

                this.Invoke((MethodInvoker)delegate () {
                    ToolStripMenuItem opendb = new ToolStripMenuItem();
                    opendb.Text = "browse data";
                    opendb.Tag = "sql";
                    opendb.Click += new EventHandler(menuClick);
                    ContextMenuStrip menu = new ContextMenuStrip();
                    menu.Items.AddRange(new ToolStripMenuItem[] { opendb});                    
                    tvDatabases.ContextMenuStrip = menu;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate () {
                    MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private void menuClick(object sender,EventArgs e)
        {
            string Host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
            int port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
            string username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
            string password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];

            mysql_servers server = new mysql_servers();
            server.host = Host;
            server.port = port;
            server.username = username;
            server.password = password;
            if (tvDatabases.SelectedNode.Parent == null)
            {
                string database = tvDatabases.SelectedNode.Text;
                SqlDbViewerForm sqlform = new SqlDbViewerForm(server,database);
                sqlform.Show();
            } else
            {
                string database = tvDatabases.SelectedNode.Parent.Text;
                SqlDbViewerForm sqlform = new SqlDbViewerForm(server, database);
                sqlform.Show();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            loadServerData();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += treeview_work;
            backgroundWorker1.RunWorkerAsync();           
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete server: " + ((DataRowView)cmbServers.Items[cmbServers.SelectedIndex])["name"], "Server Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                serverData.Rows[cmbServers.SelectedIndex].Delete();
                mysql_serversAdapter.Update(serverData); //fernei to table sto database stin katastasi tou datatable
            }
        }


        private void tvDatabases_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //an kapio child ginei checked na ginei kai o parent
            //an ginei unchecked kai to telefteo pedi na ginei unchecked kai o parent
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Parent != null)
                {
                    if (!e.Node.Checked)
                    {

                        bool found = false;
                        foreach (TreeNode n in e.Node.Parent.Nodes)
                        {
                            if (n.Checked)
                            {
                                e.Node.Parent.Checked = true;
                                found = true;
                                break;
                            }                           
                        }
                        if (!found)
                            e.Node.Parent.Checked = false;
                    }
                    else
                    {
                        e.Node.Parent.Checked = true;
                    }
                }
                else
                {                   
                    if(e.Node.Checked)
                    {
                        this.checkAllChildNodes(true, e.Node);
                    } else
                    {
                        this.checkAllChildNodes(false, e.Node);
                    }                   
                }
            }
            

            /*
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                   
                    //Calls the CheckAllChildNodes method, passing in the current 
                    //Checked value of the TreeNode whose checked state changed. 
                    this.checkAllChildNodes(e.Node.Checked, e.Node);
                }
            }
            */           
        }

        /// <summary>
        /// Recursively checks or unchecks all child nodes of a node
        /// </summary>
        /// <param name="nodeChecked">True to check nodes or false to uncheck</param>
        /// <param name="treeNode">the starting node</param>
        private void checkAllChildNodes(bool nodeChecked, TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                /* akiro to recursion giati stin periptwsi mas den exoume pote parapanw apo 1 epipedo tsampa tha trwei porous
                if (node.Nodes.Count > 0)
                {
                    this.checkAllChildNodes(nodeChecked, node); 
                }*/
            }
        }

        private bool performChecks()
        {
            //elenxoi edw logika tha einai arketoi
            //<elenxoi>
            //</elenxoi>

            return true;
        }

        private void bStartDump_Click(object sender, EventArgs e)
        {
            if (!performChecks())
            {
                return;
            }

            List<string> databases = new List<string>();
            List<string> excludedTables = new List<string>();
            foreach(TreeNode node in tvDatabases.Nodes)
            {
                if (node.Checked)
                {
                    databases.Add(node.Text);
                    string tables = "";
                    foreach(TreeNode childNode in node.Nodes)
                    {
                        if (!childNode.Checked)
                        {
                            tables += childNode.Text + ",";
                        }
                    }
                    if (tables != "")
                    {
                        tables = tables.Substring(0, tables.Length - 1); //vgazei to teleutaio comma
                    }
                    excludedTables.Add(tables);
                }
            }

            /* proxeiro testing
            Console.WriteLine("Databases:");
            foreach(string database in databases)
            {
                Console.WriteLine(database);
            }

            Console.WriteLine("Tables:");
            foreach (string table in excludedTables)
            {
                Console.WriteLine(table);
            }*/

            CredentialsConfig config = new CredentialsConfig();
            config.host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
            config.port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
            config.username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
            config.password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];

            if (databases.Count == 0)
            {
                MessageBox.Show("No database selected","MySQL Dump",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if(databases.Count == 1)
            {
                config.database = databases[0];
                if (excludedTables[0] != "")
                {
                    config.excludeTablesSingleDatabase = excludedTables[0];
                }
            }
            else
            {
                databaseList = databases;
                config.database = databases[0];
                config.databases = databases.ToArray();
                config.excludeTables = excludedTables.ToArray();
            }

            pbDumpExec.Value = 0;

            //EDW KALEITAI TO ADAPTER kai tou pernas to config
            //xriazontai kialoi elenxoi
            //tha iparxei koumpei Cancel?
            //gia oso trexei to dump to button Start Dump tha einai disable?
            //I tha to elenxoume sto performChecks ?
           
            if (!adapter.isDumpRunning())
                adapter.startDump(config, this);
            else
                //inform user...
                MessageBox.Show("dump is running...");
            
        }


        private void cmbServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //edw prepei na bei elenxos ean trexei eidh to filltreeview thread kai an trexei na ginei interrupt kai destroy
            tvDatabases.Nodes.Clear();
            if(!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.RunWorkerAsync();
            }
            
        }

        private void treeview_work(object sender, DoWorkEventArgs e)
        {
            fillTreeView();
        }


        private void resetPbarValue()
        {
            pbDumpExec.Invoke((MethodInvoker)delegate () {
                pbDumpExec.Value = 0;
                pbDumpExec.Refresh();
            });
        }

        private void maximizeProgressBar()
        {
            pbDumpExec.Invoke((MethodInvoker)delegate () {
                pbDumpExec.Value = pbDumpExec.Maximum;
            });
        }

        private void increaseProgressBarStep()
        {
            pbDumpExec.Invoke((MethodInvoker)delegate () {
                pbDumpExec.PerformStep();
            });
        }

        private void initProgressBar(List<string> tables,int max)
        {
            pbDumpExec.Invoke((MethodInvoker)delegate () {
                if(tables != null)
                {
                    pbDumpExec.Maximum = (tables.Count);
                } else
                {
                    pbDumpExec.Maximum = max;
                }
                pbDumpExec.Step = 1;
            });
        }

        private void setProgressValue(int progress)
        {
            pbDumpExec.Invoke((MethodInvoker)delegate () {
                pbDumpExec.Value = progress;
            });
        }

        private void cancelDumpClick(object sender, EventArgs e)
        {
            if(adapter != null)
            {
                adapter.cancelDump();
                lStatus.Text = "Cancelled";               
                resetPbarValue();
            }
        }



        //
        //-------------------------------------------------------------------------
        //------->INTERFACE EVENT-CALLBACK METHODS START---------------------------
        public void onProgress(string progress)
        {
            lStatus.Invoke((MethodInvoker)delegate () {
                lStatus.Text = progress;
            });
        }


        public void onError(int error)
        {
            lStatus.Invoke((MethodInvoker)delegate () {
                //to error pernei sigkekrimenes times
                //opote mporoume na to diksoume kalitera more info error
                lStatus.Text = "Error:"+error.ToString();
            });
            resetPbarValue();
        }


        public void onCancelled()
        {
            lStatus.Invoke((MethodInvoker)delegate () {              
                lStatus.Text = "Cancelled";
            });
            resetPbarValue();
        }


        public void onCompleted(DumpResultSet status)
        {
            if(status != null)
            {
                lStatus.Invoke((MethodInvoker)delegate () {
                    lStatus.Text = "Completed";
                });


                if(status.wasSuccessful)
                {
                    MessageBox.Show("Dump was completed successfully.", "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string errorMessage = "";
                    switch (status.errorNumber)
                    {
                        case 1:
                            errorMessage = "Connection credentials not set correctly:\n"+status.errorMessage;
                            break;
                        case 2:
                            errorMessage = "MySQL dump failed:\n" + status.mysqldumpexeStandardError;
                            break;
                        case 3:
                            errorMessage = "Compression failed:\n" + status.mysqldumpexeStandardError;
                            break;
                        default:
                            break;
                    }
                    MessageBox.Show(errorMessage, "Dump failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //kiala pramata na kanei edo, afta pou meleges
                //
                //gia ui components xriazete Invoke
                
            }
        }


        public void onTableDumpStart(string table)
        {
            lStatus.Invoke((MethodInvoker)delegate () {
                lStatus.Text = "dumping table " + table;
            });

            increaseProgressBarStep();
        }

        public void initDumpTables(List<string> tables)
        {
            initProgressBar(tables,0);
        }

        public void tableRowCount(int rowcount)
        {
            ltable.Invoke((MethodInvoker)delegate () {
                if(rowcount == -1)
                {
                    ltable.Text = "";
                } else
                {
                    ltable.Text = "Table rows:"+rowcount;
                }
            });
        }

        public void compressProgress(int progress)
        {
            setProgressValue(progress);
        }

        public void onCompressStart()
        {
            lStatus.Invoke((MethodInvoker)delegate () {
                lStatus.Text = "Compressing...";
                initProgressBar(null,100);
                tableRowCount(-1);
            });
        }

        private void cbShowSysDB_CheckedChanged(object sender, EventArgs e)
        {
            hideSystemDatabases = !cbShowSysDB.Checked;
            cmbServers_SelectionChangeCommitted(null, null); //ksanakalei to fillTreeView
        }


        //-----------------------------------------------------------------------
        //------------END INTERFACE METHODS--------------------------------------
        //



    }
}
