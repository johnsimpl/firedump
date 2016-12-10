using Firedump.models.databaseUtils;
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
    public partial class ImportSQL : Form
    {
        private Task<List<string>> reloadDatabasesTask;
        private List<string> databases = new List<string>();
        public ImportSQL()
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

            cbEncryptedFile_CheckedChanged(null, null);
            cmbDatabases.DataSource = databases;
            cmbServers_SelectedIndexChanged(null, null);
        }

        private bool performChecks()
        {
            //checks before import here
            return true;
        }

        private void bChoosePathSv_Click(object sender, EventArgs e)
        {
            //EDW THA TRAVAEI TO ARXEIO APO OPOIODHPOTE LOCATION
        }

        private void bChoosePathFs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //.sql .7z .rar .gzip .zip .bzip2 .tar .iso .udf
            ofd.Filter = "All allowed types|*.sql;*.7z;*.rar;*.gzip;*.zip;*.bzip2;*.tar;*.iso;*.udf|"+
                "SQL files|*.sql|7z files|*.7z|Rar files|*.rar|Gzip files|*.gzip|Zip files|*.zip|Bzip2 files|*.bzip2|Tar files|*.tar|Iso files|*.iso|Udf files|*.udf";
            DialogResult res = ofd.ShowDialog();
            if(res == DialogResult.OK)
            {
                tbFilePathSv.Text = "";
                tbFilePathFs.Text = ofd.FileName;
            }
        }

        private void cbEncryptedFile_CheckedChanged(object sender, EventArgs e)
        {
            enableORDisablePasswords(cbEncryptedFile.Checked);
        }

        private void enableORDisablePasswords(bool action)
        {
            lPass.Enabled = action;
            lConfirmPass.Enabled = action;
            lPassHelp.Enabled = action;
            tbPass.Enabled = action;
            tbConfirmPass.Enabled = action;
        }

        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServers.Items.Count == 0) return;

            Task task = new Task(reloadDatabasesCombobox);
            task.Start();
        }

        private async void reloadDatabasesCombobox()
        {
            try
            {
                databases.Clear();

                if(reloadDatabasesTask != null && !reloadDatabasesTask.IsCompleted)
                {
                    reloadDatabasesTask.Wait();
                }

                int selectedindex = 0;
                cmbServers.Invoke((MethodInvoker)delegate () {
                    selectedindex = cmbServers.SelectedIndex;
                });

                DbConnection con = new DbConnection();
                DataRow row = firedumpdbDataSet.mysql_servers.Rows[selectedindex];
                con.Host = (string)row["host"];
                con.port = unchecked((int)(Int64)row["port"]);
                con.username = (string)row["username"];
                con.password = (string)row["password"];
                try
                {
                    con.database = (string)row["database"];
                }
                catch(Exception ex) { }
                databases = new List<string>();
                databases.Add("none");

                if (!string.IsNullOrWhiteSpace(con.database))
                {
                    cmbDatabases.Invoke((MethodInvoker)delegate () {
                        cmbDatabases.DataSource = databases;
                    });
                    return;
                }

                reloadDatabasesTask = new Task<List<string>>(con.getDatabases);
                reloadDatabasesTask.Start();
                
                List<string> tempdbs = await reloadDatabasesTask;
                
                if (!cbShowSysDb.Checked)
                {
                    tempdbs.Remove("mysql");
                    tempdbs.Remove("information_schema");
                    tempdbs.Remove("performance_schema");
                }

                foreach (string database in tempdbs)
                {
                    databases.Add(database);
                }
                cmbDatabases.Invoke((MethodInvoker)delegate () {
                    cmbDatabases.DataSource = databases;
                });

            }
            catch (Exception ex)
            {
                if (cmbServers.IsDisposed) return; //sto kleisimo tou form erxetai edw den exw idea giati
                DialogResult res = MessageBox.Show("Databases load failed:\n"+ex.Message,"Databases load",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                if(res == DialogResult.Retry)
                {
                    cmbServers.Invoke((MethodInvoker)delegate () {
                        cmbServers_SelectedIndexChanged(null, null);
                    });                   
                }
            }

        }

        private void tbConfirmPass_Leave(object sender, EventArgs e)
        {
            if (tbPass.Text != tbConfirmPass.Text) { lPassHelp.Visible = true; } else { lPassHelp.Visible = false; }
        }

        private void bStartImport_Click(object sender, EventArgs e)
        {
            if (!performChecks()) return;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {

        }

        private void cbShowSysDb_CheckedChanged(object sender, EventArgs e)
        {
            cmbServers_SelectedIndexChanged(null,null);
        }
    }
}
