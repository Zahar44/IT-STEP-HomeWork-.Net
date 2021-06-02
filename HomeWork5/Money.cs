using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Money
    {
        const int centsDecimal = 100; // <99

        private int integer;
        private int cents;


        public int Integer 
        {
            get => integer; 
            private set
            {
                if (value < 0)
                    throw new BankruptException();
                integer = value;
            }
        }
        public int Cents 
        {
            get => cents;
            private set
            {
                if (value < 0)
                    throw new BankruptException();
                cents = value;
            }
        }


        public Money(int _integer, int _cents)
        {
            Integer = _integer;
            Cents = _cents;
        }

        public static Money operator+(Money a, Money b)
        {
            int _integer = a.Integer + b.Integer;
            int _cents = a.Cents + b.Cents;

            if(_cents >= centsDecimal)
            {
                _integer++;
                _cents -= centsDecimal;
            }
            
            return new Money(_integer, _cents);
        }

        public static Money operator -(Money a, Money b)
        {
            int _integer = a.Integer - b.Integer;
            int _cents = a.Cents - b.Cents;

            if(_cents < 0)
            {
                _integer--;
                _cents += centsDecimal;
            }

            return new Money(_integer, _cents);
        }

        public static Money operator /(Money m, int n)
        {
            return new Money(m.Integer / n, m.Cents / n);
        }

        public static Money operator *(Money m, int n)
        {
            return new Money(m.Integer * n, m.Cents * n);
        }

        public static Money operator ++(Money n)
        {
            return new Money(0, 1) + n;
        }

        public static Money operator --(Money n)
        {
            return n - new Money(0, 1);
        }

        public static bool operator >(Money a, Money b)
        {
            if (a.Integer == b.Integer)
                return a.Cents > b.Cents;

            return a.Integer > b.Integer;
        }

        public static bool operator <(Money a, Money b)
        {
            return !(a > b);
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Integer == b.Integer && a.Cents == b.Cents;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            if (Cents > 9)
                return $"{Integer}.{Cents}";
            else
                return $"{Integer}.0{Cents}";
        }
    }
}
