using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WF_Lab
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        bool btn1 = false;
        bool btn2 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            btn1 = !btn1;
            SoundPlayer sound = new SoundPlayer(@"F:\Предметы\Языки и методы программирования\WF_Lab\WF_Lab\bin\Music02.wav");
            sound.Play();
            if (btn1)
            {
                sound.Play();
            }
            else sound.Stop();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            btn2 = !btn2;
            SoundPlayer sound = new SoundPlayer(@"F:\Предметы\Языки и методы программирования\WF_Lab\WF_Lab\bin\Music01.wav");
            sound.Play();
            if (btn2)
            {
                sound.Play();
            }
            else sound.Stop();
        }
    }
}
