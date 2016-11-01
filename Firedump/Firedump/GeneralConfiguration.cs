using Firedump.models.configuration.jsonconfig;
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
    public partial class GeneralConfiguration : Form
    {
        public GeneralConfiguration()
        {
            InitializeComponent();
        }

        private void GeneralConfiguration_Load(object sender, EventArgs e)
        {
            setupFormComponents();
        }

        private void setupFormComponents()
        {
            ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();

            //Folder Options
            tbTempFolder.Text = configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath;
            tbLogFolder.Text = ""; //not implemented yet

            //SQL Dump Options
            cbCreateSchema.Checked = configurationManagerInstance.mysqlDumpConfigInstance.includeCreateSchema;
            cbDumpData.Checked = configurationManagerInstance.mysqlDumpConfigInstance.includeData;
            cbEvents.Checked = configurationManagerInstance.mysqlDumpConfigInstance.dumpEvents;
            cbTriggers.Checked = configurationManagerInstance.mysqlDumpConfigInstance.dumpTriggers;
            cbProcsFuncs.Checked = configurationManagerInstance.mysqlDumpConfigInstance.addCreateProcedureFunction;
            cbSingleFile.Checked = true; //not implemented yet

            //Compression settings
            cbEnableComp.Checked = configurationManagerInstance.compressConfigInstance.enableCompression;
            /// 0 - -t7z : file.7z
            /// 1 - -tgzip : file.gzip
            /// 2 - -tzip : file.zip
            /// 3 - -tbzip2 : file.bzip2
            /// 4 - -ttar : file.tar (UNIX and LINUX)
            /// 5 - -tiso : file.iso
            /// 6 - -tudf : file.udf
            cmbFileFormat.DataSource = new string[] { ".7z", ".gzip", ".zip", ".bzip2", ".tar", ".iso", ".udf" };
            cmbFileFormat.SelectedIndex = configurationManagerInstance.compressConfigInstance.fileType;
            /// 0 - -mx1 : Low compression faster proccess
            /// 1 - -mx3 : Fast compression mode
            /// 2 - -mx5 : Normal compression mode
            /// 3 - -mx7 : Maximum compression mode
            /// 4 - -mx9 : Ultra compression mode
            cmbCompressionLevel.DataSource = new string[] { "Fastest", "Fast", "Normal", "Maximum", "Ultra" };
            cmbCompressionLevel.SelectedIndex = configurationManagerInstance.compressConfigInstance.compressionLevel;
            cbUseMultithreading.Checked = configurationManagerInstance.compressConfigInstance.useMultithreading;
            cbEnablePasswordEncryption.Checked = !string.IsNullOrEmpty(configurationManagerInstance.compressConfigInstance.password);
            cbEncryptHeader.Checked = configurationManagerInstance.compressConfigInstance.encryptHeader;
            if (cbEnablePasswordEncryption.Checked)
            {
                tbPass.Text = configurationManagerInstance.compressConfigInstance.password;
                tbConfirmPass.Text = configurationManagerInstance.compressConfigInstance.password;
            }
            if (!cbEnableComp.Checked)
            {
                disableCompression();
            }
            if (!cbEnablePasswordEncryption.Checked)
            {
                disableEnryption();
            }
        }

        private void disableCompression()
        {
            lbFileFormat.Enabled = false;
            lbCompressionLevel.Enabled = false;
            cmbFileFormat.Enabled = false;
            cmbCompressionLevel.Enabled = false;
            cbUseMultithreading.Enabled = false;
            gbEncryption.Enabled = false;
        }

        private void disableEnryption()
        {
            cbEncryptHeader.Enabled = false;
            lbPass.Enabled = false;
            lbConfirmPass.Enabled = false;
            tbPass.Enabled = false;
            tbConfirmPass.Enabled = false;
        }
    }
}
