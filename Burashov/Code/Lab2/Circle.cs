using System;

namespace ConsoleApp4
{
    public class Circle
    {
        protected double x;
        protected double y;
        protected double radius;

        public Circle()
        {
            x = 0.0;
            y = 0.0;
            radius = 0.0;
        }

        public Circle(double x_, double y_, double radius_)
        {
            x = x_;
            y = y_;
            radius = radius_;
        }

        public double GetDistance()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetNearestPointDistance()
        {
            return Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) - radius);
        }

        public Circle Add(Circle c)
        {
            double x_pos = (x + c.x) / 2;
            double y_pos = (y + c.y) / 2;
            double r = radius + c.radius;
            return new Circle(x_pos, y_pos, r);
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public double GetRadius()
        {
            return radius;
        }
    }
}
