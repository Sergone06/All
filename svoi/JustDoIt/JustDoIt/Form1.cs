using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustDoIt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 kch = new Form2();
            kch.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string text = "download.png";
            pictureBox1.BackgroundImage = Image.FromFile(@text);
        }
    }
}
