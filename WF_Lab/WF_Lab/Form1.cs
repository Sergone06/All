using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            button1.Location = new Point(random.Next(this.Width - button1.Width), random.Next(this.Height - button1.Height));
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AB1 = new AboutBox1();
            AB1.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 L1 = new Form2();
            L1.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            LR_2 TR = new LR_2();
            TR.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Test2class T2 = new Test2class();
            T2.ShowDialog();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form4 OPZ = new Form4();
            OPZ.ShowDialog();
        }

        private void открытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 KR = new Form5();
            KR.Show();
        }


        private void открытьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Report.docx");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form6 RSA = new Form6();
            RSA.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form7 DB = new Form7();
            DB.Show();
        }
    }
    public class OPZ
    {
        public int operand;
        public int rang;
        public string operacia;
        public void Add(string simbol)
        {
            string Chisla = "+-*/()";

            if (Chisla.IndexOf(simbol) >= 0)
            {
                operacia = simbol;
                rang = FindRang(simbol);
            }
            else
            {
                operand = Convert.ToInt32(simbol);
                operacia = "ch";
            }
        }
        
        private int FindRang(string simbol)
        {
            if ((simbol == "(") || (simbol == ")"))
            {
                return 1;
            }
            else if ((simbol == "+") || (simbol == "-"))
            {
                return 2;
            }
            else if ((simbol == "*") || (simbol == "/"))
            {
                return 3;
            }
            else return 4;
        }
    }
    
    class R_S_A
    {
        Random rnd = new Random();
        public int GetSimpleNumber(int nach, int kon)
        {
            bool ThisIsSimpleNumber;
            for (int i = nach; i <= kon; )
            {
                i = rnd.Next(nach, kon);
                ThisIsSimpleNumber = true;
                // ищем простое число от 2 до i
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        ThisIsSimpleNumber = false;
                        break;
                    }
                }
                if (ThisIsSimpleNumber)
                {
                    return i;
                }
            }
            return 0;
        }
        //
        public int GetOpenExponent(int f)
        {
            // 1 оно взаимно простое с ф
            // 2 меньше ф

            for (int i = 10; i < f; i++)
            {
                if (IsCoprime(i, f))
                {
                    return i;
                }
            }
            return 0;
        }
        public static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }
        //
        public int GetSecretExponent(int e, int f, int ot = 1000)
        {
            // (d*e) mod f = 1
            for (int d = ot; ; d++) // бежим от 1000 до бесконечности пока условие не выполнится
            {
                if ((d * e) % f == 1) // d * 5 % 12 = 1 при d = 5
                {
                    return d;
                }
            }
        }
        //
        
        public string Encription(string m, double e, int n)
        {
            // [e,n] - открытый ключ
            // C = (m^e) mod n;
            string c = "";
            for (int i = 0; i < m.Length; i++)
            {
                c += (char)(int)BigInteger.ModPow((int)m[i], (int)e,n);
            }
            
            return c;
        }
        

        public string Decription(string c, double d, int n)
        {
            // [d,n] - закрытый ключ
            // m = (c^d) mod n;
            string  m = "";
            for (int i = 0; i < c.Length; i++)
            {
                m += (char)(int)BigInteger.ModPow((int)c[i], (int)d, n);
            }
            
            return m;
        }
    }
}
