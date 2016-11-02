using Firedump.models.dump;
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
    public partial class Test1 : Form
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Compression comp = new Compression();
            comp.absolutePath = "D:\\test\\test 1\\file test.sql";
            comp.doCompress7z();*/
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
