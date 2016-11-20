using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using Firedump.mysql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump
{
    public partial class Home : Form
    {
        firedumpdbDataSet.mysql_serversDataTable serverData;
        firedumpdbDataSetTableAdapters.mysql_serversTableAdapter mysql_serversAdapter;
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
            con.Host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
            con.port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
            con.username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
            con.password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];
            //edw prepei na bei to database kai mia if then else apo katw analoga ama kanei connect se server i se database

            ConnectionResultSet result = con.testConnection();
            if (result.wasSuccessful)
            {
                List<string> databases = con.getDatabases();
                foreach(string database in databases)
                {
                    TreeNode node = new TreeNode(database);
                    List<string> tables = con.getTables(database);
                    foreach(string table in tables)
                    {
                        node.Nodes.Add(table);
                    }
                    tvDatabases.Nodes.Add(node);
                }
            }
            else
            {
                MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            loadServerData();
            fillTreeView();
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
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.checkAllChildNodes(e.Node.Checked, e.Node);
                }
            }
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
                config.databases = databases.ToArray();
                config.excludeTables = excludedTables.ToArray();
            }

            //EDW KALEITAI TO ADAPTER kai tou pernas to config

        }

        private void cmbServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //edw prepei na bei elenxos ean trexei eidh to filltreeview thread kai an trexei na ginei interrupt kai destroy
            tvDatabases.Nodes.Clear();
            fillTreeView();
        }
    }
}
