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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string ALF = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";

        public char Table(int b, int a = 129, char c = ' ', int d = 129)
        {
            char[,] TableVigen = new char[ALF.Length, ALF.Length];
            int s = 0;
            for (int i = 0; i < ALF.Length; i++)
            {
                for (int j = 0; j < ALF.Length; j++)
                {
                    TableVigen[i, j] = ALF[(j + s) % ALF.Length];
                }
                s++;
            }
            if (a != 129)
            {
                return TableVigen[a, b];
            }
            else
            {
                for (int i = 0; i < ALF.Length; i++)
                {
                    if (TableVigen[i, b] == c)
                    {
                        return ALF[i];
                    }
                }
            }
            return '_';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string VH = textBox1.Text;
            string KL = textBox3.Text;
            int[] PKL = new int[VH.Length + 1];
            string VIH = "";
            KL = KL.Replace(" ", "").ToUpper();
            bool ER = false;
            for (int i = 0; i < KL.Length; i++)
            {
                if (ALF.IndexOf(KL[i]) >= 0)
                {
                    ER = true;
                }
                else
                {
                    ER = false;
                    break;
                }
            }
            if (textBox3.Text.Length != 0 && textBox1.Text.Length != 0 && ER)
            {
                for (int i = 0; i < VH.Length + 1; i++)
                {
                    if (i < KL.Length)
                    {
                        if (ALF.IndexOf(KL[i]) >= 0)
                        {
                            PKL[i] = ALF.IndexOf(KL[i]);
                        }
                    }
                    else PKL[i] = PKL[i - KL.Length];
                   
                }
                int s = 0;
                for (int i = 0; i < VH.Length; i++)
                {
                    
                    if (ALF.IndexOf(VH[i]) >= 0)
                    {
                        VIH += Table(a: ALF.IndexOf(VH[i]), b: PKL[s]);
                        s++;
                    }
                    else
                    {
                        VIH += VH[i];
                    }
                }
                textBox2.Text = VIH;
            }
            else
            {
                MessageBox.Show("Ошибка: Поля: \"Расшифрованное сообщение\" и/или \"Ключ\" не заполненны или заполненны неверно. \n Пожалуйста, проверьте правильность заполнения поля \"Ключ\", а именно: в поле не могут находиться знаки препинания, цифры или любые другие символы, кроме строчных и заглавный букв кириллицы или английского алфавита.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string VH = textBox2.Text;
            string KL = textBox3.Text;
            int[] PKL = new int[VH.Length + 1];
            string VIH = "";
            KL = KL.Replace(" ", "").ToUpper();
            bool ER = false;
            for (int i = 0; i < KL.Length; i++)
            {
                if (ALF.IndexOf(KL[i]) >= 0)
                {
                    ER = true;
                }
                else
                {
                    ER = false;
                    break;
                }
            }
            if (textBox3.Text.Length != 0 && textBox2.Text.Length != 0 && ER)
            {
                for (int i = 0; i < VH.Length + 1; i++)
                {
                    if (i < KL.Length)
                    {
                        if (ALF.IndexOf(KL[i]) >= 0)
                        {
                            PKL[i] = ALF.IndexOf(KL[i]);
                        }
                    }
                    else PKL[i] = PKL[i - KL.Length];

                }
                int s = 0;
                for (int i = 0; i < VH.Length; i++)
                {
                    if (ALF.IndexOf( VH[i] ) >= 0)
                    {
                        VIH += Table(b: PKL[s], c: (char)VH[i]);
                        s++;
                    }
                    else
                    {
                        VIH += VH[i];
                    }
                }
                textBox1.Text = VIH;
            }
            else
            {
                MessageBox.Show("Ошибка: Поля: \"Зашифрованное сообщение\" и/или \"Ключ\" не заполненны или заполненны неверно. \n Пожалуйста, проверьте правильность заполнения поля \"Ключ\", а именно: в поле не могут находиться знаки препинания, цифры или любые другие символы, кроме строчных и заглавный букв кириллицы или английского алфавита.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        string filename;
        private void ключToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            textBox3.Text = TEXT.Replace("Ключ: ", "");
        }

        private void зашифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            textBox2.Text = TEXT.Replace("Зашифрованное сообщение: ", "");
        }

        private void расшифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            textBox1.Text = TEXT.Replace("Расшифрованное сообщение: ", "");
        }

        private void сохранитьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Vigenère code(*.vig)|*.vig";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Ключ: " + textBox3.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void сохранитьЗашифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Vigenère code(*.vig)|*.vig";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Зашифрованное сообщение: " + textBox2.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void сохранитьРасшифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Vigenère code(*.vig)|*.vig";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Расшифрованное сообщение: " + textBox1.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void сохранитьКлючЗашифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Vigenère code(*.vig)|*.vig";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Ключ: " + textBox3.Text + "\nЗашифрованное сообщение: " + textBox2.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void ключЗашифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            string KL = TEXT.Replace("Ключ: ", "").Replace("\nЗашифрованное сообщение: ", ";");
            textBox2.Text = KL.Split(';')[1];
            textBox3.Text = KL.Split(';')[0];
        }

        private void сохранитьКлючРасшифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Vigenère code(*.vig)|*.vig";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Ключ: " + textBox3.Text + "\nРасшифрованное сообщение: " + textBox1.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void ключРасшифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            string KL = TEXT.Replace("Ключ: ", "").Replace("\nРасшифрованное сообщение: ", ";");
            textBox1.Text = KL.Split(';')[1];
            textBox3.Text = KL.Split(';')[0];
        }

        private void сохранитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Vigenère code(*.vig)|*.vig";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, "Ключ: " + textBox3.Text + "\nРасшифрованное сообщение: " + textBox1.Text + "\nЗашифрованное сообщение: " + textBox2.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void всёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            string KL = TEXT.Replace("Ключ: ", "").Replace("\nРасшифрованное сообщение: ", ";").Replace("\nЗашифрованное сообщение: ", ";");
            textBox1.Text = KL.Split(';')[1];
            textBox2.Text = KL.Split(';')[2];
            textBox3.Text = KL.Split(';')[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Replace(" ", "");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string F = textBox1.Text;
            for (int i = 0; i < F.Length; i++)
            {
                if (F[i] == ' ')
                {
                }
                else if (ALF.IndexOf(F[i]) < 0)
                {
                    F = F.Replace(F[i].ToString(),"");
                    i--;
                }
            }
            textBox1.Text = F;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string F = textBox2.Text;
            for (int i = 0; i < F.Length; i++)
            {
                if (F[i] == ' ')
                {
                }
                else if (ALF.IndexOf(F[i]) < 0)
                {
                    F = F.Replace(F[i].ToString(), "");
                    i--;
                }
            }
            textBox2.Text = F;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Replace("\n", "");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace("\n", "");
        }
    }
}
