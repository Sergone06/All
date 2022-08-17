using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Lab
{
    public partial class LR_2 : Form
    {
        public LR_2()
        {
            InitializeComponent();
            
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FD = new FontDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = FD.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            if (CD.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = CD.Color;
            }
        }
        string filename;
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            textBox1.Text = TEXT;
        }
        
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text file(*.txt)|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, textBox1.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Сохранено");
        }
    }
}
