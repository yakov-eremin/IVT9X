using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    public class Pom
    {
        private double c;
        private int a;

        public void display()
        {
            Console.WriteLine("Стоимость квадратного метра: " + c);
            Console.WriteLine("Площадь помещения: " + a);
        }

        public void init(double c1, int a1)
        {
            c = c1;
            a = a1;
        }

        public double p()
        {
            return c * a;
        }
    }
}
