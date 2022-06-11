using System;

namespace ConsoleApp1
{
    /**
	    @brief Здание
        
        Класс описывает здание. Задаётся площадью и стоимостью одного квадратного метра.
    */

    public class Building
    {
        /// Стоимость одного квадратного метра
        private double Cost;
        /// Площадь (в квадратных метрах)
        private double Square;

        public Building()
        {
            Cost = 0;
            Square = 0;
        }

        public Building(double s, double c)
        {
            Cost = c;
            Square = s;
        }

        /// <summary>
        /// Метод, определяющий стоимость всего здания
        /// \f$P=C\star S\f$
        /// (P - стоимость здания, C - цена за 1 кв.м., S - площадь)
        /// </summary>
        /// <returns>Стоимость здания</returns>
        public double AllCost()
        {
            return Cost * Square;
        }

        /// <summary>
        /// Метод, выводящий основную информацию о здании
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Площадь - " + Square + " кв.м . Стоимость 1 кв. метра - " + Cost);
        }
    }
}
