using System;

namespace ConsoleApp1
{
    /**
	    @brief Компания
        
        Класс, описывающий компанию. Включает в себя два здания (классы Building и AnotherBuilding)
    */

    public class Company
    {
        /// Первое здание
        private Building Bl1;
        /// Второе здание
        private AnotherBuilding Bl2;
        /// Стоимость дополнительных помещений
        private double AddCost;
        /// Наименование компании
        private String Name;

        public Company(String v1, double s1, double c1, int ch)
        {
            Bl1 = new Building(s1, c1);
            Bl2 = new AnotherBuilding(s1, c1, ch);
            Name = v1;
        }

        /// <summary>
        /// Метод, определяющий суммарную стоимость всех зданий компании
        /// </summary>
        /// <returns>Суммарная стоимость</returns>
        public double AllCost()
        {
            return (Bl1.AllCost() + Bl2.AllCost() + AddCost);
        }

        /// <summary>
        /// Метод, выводящий основную информацию о компании и её зданиях
        /// @image html result.png
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Предприятие " + Name);
            Bl1.Display();
            Bl2.Display();
            Console.WriteLine("Дополительные помещения стоимостью - " + AddCost);
        }
    }
}
