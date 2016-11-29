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

namespace Firedump.status
{
    public partial class AnalyzeDbForm : Form
    {
        
        private mysql_servers server;
        private string database;
        private List<MyTable> tables;
        public AnalyzeDbForm(mysql_servers server,string database)
        {
            InitializeComponent();
            this.server = server;
            this.database = database;
            setInfoTab(database);

            setTableNamesTab();
            setColumnNamesTab();

        }



        private void setInfoTab(string database)
        {
            label1.Text += ": " + database;

            DbConnection con = DbConnection.Instance();
            con.username = server.username;
            con.password = server.password;
            con.Host = server.host;
            con.database = database;

            if (con.testConnection().wasSuccessful)
            {
                List<string> t = con.getTables(database);
                tables = new List<MyTable>();
                for(int i =0; i < t.Count; i++)
                {
                    tables.Add(new MyTable(t[i]));
                }
                int tablesCount = tables.Count;
                label5.Text += " " + tablesCount;
                string connectionString = DbConnection.conStringBuilder(server.host, server.username, server.password, database);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    //database size in mb
                    connection.Open();
                    string sql = "SELECT table_schema " + database +
                       " , SUM(data_length + index_length)  / (1024 * 1024) " +
                       "FROM   information_schema.tables " +
                       "GROUP  BY table_schema; ";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        try
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.GetString(database) == database)
                                    {
                                        int size = reader.GetInt32("SUM(data_length + index_length)  / (1024 * 1024)");
                                        label6.Text += " " +size + " MB";
                                        break;
                                    }
                                }
                            }
                        }catch(MySqlException ex)
                        {
                            //handle exception
                        }
                        
                    }

                    //get default database charset
                    sql = "SELECT @@character_set_database, @@collation_database;";
                    using (MySqlCommand command = new MySqlCommand(sql,connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                string charset = reader.GetString("@@character_set_database");
                                label4.Text += " " + charset;
                                string collation = reader.GetString("@@collation_database");
                                label3.Text += " " + collation;
                            }
                        }
                    }

                    
                }
            }
           
        }

        private void setTableNamesTab()
        {
            datagridviewTables.DataSource = tables.Select(x => new { Value = x }).ToList();
        }

        private void setColumnNamesTab()
        {
            List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
            foreach(MyTable table in tables)
            {
                string connectionString = DbConnection.conStringBuilder(server.host, server.username, server.password, database);
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "DESCRIBE " + table.TableName;
                    using (MySqlCommand command = new MySqlCommand(sql,con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ColumnInfo col = new ColumnInfo();
                                string Field = reader.GetString("Field");
                                string Type = reader.GetString("Type");
                                string isNull = reader.GetString("Null");

                                col.Table = table.TableName;
                                col.Default = "";
                                col.Type = Type;
                                col.Field = Field;
                                col.IsNullable = isNull;
                                columnInfoList.Add(col);
                            }
                        }
                    }
                }

                datagridviewColumns.DataSource = columnInfoList;

            }
        }



        private static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }


        class MyTable
        {
            public MyTable() { }
            public MyTable(string t)
            {
                this.TableName = t;
            }
            public string TableName { get; set; }

            public override string ToString()
            {
                return TableName;
            }
        }


        class ColumnInfo
        {
            public ColumnInfo()
            {

            }

            public string Table { get; set; }

            public string Field { get; set; }

            public string Type { get; set; }

            public string IsNullable  {get;set;}

            public string Default { get; set; }

        }

    }
}
