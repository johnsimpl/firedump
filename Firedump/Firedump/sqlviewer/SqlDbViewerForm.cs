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

namespace Firedump.sqlviewer
{
    public partial class SqlDbViewerForm : Form
    {

        private mysql_servers server;
        private string database;

        public SqlDbViewerForm(mysql_servers server,string database)
        {
            InitializeComponent();
            DbConnection connection = DbConnection.Instance();
            connection.username = server.username;
            connection.password = server.password;
            connection.Host = server.host;


            if(connection.testConnection())
            {
                this.server = server;
                this.database = database;
                List<string> tables = connection.getTables(database);

                TreeNode[] nodearray = new TreeNode[tables.Count];
                for (int i =0; i < tables.Count; i++)
                {
                    nodearray[i] = new TreeNode(tables[i]);
                }
                
                TreeNode rootNode = new TreeNode("database:" + database, nodearray);
                rootNode.Expand();
                treeView1.Nodes.Add(rootNode);
            } else
            {
                MessageBox.Show("Couldent connect to "+database+" database");
                
            }
            
            
        }


        private void executesql_click(object sender, EventArgs e)
        {
            string query = addLimitToQuery(richTextBox1.Text);
           
            string connectionString = DbConnection.conStringBuilder(server.host,server.username,server.password,database);
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query,connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    dataGridView1.DataSource = dataset.Tables[0];
                }
            }
           
        }


        /// <summary>
        /// add safe limit to query results
        /// max row results is 500
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private string addLimitToQuery(string query)
        {
            if(query.ToUpper().Contains("LIMIT"))
            {
                return query;
            } else
            {
                return query + " LIMIT 500";
            }
        }
    }
}
