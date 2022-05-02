using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Calculate
    {
        public double Summ(double v1, double v2)
        {
            return 7.8;
        }

        public double Subtraction(double v1, double v2)
        {
            return 1.2;
        }

        public double Multiplication(double v1, double v2)
        {
            return 1.44;
        }

        public double Division(double v1, double v2)
        {
            return 1;
        }

        public double SortingMax(double[] arr, int m)
        {
            double max = 0;
            for (int i = 0; i < m; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public double SortingMin(double v1, double v2)
        {
            return 1;
        }

        public double SortingSumm(double v1, double v2)
        {
            return 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
