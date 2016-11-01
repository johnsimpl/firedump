namespace Firedump
{
    partial class Sqloptions
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
            this.gbStructure = new System.Windows.Forms.GroupBox();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.cbaddDropTable = new System.Windows.Forms.CheckBox();
            this.cbaddIfNotExists = new System.Windows.Forms.CheckBox();
            this.cbaddAutoIncreamentValue = new System.Windows.Forms.CheckBox();
            this.cbencloseWithBackquotes = new System.Windows.Forms.CheckBox();
            this.cbaddCreateProcedure = new System.Windows.Forms.CheckBox();
            this.cbaddInfoComments = new System.Windows.Forms.CheckBox();
            this.cbStructure = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.gbStructure.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStructure
            // 
            this.gbStructure.Controls.Add(this.cbStructure);
            this.gbStructure.Controls.Add(this.cbaddInfoComments);
            this.gbStructure.Controls.Add(this.cbaddCreateProcedure);
            this.gbStructure.Controls.Add(this.cbencloseWithBackquotes);
            this.gbStructure.Controls.Add(this.cbaddAutoIncreamentValue);
            this.gbStructure.Controls.Add(this.cbaddIfNotExists);
            this.gbStructure.Controls.Add(this.cbaddDropTable);
            this.gbStructure.Location = new System.Drawing.Point(12, 227);
            this.gbStructure.Name = "gbStructure";
            this.gbStructure.Size = new System.Drawing.Size(362, 312);
            this.gbStructure.TabIndex = 0;
            this.gbStructure.TabStop = false;
            this.gbStructure.Text = "Structure";
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.checkBox8);
            this.gbData.Controls.Add(this.comboBox3);
            this.gbData.Controls.Add(this.label3);
            this.gbData.Controls.Add(this.checkBox7);
            this.gbData.Controls.Add(this.checkBox6);
            this.gbData.Controls.Add(this.checkBox5);
            this.gbData.Controls.Add(this.checkBox4);
            this.gbData.Controls.Add(this.checkBox3);
            this.gbData.Controls.Add(this.comboBox2);
            this.gbData.Controls.Add(this.label2);
            this.gbData.Controls.Add(this.comboBox1);
            this.gbData.Controls.Add(this.label1);
            this.gbData.Controls.Add(this.checkBox2);
            this.gbData.Controls.Add(this.checkBox1);
            this.gbData.Location = new System.Drawing.Point(386, 232);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(347, 306);
            this.gbData.TabIndex = 1;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // cbaddDropTable
            // 
            this.cbaddDropTable.AutoSize = true;
            this.cbaddDropTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbaddDropTable.Location = new System.Drawing.Point(28, 52);
            this.cbaddDropTable.Name = "cbaddDropTable";
            this.cbaddDropTable.Size = new System.Drawing.Size(222, 17);
            this.cbaddDropTable.TabIndex = 0;
            this.cbaddDropTable.Text = "Add DROP TABLE/VIEW/PROCEDURE";
            this.cbaddDropTable.UseVisualStyleBackColor = true;
            // 
            // cbaddIfNotExists
            // 
            this.cbaddIfNotExists.AutoSize = true;
            this.cbaddIfNotExists.Location = new System.Drawing.Point(28, 76);
            this.cbaddIfNotExists.Name = "cbaddIfNotExists";
            this.cbaddIfNotExists.Size = new System.Drawing.Size(124, 17);
            this.cbaddIfNotExists.TabIndex = 1;
            this.cbaddIfNotExists.Text = "Add IF NOT EXISTS";
            this.cbaddIfNotExists.UseVisualStyleBackColor = true;
            // 
            // cbaddAutoIncreamentValue
            // 
            this.cbaddAutoIncreamentValue.AutoSize = true;
            this.cbaddAutoIncreamentValue.Location = new System.Drawing.Point(28, 100);
            this.cbaddAutoIncreamentValue.Name = "cbaddAutoIncreamentValue";
            this.cbaddAutoIncreamentValue.Size = new System.Drawing.Size(153, 17);
            this.cbaddAutoIncreamentValue.TabIndex = 2;
            this.cbaddAutoIncreamentValue.Text = "Add auto increament value";
            this.cbaddAutoIncreamentValue.UseVisualStyleBackColor = true;
            // 
            // cbencloseWithBackquotes
            // 
            this.cbencloseWithBackquotes.AutoSize = true;
            this.cbencloseWithBackquotes.Location = new System.Drawing.Point(28, 124);
            this.cbencloseWithBackquotes.Name = "cbencloseWithBackquotes";
            this.cbencloseWithBackquotes.Size = new System.Drawing.Size(237, 17);
            this.cbencloseWithBackquotes.TabIndex = 3;
            this.cbencloseWithBackquotes.Text = "Enclose table and field names in backquotes";
            this.cbencloseWithBackquotes.UseVisualStyleBackColor = true;
            // 
            // cbaddCreateProcedure
            // 
            this.cbaddCreateProcedure.AutoSize = true;
            this.cbaddCreateProcedure.Location = new System.Drawing.Point(28, 148);
            this.cbaddCreateProcedure.Name = "cbaddCreateProcedure";
            this.cbaddCreateProcedure.Size = new System.Drawing.Size(222, 17);
            this.cbaddCreateProcedure.TabIndex = 4;
            this.cbaddCreateProcedure.Text = "Add CREATE PROCEDURE/FUNCTION";
            this.cbaddCreateProcedure.UseVisualStyleBackColor = true;
            // 
            // cbaddInfoComments
            // 
            this.cbaddInfoComments.AutoSize = true;
            this.cbaddInfoComments.Location = new System.Drawing.Point(28, 172);
            this.cbaddInfoComments.Name = "cbaddInfoComments";
            this.cbaddInfoComments.Size = new System.Drawing.Size(116, 17);
            this.cbaddInfoComments.TabIndex = 5;
            this.cbaddInfoComments.Text = "Add info comments";
            this.cbaddInfoComments.UseVisualStyleBackColor = true;
            // 
            // cbStructure
            // 
            this.cbStructure.AutoSize = true;
            this.cbStructure.Location = new System.Drawing.Point(7, 20);
            this.cbStructure.Name = "cbStructure";
            this.cbStructure.Size = new System.Drawing.Size(204, 17);
            this.cbStructure.TabIndex = 6;
            this.cbStructure.Text = "Enable Sctructure options in dump file";
            this.cbStructure.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 71);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(48, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(48, 120);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 143);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(7, 167);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(7, 191);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(80, 17);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(7, 215);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(80, 17);
            this.checkBox6.TabIndex = 9;
            this.checkBox6.Text = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(7, 239);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(80, 17);
            this.checkBox7.TabIndex = 10;
            this.checkBox7.Text = "checkBox7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(48, 260);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 12;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(7, 287);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(80, 17);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.Text = "checkBox8";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // Sqloptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 551);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.gbStructure);
            this.Name = "Sqloptions";
            this.Text = "SQL Options";
            this.gbStructure.ResumeLayout(false);
            this.gbStructure.PerformLayout();
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStructure;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.CheckBox cbaddDropTable;
        private System.Windows.Forms.CheckBox cbencloseWithBackquotes;
        private System.Windows.Forms.CheckBox cbaddAutoIncreamentValue;
        private System.Windows.Forms.CheckBox cbaddIfNotExists;
        private System.Windows.Forms.CheckBox cbaddCreateProcedure;
        private System.Windows.Forms.CheckBox cbaddInfoComments;
        private System.Windows.Forms.CheckBox cbStructure;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}