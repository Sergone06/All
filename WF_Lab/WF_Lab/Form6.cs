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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        

        public void button1_Click_1(object sender, EventArgs ee)
        {
            Met();
        }
        public void Met()
        {
            R_S_A ObjectRSA = new R_S_A();
            // реализуем алгоритм RSA
            // 1) Найти 2 простых числа (разных)
            int p = ObjectRSA.GetSimpleNumber(40, 150);
            int q = ObjectRSA.GetSimpleNumber(40, 150);
            // 2) Вычислим модуль произведения
            int n = p * q;
            textBox6.Text = n.ToString();
            // 3) Вычислим функцию Эйлера ф = (p-1) * (q-1)
            int f = (p - 1) * (q - 1);
            // 4) Определяем открытую экспоненту
            int e = ObjectRSA.GetOpenExponent(f); //  < f
            textBox4.Text = e.ToString();
            // 5) Вычислить d (секретная экспонента)
            int d = ObjectRSA.GetSecretExponent(e, f, 10);
            textBox5.Text = d.ToString();
            // [e,n] - открытый ключ
            // [d,n] - закрытый ключ
            // m - наша сообщение, которое нужно зашифровать
            string m = textBox1.Text;
            // m < n
            // 6) Шифруем входящее сообщение m
            string Ec = ObjectRSA.Encription(m, e, n); // encription
            textBox2.Text = Ec.ToString();
            // 7) Расшифровываем сообщение Ес
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            R_S_A ObjectRSA = new R_S_A();
            double d = Convert.ToDouble(textBox5.Text);
            int n = Convert.ToInt32(textBox6.Text);
            string Ec = textBox2.Text;
            string Dc = ObjectRSA.Decription(Ec, d, n); // decription
            textBox3.Text = Dc;
        }
        string filename;
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "text(*.txt)|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Зашифрованное сообщение: " + textBox2.Text + "\n" + "d: " + textBox5.Text + "\n" + "n: " + textBox6.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            string KL = TEXT.Replace("Зашифрованное сообщение: ", "").Replace("\nd: ", ";").Replace("\nn: ", ";");
            textBox5.Text = KL.Split(';')[1];
            textBox6.Text = KL.Split(';')[2];
            textBox2.Text = KL.Split(';')[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
