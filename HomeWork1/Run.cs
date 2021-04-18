using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_STEP_HomeWork.Net
{
    static class Run
    {
        /// <summary>
        /// Write a program that reads characters from the keyboard yet
        /// a point will be entered.The program must count the number of entries
        /// user spaces.
        /// </summary>
        public static void Task1()
        {
            int spaceCnt = 0;
            char c;
            do
            {
                c = (char)Console.ReadKey().KeyChar;
                if (c == ' ')
                    spaceCnt++;
            } while (c != '.');
            Console.WriteLine($"\nSpace count: {spaceCnt}");
        }

        /// <summary>
        /// Enter the tram ticket number from the keyboard (6-digit number)
        /// and check if the given ticket is lucky(if the ticket is printed
        /// a six-digit number, and the sum of the first three digits is equal 
        /// to the sum of the last three, then this ticket is considered lucky).
        /// </summary>
        public static void Task2()
        {
            int ticket = inputTicket();
            int first = ticket / 1000;
            first = first % 10 + first / 10 % 10 + first / 100;
            int second = ticket % 1000;
            second = second % 10 + second / 10 % 10 + second / 100;

            Console.WriteLine($"Sum of first 3 -> {first}\nSum of last 3 -> {second}");

            if (first == second)
                Console.WriteLine("Ticket is lucky");
            else
                Console.WriteLine("Ticket is not lucky");
        }
        private static int inputTicket()
        {
            Console.Write("Enter ticket -> ");
            int ticket = 0;
            try
            {
                ticket = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                ticket = 0;
            }
            if (ticket <= 100000 || ticket >= 999999)
            {
                Console.WriteLine("Wrong input");
                ticket = inputTicket();
            }
            return ticket;
        }

        /// <summary>
        /// ASCII numeric values ​​for lowercase characters
        /// differ from the values ​​of uppercase characters by 32. Using this
        /// information, write a program that reads from the keyboard and converts
        /// all lowercase characters to uppercase characters and vice versa.
        /// </summary>
        public static void Task3()
        {
            string str = Console.ReadLine();
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if (c >= 'a' && c <= 'z')
                    chars[i] = (char)(c - 32);
                else if (c >= 'A' && c <= 'Z')
                    chars[i] = (char)(c + 32);
            }
            Console.WriteLine(chars);
        }

        /// <summary>
        /// Given positive integers A and B (A <B). Display all integers
        /// numbers from A to B inclusive; each number should be displayed on a new line;
        /// in this case, each number should be displayed the number of times equal to its value.
        /// </summary>
        public static void Task4(int _A = 3, int _B = 7)
        {
            int A = _A;
            int B = _B;

            for (int i = A; i <= B; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Given an integer N (> 0), find the number obtained by reading
        /// numbers N from right to left.For example, if the number 345 was entered,
        /// then the program should print the number 543.
        /// </summary>
        public static void Task5()
        {
            string _N = Console.ReadLine();
            char[] chars = _N.ToCharArray();
            Array.Reverse(chars);
            string N = new string(chars);
            int res = Int32.Parse(N);
            Console.WriteLine(res);
        }


    }
}
