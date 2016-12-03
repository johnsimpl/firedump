using Firedump.models.location;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class FileSystem : Form
    {
        LocationSwitchboard locswitch;
        public FileSystem(LocationSwitchboard locswitch)
        {
            InitializeComponent();
            this.locswitch = locswitch;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please enter a valid name for the enw file location","New file system location",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                Path.IsPathRooted(tbPath.Text);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("Please choose a valid folder path", "New file system location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            if ((Int64)adapter.numberOfOccurances(tbName.Text) != 0)
            {
                MessageBox.Show("A save location with this name already exists", "New file system location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adapter.Insert(tbName.Text,"","",tbPath.Text,"",0,0,"","","","","","","",0,0,"","");
            locswitch.reloadDataset(); //callback stin klasi pou to kalese na kanei refresh to combobox
            this.Close();

        }

        private void bPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            cofd.InitialDirectory = tbPath.Text;
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string newPath = cofd.FileName;
                tbPath.Text = newPath + "\\";
            }
        }
    }
}
