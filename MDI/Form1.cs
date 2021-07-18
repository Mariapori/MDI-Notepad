using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory(@"c:\temp");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ticks = DateTime.Now.Ticks;
            System.IO.File.WriteAllText(@"c:\temp\" + ticks.ToString() + ".txt","");
            Form2 form2 = new Form2(ticks);
            form2.MdiParent = this;
            form2.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
