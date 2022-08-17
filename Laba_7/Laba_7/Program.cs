using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №7 \"Сравнение алгоритмов сортировки\"");
            //--------------------Задание 1-----------------------
            int[] massiv = new int[20];
            bool flag = false;
            int dop, n = 0, m = 0, r = 0;
            var rand = new Random();
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = rand.Next(100);
            }
            Console.WriteLine("\nПузырьковый метод: ");   //----------------------------
            Console.WriteLine("Исходный массив: ");
            foreach (var item in massiv)
            {
                Console.Write(item + " ");
            }
            while (flag != true)
            {
                flag = true;
                for (int i = 0; i < massiv.Length - 1; i++)
                {
                    if (massiv[i] > massiv[i + 1])
                    {
                        dop = massiv[i];
                        massiv[i] = massiv[i + 1];
                        massiv[i + 1] = dop;
                        flag = false;
                    }
                }
                n++;
            }
            Console.WriteLine("\nСортированный массив: ");
            foreach (var item in massiv)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine( "\nКоличество итераций: " + n);
            Console.WriteLine("\n\nМетод вставки: ");    //-------------------------------
            int[] massiv2 = new int[20];
            int g;
            for (int i = 0; i < massiv2.Length; i++)
            {
                massiv2[i] = rand.Next(100);
            }
            Console.WriteLine("Исходный массив: ");
            foreach (var item in massiv2)
            {
                Console.Write(item + " ");
            }
            for (int i = 1; i < massiv2.Length; i++)
            {
                g = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    
                    if (massiv2[j] > massiv2[g])
                    {
                        dop = massiv2[g];
                        massiv2[g] = massiv2[j];
                        massiv2[j] = dop;
                        g--;
                    }
                }
                m++;
            }
            Console.WriteLine("\nСортированный массив: ");
            foreach (var item in massiv2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nКоличество итераций: " + m);
            Console.WriteLine("\n\nМетод выбора: ");  //----------------------------------
            int[] massiv3 = new int[20];
            int k = massiv3.Length - 1;
            int need, level;
            for (int i = 0; i < massiv3.Length; i++)
            {
                massiv3[i] = rand.Next(100);
            }
            Console.WriteLine("Исходный массив: ");
            foreach (var item in massiv3)
            {
                Console.Write(item + " ");
            }
            while (k > 0)
            {
                level = 0;
                for (int i = 1; i < k+1; i++)
                {
                    if (massiv3[i] >= massiv3[level])
                    {
                        level = i;
                    }
                }
                need = massiv3[k];
                massiv3[k] = massiv3[level];
                massiv3[level] = need;
                k--;
                r++;
            }
            Console.WriteLine("\nСортированный массив: ");
            foreach (var item in massiv3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nКоличество итераций: " + r);
            //----------------------------------------Задание 2---------------------------------------------
            string[] names = new string[10] {"Екатерина","Руслан", "Светлана", "Дмитрий", "Аркадий", "Мария", "Ольга", "Евгений", "Ярослав", "Юлий" };
            Console.WriteLine("\n\nМассив имён: ");
            foreach (var item in names)
            {
                Console.Write(item + " ");
            }
            flag = false;
            string dop2;
            while (flag != true)
            {
                flag = true;
                for (int i = 0; i < names.Length - 1; i++)
                {
                    if ((int)names[i][0] > (int)names[i + 1][0])
                    {
                        dop2 = names[i];
                        names[i] = names[i + 1];
                        names[i + 1] = dop2;
                        flag = false;
                    }
                }
            }
            Console.WriteLine("\nСортированные имена по алфавиту по первой букве: ");
            foreach (var item in names)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
