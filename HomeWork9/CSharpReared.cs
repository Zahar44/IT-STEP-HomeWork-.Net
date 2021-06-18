using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork9
{
    class CSharpReared
    {
        private const string filePath = @"./../../Person.cs";
        private const string savePath = @"./../../ReversedPerson.txt";
        private string str;

        public CSharpReared()
        {
            str = LoadFile();
        }

        public void DoTestWork()
        {
            Trim();
            ReverseFile();
            Replace("public", "private");
            ToUpper(2);
            CreateFile();
        }

        public void ReverseFile()
        {
            str = new string(str.Reverse().ToArray());
        }

        public void Replace(string from, string to)
        {
            str = str.Replace(from, to);
        }

        public void ToUpper(int wordLength)
        {
            var words = str.Split(' ');
            StringBuilder sb = new StringBuilder();
            str = String.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length >= wordLength)
                {
                    words[i] = words[i].ToUpper();
                    sb.Append(words[i] + " ");
                }
                if (String.IsNullOrEmpty(words[i]))
                    sb.Append(" ");
            }
            str = sb.ToString();
        }

        public void Trim()
        {
            Regex pattern = new Regex("[\t\r\n ]");
            str = pattern.Replace(str, String.Empty);
        }

        public void CreateFile()
        {
            using (var sw = new StreamWriter(new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                sw.Write(str);
            }
        }

        private string LoadFile()
        {
            if (!File.Exists(filePath))
                throw new InvalidOperationException("File does not exist");

            using (var sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
