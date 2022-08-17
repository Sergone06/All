using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {                                 // Лабораторная работа № 3 "Циклы"
            Console.WriteLine("Лабораторная работа № 3 \"Циклы\"");
            // Действие 1
            double a, i, b = 0, c = 1;
            Console.Write("Пожалуйста, введите число, которое станет ограничением для последовательности чисел Фибоначчи : ");
            a = Convert.ToDouble( Console.ReadLine() );
            Console.WriteLine("0" + '\n' + "1");
            do
            {
                i = b + c;
                Console.WriteLine(i);
                b = c;
                c = i;
            } while ( (b + c) <= a);
            //---------------------------------------------------------------------------------------------------------------------
            // Действие 2
            Console.WriteLine("Чтобы сформировать список простых чисел от 0 до 200 нажмите Enter");
            Console.ReadKey();
            for (int o = 2; o <= 200; o++)
            {
                bool usl = true;
                for (int p = 2; p < o; p++)
                {
                    if ( (o % p == 0) & (o % 1 == 0) )
                    {
                        usl = false;
                    }
                }
                if (usl)
                {
                    Console.WriteLine( o );
                }
            }
            Console.ReadKey();
        }
    }
}
