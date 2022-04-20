using System;

namespace ConsoleApp5.figures
{
    /**
	    @brief Окружность
        
        Наследуется от абстрактного класса Figure. 
        Окружность задаётся координатами (x, y) и радиусом.
    */
    public class Circle : Figure
    {
        /// Радиус
        protected double r;

        public Circle():base()
        {
            r = 0.0;
        }
        
        public Circle(double x_pos, double y_pos, double radius):base(x_pos, y_pos)
        {
            r = radius;
        }

        /// <summary>
        /// Метод, вычисляющий площадь окружности (Формула: \f$S = \pi r^2\f$)
        /// </summary>
        /// <returns>Площадь окружности</returns>
        public override double GetArea()
        {
            return Math.PI * Math.Pow(r, 2);
        }

        /// <summary>
        /// Метод, вычисляющий периметр окружности (Формула: \f$P = 2 \pi r\f$)
        /// </summary>
        /// <returns>Периметр окружности</returns>
        public override double GetPerimeter()
        {
            return Math.PI * r * 2;
        }
    }
}
