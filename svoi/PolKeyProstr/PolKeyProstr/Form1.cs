using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolKeyProstr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int l = 15;
        char[,] Mas1 = new char[15, 15];
        char[,] Mas2 = new char[15, 15];
        char[,] Mas3 = new char[15, 15];
        int k = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //l40, l71 
            Random rand = new Random();                        
            string VhStr = textBox1.Text;
            VhStr = VhStr.ToUpper();
            VhStr = VhStr.Replace(" ","");
            VhStr = VhStr.Replace(",", "");
            VhStr = VhStr.Replace(".", "");
            VhStr = VhStr.Replace("?", "");
            VhStr = VhStr.Replace("!", "");
            label1.Text = "";
            label2.Text = "";
            int dlinna = VhStr.Length;
            bool PRo;
            if (VhStr.Length > 20 && VhStr.Length < 38)
            {
                if (dlinna % 2 == 1)
                {
                    dlinna = (dlinna / 2) + 1;
                }
                else
                {
                    dlinna /= 2;
                }
            }
            else if (VhStr.Length > 37 && VhStr.Length < 50)
            {
                if (dlinna % 3 == 1)
                {
                    dlinna = (dlinna / 3) + 1;
                }
                else if (dlinna % 3 == 2)
                {
                    dlinna = (dlinna / 3) + 1;
                }
                else
                {
                    dlinna = dlinna / 3;
                }
            }
            else if (VhStr.Length > 49 && VhStr.Length < 63)
            {
                if (dlinna % 4 == 1)
                {
                    dlinna = (dlinna / 4) + 1;
                }
                else if (dlinna % 4 == 2)
                {
                    dlinna = (dlinna / 4) + 1;
                }
                else if (dlinna % 4 == 3)
                {
                    dlinna = (dlinna / 4) + 1;
                }
                else
                {
                    dlinna = dlinna / 4;
                }
            }
            else if (VhStr.Length > 62)
            {
                MessageBox.Show("Введено слишком много символов!");
                return;
            }
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Mas1[i, j] = (char)rand.Next(1040, 1072);
                }
            }
            int n = 0;
            do
            {
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        Mas2[i, j] = '1';
                    }
                }
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        int Shans = rand.Next(0, 6);
                        if (Shans == 1 & n < dlinna)
                        {
                            Mas2[i, j] = '0';
                            n++;
                        }
                    }
                }
                PRo = false;
                for (int i = 0; i < VhStr.Length / dlinna + 1; i++)
                {
                    PRo = Proverka();
                    if (PRo)
                    {
                        break;
                    }
                    Perever();
                }
            } while (n < dlinna & PRo);// & на ||
            label1.Text = "";
            label2.Text = "";
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    label1.Text += Mas1[i, j];
                    label2.Text += Mas2[i, j];
                }
                label1.Text += '\n';
                label2.Text += '\n';
            }
            k = 0;
            for (int i = 0; i < 4; i++)
            {
                Zapolnenie(VhStr);
            }
            
        }
        public bool Proverka()
        {
            char[,] Mas4 = new char[l, l];
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Mas4[i, j] = Mas2[i, j];
                }
            }
            int n = 0;
            for (int g = 0; g < 4; g++)
            {
                Perever();
                
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        if (Mas4[i, j] == '0' && Mas2[i, j] == '0')
                        {
                            return true;
                        }
                        if (Mas4[i,j] == '0')
                        {
                            n++;
                        }
                    }
                }
            }
            if (n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Zapolnenie(string Vhstr)
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (Mas2[i, j] == '0' && k < Vhstr.Length)
                    {
                        Mas1[i, j] = Vhstr[k];
                        k++;
                    }
                }
            }
            
            Perever();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (Mas2[i,j] == '1')
                    {
                        label3.Text += "_ ";
                    }
                    else
                    {
                        label3.Text += Mas1[i, j].ToString();
                    }
                }
                label3.Text += '\n';
            }
        }
        public void Perever()
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Mas3[j, 14 - i] = Mas2[i, j];
                }
            }
            label2.Text = "";
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Mas2[i, j] = Mas3[i, j];
                    label2.Text += Mas2[i,j].ToString();
                }
                label2.Text += '\n';
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /*
            1234533123    00 - 09 | 01 - 19 | 
            4325235123    l - 08 | 11 - 81 | 
            2353253123    20 - 07 | 
            2353253123
            2353253123
            2353253123
            2353253123    60 - 03
            2353253123    70 - 02 |
            2353253123    80 - 01 | 
            2353253123    90 - 00 | 
             */
            Perever();
        }
    }
}
