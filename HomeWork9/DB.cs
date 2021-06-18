using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
{
    class DB
    {
        public static double[][] GetDoubleArray()
        {
            var r = new Random();
            int sizei = r.Next(2, 10);

            double[][] res = new double[sizei][];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new double[r.Next(2, 10)];
                for (int j = 0; j < res[i].Length; j++)
                {
                    res[i][j] = r.NextDouble() * Math.Pow(10, r.Next(1, 4));
                }
            }

            return res;
        }

        public static int[][] GetIntArray()
        {
            var r = new Random();
            int sizei = r.Next(2, 10);

            int[][] res = new int[sizei][];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[r.Next(2, 10)];
                for (int j = 0; j < res[i].Length; j++)
                {
                    res[i][j] = r.Next(-10, 10);
                }
            }

            return res;
        }

    }
}
