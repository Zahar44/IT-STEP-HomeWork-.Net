using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork8
{
    class Person
    {
        private readonly DateTime _created;
        private readonly Thread animThread;
        private int health;

        public List<String> Requests { get; private set; }
        public List<List<String>> Anim { get; private set; }
        public int Health 
        {
            get => health;
            set
            {
                if (value <= 0)
                    Death?.Invoke(this, new DeathEvent { LiveTime = DateTime.Now - _created });
                health = value;
            }
        }

        public event DeathEventHandler Death;


        public Person()
        {
            _created = DateTime.Now;

            Anim = Grafick.GetPlayerAnim();
            Requests = Grafick.GetRequests();
            animThread = new Thread(new ThreadStart(ShowAnimPrivate));
        }

        public void ShowAnim()
        {
            animThread.Start();
        }

        public void StopAnim()
        {
            animThread.Abort();
        }

        private void ShowAnimPrivate()
        {
            while (Health > 0)
            {
                Show(Anim);
                Anim.Reverse();
            }
        }

        private void Show(List<List<String>> anim)
        {
            for (int i = 0; i < anim.Count; i++)
            {
                Show(anim[i], 4);
                Thread.Sleep(150);
            }
        }

        private void Show(List<String> graf, int yStart)
        {
            int _ystart = yStart;
            int _x = 4;

            Console.CursorVisible = false;
            Console.ForegroundColor = GetColor();

            ShowHealth(_x + 1, _ystart - 2);
            Clear(_x, graf.First().Length, _ystart, _ystart + graf.Count);
            foreach (var str in graf)
            {
                Console.SetCursorPosition(_x, _ystart++);
                Console.Write(str);
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
        }

        private void Clear(int x, int xLength, int yfrom, int yto)
        {
            var str = "".PadRight(xLength * 2); 
            for (int i = yfrom; i < yto; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(str);
            }
        }

        private void ShowHealth(int x, int y)
        {
            int _y = y;
            int _x = x;
            Clear(_x, Health + 1, _y, _y + 1);
            for (int i = 0; i < Health; i++)
            {
                Console.SetCursorPosition(_x, _y);
                Console.Write("*");
                _x += 2;
            }
        }

        private ConsoleColor GetColor()
        {
            switch (Health)
            {
                case 3:
                    return ConsoleColor.Green;
                case 2:
                    return ConsoleColor.Yellow;
                case 1:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
