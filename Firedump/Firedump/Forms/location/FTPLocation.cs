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

namespace Firedump.Forms.location
{
    public partial class FTPLocation : Form,ILocationListener
    {
        private LocationSwitchboard listener;
        private LocationAdapter adapter;
        private string sshKeyFingerprint;
        public DataRow ftplocation { set; get; }
        bool testConnectionSucceded = false;
        public bool isEditor { set; get; }
        public bool doLoadConfig { set; get; }
        private FTPLocation(){}

        public FTPLocation(LocationSwitchboard listener)
        {
            InitializeComponent();
            this.listener = listener;
            adapter = new LocationAdapter(this);
        }
        /// <summary>
        /// Call this constructor to load FTPconfig into the components
        /// </summary>
        /// <param name="listener">The Location switchboard instance</param>
        /// <param name="isEditor">If true on save it will try to update the save location when Save is clicked else it will try to insert</param>
        /// <param name="ftplocation">DataRow from backup_locations table that contains the ftp location to load</param>
        public FTPLocation(LocationSwitchboard listener, bool isEditor, DataRow ftplocation)
        {
            InitializeComponent();
            this.listener = listener;
            this.isEditor = isEditor;
            this.ftplocation = ftplocation;
            doLoadConfig = true;
            adapter = new LocationAdapter(this);
        }

        private bool performChecks()
        {
            //Checks here
            return true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e) //na eleksw ama egine i testconnection to fingerprint
        {

        }

        private void bPrivateKeyPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Private Key Files|*.ppk";
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                tbPrivateKey.Text = ofd.FileName;
            }
        }

        private void bPathOnServer_Click(object sender, EventArgs e)
        {
            //EDW LAUNCH TO FORM POU THA DIALEGEIS PATH APO FTP
        }

        private void cbPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            enableOrDisablePrivateKey(cbPrivateKey.Checked);
        }

        private void FTPLocation_Load(object sender, EventArgs e)
        {
            //Init Compronents
            cmbProtocol.DataSource = new string[] { "SFTP", "FTP"};
            setPort();
            enableOrDisablePrivateKey(cbPrivateKey.Checked);

            if (!doLoadConfig) return;

            //EDW LOAD TO CONFIG STA COMPONENTS
            if (ftplocation == null)
            {
                Console.WriteLine("FTPLocation: ftplocation not set cannot load config!");
                return;
            }
            tbName.Text = (string)ftplocation["name"];
            Int64 usesftp = (Int64)ftplocation[""];
        }

        private void enableOrDisablePrivateKey(bool action)
        {
            lbPrivateKey.Enabled = action;
            tbPrivateKey.Enabled = action;
            bPrivateKeyPath.Enabled = action;
        }

        private void setPort()
        {
            if (string.IsNullOrWhiteSpace(tbPort.Text))
            {
                switch (cmbProtocol.SelectedIndex)
                {
                    case 0:
                        tbPort.Text = "22";
                        break;
                    case 1:
                        tbPort.Text = "21";
                        break;
                    default:
                        tbPort.Text = "21";
                        break;
                }
            }
        }

        private void cmbProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPort();
        }

        private void bTestConnection_Click(object sender, EventArgs e)
        {
            if (!performChecks())
                return;
            FTPCredentialsConfig config = new FTPCredentialsConfig();
            //Fill  to config apo ti forma edw 
            adapter.setFtpLocation(config);
            adapter.testConnection();
        }

        public void setSaveProgress(int progress)
        {
            throw new NotImplementedException();
        }

        public void onSaveInit()
        {
            throw new NotImplementedException();
        }

        public void onSaveComplete(LocationResultSet result)
        {
            throw new NotImplementedException();
        }

        public void onSaveError(string message)
        {
            MessageBox.Show(message, "FTP test connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public void onTestConnectionComplete(LocationConnectionResultSet result)
        {
            if (result.wasSuccessful)
            {
                sshKeyFingerprint = result.sshHostKeyFingerprint;
                testConnectionSucceded = true;
                MessageBox.Show("Connection successful!","FTP test connection",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection failed:\n"+result.errorMessage, "FTP test connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
