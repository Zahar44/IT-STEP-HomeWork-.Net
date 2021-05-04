using HomeWork3.Part3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    static class Run
    {
        public static void TestStudent()
        {
            Console.WriteLine("\nStudent test:\n");
            Student student = new Student("Bob", "White", "ASdsad");

            student.AddMarks("Database", new int[] { 12, 8, 6, 4 });
            student.AddMarks("Programming", new int[] { 6, 4, 8, 12 });
            student.AddMarks("Design", new int[] { 8, 6, 4 });
            
            Console.WriteLine(student);
            Console.WriteLine($"Average mark by programming is {student.GetAvrBySubject("Programming")}");
        }

        public static void TestWonders()
        {
            Console.WriteLine("\nWonders test:\n");
            IWonder[] wonders =
            {
                new ChinaWall(),
                new MachuPicchu()
            };

            foreach (var item in wonders)
            {
                item.DoStuff();
            }
        }
    }
}
