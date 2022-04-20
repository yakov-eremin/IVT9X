using System;

namespace ConsoleApp5.figures
{
    /**
	    @brief Эллипс
        
        Наследуется от класса окружности Circle. 
        Эллипс задаётся координатами (x, y) и двумя радиусами.
        @image html ellipse_image.png
    */
    public class Ellipse: Circle
    {
        /// Второй радиус
        protected double r2;

        public Ellipse():base()
        {
            r2 = 0.0;
        }

        public Ellipse(double x_pos, double y_pos, double radius_1, double radius_2):base(x_pos, y_pos, radius_1)
        {
            r2 = radius_2;
        }

        /// <summary>
        /// Метод, вычисляющий площадь эллипса
        /// </summary>
        /// <returns>Площадь эллипса</returns>
        public override double GetArea()
        {
            return Math.PI * r * r2 * 4;
        }

        /// <summary>
        /// Метод, вычисляющий периметр эллипса
        /// </summary>
        /// <returns>Периметр эллипса</returns>
        public override double GetPerimeter()
        {
            double a = (r > r2) ? 2 * r : 2 * r2; // большая полуось
            double b = (r > r2) ? 2 * r2 : 2 * r; // малая полуось
            return 4 * (Math.PI * a * b + (a - b)) / (a + b);
        }
    }
}
