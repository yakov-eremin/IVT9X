using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ereminlab2
{
    public class Pryam
    {
        private int vlx { get; set; }
        private int vly { get; set; }
        private int npx { get; set; }
        private int npy { get; set; }

        public int plohad()
        {
            int s;
            s = Math.Abs(vlx - npx) * Math.Abs(vly - npy);
            return s;
        }

        public void init(int vlx1, int vly1, int npx1, int npy1)
        {
            vlx = vlx1;

            vly = vly1;

            npx = npx1;

            npy = npy1;
        }

        public void read()
        {
            Console.Write("Введите координаты верхнего левого угла по оси х, потом по оси у");
            vlx = int.Parse(Console.ReadLine());
            vly = int.Parse(Console.ReadLine());
            Console.Write("Введите координаты нижнего правого угла по оси х, потом по оси у");
            npx = int.Parse(Console.ReadLine());
            npy = int.Parse(Console.ReadLine());
        }

        public void display()
        {
            Console.WriteLine("Координаты верхнего левого угла = ");
            Console.WriteLine(vlx + "," + vly);
            Console.WriteLine("\nКоординаты нижнего правого угла = ");
            Console.WriteLine(npx + "," + npy);
        }

        public Pryam add(Pryam a1, Pryam a2)
        {
            Pryam a3 = new Pryam();
            a3.vlx = a1.vlx + a2.vlx;

            a3.vly = a1.vly + a2.vly;

            a3.npx = a1.npx + a2.npx;

            a3.npy = a1.npy + a2.npy;

            return a3;

        }

        public int calculate(int a, int b)
        {
            int c = a + b;
            return c;
        }

        public int div(int a, int b)
        {
            int c = a/b;
            return c;
        }
    }
}
