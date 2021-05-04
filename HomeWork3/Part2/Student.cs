using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Student
    {
        public string Name { get; set; }
        public string SName { get; set; }
        public string MName { get; set; }

        public string Group { get; set; }
        public int Age { get; set; }
        public int[][] Marks { get; set; }

        public Student(string _Name, string _SName, string _MName)
        {
            Name = _Name;
            SName = _SName;
            MName = _MName;
            Marks = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                Marks[i] = new int[0];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject">Programming, Database or Design</param>
        /// <param name="newMarks"></param>
        public void AddMarks(string _subject, params int[] newMarks)
        {
            int subject = SetSubject(_subject);

            int lengthBefore = Marks[subject].Length;
            Array.Resize<int>(ref Marks[subject], lengthBefore + newMarks.Length);

            for (int i = lengthBefore; i < Marks[subject].Length; i++)
            {
                Marks[subject][i] = newMarks[i - lengthBefore];
            }
        }
        public int[] GetMarksBySubject(string _subject) => Marks[SetSubject(_subject)];
        public double GetAvrBySubject(string _subject)
        {
            int subject = SetSubject(_subject);
            double res = 0;

            foreach (var mark in Marks[subject])
            {
                res += mark;
            }
            res = res / (double)Marks[subject].Length;

            return res;
        }
        private int SetSubject(string subject)
        {
            int subj = -1;
            switch (subject)
            {
                case "Programming":
                    subj = 0;
                    break;
                case "Database":
                    subj = 1;
                    break;
                case "Design":
                    subj = 2;
                    break;
                default:
                    break;
            }
            if (subj == -1)
                throw new Exception("Wrong subject called");
            return subj;
        }
        public override string ToString()
        {
            string res = $"{Name} {SName} {MName} - from {Group}, {Age} years old";
            res += "\n\tProgramming: ";
            foreach (var mark in Marks[0])
            {
                res += mark + " ";
            }
            res += "\n\tDatabase: ";
            foreach (var mark in Marks[1])
            {
                res += mark + " ";
            }
            res += "\n\tDesign: ";
            foreach (var mark in Marks[2])
            {
                res += mark + " ";
            }
            return res;
        }
    }
}
