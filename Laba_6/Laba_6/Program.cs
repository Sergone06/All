using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №6 \"Простая сортировка\"");
            //--------------------Алгоритм сортировки пузырьком в обратном порядке-----------
            Console.WriteLine("\nСортировка алгоритмом пузырёк: ");
            int[] massiv = new int[20];
            int dop;
            bool flag = false;
            var rand = new Random();
            for (int i = 0; i < massiv.Length ; i++)
            {
                massiv[i] = rand.Next(99);
            }
            Console.WriteLine("Несортированный массив: ");
            foreach (var item in massiv)
            {
                Console.Write(item + " ");
            }
            while (flag!=true)
            {
                flag = true;
                for (int i = 0; i < massiv.Length-1; i++)
                {
                    if (massiv[i] < massiv[i+1])
                    {
                        dop = massiv[i];
                        massiv[i] = massiv[i + 1];
                        massiv[i + 1] = dop;
                        flag = false;
                    }
                }
            }
            Console.WriteLine("\nСортировка алгоритмом пузырёк: ");
            foreach (var item in massiv)
            {
                Console.Write(item + " ");
            }
            //-----------------Сортировка вставкой-----------------
            Console.WriteLine("\n\nСортировка алгоритмом вставки: ");
            int[] massiv2 = new int[20];
            for (int i = 0; i < massiv2.Length; i++)
            {
                massiv2[i] = rand.Next(99);
            }
            Console.WriteLine("Несортированный массив: ");
            foreach (var item in massiv2)
            {
                Console.Write(item + " ");
            }
            for (int i = 1; i < massiv2.Length; i++)
            {
                for (int j = i-1; j >= 0 ; j--)
                {
                    while (massiv2[j] > massiv2[i])
                    {
                        dop = massiv2[i];
                        massiv2[i] = massiv2[j];
                        massiv2[j] = dop;
                        i--;
                    }
                }
            }
            Console.WriteLine("\nСортировка алгоритмом вставка: ");
            foreach (var item in massiv2)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
