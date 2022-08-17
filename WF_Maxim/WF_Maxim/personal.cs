using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Maxim
{
    class personal
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
        //
        public string FIO(string familia)
        {
            string[] s = new string[3];

            s = familia.Split();
            string new_str = s[0] + " " + s[1][0] + "." + s[2][0] + ".";
            return new_str;
        }
    }
    //-------------
    class buhgalter : personal
    {
        
    }
}
