using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {// Лабораторная работа №2 "Условный арифмометр" (Подгруппа а)
            Console.WriteLine("Лабораторная работа №2 \"Условный арифмометр\"");
            double a, b, c, d, s;
            string oper;
            Console.Write("Введите значение переменной а = ");  // Вводим переменную а
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение переменной b = ");  // Вводим переменную b
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение переменной c = ");  // Вводим переменную c
            c = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите операцию (+, -, *, / ) : "); // Вводим операцию
            oper = Console.ReadLine();
            switch (oper)
            {
                case "+":                                                                   // Сложение
                    d = a + b + c;
                    Console.WriteLine("Результат сложения : a + b + c = " + d);
                    Console.ReadKey();
                    break;
                case "-":                                                                   // Вычитание
                    d = a - b - c;
                    Console.WriteLine("Результат разности : a - b - c = " + d);
                    Console.ReadKey();
                    break;
                case "*":                                                                   // Умножение
                    d = a * b * c;
                    Console.WriteLine("Результат произведения : a * b * c = " + d);
                    Console.ReadKey();
                    break;
                case "/":                                                                   // Деление
                    if ((b == 0) | (c == 0))                                      // Проверка деления на ноль
                    {
                        Console.WriteLine("Деление на ноль невозможно");
                        Console.ReadKey();
                    }
                    else
                    {
                        d = a / b / c;
                        Console.WriteLine("Результат деления : a / b / c = " + d);
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.WriteLine("Введена неверная операция");
                    Console.ReadKey();
                    break;
            }
            
            if ((a % 2 == 0) & (b % 2 == 0) & (c % 2 == 0))                      // Условие 1
            {
                s = a * b * c;
                Console.WriteLine('\n' + "Выполняется условие 1 : все операнды чётные, значит a * b * c = " + s + '\n');
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine('\n' + "Условие 1 не выполняется" + '\n');
                Console.ReadKey();
            }
            
            if ( ( (a + b + c) % 2 != 0) & ( ( a + b + c ) < 21 ) )         // Условие 2
            {
                s = ((a >= b) & (a >= c)) ? (b * c) : ((b >= a) & (b >= c) ? a * c : a * b);


                Console.WriteLine("Условие 2 выполняется, значит произведение наименьших : " + s);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Условие 2 не выполняется");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}