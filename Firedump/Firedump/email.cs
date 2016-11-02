using Examples.SmptExamples.Async;
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
        public email()
        {
            InitializeComponent();
        }

        private void email_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SimpleAsynchronousExample.sendmail("smtp.live.com");
        }
    }
}
