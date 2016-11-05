using Examples.Smpt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Firedump
{
    public partial class email : Form
    {
        public static String newfrom;
        public email()
        {
            InitializeComponent();
        }

        private void email_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(newfrom))
            {
                textBox1.Text = newfrom;
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emailform.from = textBox1.Text;
            emailform.to = textBox2.Text;
            Console.WriteLine(emailform.server);
            emailform.sendmail();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form1 = new emailconfig ();
            form1.Show();
            this.Close();
        }

    }
}
