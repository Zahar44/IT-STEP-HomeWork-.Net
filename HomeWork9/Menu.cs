using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
{
    class Menu
    {
        private const string basePath = @".\..\..\";
        private readonly string fileName;
        private bool run;
        public string Path => basePath + fileName;

        public Menu()
        {
            fileName = $"Day{DateTime.Now.Day}.txt";
            Start();
        }

        public void Start()
        {
            char ch = ' ';
            run = true;

            while (run)
            {
                Console.WriteLine($"C - Create file, R - Read file, W - Write to file, E - exit");
                ch = Char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

                ExecuteAction(ch);

                Console.Clear();
            };
        }


        public void WriteToFileTestData()
        {
            var doubleArray = DB.GetDoubleArray();
            var intArray = DB.GetIntArray();
            File.WriteAllText(Path, "");
            
            WriteNumbers(doubleArray);
            WritePersonData();
            AppendData($"Rows: {doubleArray.Length}, Cols: dynamic");
            WriteNumbersSum(doubleArray);

            double[][] castedIntArray = intArray.Select(
                i => i.Select(j => (double)j).ToArray()
                ).ToArray();
            WriteNumbersSum(castedIntArray);
            WriteNumbersByLine(castedIntArray);
            AppendData(DateTime.Now.ToShortDateString());

            Console.ReadLine();
        }


        public void TryToCreateFile()
        {
            if (File.Exists(Path))
            {
                Console.WriteLine($"File with name {fileName} is already exist");
                return;
            }

            File.Create(Path);
            Console.WriteLine($"File {fileName} is created!");
            Console.ReadLine();
        }

        public void TryReadFile()
        {
            if (!File.Exists(Path))
            {
                Console.WriteLine($"File with name {fileName} is already exist");
                return;
            }

            ReadFile();
        }

        private void WritePersonData()
        {
            Console.Write("PID: ");
            var pid = Console.ReadLine();
            var splitedPid = pid.Trim().Split(' ');

            if (splitedPid.Length != 3 && splitedPid.Min(x => x.Length > 0))
                throw new InvalidOperationException("Write you full name");

            // trust to user :)
            Console.Write("Birthday (yyyy/mm/dd): ");
            var birthday = Console.ReadLine();
            
            AppendData($"{pid} {birthday}");
        }

        private void WriteNumbers(double[][] numbers)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{\n");
            foreach (var i in numbers)
            {
                stringBuilder.Append($"\t");
                foreach (var j in i)
                {
                    stringBuilder.Append($"{j} ");
                }
                stringBuilder.Append($"\n");
            }
            stringBuilder.Append("}");

            AppendData(stringBuilder.ToString());
        }

        private void WriteNumbersByLine(double[][] numbers)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{ ");
            foreach (var i in numbers)
            {
                stringBuilder.Append("{ ");
                foreach (var j in i)
                {
                    stringBuilder.Append($"{j} ");
                }
                stringBuilder.Append("} ");
            }
            stringBuilder.Append("}");

            AppendData(stringBuilder.ToString());
        }

        private void WriteNumbersSum(double[][] numbers)
        {
            foreach (var i in numbers)
            {
                double sum = 0;
                foreach (var j in i)
                {
                    sum += j;
                }
                AppendData(sum.ToString());
            }
        }

        private void Exit()
        {
            run = false;
        }

        private void ReadFile()
        {
            using (var sr = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read)))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            Console.ReadLine();
        }

        private void ExecuteAction(char ch)
        {
            Action action;
            try
            {
                action = GetActionByChar(ch);
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private void AppendData(string data)
        {
            using (var sw = new StreamWriter(new FileStream(Path, FileMode.Append, FileAccess.Write)))
            {
                sw.WriteLine(data);
            }
        }

        private Action GetActionByChar(char ch)
        {
            switch (ch)
            {
                case 'c':
                    return new Action(TryToCreateFile);
                case 'r':
                    return new Action(TryReadFile);
                case 'w':
                    return new Action(WriteToFileTestData);
                case 'e':
                    return new Action(Exit);
                default:
                    throw new InvalidOperationException("Wrong character");
            }
        }
    }
}
