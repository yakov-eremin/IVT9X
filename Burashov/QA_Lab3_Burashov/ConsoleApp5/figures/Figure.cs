using ConsoleApp5.interfaces;
using System;

namespace ConsoleApp5.figures
{
    /**
	    @brief Геометрическая фигура
        
        Абстрактный класс, реализует интерфейс IFigureProperties. 
	    Каждая фигура задана в системе координат (x, y).
    */
    public abstract class Figure: IFigureProperties
    {
        /// Координата фигуры по оси x
        protected double x;
        /// Координата фигуры по оси y
        protected double y;

        public Figure()
        {
            x = 0.0;
            y = 0.0;
        }

        public Figure(double x_pos, double y_pos)
        {
            x = x_pos;
            y = y_pos;
        }

        /// <summary>
        /// Метод для определения расстояния до фигуры от начала координат
        /// </summary>
        /// <returns>Расстояние до фигуры от начала координат</returns>
        public double GetDistance()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        /// <summary>
        /// Абстрактный метод, вычисляющий площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        public abstract double GetArea();

        /// <summary>
        /// Абстрактный метод, вычисляющий периметр фигуры
        /// </summary>
        /// <returns>Периметр фигуры</returns>
        public abstract double GetPerimeter();
    }
}
