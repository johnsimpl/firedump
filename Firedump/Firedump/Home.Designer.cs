namespace Firedump
{
    partial class Home
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
            this.bAddServer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.tvDatabases = new System.Windows.Forms.TreeView();
            this.bDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.gbDestinations = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bStartDump = new System.Windows.Forms.Button();
            this.pbDumpExec = new System.Windows.Forms.ProgressBar();
            this.lStatusLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ltable = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.bcancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbConnection.SuspendLayout();
            this.gbDestinations.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAddServer
            // 
            this.bAddServer.Location = new System.Drawing.Point(6, 36);
            this.bAddServer.Name = "bAddServer";
            this.bAddServer.Size = new System.Drawing.Size(124, 23);
            this.bAddServer.TabIndex = 0;
            this.bAddServer.TabStop = false;
            this.bAddServer.Text = "Add New Server";
            this.bAddServer.UseVisualStyleBackColor = true;
            this.bAddServer.Click += new System.EventHandler(this.bAddServer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Destination";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btAddDestClick);
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.tvDatabases);
            this.gbConnection.Controls.Add(this.bDelete);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.cmbServers);
            this.gbConnection.Controls.Add(this.bAddServer);
            this.gbConnection.Location = new System.Drawing.Point(12, 37);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(285, 402);
            this.gbConnection.TabIndex = 2;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            this.gbConnection.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tvDatabases
            // 
            this.tvDatabases.CheckBoxes = true;
            this.tvDatabases.Location = new System.Drawing.Point(6, 92);
            this.tvDatabases.Name = "tvDatabases";
            this.tvDatabases.Size = new System.Drawing.Size(273, 299);
            this.tvDatabases.TabIndex = 4;
            this.tvDatabases.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabases_AfterCheck);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(148, 36);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(131, 23);
            this.bDelete.TabIndex = 3;
            this.bDelete.Text = "Delete Server";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Not connected";
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(6, 65);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(273, 21);
            this.cmbServers.TabIndex = 1;
            this.cmbServers.SelectionChangeCommitted += new System.EventHandler(this.cmbServers_SelectionChangeCommitted);
            // 
            // gbDestinations
            // 
            this.gbDestinations.Controls.Add(this.button1);
            this.gbDestinations.Location = new System.Drawing.Point(420, 37);
            this.gbDestinations.Name = "gbDestinations";
            this.gbDestinations.Size = new System.Drawing.Size(279, 172);
            this.gbDestinations.TabIndex = 0;
            this.gbDestinations.TabStop = false;
            this.gbDestinations.Text = "Destinations";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfiguration});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // miConfiguration
            // 
            this.miConfiguration.Name = "miConfiguration";
            this.miConfiguration.Size = new System.Drawing.Size(157, 22);
            this.miConfiguration.Text = "Configuration...";
            this.miConfiguration.Click += new System.EventHandler(this.miConfiguration_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // bStartDump
            // 
            this.bStartDump.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bStartDump.Location = new System.Drawing.Point(303, 386);
            this.bStartDump.Name = "bStartDump";
            this.bStartDump.Size = new System.Drawing.Size(174, 53);
            this.bStartDump.TabIndex = 5;
            this.bStartDump.Text = "Start Dump";
            this.bStartDump.UseVisualStyleBackColor = true;
            this.bStartDump.Click += new System.EventHandler(this.bStartDump_Click);
            // 
            // pbDumpExec
            // 
            this.pbDumpExec.Location = new System.Drawing.Point(18, 470);
            this.pbDumpExec.Name = "pbDumpExec";
            this.pbDumpExec.Size = new System.Drawing.Size(681, 23);
            this.pbDumpExec.TabIndex = 6;
            // 
            // lStatusLabel
            // 
            this.lStatusLabel.AutoSize = true;
            this.lStatusLabel.Location = new System.Drawing.Point(20, 442);
            this.lStatusLabel.Name = "lStatusLabel";
            this.lStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.lStatusLabel.TabIndex = 7;
            this.lStatusLabel.Text = "Status:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.treeview_work);
            // 
            // ltable
            // 
            this.ltable.AutoSize = true;
            this.ltable.Location = new System.Drawing.Point(256, 442);
            this.ltable.Name = "ltable";
            this.ltable.Size = new System.Drawing.Size(37, 13);
            this.ltable.TabIndex = 8;
            this.ltable.Text = "Table:";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(63, 442);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(0, 13);
            this.lStatus.TabIndex = 9;
            // 
            // bcancel
            // 
            this.bcancel.ForeColor = System.Drawing.Color.Red;
            this.bcancel.Location = new System.Drawing.Point(624, 437);
            this.bcancel.Name = "bcancel";
            this.bcancel.Size = new System.Drawing.Size(75, 23);
            this.bcancel.TabIndex = 10;
            this.bcancel.Text = "Cancel";
            this.bcancel.UseVisualStyleBackColor = true;
            this.bcancel.Click += new System.EventHandler(this.cancelDumpClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "<-right click on database";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bcancel);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.ltable);
            this.Controls.Add(this.lStatusLabel);
            this.Controls.Add(this.pbDumpExec);
            this.Controls.Add(this.bStartDump);
            this.Controls.Add(this.gbDestinations);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Firedump";
            this.Load += new System.EventHandler(this.Home_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbDestinations.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAddServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.GroupBox gbDestinations;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miConfiguration;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.TreeView tvDatabases;
        private System.Windows.Forms.Button bStartDump;
        private System.Windows.Forms.ProgressBar pbDumpExec;
        private System.Windows.Forms.Label lStatusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ltable;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Button bcancel;
        private System.Windows.Forms.Label label2;
    }
}