using System;
using System.IO;

namespace ConsoleApp7
{
    /**
	    @brief Работодатель
        
        Класс работодатель, описывает предоставляемую работу и кол-во занятых мест на каждой работе
    */

    public class Employer
    {
        /// Первая работа
        private Job job1;
        /// Вторая работа
        private AnotherJob job2;
        /// Количество занятых мест (первая работа)
        private int empl1;
        /// Количество занятых мест (вторая работа)
        private int empl2;

        public Employer()
        {
            job1 = new Job();
            job2 = new AnotherJob();
        }

        public Employer(Job j1, AnotherJob j2, int e1, int e2)
        {
            job1 = j1;
            job2 = j2;
            empl1 = e1;
            empl2 = e2;
        }

        /// <summary>
        /// Метод, определяющий полную сумму выплат работникам
        /// </summary>
        /// <returns>Полная сумма выплаты всем работникам</returns>
        public double FullPay()
        {
            return job1.getFullSalary()*empl1 + job2.getFullSalary()*empl2;
        }

        /// <summary>
        /// Метод загрузки данных из файла
        /// </summary>
        /// <param name="p">Путь к файлу с данными</param>
        public void LoadFromFile(string p)
        {
            if (File.Exists(p))
            {
                StreamReader r = new StreamReader(p);

                double s1 = double.Parse(r.ReadLine());
                double k1 = double.Parse(r.ReadLine());
                double s2 = double.Parse(r.ReadLine());
                double k2 = double.Parse(r.ReadLine());
                int t = int.Parse(r.ReadLine());

                job1 = new Job(s1, k1);
                job2 = new AnotherJob(s2, k2, t);
                empl1 = int.Parse(r.ReadLine());
                empl2 = int.Parse(r.ReadLine());
                r.Close();
            }
            else 
                throw new FileNotFoundException("файл не найден!");
        }

        /// <summary>
        /// Метод для вывода основной информации о работах и кол-ве занятых мест в консоль. 
        /// Пример вывода представлен на рисунке.
        /// @image html display.png
        /// </summary>
        public void Display()
        {
            job1.Display();
            job2.Display();
            Console.WriteLine("Занято мест: {0} {1}", empl1, empl2);
        }
    }
}
