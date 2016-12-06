using Firedump.models.configuration.dynamicconfig;
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
using WinSCP;

namespace Firedump.Forms.location
{
    public partial class FTPDirectory : Form
    {
        public string path { set; get; }
        public bool isDirectory { get; set; }
        private bool isFolderPicker;
        private FTPCredentialsConfig credentials;
        private FTPUtils ftpUtils;
        private bool showHidenFiles;
        private bool onlyDirectories;
        private string previousPath = "/";

        private List<RemoteFileInfo> remoteFileInfoList;

        public FTPDirectory(bool isFolderPicker, FTPCredentialsConfig ftpcreds)
        {
            InitializeComponent();
            this.isFolderPicker = isFolderPicker;
            this.credentials = ftpcreds;

            ftpUtils = new FTPUtils(ftpcreds);
            
            ftpUtils.startSession();

            if (!String.IsNullOrEmpty(path))
            {
                remoteFileInfoList = ftpUtils.getDirectoryListing(path, true, false);
                previousPath = path;
            }    
            else
            {
                remoteFileInfoList = ftpUtils.getDirectoryListing("/", true, false);
            }

            listView1.Items.Add("..");
            foreach(RemoteFileInfo file in remoteFileInfoList)
            {               
                ListViewItem item = new ListViewItem();
                item.Text = file.FullName;
                item.Tag = file.IsDirectory; 
                listView1.Items.Add(item);
            }
            
        }


        private void setDirectoryList(string path)
        {
            listView1.Items.Clear();
            listView1.Items.Add("..");
            remoteFileInfoList = ftpUtils.getDirectoryListing(path, onlyDirectories, showHidenFiles);
            foreach (RemoteFileInfo file in remoteFileInfoList)
            {
                ListViewItem item = new ListViewItem();
                item.Text = file.FullName;
                item.Tag = file.IsDirectory;
                listView1.Items.Add(item);
            }
        }


        private void cbShowFolders_CheckedChanged(object sender, EventArgs e)
        {
            onlyDirectories = cbShowFolders.Checked;
        }

        private void cbshowHidenFiles_CheckedChanged(object sender, EventArgs e)
        {
            showHidenFiles = cbshowHidenFiles.Checked;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            path = listView1.SelectedItems[0].Text;
            isDirectory = (bool)listView1.SelectedItems[0].Tag;
            lpath.Text = path;
            if(isDirectory)
            {
                if (!(listView1.SelectedItems[0].Text == ".."))
                {
                    previousPath = listView1.SelectedItems[0].Text;
                    setDirectoryList(listView1.SelectedItems[0].Text);
                }
                else
                {
                    try
                    {
                        if (previousPath.Split('/').Length != 2)
                        {
                            previousPath = previousPath.Substring(0, previousPath.LastIndexOf('/'));
                            Console.WriteLine(previousPath);
                            setDirectoryList(previousPath);
                        }
                        else
                        {
                            setDirectoryList("/");
                        }

                    }
                    catch (ArgumentOutOfRangeException ex)
                    {

                    }

                }
            } else
            {
                //An ginei double click panw se file
                //btusepath_Click(null,null)
            }

        }



        private void FTPDirectory_FormClosed(object sender, FormClosedEventArgs e)
        {
            ftpUtils.disposeSession();
        }

        private void btusepath_Click(object sender, EventArgs e)
        {
            path = listView1.SelectedItems[0].Text;
            isDirectory = (bool)listView1.SelectedItems[0].Tag;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
