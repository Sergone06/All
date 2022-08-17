using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список простых чисел от 0 до 200: ");
            Prost(201);
            Console.ReadKey();
        }
        static int Prost(int a)
        {
            int z;
            if (a == 0)
            {
                return 0;
            }
            z = Prost(a - 1);
            if (ProstoeChislo(z) & z!=0 & z!=1)
            {
                Console.Write((z) + " ");                
            }
            return a - 1;
        }
        static bool ProstoeChislo(int chislo)
        {
            for (int i = 2; i <= Math.Sqrt(chislo); i++)
            {
                if (chislo % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
