using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_lib1
{
    public class Parall_Triangle : Triangle
    {
        private int z;

        public Parall_Triangle(int x11, int y11, int x22, int y22, int x33, int y33, int z11) : base(x11, y11, x22, y22, x33, y33)
        {
            z = z11;
        }

        public Parall_Triangle() { }

        public int Get_Z()
        {
            return z;
        }

        public void Put_Z(int z1)
        {
            z = z1;
        }

        public double Perimetr()
        {
            double AB = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double AC = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
            double BC = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));

            return Math.Floor(((AB + AC + BC) * 100) / 100) + z;
        }

        public void Init(int x11, int y11, int x22, int y22, int x33, int y33, int z11)
        {
            base.Init(x11, y11, x22, y22, x33, y33);
            z = z11;
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine("Высота z - " + z);

        }

    }
}
