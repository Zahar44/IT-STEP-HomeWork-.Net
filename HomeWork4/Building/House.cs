using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.Building
{
    class House
    {
        public Basement Basement { get; private set; } = new Basement();

        public Wall[] Walls { get; private set; }

        public Door Door { get; set; } = new Door();

        public Window[] Windows { get; private set; }

        public Roof Roof { get; private set; } = new Roof();

        public bool IsBuilted { get; set; } = false;

        public House()
        {
            Walls = new Wall[] {
                new Wall(),
                new Wall(),
                new Wall(),
                new Wall(),
            };
            Windows = new Window[] { 
                new Window(),
                new Window(),
                new Window(),
                new Window(),
            };
        }

        public IPart Next()
        {
            if (!Basement.IsBuilted)
                return Basement;
            foreach (var wall in Walls)
            {
                if (!wall.IsBuilted)
                    return wall;
            }
            if (!Door.IsBuilted)
                return Door;
            foreach (var window in Windows)
            {
                if (!window.IsBuilted)
                    return window;
            }
            if (!Roof.IsBuilted)
                return Roof;

            throw new Exception();
        }

    }
}
