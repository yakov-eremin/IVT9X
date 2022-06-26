using System;

namespace ConsoleApp7
{
    /**
	    @brief Дочерный класс Работа
        
        Дочерный класс работы с дополнительным полем type (сложность работы)
    */

    public class AnotherJob: Job
    {
        /// Сложность работы
        private int type;

        public AnotherJob():base()
        {
            type = 0;
        }

        public AnotherJob(double salary_, double k_, int type_):base(salary_, k_)
        {
            type = type_;
        }

        /// <summary>
        /// Метод вычисления полной зарплаты с учетом коэффициента доплаты за квалификацию и сложности  работы. 
        /// Если сложность работы равна 1, то зарплата увеличивается в два раза
        /// </summary>
        /// <returns>Зарплата с учетом коэффициента доплаты за квалификацию и сложности работы</returns>
        public double getFullSalary()
        {
            if (type == 1)
                return base.getFullSalary() * 2;
            else
                return base.getFullSalary();
        }

        /// <summary>
        /// Метод для вывода основной информации о работе в консоль
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Зарплата: {0}\nКоэф. доплаты за квалификацию: {1}\nТип: {2}", salary, k, type);
        }
    }
}
