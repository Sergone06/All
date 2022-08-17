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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // создать объект класса personal
            personal Sotrudnic = new personal();
            Sotrudnic.DataR = DateTime.Parse("10.03.2002");
            textBox1.Text = Sotrudnic.Vozrast().ToString();
            // создаем объект дочернего класса
            Uborschica TetaGala = new Uborschica();
            TetaGala.DataR = DateTime.Parse("15.02.1952");
            TetaGala.Ploschad = 250;
            textBox1.Text = TetaGala.ZP(50).ToString();
            textBox1.Text = TetaGala.ZP("Программист").ToString();
            textBox1.Text = TetaGala.FIO("Иванова Галина Ивановна");
        }
    }
    
    //
    class Uborschica  : personal
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
    
}
