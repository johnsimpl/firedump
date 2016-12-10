using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using Firedump.models.dump;
using Firedump.Forms.mysql.sqlviewer;
using Firedump.Forms.mysql.status;
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
using Firedump.Forms.configuration;
using Firedump.Forms.mysql;
using Firedump.Forms.location;
using Firedump.models.location;
using Firedump.Forms.sqlimport;

namespace Firedump
{
    public partial class Home : Form , IDumpProgressListener,ILocationManagerListener
    {
        private firedumpdbDataSet.mysql_serversDataTable serverData;
        private firedumpdbDataSetTableAdapters.mysql_serversTableAdapter mysql_serversAdapter;
        private MySqlDumpAdapter adapter;
        private List<string> databaseList;
        private List<String> tableList = new List<string>();
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
                newMysqlServer = new NewMySQLServer(this);
            }
            return newMysqlServer;
        }

        public Home()
        {
            InitializeComponent();       
            adapter = new MySqlDumpAdapter();

            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter ad = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            
        }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void btAddDestClick(object sender, EventArgs e)
        {
            LocationSwitchboard locswitch = new LocationSwitchboard(this);
            locswitch.ShowDialog();
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
                getNewMysqlServerInstance().ShowDialog();
            }
            catch (ObjectDisposedException ex)
            {
                newMysqlServer = new NewMySQLServer(this);
                bAddServer_Click(null, null);
            }
        }

        public void reloadServerData()
        {
            mysql_serversAdapter.Fill(serverData);
            //edw kanei select to teleutaio item (auto pou molis egine insert kai to fortwnei)
            cmbServers.SelectedIndex = cmbServers.Items.Count - 1;
            cmbServers_SelectionChangeCommitted(null,null);
        }

        private void loadServerData()
        {
            serverData = new firedumpdbDataSet.mysql_serversDataTable();
            mysql_serversAdapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
            mysql_serversAdapter.Fill(serverData);
            cmbServers.DataSource = serverData;           
            cmbServers.DisplayMember = "name";
            cmbServers.ValueMember = "id";
            if(cmbServers.Items.Count > 0)
            {
                cmbServers.SelectedIndex = 0;
            }
            
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
                    databases.Remove("sys");
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
                    ToolStripMenuItem analyzedb = new ToolStripMenuItem();
                    opendb.Text = "browse data";
                    opendb.Tag = "sql";
                    opendb.Click += new EventHandler(menuClick);
                    analyzedb.Text = "inspect database";
                    analyzedb.Click += new EventHandler(menuClick);
                    ContextMenuStrip menu = new ContextMenuStrip();
                    menu.Items.AddRange(new ToolStripMenuItem[] { opendb,analyzedb});                    
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
            if (tvDatabases.SelectedNode != null && tvDatabases.SelectedNode.Parent == null)
            {
                string database = tvDatabases.SelectedNode.Text;
                if(sender.ToString() == "browse data")
                {
                    SqlDbViewerForm sqlform = new SqlDbViewerForm(server, database);
                    sqlform.Show();
                } else if(sender.ToString() == "inspect database")
                {
                    AnalyzeDbForm adbf = new AnalyzeDbForm(server, database);
                    adbf.Show();
                }
                
            } else
            {
                string database = tvDatabases.SelectedNode.Parent.Text;
                if (sender.ToString() == "browse data")
                {
                    SqlDbViewerForm sqlform = new SqlDbViewerForm(server, database);
                    sqlform.Show();
                }
                else if (sender.ToString() == "inspect database")
                {
                    AnalyzeDbForm adbf = new AnalyzeDbForm(server, database);
                    adbf.Show();
                }
               
            }
        }

        public void addToLbSaveLocation(BackupLocation loc)
        {
            if (lbSaveLocations.Items.Contains(loc))
            {
                return;
            }
            lbSaveLocations.Items.Add(loc);
        }

       

        private void Home_Load(object sender, EventArgs e)
        {
            lbSaveLocations.DisplayMember = "path";
            lbSaveLocations.ValueMember = "id";
            loadServerData();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += treeview_work;
            backgroundWorker1.RunWorkerAsync();           
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (cmbServers.Items.Count == 0)
            {
                MessageBox.Show("There are no servers to delete","Server Delete",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete server: " + ((DataRowView)cmbServers.Items[cmbServers.SelectedIndex])["name"], "Server Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                serverData.Rows[cmbServers.SelectedIndex].Delete();
                mysql_serversAdapter.Update(serverData); //fernei to table sto database stin katastasi tou datatable
                cmbServers_SelectionChangeCommitted(null,null);
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
            if (lbSaveLocations.Items.Count==0)
            {
                MessageBox.Show("No save locations. Add at least one save location and try again.", "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //</elenxoi>

            return true;
        }

        private void bStartDump_Click(object sender, EventArgs e)
        {
            if (!performChecks())
            {
                return;
            }
            if(adapter.isDumpRunning())
            {
                MessageBox.Show("dump is running...");
                return;
            }

            List<string> databases = new List<string>();
            List<string> excludedTables = new List<string>();
            tableList = new List<string>();
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
                        } else
                        {
                            tableList.Add(childNode.Text);
                        }
                    }
                    if (tables != "")
                    {
                        tables = tables.Substring(0, tables.Length - 1); //vgazei to teleutaio comma
                    }
                    excludedTables.Add(tables);
                }
            }
            
            DumpCredentialsConfig config = new DumpCredentialsConfig();
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

            bStartDump.Enabled = false;
            adapter.setTableList(tableList);
            adapter.startDump(config, this);
            
        }


        private void cmbServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //edw prepei na bei elenxos ean trexei eidh to filltreeview thread kai an trexei na ginei interrupt kai destroy
            tvDatabases.Nodes.Clear();
            if(!backgroundWorker1.IsBusy)
            {
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
                Task task = new Task(resetProgressBarAfterCancel);
                task.Start();
                lStatus.Text = "Cancelled";               
                resetPbarValue();
                tableList = new List<string>();
                bStartDump.Enabled = true;
            }
        }



        /// <summary>
        /// Callbacks are still comming from compress and process.
        /// We cant stop them because its exe
        /// so just wait a second after proc kill for all callbacks to come and then reset the progressbar
        /// </summary>
        async void resetProgressBarAfterCancel()
        {
            Thread.Sleep(1000);
            if (pbDumpExec != null)
            {
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

                pbDumpExec.Invoke((MethodInvoker)delegate () {
                    pbDumpExec.Value = pbDumpExec.Maximum;
                });           

                if (status.wasSuccessful)
                {
                    //EDW KALEITAI TO SAVE STA LOCATIONS
                    List<int> locations = new List<int>();
                    foreach (object item in lbSaveLocations.Items)
                    {
                        BackupLocation loc = (BackupLocation)item;
                        locations.Add(loc.id);
                    }
                    LocationAdapterManager adapter = new LocationAdapterManager(this,locations,status.fileAbsPath);
                    adapter.startSave();
                    //MessageBox.Show("Dump was completed successfully.", "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bDeleteSaveLocation_Click(object sender, EventArgs e)
        {
            if (lbSaveLocations.Items.Count == 0 || lbSaveLocations.SelectedIndex==-1) //-1 einai ama den exei tpt selected
            {
                return;
            }
            lbSaveLocations.Items.RemoveAt(lbSaveLocations.SelectedIndex);
        }

        public void deleteSaveLocation(BackupLocation loc)
        {
            if (lbSaveLocations.Items.Contains(loc))
            {
                lbSaveLocations.Items.Remove(loc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress">Progress int 1-100</param>
        /// <param name="speed">Speed in B/s -1 to ignore</param>
        public void setSaveProgress(int progress, int speed)
        {
            setProgressValue(progress);
            Console.WriteLine(speed);
            if(speed == -1) { return; }
            Console.WriteLine(speed);
            string speedlabelext = "B/s";
            double tspeed = 0;
            if(speed <= 1050)
            {
                speedlabelext = "B/s";
                tspeed = speed;
            }
            else if (speed <= 1050000)
            {
                speedlabelext = "kB/s";
                tspeed = speed / 1000;
            }
            else
            {
                speedlabelext = "mB/s";
                tspeed = speed / 1000000;
            }
            string printedspeed = "";
            if (tspeed < 10)
            {
                //kanei format to double se ena dekadiko psifio se morfi string alliws den ginete stin c#
                printedspeed = string.Format("{0:0.0}", tspeed);
            }
            else
            {
                printedspeed = Convert.ToInt32(tspeed).ToString();
            }
            ltable.Invoke((MethodInvoker)delegate () {                          
                ltable.Text = printedspeed+" "+speedlabelext;
            });

        }

        public void onSaveInit(int maxprogress)
        {
            lStatus.Invoke((MethodInvoker)delegate () {
                lStatus.Text = "Saving to locations...";
                initProgressBar(null, maxprogress);
                tableRowCount(-1);
            });
        }

        public void onSaveComplete(List<LocationResultSet> results)
        {
            lStatus.Invoke((MethodInvoker)delegate () {
                lStatus.Text = "Save complete!";
                tableRowCount(-1);
            });
            string errorsToOutput = "";
            bool koble = true;
            int errorcounter = 0;
            foreach (LocationResultSet result in results)
            {
                if (!result.wasSuccessful)
                {
                    errorcounter++;
                    koble = false;
                    errorsToOutput += result.errorMessage + "\n";
                }
            }

            bStartDump.Invoke((MethodInvoker)delegate ()
            {
                bStartDump.Enabled = true;
            });

            if (koble)
            {
                MessageBox.Show("Dump was completed successfully.", "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Saving to "+errorcounter+" out of "+results.Count+" save location(s) failed:\n"+errorsToOutput, "MySQL Dump", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        public void onSaveError(string message)
        {
            MessageBox.Show("Save to locations failed:\n"+message,"Locations Save",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public void onInnerSaveInit(string location_name, int location_type)
        {
            string location = "";
            switch (location_type)
            {
                case 0: //file system
                    location = "FileSystem";
                    break;
                case 1: //ftp
                    location = "FTP";
                    break;
                case 2: //dropbox
                    location = "Dropbox";
                    break;
                case 3: //google drive
                    location = "Google Drive";
                    break;
                default:
                    break;
            }
            if (location_name.Length>20) //ama einai poli megalo to name to kovei
            {
                location_name = location_name.Substring(0, 17) + "...";
            }
            lStatus.Invoke((MethodInvoker)delegate () {
                lStatus.Text = "Saving to: "+location_name + " ("+location+")";
            });
        }

        private void importSQLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportSQL importinstance = new ImportSQL();
            importinstance.Show();
        }




        //-----------------------------------------------------------------------
        //------------END INTERFACE METHODS--------------------------------------
        //



    }
}
