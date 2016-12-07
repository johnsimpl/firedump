namespace Firedump.Forms.location
{
    partial class LocationSwitchboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bFileSystem = new System.Windows.Forms.Button();
            this.bFTP = new System.Windows.Forms.Button();
            this.bDropbox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bGoogleDrive = new System.Windows.Forms.Button();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.backuplocationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firedumpdbDataSet = new Firedump.firedumpdbDataSet();
            this.bAdd = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.lPath = new System.Windows.Forms.Label();
            this.bDelete = new System.Windows.Forms.Button();
            this.backup_locationsTableAdapter = new Firedump.firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            this.bEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backuplocationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bFileSystem
            // 
            this.bFileSystem.Location = new System.Drawing.Point(21, 39);
            this.bFileSystem.Name = "bFileSystem";
            this.bFileSystem.Size = new System.Drawing.Size(198, 52);
            this.bFileSystem.TabIndex = 0;
            this.bFileSystem.Text = "File System";
            this.bFileSystem.UseVisualStyleBackColor = true;
            this.bFileSystem.Click += new System.EventHandler(this.bFileSystem_Click);
            // 
            // bFTP
            // 
            this.bFTP.Location = new System.Drawing.Point(21, 116);
            this.bFTP.Name = "bFTP";
            this.bFTP.Size = new System.Drawing.Size(198, 52);
            this.bFTP.TabIndex = 1;
            this.bFTP.Text = "FTP";
            this.bFTP.UseVisualStyleBackColor = true;
            this.bFTP.Click += new System.EventHandler(this.bFTP_Click);
            // 
            // bDropbox
            // 
            this.bDropbox.Location = new System.Drawing.Point(279, 39);
            this.bDropbox.Name = "bDropbox";
            this.bDropbox.Size = new System.Drawing.Size(198, 52);
            this.bDropbox.TabIndex = 2;
            this.bDropbox.Text = "Dropbox";
            this.bDropbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bGoogleDrive);
            this.groupBox1.Controls.Add(this.bFileSystem);
            this.groupBox1.Controls.Add(this.bDropbox);
            this.groupBox1.Controls.Add(this.bFTP);
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Save Location";
            // 
            // bGoogleDrive
            // 
            this.bGoogleDrive.Location = new System.Drawing.Point(279, 116);
            this.bGoogleDrive.Name = "bGoogleDrive";
            this.bGoogleDrive.Size = new System.Drawing.Size(198, 52);
            this.bGoogleDrive.TabIndex = 3;
            this.bGoogleDrive.Text = "Google Drive";
            this.bGoogleDrive.UseVisualStyleBackColor = true;
            // 
            // cmbName
            // 
            this.cmbName.DataSource = this.backuplocationsBindingSource;
            this.cmbName.DisplayMember = "name";
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(59, 82);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(315, 21);
            this.cmbName.TabIndex = 4;
            this.cmbName.ValueMember = "id";
            this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
            // 
            // backuplocationsBindingSource
            // 
            this.backuplocationsBindingSource.DataMember = "backup_locations";
            this.backuplocationsBindingSource.DataSource = this.firedumpdbDataSet;
            // 
            // firedumpdbDataSet
            // 
            this.firedumpdbDataSet.DataSetName = "firedumpdbDataSet";
            this.firedumpdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(398, 80);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add ";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(59, 140);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(315, 20);
            this.tbPath.TabIndex = 6;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 85);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 13);
            this.lName.TabIndex = 7;
            this.lName.Text = "Name:";
            // 
            // lPath
            // 
            this.lPath.AutoSize = true;
            this.lPath.Location = new System.Drawing.Point(12, 143);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(32, 13);
            this.lPath.TabIndex = 8;
            this.lPath.Text = "Path:";
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(15, 191);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(140, 23);
            this.bDelete.TabIndex = 9;
            this.bDelete.Text = "Delete Save Location";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // backup_locationsTableAdapter
            // 
            this.backup_locationsTableAdapter.ClearBeforeFill = true;
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(234, 191);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(140, 23);
            this.bEdit.TabIndex = 10;
            this.bEdit.Text = "Edit Save Location";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // LocationSwitchboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 466);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.lPath);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.groupBox1);
            this.Name = "LocationSwitchboard";
            this.Text = "Add Location";
            this.Load += new System.EventHandler(this.LocationSwitchboard_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backuplocationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bFileSystem;
        private System.Windows.Forms.Button bFTP;
        private System.Windows.Forms.Button bDropbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bGoogleDrive;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lPath;
        private System.Windows.Forms.Button bDelete;
        private firedumpdbDataSet firedumpdbDataSet;
        private System.Windows.Forms.BindingSource backuplocationsBindingSource;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_locationsTableAdapter;
        private System.Windows.Forms.Button bEdit;
    }
}