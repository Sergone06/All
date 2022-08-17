using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Maxim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((WindowState == FormWindowState.Maximized) & (e.Button == MouseButtons.Left))
                // если форма развернута и нажата левая клавиша мыши
            {
                WindowState = FormWindowState.Normal; // сделать нормальную форму
            }
            else if (e.Button == MouseButtons.Left)
                WindowState = FormWindowState.Maximized; // развернуть форму
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            // ИмяКласса Имя_объекта = new ИмяКласса();
            if (CD.ShowDialog() == DialogResult.OK)
                BackColor = CD.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random RD = new Random();

            button2.Left = button2.Location.X + RD.Next(-100,100);
            button2.Top  = button2.Location.Y + RD.Next(-100,100);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void лР1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AD = new AboutBox1();
            AD.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // создать объект нашего класса Personal
            Personal Sotrudnic = new Personal();
            Sotrudnic.DataR = DateTime.Parse("10.04.2000");
            textBox1.Text = Convert.ToString( Sotrudnic.Vozrast() );
            // cоздаем объект дочернего класса
            Uborschica TetaGala = new Uborschica();
            TetaGala.DataR = DateTime.Parse("15.02.1952");
            TetaGala.Ploschad = 250;
            textBox1.Text = TetaGala.ZP(50);
            textBox1.Text = TetaGala.ZP("Программист").ToString();
            textBox1.Text = TetaGala.FIO("Иванова Галина Ивановна");
        }

        private void лр2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader TR = new TextReader();
            TR.Show();
        }

        private void лр3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // тестировщик
            Form F4 = new Form4();
            F4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random RD = new Random();
           // textBox1.Text = RD.N            ).ToString(); //Convert.ToString( (5 + 4) * (7 + 6 / 2) - 2  );
        }

        private void лр4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form OPZ = new Form5();
            OPZ.ShowDialog();
        }

        private void лр5RSAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void лр5RSAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form RSAForm = new RSA();
            RSAForm.Show();
        }
    }

    //
    class Uborschica : Personal
    {
        public int Ploschad;
        public string ZP(int Rascenok)
        {
            return base.FIO("Иванов Иван Иванович");
        }
        public int ZP(string Dolgnost)
        {
            if (Dolgnost == "Бухгалтер")
            {
                return 30000;
            }
            else if (Dolgnost == "Программист")
            {
                return 70000;
            }
            else
                return 20000;
        }
        // переопределение методов        
        public string FIO(string familia)
        {
            string[] s = new string[3];
            s = familia.Split();
            string new_str = s[1][0] + "." + s[2][0] + ". " + s[0];
            return new_str;
        }
    }
    //
    
}
