namespace Firedump
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.bCancelDump = new System.Windows.Forms.Button();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.bRefresh = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pbDumpprogress = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "test btn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 171);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Execute Dump";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(74, 6);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(167, 20);
            this.txtHost.TabIndex = 2;
            this.txtHost.Text = "localhost";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(285, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "3306";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(74, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(167, 20);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "root";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtPassword.Location = new System.Drawing.Point(74, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "database:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "set save path";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bCancelDump
            // 
            this.bCancelDump.ForeColor = System.Drawing.Color.Red;
            this.bCancelDump.ImageKey = "(none)";
            this.bCancelDump.Location = new System.Drawing.Point(348, 171);
            this.bCancelDump.Name = "bCancelDump";
            this.bCancelDump.Size = new System.Drawing.Size(105, 23);
            this.bCancelDump.TabIndex = 15;
            this.bCancelDump.Text = "cancelDumpTask";
            this.bCancelDump.UseVisualStyleBackColor = true;
            this.bCancelDump.Click += new System.EventHandler(this.cancelDUmpTaskClickListener);
            // 
            // cbDatabases
            // 
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(74, 120);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(167, 21);
            this.cbDatabases.TabIndex = 16;
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(254, 120);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 17;
            this.bRefresh.Text = "refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.btnRefreshDatabasesClickListener);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(131, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "test connection";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.test_con_clickListener);
            // 
            // pbDumpprogress
            // 
            this.pbDumpprogress.Location = new System.Drawing.Point(13, 277);
            this.pbDumpprogress.Name = "pbDumpprogress";
            this.pbDumpprogress.Size = new System.Drawing.Size(440, 31);
            this.pbDumpprogress.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "status:";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(57, 258);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(0, 13);
            this.lStatus.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 347);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbDumpprogress);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.cbDatabases);
            this.Controls.Add(this.bCancelDump);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bCancelDump;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ProgressBar pbDumpprogress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lStatus;
    }
}

