using System;

namespace ConsoleApp7
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
            Job job1 = new Job(30000, 1.1);
            AnotherJob job2 = new AnotherJob(40000, 1.2, 1);
            Employer e = new Employer(job1, job2, 10, 15);
            e.Display();
            Console.WriteLine("FullPay = {0}", e.FullPay());
            Console.ReadKey();
        }
    }
}
