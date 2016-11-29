using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class LocationSwitchboard : Form
    {
        private Home homeinstance;
        public LocationSwitchboard(Home homeinstance)
        {
            InitializeComponent();
            this.homeinstance = homeinstance;
        }

        private void bFileSystem_Click(object sender, EventArgs e)
        {

        }
    }
}
