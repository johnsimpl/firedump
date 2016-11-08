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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bDumpForm_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
        }

        private void bTest1_Click(object sender, EventArgs e)
        {
            Form form1 = new Test1();
            form1.Show();
        }

        private void bGenConfig_Click(object sender, EventArgs e)
        {
            Form form = new GeneralConfiguration();
            form.Show();
        }

        private void email_click(object sender, EventArgs e)
        {
            Form form = new email();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mysql_servers server = new mysql_servers();
            server.host = "localhost";
            server.username = "user";
            server.password = "password";

            string database = "wall";
            sqlviewer.SqlDbViewerForm form = new sqlviewer.SqlDbViewerForm(server, database);
            form.Show();
        }
    }
}
