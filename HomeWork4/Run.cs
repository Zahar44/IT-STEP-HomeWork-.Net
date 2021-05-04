using HomeWork4.Building;
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
    }
}
