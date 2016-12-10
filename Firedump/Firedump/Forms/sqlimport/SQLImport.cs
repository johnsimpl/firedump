using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.sqlimport
{
    public partial class SQLImport : Form
    {
        public SQLImport()
        {
            InitializeComponent();
        }

        private void SQLImport_Load(object sender, EventArgs e)
        {
            linfo.Text = "If the file is compressed it must contain\na .sql file with the same name for example\nthefile.7z must contain thefile.sql";

            // TODO: This line of code loads data into the 'firedumpdbDataSet.backup_locations' table. You can move, or remove it, as needed.
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            // TODO: This line of code loads data into the 'firedumpdbDataSet.mysql_servers' table. You can move, or remove it, as needed.
            this.mysql_serversTableAdapter.Fill(this.firedumpdbDataSet.mysql_servers);

        }
    }
}
