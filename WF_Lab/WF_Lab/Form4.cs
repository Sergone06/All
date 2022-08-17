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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // сформировать ОПЗ
            // 1) Представим инфиксную запись в виде массива элементов
            OPZ[] masOPZ = new OPZ[100];
            // заполним массив на основе анализа строки
            string VhStr = textBox1.Text;
            string[] vs = new string[100];
            List<String> Vs = new List<string>();
            string[] VS = new string[100];
            string CH = "0123456789";
            int a = 0;
            for (int i = 0; i < VhStr.Length; i++)
            {
                if (CH.IndexOf(VhStr[i]) >= 0)
                {
                    while ((i != VhStr.Length) && (CH.IndexOf(VhStr[i]) >= 0))
                    {
                        VS[a] += VhStr[i];

                        i++;
                    }
                    a++;
                    i--;
                }
                else
                {
                    VS[a] = (VhStr[i].ToString());
                    a++;
                }
            }
            for (int i = 0; i < VS.Length; i++)
            {
                if (VS[i] == null)
                {
                    continue;
                }
                masOPZ[i] = new OPZ();
                masOPZ[i].Add(VS[i]);
            }
            // 2) Представим ОПЗ 
            CreateOPZ(masOPZ);
            // 3) Посчитаем
            
        }
        private void CreateOPZ(OPZ[] masOPZ)
        {
            OPZ[] mas_EL_OPZ = new OPZ[100]; // выходная строка
            int schELOPZ = 0;
            Stack<OPZ> Stek = new Stack<OPZ>();
            for (int i = 0; i < masOPZ.Length; i++)
            {
                if (masOPZ[i] == null)
                {
                    continue;
                }
                if (masOPZ[i].operacia == "ch")
                {
                    // Правило 4 - добавляем в выходную строку
                    mas_EL_OPZ[schELOPZ] = new OPZ();
                    mas_EL_OPZ[schELOPZ] = masOPZ[i];
                    schELOPZ++;
                }
                else // если не число
                {
                    if (Stek.Count == 0)
                    {// если стек пустой, то добавляем опреацию в стек
                        Stek.Push(masOPZ[i]);
                    }
                    else if (masOPZ[i].operacia == "(")
                    { // правило 2
                        Stek.Push(masOPZ[i]);
                    }
                    else if (masOPZ[i].operacia == ")")
                    {
                        // 3 правило - извлекаем из стека все операции до "("
                        while (Stek.Peek().operacia != "(")
                        {
                            mas_EL_OPZ[schELOPZ] = new OPZ();
                            mas_EL_OPZ[schELOPZ] = Stek.Pop();
                            schELOPZ++;
                        }
                        Stek.Pop();
                    }

                    else if (masOPZ[i].rang > Stek.Peek().rang)
                    {// правило 5.1
                        Stek.Push(masOPZ[i]);
                    }
                    else
                    { // если ранг рассм операции меньше чем ранг рассм операции в стеке
                      // правило 5.2 - извлекаем из стека все операции до тех пор, пока не встреитм операцию в стекее ранг которой < ранга рассм. опреации mas_EL[i]

                        while ((masOPZ[i].rang <= Stek.Peek().rang))
                        {
                            mas_EL_OPZ[schELOPZ] = new OPZ();
                            mas_EL_OPZ[schELOPZ] = Stek.Pop();
                            schELOPZ++;
                            if (Stek.Count == 0)
                            {
                                break;
                            }
                        } 
                        // а теперь добавим в стек рассм операцию
                        Stek.Push(masOPZ[i]);
                    }
                }
            }
            // правило 6 - извлекает из стека оставшиеся элементы
            while (Stek.Count != 0)
            {
                mas_EL_OPZ[schELOPZ] = new OPZ();
                mas_EL_OPZ[schELOPZ] = Stek.Pop();
                schELOPZ++;
            }
            // выходная строка готова, она хранится в mas_EL_OPZ
            // выведем на экран получившеюся строку
            label5.Text = "";
            for (int i = 0; i < schELOPZ; i++)
            {
                label5.Text = label5.Text + ((mas_EL_OPZ[i].operacia == "ch") ? mas_EL_OPZ[i].operand.ToString() : mas_EL_OPZ[i].operacia) + " ";
            }
            double result = Rezult(mas_EL_OPZ);
            label4.Text = result.ToString();
        }
        /*static private string CreateOPZ(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                //Разделители пропускаем
                if (IsDelimeter(input[i]))
                    continue; //Переходим к следующему символу

                //Если символ - цифра, то считываем все число
                if (Char.IsDigit(input[i])) //Если цифра
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу

                        if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                    }

                    output += " ";
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }

                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {
                    if (input[i] == '(') //Если символ - открывающая скобка
                        operStack.Push(input[i]); //Записываем её в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + " ";
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) //Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output; //Возвращаем выражение в постфиксной записи
        
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }
        static private double Counting(string input)
        {
            double result = 0; //Результат
            Stack<double> temp = new Stack<double>(); 

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }*/
        public double Rezult(OPZ[] OPZ)
        {
            double rez = 0;
            Stack<string> VIS = new Stack<string>();
            for (int i = 0; i < OPZ.Length; i++)
            {
                if (OPZ[i] == null)
                {
                    continue;
                }
                if ((VIS.Count != 0) & ("+-*/".IndexOf(OPZ[i].operacia) >= 0))
                {
                    double a, b;
                    switch (OPZ[i].operacia)
                    {
                        case "+":
                            a = (Convert.ToDouble(VIS.Pop()));
                            b = (Convert.ToDouble(VIS.Pop()));
                            VIS.Push((b + a).ToString());
                            break;
                        case "-":
                            a = (Convert.ToDouble(VIS.Pop()));
                            b = (Convert.ToDouble(VIS.Pop()));
                            VIS.Push((b - a).ToString());
                            break;
                        case "/":
                            a = (Convert.ToDouble(VIS.Pop()));
                            b = (Convert.ToDouble(VIS.Pop()));
                            VIS.Push((b / a).ToString());
                            break;
                        case "*":
                            a = (Convert.ToDouble(VIS.Pop()));
                            b = (Convert.ToDouble(VIS.Pop()));
                            VIS.Push((b * a).ToString());
                            break;
                        default:
                            break;
                    }
                }
                
                else VIS.Push(OPZ[i].operand.ToString());
                
            }
            rez = Convert.ToDouble(VIS.Pop());
            return rez;
        } 
    }
}
