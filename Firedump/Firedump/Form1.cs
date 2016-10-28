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

namespace Firedump
{
    public partial class Form1 : Form
    {
        private string savepath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FiredumpContext f = new FiredumpContext();
            List<mysql_servers> s = f.getAllMySqlServers();
            //string newdpath = Environment.GetFolderPath(Environment.SpecialFolder.Da);
            Console.WriteLine(s.Count);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            Console.WriteLine("yo");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe"));*/
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
    }
}
