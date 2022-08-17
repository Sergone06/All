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
    public partial class Test2class : Form
    {
        int i = 0;
        public Test2class()
        {
            InitializeComponent();
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
        }
        Random random = new Random();
        private void Test2class_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public int KZ()
        {
            int k = Convert.ToInt32(textBox1.Text);
            return(k);
        }
        public int KO()
        {
            Random random = new Random();
            int KO = random.Next(2, 5);
            return (KO);
        }
        public string OPER()
        {
            Random op = new Random();
            int ope = op.Next(0,1);
            string oper;
            if (ope == 1)
            {
                oper = "+";
            }
            else oper = "-";
            return (oper);
        }
        public int chisla()
        {
            Random ch = new Random();
            int mc;
                mc = ch.Next(100);
            
            return (mc);
        }
        int Po;
        string vir;
        public string virag()
        {
            do
            {

                vir = Convert.ToString(chisla());
                int[] Ch = new int[KO()];
                string[] Op = new string[KO() - 1];
                int[] O = new int[Op.Length];

                for (int i = 0; i < Op.Length; i++)
                {
                    O[i] = random.Next(0, 2);
                    if (O[i] == 1)
                    {
                        Op[i] = "+";
                    }
                    else Op[i] = "-";
                }
                for (int i = 0; i < KO(); i++)
                {
                    Ch[i] = random.Next(100);
                }
                vir = Convert.ToString(Ch[0]);
                Po = Ch[0];
                for (int i = 0; i < KO() - 1; i++)
                {
                    vir += Op[i] + Ch[i + 1];
                    if (Op[i] == "+")
                    {
                        Po += Ch[i + 1];
                    }
                    else Po -= Ch[i + 1];
                }
                
            } while (Po < 0);
            return (vir);

        }
        public int KK()
        {
            int k = random.Next(2, 5);
            for (int i = 2; i < k+1; i++)
            {
                switch (i)
                {
                    case 2: button3.Visible = false;
                        button4.Visible = false;
                        break;
                    case 3: button4.Visible = false;
                        button3.Visible = true;
                        break;
                    default: button3.Visible = true;
                        button4.Visible = true;
                        break;
                }
            }
            return (k);
        }
        public int PPO()
        {
            int PPO = random.Next(1, KK()+1);
            return (PPO);
        }
        public void Metod()
        {
            
            label5.Text = virag();
            
            
            int ppo = PPO();
            for (int i = 1; i < 5; i++)
            {
                if (i != ppo)
                {
                    switch (i)
                    {
                        case 1:
                            
                            
                                button1.Text = Convert.ToString(random.Next(Po - 20, Po + 20));
                            
                            
                                break;
                        case 2:
                            
                            
                                button2.Text = Convert.ToString(random.Next(Po - 20, Po + 20));
                            
                            
                                break;
                        case 3:
                            
                            
                                button3.Text = Convert.ToString(random.Next(Po - 20, Po + 20));
                            
                            
                                break;
                        default:
                            
                            
                                button4.Text = Convert.ToString(random.Next(Po - 20, Po + 20));
                            
                            
                                break;
                    }
                    
                }
                else
                {
                    switch (ppo)
                    {
                        case 1:
                            button1.Text = Convert.ToString(Po);
                            break;
                        case 2:
                            button2.Text = Convert.ToString(Po);
                            break;
                        case 3:
                            button3.Text = Convert.ToString(Po);
                            break;
                        default:
                            button4.Text = Convert.ToString(Po);
                            break;
                    }
                }
            }
            label3.Text = Convert.ToString(KPO);
            label7.Text = Convert.ToString(KNPO);
            label6.Text = Convert.ToString(i + 1);
            i++;
        }
        int KPO = 0;
        int KNPO = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (label6.Text == textBox1.Text & button1.Text == Convert.ToString(Po))
            {
                KPO++;
                button1.BackColor = Color.Green;
                timer2.Start();
                return;
            }
            else if (label6.Text == textBox1.Text & button1.Text != Convert.ToString(Po))
            {
                KNPO++;
                button1.BackColor = Color.Red;
                timer2.Start();
                return;
            }
            if (button1.Text == Convert.ToString(Po))
            {
                KPO++;
                button1.BackColor = Color.Green;
                timer3.Start();
            }
            else
            {
                KNPO++;
                button1.BackColor = Color.Red;
                timer3.Start();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label6.Text == textBox1.Text & button2.Text == Convert.ToString(Po))
            {
                KPO++;
                button2.BackColor = Color.Green;
                timer2.Start();
                return;
            }
            else if (label6.Text == textBox1.Text & button2.Text != Convert.ToString(Po))
            {
                KNPO++;
                button2.BackColor = Color.Red;
                timer2.Start();
                return;
            }
            if (button2.Text == Convert.ToString(Po))
            {
                KPO++;
                button2.BackColor = Color.Green;
                timer3.Start();
            }
            else
            {
                KNPO++;
                button2.BackColor = Color.Red;
                timer3.Start();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label6.Text == textBox1.Text & button3.Text == Convert.ToString(Po))
            {
                KPO++;
                button3.BackColor = Color.Green;
                timer2.Start();
                return;
            }
            else if (label6.Text == textBox1.Text & button3.Text != Convert.ToString(Po))
            {
                KNPO++;
                button3.BackColor = Color.Red;
                timer2.Start();
                return;
            }
            if (button3.Text == Convert.ToString(Po))
            {
                KPO++;
                button3.BackColor = Color.Green;
                timer3.Start();
            }
            else
            {
                KNPO++;
                button3.BackColor = Color.Red;
                timer3.Start();
            }
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label6.Text == textBox1.Text & button4.Text == Convert.ToString(Po))
            {
                KPO++;
                button4.BackColor = Color.Green;
                timer2.Start();
                return;
                
            }
            else if (label6.Text == textBox1.Text & button4.Text != Convert.ToString(Po))
            {
                KNPO++;
                button4.BackColor = Color.Red;
                timer2.Start();
                return;
                
            }
            if (button4.Text == Convert.ToString(Po))
            {
                KPO++;
                button4.BackColor = Color.Green;
                timer3.Start();
                
            }
            else
            {
                KNPO++;
                button4.BackColor = Color.Red;
                timer3.Start();
                
            }
        }
        public void Rezult()
        {
            Form3 Rez = new Form3();
            
            double z = Convert.ToInt32(textBox1.Text);
            double p = (KPO / z) * 100;
            int o;
            if (p >= 70)
            {
                if (p <= 90)
                {
                    o = 4;
                }
                else o = 5;
            }
            else
            {
                if (p <= 40)
                {
                    o = 2;
                }
                else o = 3;
            }
            timer2.Stop();
            MessageBox.Show("Процент правильных ответов: " + p + "%" + "\nОценка: " + o);

            Close();
            
        }
        public void Restart()
        {
            Test2class test = new Test2class();
            test.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button5.Visible = false;
            label9.Visible = true;
            textBox1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Metod();
            
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = false;
            timer1.Stop();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Rezult();
            
            
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Metod();
            
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            timer3.Stop();
        }
    }
}
