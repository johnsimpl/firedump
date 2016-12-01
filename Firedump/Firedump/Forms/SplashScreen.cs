using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Firedump.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.CenterToScreen();
            init();      
        }

        private void init()
        {

            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            Task task = new Task(increaseProgressBar);
            task.Start();
        }

        async void increaseProgressBar()
        {
            for (int i = 0; i <= progressBar1.Maximum; i++)
            {
                Thread.Sleep(25);
                this.Invoke((MethodInvoker)delegate ()
                {
                    progressBar1.Value = i;
                });
                   
            }
        }
    }
}
