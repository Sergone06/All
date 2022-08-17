using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5 \"Символы и строки\"");
            // Действие 1--------------------------------------------
            string str;
            int a;
            Console.Write("Введите фразу для кодировки: ");
            str = Console.ReadLine();
            char[] massiv1 = str.ToCharArray();
            Console.Write("Введите ключ для кодировки: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кодировка: ");
            for (int i = 0; i < massiv1.Length; i++)
            {
                massiv1[i] = (char)(massiv1[i] + a);
                Console.Write(massiv1[i]);
            }
            Console.WriteLine("\nДекодировка: ");
            for (int i = 0; i < massiv1.Length; i++)
            {
                Console.Write((char)(massiv1[i] - a));
            }
            // Действие 2--------------------------------------
            string[] eng = new string[10] {"a","o","u","e","iu","ia","ae","y","i","ie" };
            string[] rus = new string[10] { "а", "о", "у", "е", "ю", "я", "э", "ы", "и", "ё" };
            string stroka;
            Console.Write("\n\nВведите фразу для замены гласных букв:");
            stroka = Console.ReadLine();
            for (int i = 0; i < 9; i++)
            {
                stroka = stroka.Replace(rus[i], eng[i]).Trim();
            }
            Console.Write( stroka );
            Console.ReadKey();
        }
    }
}
