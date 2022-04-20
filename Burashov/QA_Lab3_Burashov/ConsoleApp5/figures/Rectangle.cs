namespace ConsoleApp5.figures
{
    /**
	    @brief Прямоугольник
        
        Наследуется от класса квадрата Square. 
        Прямоугольник задаётся координатами (x, y) и двумя сторонами (a, b).
    */
    public class Rectangle: Square
    {
        /// Вторая сторона
        protected double b;

        public Rectangle():base()
        {
            b = 0.0;
        }

        public Rectangle(double x_pos, double y_pos, double side_a, double side_b):base(x_pos, y_pos, side_a)
        {
            b = side_b;
        }

        /// <summary>
        /// Метод, вычисляющий площадь прямоугольника
        /// </summary>
        /// <returns>Площадь прямоугольника</returns>
        public override double GetArea()
        {
            return a * b;
        }

        /// <summary>
        /// Метод, вычисляющий периметр прямоугольника
        /// </summary>
        /// <returns>Периметр прямоугольника</returns>
        public override double GetPerimeter()
        {
            return (a + b) * 2;
        }
    }
}
