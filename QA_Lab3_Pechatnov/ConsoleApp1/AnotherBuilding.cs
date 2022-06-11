using System;

namespace ConsoleApp1
{
    /**
	    @brief Здание определённого типа
        
        Класс является производным от Building. Помимо площади и стоимости, имеет дополнительное поле с типом здания.
    */

    public class AnotherBuilding : Building
    {
        /// Тип здания
        private int choice;

        public AnotherBuilding(double s, double c, int ch) : base(s, c)
        {
            choice = ch;
        }

        /// <summary>
        /// Метод, выводящий основную информацию о здании
        /// </summary>
        public void Display()
        {
            base.Display();
            if (choice == 0)
                Console.WriteLine("Тип здания - склад");
            else if (choice == 2)
                Console.WriteLine("Тип здания - офис");
            else if (choice == 1)
                Console.WriteLine("Тип здания - обычное");
        }
    }
}
