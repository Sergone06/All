using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    class Program
    {
        static void Main(string[] args)
        {
            { //Лабораторная работа №1 "Простейших калькулятор"
              // "\n" - перевод каретки
                double a, b, c; // c=a(+-/*)b
                string a_s, b_s;
                Console.WriteLine("Лабораторная работа №1 \"Простейших калькулятор\" ");
                //вводим a
                Console.Write("Введите значение переменной a = ");
                a_s = Console.ReadLine();
                a = Convert.ToInt16(a_s);
                //вводим b
                Console.Write("Введите значение переменной b = ");
                b_s = Console.ReadLine();
                b = Convert.ToInt16(b_s);
                // 1) Сложение a + b
                c = a + b;
                Console.Write("Результат выражения a + b = " + c + "\n");
                // 2) Вычитание a - b
                c = a - b;
                Console.Write("Результат выражения a - b = " + c + "\n");
                // 3) Умножение a * b
                c = a * b;
                Console.Write("Результат выражения a * b = " + c + "\n");
                // 4) Деление a / b
                c = (Convert.ToDouble(a)) / (Convert.ToDouble(b));
                Console.Write("Результат выражения a / b = " + c + "\n");
                Console.ReadKey();
            }
        }
    }
}
