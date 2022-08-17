using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №8 \"Методы\"");
            Console.WriteLine("\nЧасть 1:");
            double a, b, rezult;
            string oper;
            Console.Write("Введите значение переменной а = ");  // Вводим переменную а
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение переменной b = ");  // Вводим переменную b
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите операцию (+, -, *, / ) : "); // Вводим операцию
            oper = Console.ReadLine();
            rezult = Kalkul(a, b, oper);
            Console.WriteLine("Результат выражения = " + rezult);
            Console.ReadKey();
            Console.WriteLine("\nЧасть 2: ");
            int r;
            int[] massiv = new int[20];
            var rand = new Random();
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = rand.Next(100);
            }
            r = Sort(massiv);
            Console.WriteLine("Количество итераций сортировки массива: " + r);
            Console.ReadKey();
        }
        static double Kalkul(double a, double b, string oper)
        {
            double d = 0;
            switch (oper)
            {
                case "+":                                                                   // Сложение
                    d = a + b;
                    break;
                case "-":                                                                   // Вычитание
                    d = a - b;
                    break;
                case "*":                                                                   // Умножение
                    d = a * b ;
                    break;
                case "/":                                                                   // Деление
                    if (b == 0)                                      // Проверка деления на ноль
                    {
                        Console.WriteLine("Деление на ноль невозможно");
                        Console.ReadKey();
                    }
                    else
                    {
                        d = a / b;
                    }
                    break;
                default:
                    Console.WriteLine("Введена неверная операция");
                    Console.ReadKey();
                    break;
            }
            return d;
        }
        
        static int Sort(int[] massiv)
        {
            int dop, r = 0, g;
            for (int i = 1; i < massiv.Length; i++)
            {
                g = i;
                for (int j = i - 1; j >= 0; j--)
                {

                    if (massiv[j] > massiv[g])
                    {
                        dop = massiv[g];
                        massiv[g] = massiv[j];
                        massiv[j] = dop;
                        g--;
                    }
                }
                r++;
            }
            return r;
        }
    }
}
