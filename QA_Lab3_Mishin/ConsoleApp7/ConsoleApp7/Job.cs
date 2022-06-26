using System;

namespace ConsoleApp7
{
    /**
	    @brief Работа
        
        Класс описывает работу (зарплата и коэффициент доплаты за квалификацию)
    */
    
    public class Job
    {
        /// Зарплата
        protected double salary;
        /// Коэффициент доплаты за квалификацию
        protected double k;

        public Job()
        {
            salary = 0.0;
            k = 1.0;
        }

        public Job(double salary_, double k_)
        {
            salary = salary_;
            k = k_;
        }

        /// <summary>
        /// Метод вычисления полной зарплаты с учетом коэффициента доплаты за квалификацию. 
        /// Формула: \f$S=Z\star k\f$ (Z - зарплата, k - коэф. доплаты, S - полная зарплата)
        /// </summary>
        /// <returns>Зарплата с учетом коэффициента доплаты за квалификацию</returns>
        public double getFullSalary()
        {
            return salary * k;
        }

        /// <summary>
        /// Метод для вывода основной информации о работе в консоль
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Зарплата: {0}\nКоэф. доплаты за квалификацию: {1}", salary, k);
        }
    }
}
