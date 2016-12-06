namespace Firedump.Forms.location
{
    partial class FTPDirectory
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
            this.cbShowFolders = new System.Windows.Forms.CheckBox();
            this.cbshowHidenFiles = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btusepath = new System.Windows.Forms.Button();
            this.lpath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbShowFolders
            // 
            this.cbShowFolders.AutoSize = true;
            this.cbShowFolders.Location = new System.Drawing.Point(12, 34);
            this.cbShowFolders.Name = "cbShowFolders";
            this.cbShowFolders.Size = new System.Drawing.Size(107, 17);
            this.cbShowFolders.TabIndex = 1;
            this.cbShowFolders.Text = "show only folders";
            this.cbShowFolders.UseVisualStyleBackColor = true;
            this.cbShowFolders.CheckedChanged += new System.EventHandler(this.cbShowFolders_CheckedChanged);
            // 
            // cbshowHidenFiles
            // 
            this.cbshowHidenFiles.AutoSize = true;
            this.cbshowHidenFiles.Location = new System.Drawing.Point(150, 34);
            this.cbshowHidenFiles.Name = "cbshowHidenFiles";
            this.cbshowHidenFiles.Size = new System.Drawing.Size(101, 17);
            this.cbshowHidenFiles.TabIndex = 2;
            this.cbshowHidenFiles.Text = "show hiden files";
            this.cbshowHidenFiles.UseVisualStyleBackColor = true;
            this.cbshowHidenFiles.CheckedChanged += new System.EventHandler(this.cbshowHidenFiles_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(664, 349);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // btusepath
            // 
            this.btusepath.Location = new System.Drawing.Point(13, 5);
            this.btusepath.Name = "btusepath";
            this.btusepath.Size = new System.Drawing.Size(75, 23);
            this.btusepath.TabIndex = 4;
            this.btusepath.Text = "use this path";
            this.btusepath.UseVisualStyleBackColor = true;
            this.btusepath.Click += new System.EventHandler(this.btusepath_Click);
            // 
            // lpath
            // 
            this.lpath.AutoSize = true;
            this.lpath.Location = new System.Drawing.Point(94, 10);
            this.lpath.Name = "lpath";
            this.lpath.Size = new System.Drawing.Size(28, 13);
            this.lpath.TabIndex = 5;
            this.lpath.Text = "path";
            // 
            // FTPDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 429);
            this.Controls.Add(this.lpath);
            this.Controls.Add(this.btusepath);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.cbshowHidenFiles);
            this.Controls.Add(this.cbShowFolders);
            this.Name = "FTPDirectory";
            this.Text = "FTPDirectory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FTPDirectory_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbShowFolders;
        private System.Windows.Forms.CheckBox cbshowHidenFiles;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btusepath;
        private System.Windows.Forms.Label lpath;
    }
}