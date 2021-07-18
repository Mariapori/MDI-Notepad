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
    public partial class Form2 : Form
    {
        private long tickss;
        private string filepath;
        public Form2(long ticks)
        {
            InitializeComponent();
            tickss = ticks;
            this.Text = "Uusi tekstitiedosto";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = System.IO.File.ReadAllText(@"c:\temp\" + tickss.ToString() + ".txt");
        }

        private void tallennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(filepath == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Tekstitiedosto | .txt";
                var result = sfd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, richTextBox1.Text);
                    this.Text = sfd.FileName;
                    System.IO.File.Delete(@"c:\temp\" + tickss.ToString() + ".txt");
                    filepath = sfd.FileName;
                }
            }
            else
            {
                System.IO.File.WriteAllText(filepath, richTextBox1.Text);
            }


        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.IO.File.Delete(@"c:\temp\" + tickss.ToString() + ".txt");
        }

        private void fonttiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            var fontti = fd.ShowDialog();
            if(fontti == DialogResult.OK)
            {
                if (richTextBox1.SelectedText != null)
                {
                    richTextBox1.SelectionFont = fd.Font;
                }
                else
                {
                    richTextBox1.Font = fd.Font;
                }
            }
        }

        private void tekstinVäriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            var colori = cd.ShowDialog();

            if(colori == DialogResult.OK)
            {
                if(richTextBox1.SelectedText != null)
                {
                    richTextBox1.SelectionColor = cd.Color;
                }
                else
                {
                    richTextBox1.ForeColor = cd.Color;
                }

            }
        }
    }
}
