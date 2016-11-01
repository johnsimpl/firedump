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
            this.bConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.gbSchedule = new System.Windows.Forms.GroupBox();
            this.gbDestinations = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbConnection.SuspendLayout();
            this.gbDestinations.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(6, 36);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(124, 23);
            this.bConnect.TabIndex = 0;
            this.bConnect.TabStop = false;
            this.bConnect.Text = "Connect to Server";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Destination";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.listBox1);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.cbDatabases);
            this.gbConnection.Controls.Add(this.bConnect);
            this.gbConnection.Location = new System.Drawing.Point(5, 58);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(241, 344);
            this.gbConnection.TabIndex = 2;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            this.gbConnection.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbDatabases
            // 
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(9, 65);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(222, 21);
            this.cbDatabases.TabIndex = 1;
            // 
            // gbSchedule
            // 
            this.gbSchedule.Location = new System.Drawing.Point(303, 58);
            this.gbSchedule.Name = "gbSchedule";
            this.gbSchedule.Size = new System.Drawing.Size(279, 121);
            this.gbSchedule.TabIndex = 3;
            this.gbSchedule.TabStop = false;
            this.gbSchedule.Text = "Schedule";
            // 
            // gbDestinations
            // 
            this.gbDestinations.Controls.Add(this.button1);
            this.gbDestinations.Location = new System.Drawing.Point(303, 185);
            this.gbDestinations.Name = "gbDestinations";
            this.gbDestinations.Size = new System.Drawing.Size(279, 152);
            this.gbDestinations.TabIndex = 0;
            this.gbDestinations.TabStop = false;
            this.gbDestinations.Text = "Destinations";
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 91);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(229, 290);
            this.listBox1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
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
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 482);
            this.Controls.Add(this.gbDestinations);
            this.Controls.Add(this.gbSchedule);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbDestinations.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.GroupBox gbSchedule;
        private System.Windows.Forms.GroupBox gbDestinations;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}