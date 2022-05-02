using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using lab4;

namespace lab4
{
    public class Calculate
    {
        public double Summ(double x1, double y1)
        {
            double summ = x1 + y1;
            return summ;
        }
        public double Subtraction(double x1, double y1)
        {
            double summ = x1 - y1;
            return summ;
        }
        public double Multiplication(double x1, double y1)
        {
            double summ = x1 * y1;
            return summ;
        }
        public double Division(double x1, double y1)
        {
            double summ = x1 / y1;
            return summ;
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
        public double SortingMin(double[] arr, int m)
        {
            double min = arr[0];
            for (int i = 0; i < m; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public double SortingSumm(double[] arr, int m)
        {
            double summ = 0;
            for (int i = 0; i < m; i++)
            {
                summ += arr[i];
            }
            return summ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}