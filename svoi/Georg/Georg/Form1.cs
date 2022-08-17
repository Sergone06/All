using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Georg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ALF = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";            // Алфавит с кириллицей
        string chisla = "0123456789";                                // Алфавит цифр
        // Шифровка в общем
        private void button1_Click(object sender, EventArgs e)
        {
            string alf = ALF.ToLower();      // Создаем алфавит прописных букв путем снижения региста алфавита заглавных букв
            string Vhstr = textBox1.Text;    // Переменная с введенным пользователем текстом
            // Проверка на пустую строку
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Символы не введенены!");
                return;
            }
            // Проверка на неверные символы
            bool bill = true;
            for (int i = 0; i < Vhstr.Length; i++)
            {
                if ( bill & (ALF.IndexOf(Vhstr[i].ToString()) < 0 & alf.IndexOf(Vhstr[i].ToString()) < 0 & chisla.IndexOf(Vhstr[i].ToString()) < 0))
                {
                    MessageBox.Show("Не все символы введены верно!\nСимволы, введенные неверно, будут пропущены.");
                    bill = false;
                }
            }
            string Atb = Atbash(Vhstr);     // Шифровка Атбаш
            textBox2.Text = Atb;            // Вывод промежуточного результата (Шифр Атбаш)
            //------------------------------------------------------------
            string Binary = "";      // Пустая строка для двоичного кода текста
            // Шифровка в двоичный код и расстановка пробелов
            for (int i = 0; i < Atb.Length; i++)
            {
                Binary += Dvoich(Atb[i]) + " ";
            }
            // Вывод двоичного кода и удаление последнего пробела
            textBox3.Text = Binary.Remove(Binary.Length - 1);
        }
        // Шифрует и дешифрует в Атбаш
        public string Atbash(string Vhstr)
        {
            string alf = ALF.ToLower();
            string Atbash = "";
            for (int i = 0; i < Vhstr.Length; i++)
            {
                if (ALF.IndexOf(Vhstr[i].ToString()) >= 0)
                {
                    Atbash += ALF[Obratn(ALF).IndexOf(Vhstr[i])];
                }
                else if (alf.IndexOf(Vhstr[i].ToString()) >= 0)
                {
                    Atbash += alf[Obratn(alf).IndexOf(Vhstr[i])];
                }
                else if (chisla.IndexOf(Vhstr[i].ToString()) >= 0)
                {
                    Atbash += chisla[Obratn(chisla).IndexOf(Vhstr[i])];
                }
            }
            return Atbash;
        }
        // "Переворачивает" строку
        public string Obratn(string alf)
        {
            char[] arr = alf.ToCharArray();
            Array.Reverse(arr);
            string fla = new string(arr);
            return fla;
        }
        // Шифрует символ в двоичный код
        public string Dvoich(char simbol)
        {
            string Kod = "";
            int K = (int)simbol;
            while (K != 0 & K != 1)
            {
                Kod += (K % 2).ToString();
                K = K / 2;
                if (K == 1 || K == 0)
                {
                    Kod += K.ToString();
                }
            }
            return Obratn(Kod);
        }
        // Дешифровка в общем
        private void button2_Click(object sender, EventArgs e)
        {
            string alf = ALF.ToLower();      // Создаем алфавит прописных букв путем снижения региста алфавита заглавных букв
            string VHstr = textBox4.Text;    // Строка с текстом двоичного кода
            string Atb = "";                 // Создаем пустую строку для дешифрованного текста
            // Проверка на пустую строку
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Символы не введенены!");
                return;
            }
            // Дешифрует из двоичного в атбаш
            for (int i = 0; i < VHstr.Split(' ').Length; i++)
            {
                // Проверяет двочиные коды на длинну, должна быть 11 или 6 символов
                if (VHstr.Split(' ')[i].Length != 11 && VHstr.Split(' ')[i].Length != 6)
                {
                    MessageBox.Show("Введены неверные символы!");
                    return;
                }
                // Проверяет есть ли в строке что то кроме 0 и 1
                for (int j = 0; j < VHstr.Split(' ')[i].Length; j++)
                {
                    if (VHstr.Split(' ')[i][j] != '0' && VHstr.Split(' ')[i][j] != '1')
                    {
                        MessageBox.Show("Введены неверные символы!");
                        return;
                    }
                }
                Atb += (char)DeD(VHstr.Split(' ')[i]);
            }
            textBox5.Text = Atb;
            //Дешифрует из атбаш в исходный текст
            textBox6.Text = Atbash(Atb);
        }
        // Дешифрует один символ из двоичного кода
        public int DeD(string simbol)
        {
            simbol = Obratn(simbol);
            int number = 0;
            for (int i = 0; i < simbol.Length; i++)
            {
                number += Convert.ToInt32(Convert.ToInt32(simbol[i].ToString()) * Math.Pow(2, i));
            }
            return number;
        }
        // Переносит текст из 3 в 4 текстбокс
        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox3.Text;
        }
        string filename; // Переменная с именем файла
        // Открытие текста для шифровки
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            textBox1.Text = TEXT;
        }
        // Открытие файла для расшифровки
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.Cancel) return;
            filename = OFD.FileName;
            string TEXT = System.IO.File.ReadAllText(filename);
            textBox4.Text = TEXT;
        }
       
        // Сохранить файл из шифровки атбаш
        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text file(*.txt)|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, textBox2.Text);
            }
        }
        // Сохранить файл из шифровки двоичный код
        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text file(*.txt)|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, textBox3.Text);
            }
        }
        // Сохранить файл из расшифровки атбаш
        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text file(*.txt)|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, textBox5.Text);
            }
        }
        // Сохранить файл из расшифровки двоичный код
        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text file(*.txt)|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                System.IO.File.WriteAllText(filename, textBox6.Text);
            }
        }
    }
}
