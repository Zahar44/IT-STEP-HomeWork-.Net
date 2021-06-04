using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    class Grafick
    {
        public static List<String> GetPlayer()
        {
            return new List<string>
            {
                "  * * \n",
                " *****\n",
                "* *** *\n",
                "* *** *\n",
                "  * *\n",
                "  * *\n"
            };
        }

        public static List<List<String>> GetPlayerAnim()
        {
            return new List<List<string>>
            {
                new List<string>
                {
                    "  * * \n",
                    " *****\n",
                    "* *** *\n",
                    "* *** *\n",
                    "  * *\n",
                    "  * *\n"
                },
                new List<string>
                {
                    "  * * \n",
                    " *****\n",
                    "* *** ***\n",
                    "* ***\n",
                    "  * *\n",
                    "  * *\n"
                },
                new List<string>
                {
                    "  * *   *\n",
                    " *******\n",
                    "* ***\n",
                    "* ***\n",
                    "  * *\n",
                    "  * *\n"
                }
            };
        }

        public static List<String> GetRequests()
        {
            return new List<string>
            {
                "Feed",
                "Take a walk",
                "Sleep",
                "Heal",
                "Play"
            };
        }
    }
}
