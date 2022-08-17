using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №4 \"Массивы\"");
            // Первое действие 
            var rand = new Random();
            double p = 1;
            int[,] massiv2 = new int[5, 5];
            Console.WriteLine("Случайный двумерный массив: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    massiv2[i, j] = rand.Next(500);                // Присвоение элементам массива значения
                    Console.Write(massiv2[i, j] + " ");            // Вывод двумерного массива
                    if (i == j)                                    
                    {
                        p *= massiv2[i, j];                     // Вычисление произведения элементов главной диагонали
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Произведение элементов главной диагонали равно " + p);
            // Второе действие
            string[] raduga = new string[7] { "красный", "оранжевый", "желтый", "зелёный", "голубой", "синий", "фиолетовый" };
            int[] chislo = new int[7];
            Console.WriteLine("\nВведите значения элементов массива ( Семь чисел от 1 до 7 ) ");
            for (int i = 0; i < chislo.Length; i++)                  // Присваиваем значения элементам массива
            {
                Console.Write(i+1 + ") ");
                chislo[i] = Convert.ToInt32(Console.ReadLine());
                if (chislo[i] > 7 | chislo[i] < 1)
                {
                    Console.WriteLine("ERROR: Введено неверное значение элемента массива.");
                    break;
                } 
            }
            Console.WriteLine("\nЦвета радуги в соответствии с введенными значениями массива: ");
            for (int i = 0; i < chislo.Length; i++)
            {
                Console.Write(raduga[chislo[i]-1] + " " );           // Выводим на экран получившиеся цвета
            }
            Console.ReadKey();
        }
    }
}
