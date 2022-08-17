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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string Zhel = "";
        List<int> Zero = new List<int> { -1 };
        private void button1_Click(object sender, EventArgs e)
        {
            string Chis = textBox1.Text;
            string Znam = textBox2.Text;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Заполните графы числитель и знаменатель!");
                return;
            }
            Chis = Chis.Replace("x", "").Replace("^", "");
            int[] Chis1 = new int[Chis.Split('+').Length];
            int j = 0;
            foreach (var i in Chis.Split('+'))
            {
                if (i == "1")
                {
                    Chis1[j] = 0;
                    j++;
                }
                else if (i == "")
                {
                    Chis1[j] = 1;
                    j++;
                }
                else
                {
                    Chis1[j] = Convert.ToInt32(i);
                    j++;
                }
            }
            Znam = Znam.Replace("x", "").Replace("^", "");
            int[] Znam1 = new int[Znam.Split('+').Length];
            j = 0;
            foreach (var i in Znam.Split('+'))
            {
                if (i == "1")
                {
                    Znam1[j] = 0;
                    j++;
                }
                else if (i == "")
                {
                    Znam1[j] = 1;
                    j++;
                }
                else
                {
                    Znam1[j] = Convert.ToInt32(i);
                    j++;
                }
            }
            textBox3.Text = "";
            textBox4.Text = "";
            List<int> lal = new List<int>(Chis1);
            while (lal[0] != -1)
            {
                lal = Chet(lal, Znam1);
            }
        }
        public List<int> Chet(List<int> Chis, int[] Znam)
        {
            int raz;
            raz = Convert.ToInt32(Chis.Max()) - Convert.ToInt32(Znam.Max());
            List<int> vrem = new List<int>();
            string str = "";
            if (raz < 0)
            {
                for (int i = 0; i < Chis.Count; i++)
                {
                    vrem.Add(Chis[i]);
                }
                foreach (var item in vrem)
                {
                    if (item == 0)
                    {
                        str += 1 + "+";
                    }
                    else if (item == 1)
                    {
                        str += "x" + "+";
                    }
                    else
                        str += "x" + "^" + item + "+";
                }
                textBox4.Text = str.Remove(str.Length - 1);
                textBox3.Text = Zhel.Remove(Zhel.Length - 1);
                Zhel = "";
                return Zero;
            }
            if (raz == 1)
            {
                Zhel += "x" + "+";
            }
            else if (raz == 0)
            {
                Zhel += "1" + "+";
            }
            else
                Zhel += "x" + "^" + raz.ToString() + "+";
            
            for (int i = 0; i < Znam.Length; i++)
            {
                vrem.Add(Convert.ToInt32(Znam[i].ToString()) + raz);
            }
            for (int i = 0; i < Chis.Count; i++)
            {
                vrem.Add(Chis[i]);
            }

            for (int i = 0; i < vrem.Count; i++)
            {
                for (int j = 0; j < vrem.Count; j++)
                {
                    if (i >= vrem.Count || j >= vrem.Count)
                    {
                        break;
                    }
                    if ((vrem[i] == vrem[j]) && (i != j) )
                    {
                        if (i > j)
                        {
                            vrem.RemoveAt(i);
                            vrem.RemoveAt(j);
                        }
                        else
                        {
                            vrem.RemoveAt(j);
                            vrem.RemoveAt(i);
                        }
                        i = 0;
                        j = 0;
                        
                    }
                }
            }
            if (vrem.Count == 0)
            {
                textBox4.Text = "0";
                textBox3.Text = Zhel.Remove(Zhel.Length - 1);
                Zhel = "";
                return Zero;
            }
            return vrem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "x^";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text += "x^";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text += "x^";
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text += "x^";
        }
    }
}
