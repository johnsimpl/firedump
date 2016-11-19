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
using MySql.Data;
using MySql.Data.MySqlClient;
using Firedump.utils;

namespace Firedump.sqlviewer
{
    public partial class SqlDbViewerForm : Form
    {

        private mysql_servers server;
        //merge whene database mysql_server gets database field
        private string database;

        public SqlDbViewerForm(mysql_servers server,string database)
        {
            InitializeComponent();
            DbConnection connection = DbConnection.Instance();
            connection.username = server.username;
            connection.password = server.password;
            connection.Host = server.host;


            if(connection.testConnection().wasSuccessful)
            {
                this.server = server;
                this.database = database;
                List<string> tables = connection.getTables(database);

                TreeNode[] nodearray = new TreeNode[tables.Count];
                //ImageList imagelist = new ImageList();
                for (int i =0; i < tables.Count; i++)
                {
                    nodearray[i] = new TreeNode(tables[i]);
                    //imagelist.Images.Add(Image.FromFile("../../resources/icons/sqlselecticon.png"));
                }
                
                TreeNode rootNode = new TreeNode("database:" + database, nodearray);
                rootNode.Expand();
                treeView1.Nodes.Add(rootNode);
                
                treeView1.ImageList = imageList1;
            } else
            {
                MessageBox.Show("Couldent connect to "+database+" database");
                
            }
            
            
        }


        private void executesql_click(object sender, EventArgs e)
        {
            executeQuery(richTextBox1.Text);
           
        }
        

        private void executeQuery(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                string sql = SqlUtils.limitQuery(query);

                string connectionString = DbConnection.conStringBuilder(server.host, server.username, server.password, database);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection))
                    {
                        try
                        {
                            DataSet dataset = new DataSet();
                            adapter.Fill(dataset);
                            dataGridView1.DataSource = dataset.Tables[0];
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                            DataSet dataset = new DataSet();
                            DataTable datatable = new DataTable("MySql Error");
                            datatable.Columns.Add(new DataColumn("Type", typeof(string)));
                            datatable.Columns.Add(new DataColumn("Message", typeof(string)));
                            DataRow datarow = datatable.NewRow();
                            datarow["Type"] = "MySql Error";
                            datarow["Message"] = ex.Message;
                            datatable.Rows.Add(datarow);
                            dataset.Tables.Add(datatable);

                            dataGridView1.DataSource = dataset.Tables[0];

                        }

                    }
                }
            }
        }


        private void nodeSelectEvent(object sender, TreeViewEventArgs e)
        {
            if(!e.Node.Text.StartsWith("database:"))
            {
                string table = e.Node.Text;
                string sql = "SELECT * FROM "+table + " ";
                executeQuery(sql);
            }
        }
    }
}
