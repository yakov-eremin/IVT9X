using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_3
{
    public class Section
    { 
        private double x1;
        public double X1
        {
            get
            {
                return x1; // извлечение значения sec
            }
            set
            {
                x1 = value;
            }
        }
        private double x2;
        private double y1;
        private double y2;

        public void Init(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public void Read()
        {
            Console.WriteLine("\nВведите координаты 1 точки: ");
            x1 = Convert.ToDouble(Console.ReadLine());
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nВведите координаты 2 точки: ");
            x2 = Convert.ToDouble(Console.ReadLine());
            y2 = Convert.ToDouble(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("\nКоординаты 1 точки: (" + x1 + ";" + y1 + ")\n"
                    + "Координаты 2 точки: (" + x2 + ";" + y2 + ")");
        }

        public Section Add(Section s1, Section s2)
        {
            Section add = new Section();
            add.x1 = s1.x1;
            add.y1 = s1.y1;

            add.x2 = s2.x2;
            add.y2 = s2.y2;

            return add;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public double Area()
        {
            if (x1 > 0)
            {
                if(x2 > 0)
                {
                    if (y1 > 0 && y2 > 0)
                        return 1;
                    else if (y1 < 0 && y2 < 0)
                        return 0.5;
                } 
            } else
            {
                if (x2 < 0)
                {
                    if (y1 < 0 && y2 < 0)
                        return -1;
                    else if (y1 > 0 && y2 > 0)
                        return -0.5;
                }
            }
            return 0;
        }
    }
}
