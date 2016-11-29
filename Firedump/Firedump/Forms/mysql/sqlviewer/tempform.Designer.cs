namespace Firedump.Forms.mysql.sqlviewer
{
    partial class tempform
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
            this.btconnect = new System.Windows.Forms.Button();
            this.tbdatabase = new System.Windows.Forms.TextBox();
            this.ldatabase = new System.Windows.Forms.Label();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.lpassword = new System.Windows.Forms.Label();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.tbport = new System.Windows.Forms.TextBox();
            this.lport = new System.Windows.Forms.Label();
            this.lusername = new System.Windows.Forms.Label();
            this.lhostname = new System.Windows.Forms.Label();
            this.tbhostname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btconnect
            // 
            this.btconnect.Location = new System.Drawing.Point(11, 256);
            this.btconnect.Name = "btconnect";
            this.btconnect.Size = new System.Drawing.Size(114, 23);
            this.btconnect.TabIndex = 21;
            this.btconnect.Text = "start sqlViewer";
            this.btconnect.UseVisualStyleBackColor = true;
            this.btconnect.Click += new System.EventHandler(this.sqlviewerclick);
            // 
            // tbdatabase
            // 
            this.tbdatabase.Location = new System.Drawing.Point(66, 202);
            this.tbdatabase.Name = "tbdatabase";
            this.tbdatabase.Size = new System.Drawing.Size(164, 20);
            this.tbdatabase.TabIndex = 20;
            this.tbdatabase.Text = "wall";
            // 
            // ldatabase
            // 
            this.ldatabase.AutoSize = true;
            this.ldatabase.Location = new System.Drawing.Point(8, 202);
            this.ldatabase.Name = "ldatabase";
            this.ldatabase.Size = new System.Drawing.Size(51, 13);
            this.ldatabase.TabIndex = 19;
            this.ldatabase.Text = "database";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(66, 168);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.PasswordChar = '*';
            this.tbpassword.Size = new System.Drawing.Size(164, 20);
            this.tbpassword.TabIndex = 18;
            this.tbpassword.Text = "password";
            // 
            // lpassword
            // 
            this.lpassword.AutoSize = true;
            this.lpassword.Location = new System.Drawing.Point(7, 168);
            this.lpassword.Name = "lpassword";
            this.lpassword.Size = new System.Drawing.Size(52, 13);
            this.lpassword.TabIndex = 17;
            this.lpassword.Text = "password";
            // 
            // tbusername
            // 
            this.tbusername.Location = new System.Drawing.Point(66, 128);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(164, 20);
            this.tbusername.TabIndex = 16;
            this.tbusername.Text = "user";
            // 
            // tbport
            // 
            this.tbport.Location = new System.Drawing.Point(268, 85);
            this.tbport.Name = "tbport";
            this.tbport.Size = new System.Drawing.Size(59, 20);
            this.tbport.TabIndex = 15;
            // 
            // lport
            // 
            this.lport.AutoSize = true;
            this.lport.Location = new System.Drawing.Point(237, 88);
            this.lport.Name = "lport";
            this.lport.Size = new System.Drawing.Size(25, 13);
            this.lport.TabIndex = 14;
            this.lport.Text = "port";
            // 
            // lusername
            // 
            this.lusername.AutoSize = true;
            this.lusername.Location = new System.Drawing.Point(7, 128);
            this.lusername.Name = "lusername";
            this.lusername.Size = new System.Drawing.Size(53, 13);
            this.lusername.TabIndex = 13;
            this.lusername.Text = "username";
            // 
            // lhostname
            // 
            this.lhostname.AutoSize = true;
            this.lhostname.Location = new System.Drawing.Point(7, 85);
            this.lhostname.Name = "lhostname";
            this.lhostname.Size = new System.Drawing.Size(53, 13);
            this.lhostname.TabIndex = 12;
            this.lhostname.Text = "hostname";
            // 
            // tbhostname
            // 
            this.tbhostname.Location = new System.Drawing.Point(66, 85);
            this.tbhostname.Name = "tbhostname";
            this.tbhostname.Size = new System.Drawing.Size(164, 20);
            this.tbhostname.TabIndex = 11;
            this.tbhostname.Text = "localhost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Prosorino form gia dokimi sqlviewer. Prepei na simplirothoun ola ta pedia .";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "sqlviewer tha anigei apo epilogi database apo UI kanonika";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Elenxous gia kena pedia den evala kai oute prokite na valw edo!";
            // 
            // tempform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 302);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btconnect);
            this.Controls.Add(this.tbdatabase);
            this.Controls.Add(this.ldatabase);
            this.Controls.Add(this.tbpassword);
            this.Controls.Add(this.lpassword);
            this.Controls.Add(this.tbusername);
            this.Controls.Add(this.tbport);
            this.Controls.Add(this.lport);
            this.Controls.Add(this.lusername);
            this.Controls.Add(this.lhostname);
            this.Controls.Add(this.tbhostname);
            this.Name = "tempform";
            this.Text = "tempform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btconnect;
        private System.Windows.Forms.TextBox tbdatabase;
        private System.Windows.Forms.Label ldatabase;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Label lpassword;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.TextBox tbport;
        private System.Windows.Forms.Label lport;
        private System.Windows.Forms.Label lusername;
        private System.Windows.Forms.Label lhostname;
        private System.Windows.Forms.TextBox tbhostname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}