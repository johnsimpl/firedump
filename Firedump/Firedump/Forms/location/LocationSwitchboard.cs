using Firedump.models.location;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class LocationSwitchboard : Form
    {
        private Home homeinstance;
        public LocationSwitchboard(Home homeinstance)
        {
            InitializeComponent();
            this.homeinstance = homeinstance;
        }

        private void bFileSystem_Click(object sender, EventArgs e)
        {
            FileSystem fs = new FileSystem(this);
            fs.ShowDialog();
        }

        public void reloadDataset()
        {
            /*
            backuplocationsBindingSource.DataSource = firedumpdbDataSet.backup_locations;
            backuplocationsBindingSource.ResetBindings(false);
            /*
            backuplocationsBindingSource.ResetBindings(false);
            cmbName.DataSource = backuplocationsBindingSource;
            cmbName.DataSource = backuplocationsBindingSource;
            cmbName.Refresh();*/ //mou evgale ti pisti mexri na vrw pws ginete ...
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            try
            {
                cmbName.SelectedIndex = cmbName.Items.Count - 1;
            }
            catch (Exception ex)
            {

            }
        }

        private void reloadPath()
        {
            if (cmbName.Items.Count == 0 || cmbName.SelectedIndex == -1)
            {
                return;
            }
            tbPath.Text = (string)firedumpdbDataSet.backup_locations.Rows.Find((Int64)cmbName.SelectedValue)["path"];
        }

        private void LocationSwitchboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'firedumpdbDataSet.backup_locations' table. You can move, or remove it, as needed.
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            // TODO: This line of code loads data into the 'firedumpdbDataSet.backup_locations' table. You can move, or remove it, as needed.
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            if (cmbName.Items.Count != 0)
            {
                cmbName.SelectedIndex = 0;
            }
            reloadPath();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if(cmbName.Items.Count==0 || cmbName.SelectedIndex == -1)
            {
                return;
            }

            BackupLocation loc = new BackupLocation();
            loc.id = unchecked((int)(Int64)cmbName.SelectedValue);

            this.backup_locationsTableAdapter.DeleteQuery((Int64)cmbName.SelectedValue);
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);

            homeinstance.deleteSaveLocation(loc); //kanei delete kai apo to listbox sto home an tixon auto to location exei ginei eidh add
            reloadPath();
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadPath();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (cmbName.Items.Count == 0 || cmbName.SelectedIndex == -1)
            {
                MessageBox.Show("There are no save locations. Please create a new save location and try again.", "Add save location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine(cmbName.SelectedValue);
            BackupLocation loc = new BackupLocation();
            loc.id = unchecked((int)(Int64)cmbName.SelectedValue);
            loc.path = tbPath.Text;
            firedumpdbDataSet.backup_locationsRow backloc = backup_locationsTableAdapter.GetDataByID(loc.id)[0];
            loc.Tag = backloc;
            homeinstance.addToLbSaveLocation(loc);           
        }

        private void bFTP_Click(object sender, EventArgs e)
        {
            FTPLocation ftploc = new FTPLocation(this);
            ftploc.ShowDialog();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if(cmbName.Items.Count == 0)
            {
                MessageBox.Show("No save locations to edit. Add a new save location.","Edit save location",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            DataRow row = ((DataRowView)cmbName.Items[cmbName.SelectedIndex]).Row;
            Int64 service_type = (Int64)row["service_type"];
            switch (service_type)
            {
                case 0: //local
                    FileSystem fs = new FileSystem(this, true, row);
                    fs.ShowDialog();
                    break;
                case 1: //ftp
                    FTPLocation ftploc = new FTPLocation(this, true, row);
                    ftploc.ShowDialog();
                    break;
                case 2: //dropbox
                    break;
                case 3: //google drive
                    break;
                default: //error
                    MessageBox.Show("Unknown location service type", "Edit save location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }
    }
}
