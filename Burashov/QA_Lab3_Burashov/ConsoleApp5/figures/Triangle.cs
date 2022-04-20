using System;

namespace ConsoleApp5.figures
{
    /**
	    @brief Равнобедренный треугольник
        
        Наследуется от абстрактного класса Figure. 
        Равнобедренный треугольник задаётся координатами (x, y), основанием (a) и высотой (h).
    */
    public class Triangle : Figure
    {
        /// Основание равнобедренного треугольника
        protected double a;
        /// Высота равнобедренного треугольника
        protected double h;

        public Triangle():base()
        {
            a = 0.0;
            h = 0.0;
        }

        public Triangle(double x_pos, double y_pos, double a_, double h_):base(x_pos, y_pos)
        {
            a = a_;
            h = h_;
        }

        /// <summary>
        /// Метод, вычисляющий площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public override double GetArea()
        {
            return 0.5 * a * h;
        }

        /// <summary>
        /// Метод, вычисляющий периметр треугольника
        /// </summary>
        /// <returns>Периметр треугольника</returns>
        public override double GetPerimeter()
        {
            return 2 * Math.Sqrt(Math.Pow(h, 2) + Math.Pow(a, 2) / 4) + a;
        }
    }
}
