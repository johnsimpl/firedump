namespace Firedump
{
    partial class Location
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
            this.bSelectFolder = new System.Windows.Forms.Button();
            this.bSelectServer = new System.Windows.Forms.Button();
            this.bOther = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // bSelectFolder
            // 
            this.bSelectFolder.Location = new System.Drawing.Point(13, 13);
            this.bSelectFolder.Name = "bSelectFolder";
            this.bSelectFolder.Size = new System.Drawing.Size(198, 52);
            this.bSelectFolder.TabIndex = 0;
            this.bSelectFolder.Text = "Local Folder";
            this.bSelectFolder.UseVisualStyleBackColor = true;
            // 
            // bSelectServer
            // 
            this.bSelectServer.Location = new System.Drawing.Point(12, 71);
            this.bSelectServer.Name = "bSelectServer";
            this.bSelectServer.Size = new System.Drawing.Size(198, 52);
            this.bSelectServer.TabIndex = 1;
            this.bSelectServer.Text = "FTP Server";
            this.bSelectServer.UseVisualStyleBackColor = true;
            // 
            // bOther
            // 
            this.bOther.Location = new System.Drawing.Point(12, 129);
            this.bOther.Name = "bOther";
            this.bOther.Size = new System.Drawing.Size(198, 52);
            this.bOther.TabIndex = 2;
            this.bOther.Text = "Other";
            this.bOther.UseVisualStyleBackColor = true;
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 191);
            this.Controls.Add(this.bOther);
            this.Controls.Add(this.bSelectServer);
            this.Controls.Add(this.bSelectFolder);
            this.Name = "Location";
            this.Text = "Add Location";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSelectFolder;
        private System.Windows.Forms.Button bSelectServer;
        private System.Windows.Forms.Button bOther;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}