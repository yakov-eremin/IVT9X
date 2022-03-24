using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_lib1
{
    public class Triangle
    {
        protected int x1;
        protected int y1;
        protected int x2;
        protected int y2;
        protected int x3;
        protected int y3;

        public int X1 { get { return x1; } }

        public int X2 { get { return x2; } }

        public int Y1 { get { return y1; } }

        public int Y2 { get { return y2; } }

        public int X3 { get { return x3; } }

        public int Y3 { get { return y3; } }

        public Triangle(int x11, int y11, int x22, int y22, int x33, int y33)
        {
            x1 = x11;
            y1 = y11;
            x2 = x22;
            y2 = y22;
            x3 = x33;
            y3 = y33;
        }

        public Triangle() { }

        public void Init(int x11, int y11, int x22, int y22, int x33, int y33)
        {
            x1 = x11;
            y1 = y11;
            x2 = x22;
            y2 = y22;
            x3 = x33;
            y3 = y33;

        }

        public void Display()
        {
            Console.WriteLine("A(" + x1 + ";" + y1 + "), B(" + x2 + ";" + y2 + ") C(" + x3 + ";" + y3 + ")");
        }

        public double Perimetr()
        {
            double AB = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double AC = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
            double BC = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));

            return Math.Floor((AB + AC + BC) * 100) / 100;
        }

        public Triangle Add(Triangle a, Triangle b)
        {
            Triangle c = new Triangle();

            c.x1 = a.x1 + b.x1;
            c.y1 = a.y1 + b.y1;

            c.x2 = a.x2 + b.x2;
            c.y2 = a.y2 + b.y2;

            c.x3 = a.x3 + b.x3;
            c.y3 = a.y3 + b.y3;

            return c;

        }


    }
}
