using System;

namespace ConsoleApp5.figures
{
    /**
	    @brief Квадрат
        
        Наследуется от абстрактного класса Figure. 
        Квадрат задаётся координатами (x, y) и стороной (a).
    */
    public class Square: Figure
    {
        /// Сторона
        protected double a;

        public Square():base()
        {
            a = 0.0;
        }

        public Square(double x_pos, double y_pos, double side_a):base(x_pos, y_pos)
        {
            a = side_a;
        }

        /// <summary>
        /// Метод, вычисляющий площадь квадрата
        /// </summary>
        /// <returns>Площадь квадрата</returns>
        public override double GetArea()
        {
            return Math.Pow(a, 2);
        }

        /// <summary>
        /// Метод, вычисляющий периметр квадрата
        /// </summary>
        /// <returns>Периметр квадрата</returns>
        public override double GetPerimeter()
        {
            return 4 * a;
        }
    }
}
