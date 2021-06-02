using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    static class Run
    {
        public static void TestMoney()
        {
            var m1 = new Money(1, 2);
            var m2 = new Money(2, 98);
            var m3 = new Money(0, 0);
            Console.WriteLine($"M1:\t\t{m1}");
            Console.WriteLine($"M2:\t\t{m2}");
            Console.WriteLine();
            Console.WriteLine($"M1 + M2:\t{m1 + m2}");
            Console.WriteLine($"(M1 + M2) / 2:\t{(m1 + m2) / 2}");
            Console.WriteLine($"M2 - M1:\t{m2 - m1}");
            Console.WriteLine();
            Console.WriteLine($"++M2:\t\t{++m2}");
            Console.WriteLine($"++M2:\t\t{++m2}");
            Console.WriteLine();
            Console.WriteLine($"M3:\t\t{m3}");
            try
            {
                --m3;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--M3:\t\t{ex.Message}");
            }
        }
    }
}
