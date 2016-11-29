using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.mysql.sqlviewer
{
    public partial class tempform : Form
    {
        public tempform()
        {
            InitializeComponent();
        }

        private void sqlviewerclick(object sender, EventArgs e)
        {
            
            mysql_servers server = new mysql_servers();
            server.host = tbhostname.Text;
            server.username = tbusername.Text;
            server.password = tbpassword.Text;

            string database = tbdatabase.Text;
            SqlDbViewerForm form = new SqlDbViewerForm(server, database);
            form.Show();
            
        }


    }
}
