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

        //default
        private bool showHidenFiles = false;
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
                remoteFileInfoList = ftpUtils.getDirectoryListing(path, isFolderPicker, false);
                previousPath = path;
            }    
            else
            {
                remoteFileInfoList = ftpUtils.getDirectoryListing("/", isFolderPicker, false);
            }
            ListViewItem headItem = new ListViewItem();
            FileInfo finfo = new FileInfo();
            finfo.FullName = "..";
            finfo.Name = "..";
            finfo.IsDirectory = true;
            headItem.Text = "..";
            headItem.Tag = finfo;
            listView1.Items.Add(headItem);
            foreach(RemoteFileInfo file in remoteFileInfoList)
            {               
                ListViewItem item = new ListViewItem();
                
                FileInfo fileinfo = new FileInfo();
                fileinfo.IsDirectory = file.IsDirectory;
                fileinfo.Persmissions = file.FilePermissions.Text;
                fileinfo.FullName = file.FullName;
                fileinfo.Type = file.FileType;
                fileinfo.Owner = file.Owner;
                fileinfo.Name = file.Name;
                fileinfo.Owner = file.Owner;
                fileinfo.Group = file.Group;
                item.Tag = fileinfo;
                item.Text = fileinfo.ToString(); 
                listView1.Items.Add(item);
            }


            tbpath.Text = previousPath;
        }


        private void setDirectoryList(string path)
        {
            listView1.Items.Clear();
            ListViewItem headItem = new ListViewItem();
            FileInfo finfo = new FileInfo();
            finfo.FullName = "..";
            finfo.Name = "..";
            finfo.IsDirectory = true;
            finfo.Persmissions = "";
            headItem.Text = "..";
            headItem.Tag = finfo;         
            listView1.Items.Add(headItem);
            remoteFileInfoList = ftpUtils.getDirectoryListing(path, isFolderPicker, showHidenFiles);
            foreach (RemoteFileInfo file in remoteFileInfoList)
            {
                ListViewItem item = new ListViewItem();
                FileInfo fileinfo = new FileInfo();              
                fileinfo.IsDirectory = file.IsDirectory;
                fileinfo.Persmissions = file.FilePermissions.Text;
                fileinfo.FullName = file.FullName;
                fileinfo.Type = file.FileType;
                fileinfo.Owner = file.Owner;
                fileinfo.Name = file.Name;
                fileinfo.Owner = file.Owner;
                fileinfo.Group = file.Group;

                item.Text = fileinfo.ToString();
                item.Tag = fileinfo;
                listView1.Items.Add(item);
            }
        }

        

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            path = ((FileInfo)listView1.SelectedItems[0].Tag).FullName;
            FileInfo fileinfo = (FileInfo)listView1.SelectedItems[0].Tag;
            isDirectory = fileinfo.IsDirectory;

            if(isDirectory)
            {
                tbpath.Text = path;
                if (!(((FileInfo)listView1.SelectedItems[0].Tag).FullName == ".."))
                {
                    previousPath = ((FileInfo)listView1.SelectedItems[0].Tag).FullName;
                    setDirectoryList(((FileInfo)listView1.SelectedItems[0].Tag).FullName);
                }
                else
                {
                    bgoBack_Click(null, null);
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
            try
            {
                path = ((FileInfo)listView1.SelectedItems[0].Tag).FullName;
                FileInfo fileinfo = (FileInfo)listView1.SelectedItems[0].Tag;
                isDirectory = fileinfo.IsDirectory;
            }
            catch(ArgumentOutOfRangeException ex)
            {
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }


        private void bgoBack_Click(object sender, EventArgs e)
        {
            try
            {
                //check if we are in root
                if (previousPath.Split('/').Length > 2)
                {
                    previousPath = previousPath.Substring(0, previousPath.LastIndexOf('/'));
                    Console.WriteLine(previousPath);
                    setDirectoryList(previousPath);
                    tbpath.Text = previousPath;
                }
                else
                {
                    previousPath = "/";
                    setDirectoryList("/");
                    tbpath.Text = previousPath;
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }


        class FileInfo
        {
            public FileInfo() { }

            public string Name { get; set; }

            public string FullName { get; set; }

            public bool IsDirectory { get; set; }

            public char Type { get; set; } 

            public string Persmissions { get; set; }

            public string Owner { get; set; }

            public string Group { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Type.ToString()+" "+Persmissions+"    " +Name+"   "+Owner;
            }
        }


        

    }
}
