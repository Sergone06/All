using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Maxim
{
    class Personal
    {
        // свойства
        public DateTime DataR;
        // методы
        public int Vozrast()
        {
            int V;
            V = DateTime.Today.Year - DataR.Year;
            return V;
        }
        // метода преобразования ФИО
        public string FIO(string familia)
        {
            string[] s = new string[3];
            s = familia.Split();
            string new_str = s[0] + " " + s[1][0] + "." + s[2][0] + ".";
            return new_str;
        }
    }
    // - - -
    class Buhgalter : Personal
    {

    }
    class TekTest
    {
        public int Kol_O; // количество ответов
        public int PO = -1;  // правильный ответ
        public char PO_sravnenie; //
        public int Pol_PO; // положение правильного ответа
        public string Virag; // само выражение
        public int[] NePO;  // неправильные ответы
        public char[] NePO_sravnenie = new char [3]; // неправильные ответы для сравнения
        Random Rand = new Random();
        //
        public void TEST() // метод, который
            // все эти свойства заполняет!
        {            
            while (PO < 0)
            {
                Virag = Viragenie();
            }
            Pol_PO = Rand.Next(1, 5);
        }
        //
        public void TEST_sravnenie()
        {
            Kol_O = 4;
            // 1) Генерируем 2 числа
            int ch1 = Rand.Next(0, 100);
            int ch2 = Rand.Next(0, 100);
            Virag = ch1.ToString() + " - ? - " + ch2.ToString();
            Pol_PO = Rand.Next(1, 5);
            if (ch1 > ch2)
            {
                PO_sravnenie = '>';
                NePO_sravnenie[0] = '<';
                NePO_sravnenie[1] = '=';
                NePO_sravnenie[2] = '!';
            }
            else if (ch1 < ch2)
            {
                PO_sravnenie = '<';
                NePO_sravnenie[0] = '>';
                NePO_sravnenie[2] = '!';
                NePO_sravnenie[1] = '=';
            }
            else
	        {
                PO_sravnenie = '=';
                NePO_sravnenie[2] = '!';
                NePO_sravnenie[0] = '>';
                NePO_sravnenie[1] = '<';
            }

        }
        //
        private string Viragenie()
        {
            int[]    operand = new int[4];
            string[] operaci = new string[3];
            string Primer = "";
            // 1) Определяем количество операндов
            int i = 0; // i - количество операндов
            int SCH = 0; // случайное число
            SCH = Rand.Next(2, 4); // от 2 до 3
            while (i < SCH)
            {
                // 2) Генерируем операнд
                i++;
                operand[i] = Rand.Next(0, 100);                
            }
            // 3) Генерируем операции
            int j = 0;// количество операций
            while (j < i-1)
            {
                j++;
                operaci[j] = (Rand.Next(0, 2) == 0) ? "-" : "+";   
            }
            //
            // 4) Генерируем пример
            for (int k = 1; k < i; k++)
            {
                Primer = Primer + operand[k].ToString() + " ";
                Primer = Primer + operaci[k] + " ";
            }
            Primer = Primer + operand[i].ToString();
            // 5) рассчитать правильный ответ
            for (int l = 1; l <= j; l++) // j - количество операций
            { // 5 + 2 - 3
                PO = (operaci[l] == "+") ? (operand[l] + operand[l+1]) : (operand[l] - operand[l + 1]);
                // PO = 7
                operand[l + 1] = PO;
            }
            return Primer;
        }
    }
    //
    class OPZ
    {
        public int operand; // число
        public int rang;    // ранг операции
        public string operacia;  // операция
        // "5+2*(8-4/2)"
        public void Add(string simbol)
        {
            string Chisla = "0123456789";
            if (Chisla.IndexOf(simbol) >= 0)
            {
                operand = Convert.ToInt32(simbol);
                operacia = "ch";
            }
            else
            {
                operacia = simbol;
                rang = FindRang(simbol);
            }
        }
        //
        private int FindRang(string simbol)
        {
            if ((simbol == "(") || (simbol == ")"))
            {
                return 1;
            }
            else if ((simbol == "+") || (simbol == "-"))
            {
                return 2;
            }
            else if ((simbol == "*") || (simbol == "/"))
            {
                return 3;
            }
            return 4;
        }
    }
    //
    class R_S_A
    {
        public int GetSimpleNumber(int nach, int kon)
        {
            bool ThisIsSimpleNumber;
            for (int i = nach; i <= kon; i++)
            {
                ThisIsSimpleNumber = true;
                // ищем простое число от 2 до i
                for (int j = 2; j <= Math.Sqrt(i) ; j++)
                {
                    if ( i % j == 0)
                    {
                        ThisIsSimpleNumber = false;
                        break;
                    }
                }
                if (ThisIsSimpleNumber)
                {
                    return i;
                }
            }
            return 0;
        }
        //
        public int GetOpenExponent(int f)
        {
            // 1 оно взаимно простое с ф
            // 2 меньше ф
            int SimleNumber = 0;
            for (int i = 3; i < f; i++)
            {
                SimleNumber = GetSimpleNumber(i, i);
                if (SimleNumber > 0)
                    if (f % SimleNumber > 0)
                        return i;
            }
            return 0;
        }
        //
        public int GetSecretExponent(int e, int f, int ot = 2)
        {
            // (d*e) mod f = 1
            for (int d = ot; ; d++) // бежим от 2 до бесконечности пока условие не выполнится
            {
                if ((d * e) % f == 1) // d * 5 % 12 = 1 при d = 5
                {
                    return d;
                }
            }
        }
        //
        public double Encription(double m, double e, int n)
        {
            // [e,n] - открытый ключ
            // C = (m^e) mod n;
            double c = Math.Pow(m, e) % n;
            return c;
        }
        //
        public double Decription(double c, double d, int n)
        {
            // [d,n] - закрытый ключ
            // m = (c^d) mod n;
            double m = Math.Pow(c, d) % n;
            return m;
        }
    }
}
