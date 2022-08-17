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
    public partial class Form5 : Form
    {        
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // сформировать ОПЗ
            // 1) Представим инфексную запись в виде массива элементов
            OPZ[] mas_El = new OPZ[100];
            // заполним массив на основе анализа строки
            string VhStr = textBox1.Text;
            //     "5+2*(8-4/2)"
            for (int i = 0; i < VhStr.Length; i++)
            {
                mas_El[i] = new OPZ();
                mas_El[i].Add( VhStr[i].ToString() ); // заполняет свойства объекта masOPZ[i]
            }
            // 2) Представим ОПЗ 
            CreateOPZ(mas_El);
        }
        //
        private void CreateOPZ(OPZ[] mas_El)
        {
            OPZ[] mas_El_OPZ = new OPZ[100]; // выходная строка
            int schElOPZ=0; // счетчик элементов ОПЗ
            Stack<OPZ> Stek = new Stack<OPZ>();
            //"5+2*(8-4/2)"
            for (int i = 0; i < mas_El.Length; i++)
            {
                if (mas_El[i] == null) continue;
                if (mas_El[i].operacia == "ch")  // если число
                {
                    // Правило 4 - добавляем в выходную строку 
                    mas_El_OPZ[schElOPZ] = new OPZ();
                    mas_El_OPZ[schElOPZ] = mas_El[i];
                    schElOPZ++;
                }
                else // если не число
                {
                    if (Stek.Count == 0)
                    { // если стек пустой, то добавляем операцию в стек
                        Stek.Push(mas_El[i]);
                    }
                    else if (mas_El[i].operacia == "(") 
                    { // Правило 2 - заносим в стек
                        Stek.Push(mas_El[i]);
                    }
                    else if(mas_El[i].operacia == ")")
                    {
                        // Правило 3 - извлекаем из стека все операции до ")"
                        do
                        {
                            mas_El_OPZ[schElOPZ] = new OPZ();
                            mas_El_OPZ[schElOPZ] = Stek.Pop();
                            schElOPZ++;                             
                        } // пока не встретится открывающаяся скобка
                        while ( Stek.Peek().operacia != "("  );
                        Stek.Pop();
                    }               
                    else if(mas_El[i].rang > Stek.Peek().rang)
                    {  // Правило 5.1 Если ранг рассматриваемой операции больше
                       //  ранга последней операции в стеке, то добавляем в стек 
                        Stek.Push(mas_El[i]);
                    }
                    else
                    { // если ранг рассматриваемой операции <= ранга последней
                      // операции в стеке
                      // правило 5.2 - извлекаем из стека все операции до тех пор,
                      // пока не встретим операцию в стеке, ранг которой < ранга
                      // рассматриваемой операции mas_El[i]
                        do
                        {
                            mas_El_OPZ[schElOPZ] = new OPZ();
                            mas_El_OPZ[schElOPZ] = Stek.Pop();
                            schElOPZ++;
                            if (Stek.Count == 0)
                            {
                                break;
                            }
                        }
                        // извлекаем из стека пока стек не станет пустым или пока 
                        // выполняется условие (mas_El[i].rang <= Stek.Peek().rang)
                        while ((Stek.Count != 0) | (mas_El[i].rang <= Stek.Peek().rang));
                        // а теперь добавим в стек рассматриваемую операцию
                        Stek.Push(mas_El[i]);
                    }
                }
            }
            // Правило 6 - конец "строки", извлекаем из стека оставшиеся элементы
            while (Stek.Count != 0)
            {
                mas_El_OPZ[schElOPZ] = new OPZ();
                mas_El_OPZ[schElOPZ] = Stek.Pop();

                schElOPZ++;
            }
            // "Выходная строка" готова, она хранится в  mas_El_OPZ
            // выведем на экран получившуюся строку
            textBox2.Text = "";
            for (int i = 0; i < mas_El_OPZ.Length; i++)
            {
                if (mas_El_OPZ[i] == null) continue;            // (условие) ? (если иситна) : (если ложь)
                textBox2.Text = textBox2.Text + ((mas_El_OPZ[i].operacia == "ch") ? mas_El_OPZ[i].operand.ToString() : mas_El_OPZ[i].operacia);
            }

        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            textBox1.Text = "5+2*(8-4/2)";
        }
    }
}
