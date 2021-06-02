using HomeWork4.Building;
using HomeWork4.MyMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    static class Run
    {
        public static void TestBuilding()
        {
            Team team = new Team
            (
                new Worker { Name = "Bob" },
                new Worker { Name = "Anton" },
                new TeamLeader { Name = "Jon" },
                new House()
            );

            team.Work();
        }

        public static void TestComplex()
        {
            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine($"z1 = {z1}");
        }

        public static void TestFraction()
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + (decimal)d;
            Console.WriteLine($"f1 = {f1}\nf2 = {f2}\nf3 = {f3}");
        }
    }
}
