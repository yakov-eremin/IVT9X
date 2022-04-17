using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R1
{
    public class MyClass
    {
        public static double sum_squares (int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = sum + (i * i);
            }
            return sum;
        }
        public static double cube_volume(double[] s)
        {
            double v = 1;
            if (s != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    v = v * s[i];
                }
                return v;
            }
            else
            {
                throw new NullReferenceException();
            }            
        }
        public static void swap (ref object a, ref object b)
        {
            if (a.GetType() == b.GetType())
            {
                if (a is double)
                {
                    double tmp;
                    tmp = (double)a;
                    a = b;
                    b = tmp;
                }
                if (a is string)
                {
                    string tmp;
                    tmp = (string)a;
                    a = b;
                    b = tmp;
                }
                if (a is int)
                {
                    int tmp;
                    tmp = (int)a;
                    a = b;
                    b = tmp;
                }
            }
            else
            {
                throw new ArgumentException();
            }            
        }
        public static bool over (object a, object b)
        {
            if (a.GetType() == b.GetType())
            {
                if (a is double)
                {
                    if ((double)a > (double)b)
                        return true;
                    else
                        return false;
                }
                if (a is string)
                {
                    string temp_a = (string)a;
                    string temp_b = (string)b;
                    if (temp_a.Length > temp_b.Length)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                throw new ArgumentException();
            }
            return false;
        }
    }

    internal class Program
    {       
        static void Main(string[] args)
        {
            
        }
    }
}
