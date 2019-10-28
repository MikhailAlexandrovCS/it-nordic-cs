using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTests_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //testc();
            int a = 5 - -4;
            Console.Write(a);
            Console.ReadKey();
        }

        private static void testc(int x = int.MaxValue)
        {
            Console.Write(x);
        }
    }
}
