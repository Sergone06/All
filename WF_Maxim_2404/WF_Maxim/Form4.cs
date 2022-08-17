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
    public partial class Form4 : Form
    {
        int Pol_PO;
        Random Rand = new Random();
        TekTest TT = new TekTest();
        //
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            
            label1.Visible = true;
            for (int i = 1; i <= 4; i++)
            {
                Controls["button" + i].Visible = true;
            }
            ZapuskTesta();
        }
        //
        private void ZapuskTesta()
        {
            for (int i = 1; i <= 4; i++)
            {
                Controls["button" + i].BackColor = BackColor;
            }
            //
            int VariantTesta = Rand.Next(0, 2);
            if (VariantTesta == 0)
            {
                TT.TEST_sravnenie();
                label1.Text = TT.Virag;
                Pol_PO = TT.Pol_PO;
                int sch_NO = 0; // счетчик для перебора неправильных ответов
                for (int i = 1; i <= 4; i++)
                {
                    if (TT.Pol_PO == i)
                    {
                        Controls["button" + i].Text = TT.PO_sravnenie.ToString();
                    }
                    else
                    {
                        Controls["button" + i].Text = TT.NePO_sravnenie[sch_NO].ToString();
                        sch_NO++;
                    }
                }
            }
            else
            {
                TT.TEST();
                //
                label1.Text = TT.Virag;
                Pol_PO = TT.Pol_PO;
                for (int i = 1; i <= 4; i++)
                {
                    if (TT.Pol_PO == i)
                    {
                        Controls["button" + i].Text = TT.PO.ToString();
                    }
                    else
                        Controls["button" + i].Text = Rand.Next(0, 100).ToString();
                }
            }
        }
        //
        private void button2_Click(object sender, EventArgs e)
        {
            if (Pol_PO == 2)
            {
                button2.BackColor = Color.Green;
                System.Threading.Thread.Sleep(500);
                ZapuskTesta();
            }
            else
                button2.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pol_PO == 1)
            {
                button1.BackColor = Color.Green;
                System.Threading.Thread.Sleep(500);
                ZapuskTesta();
            }
            else
                button1.BackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Pol_PO == 3)
            {
                button3.BackColor = Color.Green;
                System.Threading.Thread.Sleep(500);
                ZapuskTesta();
            }
            else
                button3.BackColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Pol_PO == 4)
            {
                button4.BackColor = Color.Green;
                System.Threading.Thread.Sleep(500);
                ZapuskTesta();
            }
            else
                button4.BackColor = Color.Red;
        }
    }
}
