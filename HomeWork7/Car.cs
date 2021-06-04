using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    abstract class Car
    {
        public delegate void FinishDelegate(object sender, FinishEventArg e);
        protected int yPos;

        public Car()
        {
            yPos = 0;
        }

        public int Speed { get; protected set; }

        public string Name { get; set; }

        public virtual int Drive(int x) 
        {
            DeleteLast(x);
            DrowNew(x);
            return yPos;
        }

        public abstract void Finish(object sender, FinishEventArg e);

        protected virtual void DeleteLast(int x)
        {
            int _pos = yPos - Speed / 25;
            _pos = _pos > 0 ? _pos : 0;
            Console.SetCursorPosition(x, _pos);
            Console.Write(' ');
        }

        protected virtual void DrowNew(int x)
        {
            Console.SetCursorPosition(x, yPos);
            yPos += Speed / 25;
            Console.Write(Name);
        }
    }
}
