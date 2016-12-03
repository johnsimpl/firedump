using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.mysql.sqlviewer
{
    public partial class IntelliSense : Form
    {
        public IntelliSense()
        {
            InitializeComponent();
            this.listView1.Items.Add("Item one");
            this.listView1.Items.Add("Item two");
            this.listView1.Items.Add("Item three");
        }



        public void setItemsToListView(List<string> items)
        {
            this.listView1.Items.Clear();
            foreach (string item in items)
                this.listView1.Items.Add(item);
        }


    }
}
