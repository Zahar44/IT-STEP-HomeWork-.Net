using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Threading;

namespace HomeWork8
{
    class Tamagotchi
    {
        private const int defaultHealth = 3;
        private readonly Timer timer;
        private int lastReqInd;
        public Person Person { get; private set; }

        public Tamagotchi()
        {
            Person = new Person { Health = defaultHealth };
            Person.Death += OnDeath;

            timer = new Timer { Interval = 2000 };
            timer.Elapsed += ShowStatus;
        }

        public void Start()
        {
            Person.ShowAnim();
            timer.Start();
        }

        public void ShowStatus(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            var reqInd = GetRandomInd(Person.Requests.Count - 1);
            var req = Person.Requests[reqInd];
            var response = 
                MessageBox.Show(req, "Request", MessageBoxButtons.YesNo);

            if (response == DialogResult.No)
                Person.Health--;
            timer.Start();
        }


        private void OnDeath(object sender, DeathEvent e)
        {
            timer.Stop();
            Console.Clear();
            Console.WriteLine("Person is dead :(");
            Console.WriteLine($"Live time {e.LiveTime.TotalSeconds}");
            Person.StopAnim();
        }

        private int GetRandomInd(int max)
        {
            var r = new Random();
            var reqInd = r.Next(0, max);

            if (lastReqInd == reqInd)
                GetRandomInd(max);

            lastReqInd = reqInd;
            return reqInd;
        }
    }
}
