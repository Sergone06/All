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
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs ee)
        {
            R_S_A ObjectRSA = new R_S_A();
            // реализуем алгоритм RSA
            // 1) Найти 2 простых числа (разных)
            int p = ObjectRSA.GetSimpleNumber(100,500);
            int q = ObjectRSA.GetSimpleNumber(500,10000); ;
            // 2) Вычислим модуль произведения
            int n = p * q;
            // 3) Вычислим функцию Эйлера ф = (p-1) * (q-1)
            int f = (p - 1) * (q - 1);
            // 4) Определяем открытую экспоненту
            int e = ObjectRSA.GetOpenExponent(f); //  < f
            // 5) Вычислить d (секретная экспонента)
            int d = ObjectRSA.GetSecretExponent(e,f,10);
            // [e,n] - открытый ключ
            // [d,n] - закрытый ключ
            // m - наша сообщение, которое нужно зашифровать
            double m = Convert.ToDouble(textBox1.Text); // m < n
            // 6) Шифруем входящее сообщение m
            double Ec = ObjectRSA.Encription(m,e,n); // encription
            textBox2.Text = Ec.ToString();
            // 7) Расшифровываем сообщение Ес
            double Dc = ObjectRSA.Decription(Ec, d, n); // decription
            textBox1.Text = Dc.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        //

    }
}
