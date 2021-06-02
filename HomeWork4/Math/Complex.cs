using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4.MyMath
{
    class Complex
    {
        private int re;
        private int im;

        public Complex(int _re, int _im)
        {
            re = _re;
            im = _im;
        }

        public Complex()
        {
            re = 0;
            im = 0;
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(
                c1.re * c2.re - c1.im * c2.im,
                c1.im * c2.re + c1.re * c2.im
                );
        }

        public static Complex operator *(int num, Complex c1)
        {
            return new Complex(
                c1.re * num,
                c1.im
                );
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex(
                (c1.re * c2.re + c1.im * c2.im) / (c2.re * c2.re + c2.im * c2.im),
                (c1.im * c2.re - c1.re * c2.im) / (c2.re * c2.re + c2.im * c2.im)
                );
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.re - c2.re, c1.im - c2.im);
        }

        public static Complex operator -(Complex c1, int num)
        {
            return new Complex(c1.re - num, c1.im);
        }

        public override string ToString() => $"{re} + {im}i";
    }
}
