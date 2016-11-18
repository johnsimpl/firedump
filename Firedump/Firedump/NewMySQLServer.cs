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
    public partial class NewMySQLServer : Form
    {
        public NewMySQLServer()
        {
            InitializeComponent();
        }

        private void bTestConnection_Click(object sender, EventArgs e)
        {
            DbConnection con = new DbConnection();

            //port
            if (!string.IsNullOrEmpty(tbPort.Text))
            {
                try
                {
                    int port = int.Parse(tbPort.Text);
                    if (port < 1 || port > 65535)
                    {
                        MessageBox.Show(tbPort.Text + " is not a valid port number", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    con.port = port;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(tbPort.Text + " is not a valid port number", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //host
            if (!string.IsNullOrEmpty(tbHost.Text))
            {
                con.Host = tbHost.Text;
            }
            else
            {
                MessageBox.Show("Hostname is empty.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //username
            if (!string.IsNullOrEmpty(tbUsername.Text))
            {
                con.username = tbUsername.Text;
            }
            else
            {
                MessageBox.Show("Username is empty.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //password
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                con.password = tbPassword.Text;
            }

            //test connection
            if (con.testConnection())
            {
                MessageBox.Show("Connection Successful", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection failed", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            firedumpdbDataSetTableAdapters.mysql_serversTableAdapter adapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
