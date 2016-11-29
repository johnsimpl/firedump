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
using Firedump.models.databaseUtils;

namespace Firedump.Forms.mysql.sqlviewer
{
    public partial class SqlDbViewerForm : Form
    {

        private bool skip = false;
        private Stack<string> undoList = new Stack<string>();
        private Stack<string> redoList = new Stack<string>();

        private mysql_servers server;
        //merge whene database mysql_server gets database field
        private string database;

        private string[] limits = new string[] {
            "Limit to 50 rows",
            "Limit to 100 rows",
            "Limit to 500 rows",
            "Limit to 1000 rows",
            "Limit to 5000 rows",
            "No Limit"
        };

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
                MysqlWords.tables = tables;
                for(int i =0; i < MysqlWords.tables.Count; i++)
                {
                    MysqlWords.tables[i].ToUpper();
                }

                TreeNode[] nodearray = new TreeNode[tables.Count];
                for (int i =0; i < tables.Count; i++)
                {
                    nodearray[i] = new TreeNode(tables[i]);
                }
                
                TreeNode rootNode = new TreeNode("database:" + database, nodearray);
                rootNode.Expand();
                treeView1.Nodes.Add(rootNode);
                
                treeView1.ImageList = imageList1;
            } else
            {
                MessageBox.Show("Couldent connect to "+database+" database");                
            }

            richTextBox1.Text = "";
            for(int i =0; i < limits.Length; i++)
            {
                toolStripComboBox1.Items.Add(limits[i]);
            }
            toolStripComboBox1.SelectedIndex = 2;
            
        }


        private void executesql_click(object sender, EventArgs e)
        {
            executeQuery(richTextBox1.Text);
        }
        

        private void executeQuery(string query)
        {
            
            if (!String.IsNullOrEmpty(query))
            {
                undoList.Push(query);
                string sql = limitQuery(query);
                
                string connectionString = DbConnection.conStringBuilder(server.host, server.username, server.password, database);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection))
                    {
                        try
                        {
                            DataSet dataset = new DataSet();
                            BindingSource bs = new BindingSource();
                            adapter.Fill(dataset);
                            bs.DataSource = dataset.Tables[0].DefaultView;
                            dataGridView1.DataSource = bs;

                            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                richTextBox1.Text = sql;
                executeQuery(sql);
                setSqlHighlight(sql);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
           
        }
        

        private void setSqlHighlight(string sql)
        {
            if(!String.IsNullOrEmpty(sql))
            {
                
            }           
        }

        private void onKeyUpEvent(object sender, KeyEventArgs e)
        {
                      
            //space
            if(((char)e.KeyCode) == ' ' && ((char)e.KeyCode) != (char)Keys.Back)
            {
                undoList.Push(richTextBox1.Text);
                
                string word = richTextBox1.Text.Split(' ').Last();
               
                //string word = richTextBox1.Text.Substring(i + 1).TrimEnd().ToUpper().Trim();
                if(!String.IsNullOrEmpty(word))
                {
                    if(MysqlWords.words.Contains(word))
                    {                   

                        Console.WriteLine("wordIndex:");
                        int index = -1;
                        int selectStart = this.richTextBox1.SelectionStart;
                        int startIndex = 0;
                       
                            int stIndex = 0;
                            stIndex = richTextBox1.Find(word, stIndex, RichTextBoxFinds.MatchCase);
                            richTextBox1.Select(stIndex, word.Length);
                            richTextBox1.SelectionColor = Color.Aqua;
                            richTextBox1.Select(richTextBox1.TextLength, 0);
                            richTextBox1.SelectionColor = richTextBox1.ForeColor;
                            Console.WriteLine("selectStart:"+selectStart);
                            Console.WriteLine("index:"+index);
                            Console.WriteLine("startIndex:" + startIndex);

                        
                    } else if(MysqlWords.tables.Contains(word))
                    {

                    }
                }     
                           
            }
            
        }


        private string limitQuery(string query)
        {
            if (!query.ToUpper().StartsWith("SHOW"))
            {
                if (query.ToUpper().Contains("LIMIT"))
                {
                    return query;
                }
                else
                {
                    int pos = toolStripComboBox1.SelectedIndex;
                    if (pos == 0)
                    {
                        return query+" LIMIT 50";
                    }
                    if (pos == 1)
                        return query+" LIMIT 100";
                    if (pos == 2)
                        return query+" LIMIT 500";
                    if (pos == 3)
                        return query+" LIMIT 1000";
                    if (pos == 4)
                        return query+" LIMIT 5000";
                    return query;
                }
            }

            return query;
        }

        private void clearQueryField(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }


        private void unduTextClick(object sender, EventArgs e)
        {
            if(undoList.Count != 0)
            {
                string unduText = undoList.Pop();
                richTextBox1.Text = unduText;
                redoList.Push(unduText);
            }         
        }

        private void redoClick(object sender, EventArgs e)
        {
            if(redoList.Count != 0)
            {
                string content = redoList.Pop();
                richTextBox1.Text = content;
                undoList.Push(content);
            }
        }

        private void saveToExcelClick(object sender, EventArgs e)
        {

        }
    }
}
