using System;

namespace ConsoleApp1
{
    /**
	    @brief Основной класс программы
        
        Содержит метод Main
    */

    class Program
    {
        /// <summary>
        /// Точка входа выполняемой программы
        /// </summary>
        /// <param name="args">Аргументы</param>
        static void Main(string[] args)
        {
            Building Bl1 = new Building(10, 20);
            AnotherBuilding Bl2 = new AnotherBuilding(10, 20, 2);

            Bl1.Display();
            Console.WriteLine(Bl1.AllCost());
            Bl2.Display();
            Console.WriteLine(Bl2.AllCost());

            Company Cmp = new Company("Барнаул-строй", 20, 40, 0);
            Cmp.Display();
            Console.WriteLine("Суммарная стоимость - " + Cmp.AllCost());
            Console.ReadKey();
        }
    }
}
