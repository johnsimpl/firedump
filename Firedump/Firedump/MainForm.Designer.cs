namespace Firedump
{
    partial class MainForm
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
            this.bDumpForm = new System.Windows.Forms.Button();
            this.bTest1 = new System.Windows.Forms.Button();
            this.bGenConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDumpForm
            // 
            this.bDumpForm.Location = new System.Drawing.Point(12, 12);
            this.bDumpForm.Name = "bDumpForm";
            this.bDumpForm.Size = new System.Drawing.Size(75, 23);
            this.bDumpForm.TabIndex = 0;
            this.bDumpForm.Text = "Dump Form";
            this.bDumpForm.UseVisualStyleBackColor = true;
            this.bDumpForm.Click += new System.EventHandler(this.bDumpForm_Click);
            // 
            // bTest1
            // 
            this.bTest1.Location = new System.Drawing.Point(13, 223);
            this.bTest1.Name = "bTest1";
            this.bTest1.Size = new System.Drawing.Size(75, 23);
            this.bTest1.TabIndex = 1;
            this.bTest1.Text = "Test1";
            this.bTest1.UseVisualStyleBackColor = true;
            this.bTest1.Click += new System.EventHandler(this.bTest1_Click);
            // 
            // bGenConfig
            // 
            this.bGenConfig.Location = new System.Drawing.Point(12, 57);
            this.bGenConfig.Name = "bGenConfig";
            this.bGenConfig.Size = new System.Drawing.Size(75, 23);
            this.bGenConfig.TabIndex = 2;
            this.bGenConfig.Text = "GenConfig";
            this.bGenConfig.UseVisualStyleBackColor = true;
            this.bGenConfig.Click += new System.EventHandler(this.bGenConfig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.email_click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bGenConfig);
            this.Controls.Add(this.bTest1);
            this.Controls.Add(this.bDumpForm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDumpForm;
        private System.Windows.Forms.Button bTest1;
        private System.Windows.Forms.Button bGenConfig;
        private System.Windows.Forms.Button button1;
    }
}