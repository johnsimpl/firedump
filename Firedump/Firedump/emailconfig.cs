using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examples.Smpt;

namespace Firedump
{
    public partial class emailconfig : Form
    {
        public emailconfig()
        {
            InitializeComponent();
        }

        private void customchecked(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked )
            {
                emailform.server = "smtp.live.com";
                emailform.pass = textBox3.Text;
                emailform.port = 25;
                Form form1 = new email();
                form1.Show();
                Console.WriteLine(emailform.server);
                this.Close();
            }
            else 
                if(radioButton2.Checked )
            {
                emailform.server = textBox2.Text ;
                emailform.from = textBox1.Text;
                emailform.port = Convert.ToInt32(numericUpDown1.Value);
                email.newfrom= textBox1.Text;
                Form form1 = new email();
                form1.Show();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form1 = new email();
            form1.Show();
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
        }
    }
}
