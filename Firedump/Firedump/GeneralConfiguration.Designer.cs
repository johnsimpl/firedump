namespace Firedump
{
    partial class GeneralConfiguration
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
            this.gbFolders = new System.Windows.Forms.GroupBox();
            this.tbTempFolder = new System.Windows.Forms.TextBox();
            this.bTempFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bLogFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDumpOptions = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cbEvents = new System.Windows.Forms.CheckBox();
            this.cbTriggers = new System.Windows.Forms.CheckBox();
            this.cbSingleFile = new System.Windows.Forms.CheckBox();
            this.bMoreSQLOptions = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.gbCompressionSettings = new System.Windows.Forms.GroupBox();
            this.cbEnableComp = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cbUseMultithreading = new System.Windows.Forms.CheckBox();
            this.gbEncryption = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.gbFolders.SuspendLayout();
            this.gbDumpOptions.SuspendLayout();
            this.gbCompressionSettings.SuspendLayout();
            this.gbEncryption.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFolders
            // 
            this.gbFolders.Controls.Add(this.label2);
            this.gbFolders.Controls.Add(this.bLogFolder);
            this.gbFolders.Controls.Add(this.textBox1);
            this.gbFolders.Controls.Add(this.label1);
            this.gbFolders.Controls.Add(this.bTempFolder);
            this.gbFolders.Controls.Add(this.tbTempFolder);
            this.gbFolders.Location = new System.Drawing.Point(24, 24);
            this.gbFolders.Name = "gbFolders";
            this.gbFolders.Size = new System.Drawing.Size(510, 166);
            this.gbFolders.TabIndex = 0;
            this.gbFolders.TabStop = false;
            this.gbFolders.Text = "Folder locations";
            // 
            // tbTempFolder
            // 
            this.tbTempFolder.Enabled = false;
            this.tbTempFolder.Location = new System.Drawing.Point(133, 49);
            this.tbTempFolder.Name = "tbTempFolder";
            this.tbTempFolder.Size = new System.Drawing.Size(315, 20);
            this.tbTempFolder.TabIndex = 0;
            // 
            // bTempFolder
            // 
            this.bTempFolder.Location = new System.Drawing.Point(454, 47);
            this.bTempFolder.Name = "bTempFolder";
            this.bTempFolder.Size = new System.Drawing.Size(40, 23);
            this.bTempFolder.TabIndex = 1;
            this.bTempFolder.Text = "...";
            this.bTempFolder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Temporary folder:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 20);
            this.textBox1.TabIndex = 3;
            // 
            // bLogFolder
            // 
            this.bLogFolder.Location = new System.Drawing.Point(454, 105);
            this.bLogFolder.Name = "bLogFolder";
            this.bLogFolder.Size = new System.Drawing.Size(40, 23);
            this.bLogFolder.TabIndex = 4;
            this.bLogFolder.Text = "...";
            this.bLogFolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Log folder:";
            // 
            // gbDumpOptions
            // 
            this.gbDumpOptions.Controls.Add(this.bMoreSQLOptions);
            this.gbDumpOptions.Controls.Add(this.cbSingleFile);
            this.gbDumpOptions.Controls.Add(this.cbTriggers);
            this.gbDumpOptions.Controls.Add(this.cbEvents);
            this.gbDumpOptions.Controls.Add(this.checkBox2);
            this.gbDumpOptions.Controls.Add(this.checkBox1);
            this.gbDumpOptions.Location = new System.Drawing.Point(24, 240);
            this.gbDumpOptions.Name = "gbDumpOptions";
            this.gbDumpOptions.Size = new System.Drawing.Size(510, 261);
            this.gbDumpOptions.TabIndex = 1;
            this.gbDumpOptions.TabStop = false;
            this.gbDumpOptions.Text = "SQL Dump options";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.checkBox1.Location = new System.Drawing.Point(28, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Include Create Schema";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.checkBox2.Location = new System.Drawing.Point(28, 99);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Dump Data";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbEvents
            // 
            this.cbEvents.AutoSize = true;
            this.cbEvents.Location = new System.Drawing.Point(28, 193);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.Size = new System.Drawing.Size(90, 17);
            this.cbEvents.TabIndex = 2;
            this.cbEvents.Text = "Dump Events";
            this.cbEvents.UseVisualStyleBackColor = true;
            // 
            // cbTriggers
            // 
            this.cbTriggers.AutoSize = true;
            this.cbTriggers.Location = new System.Drawing.Point(187, 193);
            this.cbTriggers.Name = "cbTriggers";
            this.cbTriggers.Size = new System.Drawing.Size(95, 17);
            this.cbTriggers.TabIndex = 3;
            this.cbTriggers.Text = "Dump Triggers";
            this.cbTriggers.UseVisualStyleBackColor = true;
            // 
            // cbSingleFile
            // 
            this.cbSingleFile.AutoSize = true;
            this.cbSingleFile.Location = new System.Drawing.Point(349, 193);
            this.cbSingleFile.Name = "cbSingleFile";
            this.cbSingleFile.Size = new System.Drawing.Size(95, 17);
            this.cbSingleFile.TabIndex = 4;
            this.cbSingleFile.Text = "Single SQL file";
            this.cbSingleFile.UseVisualStyleBackColor = true;
            // 
            // bMoreSQLOptions
            // 
            this.bMoreSQLOptions.Location = new System.Drawing.Point(227, 99);
            this.bMoreSQLOptions.Name = "bMoreSQLOptions";
            this.bMoreSQLOptions.Size = new System.Drawing.Size(217, 23);
            this.bMoreSQLOptions.TabIndex = 5;
            this.bMoreSQLOptions.Text = "More SQL Options ...";
            this.bMoreSQLOptions.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bSave.Location = new System.Drawing.Point(52, 525);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(177, 37);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save Options";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bCancel.Location = new System.Drawing.Point(1010, 525);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(95, 37);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bReset.Location = new System.Drawing.Point(748, 525);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(184, 37);
            this.bReset.TabIndex = 4;
            this.bReset.Text = "Reset to defaults";
            this.bReset.UseVisualStyleBackColor = true;
            // 
            // gbCompressionSettings
            // 
            this.gbCompressionSettings.Controls.Add(this.cbUseMultithreading);
            this.gbCompressionSettings.Controls.Add(this.comboBox2);
            this.gbCompressionSettings.Controls.Add(this.label4);
            this.gbCompressionSettings.Controls.Add(this.comboBox1);
            this.gbCompressionSettings.Controls.Add(this.label3);
            this.gbCompressionSettings.Controls.Add(this.cbEnableComp);
            this.gbCompressionSettings.Location = new System.Drawing.Point(584, 24);
            this.gbCompressionSettings.Name = "gbCompressionSettings";
            this.gbCompressionSettings.Size = new System.Drawing.Size(521, 166);
            this.gbCompressionSettings.TabIndex = 5;
            this.gbCompressionSettings.TabStop = false;
            this.gbCompressionSettings.Text = "Compression Settings";
            // 
            // cbEnableComp
            // 
            this.cbEnableComp.AutoSize = true;
            this.cbEnableComp.Location = new System.Drawing.Point(16, 28);
            this.cbEnableComp.Name = "cbEnableComp";
            this.cbEnableComp.Size = new System.Drawing.Size(122, 17);
            this.cbEnableComp.TabIndex = 0;
            this.cbEnableComp.Text = "Enable Compression";
            this.cbEnableComp.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Compression Level:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(354, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "File format:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(80, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // cbUseMultithreading
            // 
            this.cbUseMultithreading.AutoSize = true;
            this.cbUseMultithreading.Location = new System.Drawing.Point(19, 120);
            this.cbUseMultithreading.Name = "cbUseMultithreading";
            this.cbUseMultithreading.Size = new System.Drawing.Size(114, 17);
            this.cbUseMultithreading.TabIndex = 5;
            this.cbUseMultithreading.Text = "Use Multithreading";
            this.cbUseMultithreading.UseVisualStyleBackColor = true;
            // 
            // gbEncryption
            // 
            this.gbEncryption.Controls.Add(this.checkBox3);
            this.gbEncryption.Location = new System.Drawing.Point(584, 240);
            this.gbEncryption.Name = "gbEncryption";
            this.gbEncryption.Size = new System.Drawing.Size(521, 182);
            this.gbEncryption.TabIndex = 6;
            this.gbEncryption.TabStop = false;
            this.gbEncryption.Text = "Encryption Settings";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(16, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(143, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Enable zip file encryption";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // GeneralConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 574);
            this.Controls.Add(this.gbEncryption);
            this.Controls.Add(this.gbCompressionSettings);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.gbDumpOptions);
            this.Controls.Add(this.gbFolders);
            this.Name = "GeneralConfiguration";
            this.Text = "GeneralConfiguration";
            this.gbFolders.ResumeLayout(false);
            this.gbFolders.PerformLayout();
            this.gbDumpOptions.ResumeLayout(false);
            this.gbDumpOptions.PerformLayout();
            this.gbCompressionSettings.ResumeLayout(false);
            this.gbCompressionSettings.PerformLayout();
            this.gbEncryption.ResumeLayout(false);
            this.gbEncryption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFolders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bLogFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTempFolder;
        private System.Windows.Forms.TextBox tbTempFolder;
        private System.Windows.Forms.GroupBox gbDumpOptions;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cbSingleFile;
        private System.Windows.Forms.CheckBox cbTriggers;
        private System.Windows.Forms.CheckBox cbEvents;
        private System.Windows.Forms.Button bMoreSQLOptions;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.GroupBox gbCompressionSettings;
        private System.Windows.Forms.CheckBox cbEnableComp;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbUseMultithreading;
        private System.Windows.Forms.GroupBox gbEncryption;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}