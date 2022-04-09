using System;

namespace ConsoleApp4
{
    public class Cylinder: Circle
    {
        private double h;

        public Cylinder():base()
        {
            h = 0.0;
        }

        public Cylinder(double x_, double y_, double h_, double radius_):base(x_, y_, radius_)
        {
            h = h_;
        }

        public new double GetDistance()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(h / 2, 2));
        }

        public double GetVolume()
        {
            return base.GetArea() * h;
        }

        public Cylinder Add(Cylinder c)
        {
            double x_pos = (x + c.x) / 2;
            double y_pos = (y + c.y) / 2;
            double height = h + c.h;
            double r = radius + c.radius;
            return new Cylinder(x_pos, y_pos, height, r);
        }

        public double GetHeight()
        {
            return h;
        }
    }
}
