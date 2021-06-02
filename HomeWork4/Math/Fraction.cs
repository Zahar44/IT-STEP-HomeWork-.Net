using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.MyMath
{
    class Fraction
    {
        decimal i;
        decimal d;

        public Fraction()
        {
            i = 0;
            d = 1;
        }

        public Fraction(decimal num)
        {
            i = (int)num;
            d = num - ((int)num);
        }

        public Fraction(int _integer, int _denominator)
        {
            if (_denominator == 0)
                throw new Exception();

            i = _integer;
            d = _denominator;
        }

        public Fraction(decimal _integer, decimal _denominator)
        {
            if (_denominator == 0)
                throw new Exception();

            i = _integer;
            d = _denominator;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction res = new Fraction();
            decimal cd = GetCommonDivisor(f1, f2);
            res.d = cd;
            res.i = f1.i * (res.d / f1.d) + f2.i * (res.d / f2.d);
            return res;
        }
        public static Fraction operator +(Fraction f1, decimal num)
        {
            return f1 + new Fraction(num);
        }
        public static Fraction operator +(decimal num, Fraction f1)
        {
            return f1 + num;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction res = new Fraction();
            decimal cd = GetCommonDivisor(f1, f2);
            res.d = cd;
            res.i = f1.i * (res.d / f1.d) - f2.i * (res.d / f2.d);
            return res;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(
                f1.i * f1.d,
                f2.i * f2.d
                );
        }

        public static Fraction operator *(int num, Fraction f)
        {
            return new Fraction(f.i * num, f.d);
        }

        public static Fraction operator *(decimal num, Fraction f)
        {
            return new Fraction(num) * f;
        }

        public static Fraction operator *(Fraction f, int num)
        {
            return num * f;
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.i / f1.d > f2.i / f2.d;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return !(f1 > f2);
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.i == f2.i && f1.d == f2.d;
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static bool operator true(Fraction f1)
        {
            return f1.i < f1.d;
        }

        public static bool operator false(Fraction f1)
        {
            return (f1.i < f1.d) == false;
        }

        private static decimal GetCommonDivisor(Fraction f1, Fraction f2)
        {
            if (f1.d == f2.d)
                return f2.d;

            return f1.d * f2.d;
        }

        public override string ToString() => $"{i} / {d}";

    }
}
