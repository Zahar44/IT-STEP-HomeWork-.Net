using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public delegate void DeathEventHandler(object sender, DeathEvent e);
    public class DeathEvent
    {
        public TimeSpan LiveTime { get; set; }
    }
}
