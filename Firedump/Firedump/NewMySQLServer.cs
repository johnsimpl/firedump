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
    public partial class NewMySQLServer : Form
    {
        DbConnection con = new DbConnection();
        public NewMySQLServer()
        {
            InitializeComponent();
            
        }

        private void bTestConnection_Click(object sender, EventArgs e)
        {

            if (!performChecks())
            {
                return;
            }

            //test connection
            ConnectionResultSet result = con.testConnection();
            if (result.wasSuccessful)
            {
                MessageBox.Show("Connection Successful", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection failed: \n"+result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean performChecks()
        {
            //port
            if (!string.IsNullOrEmpty(tbPort.Text))
            {
                try
                {
                    int port = int.Parse(tbPort.Text);
                    if (port < 1 || port > 65535)
                    {
                        MessageBox.Show(tbPort.Text + " is not a valid port number", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    con.port = port;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(tbPort.Text + " is not a valid port number", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
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
                return false;
            }
            //username
            if (!string.IsNullOrEmpty(tbUsername.Text))
            {
                con.username = tbUsername.Text;
            }
            else
            {
                MessageBox.Show("Username is empty.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //password
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                con.password = tbPassword.Text;
            }
            //database
            if (!string.IsNullOrEmpty(tbDatabase.Text))
            {
                con.database = tbDatabase.Text;
            }

            return true;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            firedumpdbDataSetTableAdapters.mysql_serversTableAdapter adapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Type a name for the new server", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((Int64)adapter.numberOfOccurances(tbName.Text) == 0)
            {
                if(!performChecks())
                {
                    return;
                }

                adapter.Insert(tbName.Text, con.port, con.Host, con.username, tbPassword.Text); //prepei na bei kai database
                this.Close();
                return;
            }
            MessageBox.Show("Name "+tbName.Text+ " already exists", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
