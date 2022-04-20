namespace ConsoleApp5.interfaces
{
    /**
	    @brief Интерфейс для вычисления параметров фигур
        
        Параметры фигур: площадь и периметр
    */
    interface IFigureProperties
    {
        /// <summary>
        /// Метод для определения площади фигуры
        /// </summary>
        /// <returns>Плоащдь фигуры</returns>
        double GetArea();

        /// <summary>
        /// Метод для определения периметра фигуры
        /// </summary>
        /// <returns>Периметр фигуры</returns>
        double GetPerimeter();
    }
}
