using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QA_Lab3
{
    /// \brief Вспомогательный класс Культура
    /// 
    /// Класс имеет поля: Стоимость затрат на один гектар, доход. В классе описаны методы инициализации, вывода данных, а также метод, вычисляющий прибыль 
    /// 
    class Culture
    {
        protected double Cost; // Стоимость затрат на один гектар
        protected double Income; // Стоимость от продажи с одного гектара (доход)


        /// Метод для инициализации полей класс
        /// \param[in] c Стоимость затрат
        /// \param[in] i Доход
        public void Init(double c, double i)
        {
            Cost = c;
            Income = i;
        }

        /// Вывод на экран информации о культуре
        public void Display()
        {
            Console.WriteLine("Затраты на культуру: " + Cost + " . Доход с культуры: " + Income);
        }
        /// Функция, предназначенная для подсчёта прибыли \f$\{Income-Cost}\f$
        /// \param Income стоимость затрат
        /// \param Cost Доход
        /// <returns> Прибыль культуры </returns>
        public double Profit()
        {
            double k;
            k = (Income - Cost);
            return k;
        }

    }
    /// \brief Производный класс: Профессиональная культура
    /// 
    /// Этот класс наследуется от вспомогательного класса, имеет дополнительное поле - орашаемость.
    class profCulture : Culture
    {
        private int plus30; // Орашаемость

        /// Метод для инициализации профессиональной культуры
        /// \param[in] c Стоимость затрат
        /// \param[in] i Доход
        /// \param[in] p Орашаемость
        public void Init(double c, double i, int p)
        {
            base.Init(c, i);
            plus30 = p;
        }
        /// Вывод на экран информации о профессиональной культуре
        public void Display()
        {
            base.Display();
            if (plus30 == 1)
            {
                Console.WriteLine("Поле - орошаемое");
            }
            else
            {
                Console.WriteLine("Поле - не орошаемое");
            }
        }
        /// Функция, предназначенная для подсчёта прибыли \f$ {(income-cost)}\f$
        /// \param Income стоимость затрат
        /// \param Cost Доход
        /// \param plus30 Орашаемость
        /// <returns> Прибыль профессиональной культуры </returns>
        public double Profit()
        {
            double c;
            c = Income - Cost;
            if (plus30 == 1)
                return 1.3 * c;
            else
                return c;
        }

    }

    /// \brief Основной класс: Деревня
    /// 
    /// Этот класс имеет поля: название деревни, один объект вспомогательного класса, один объект производного класса
    public class Village
    {
        private Culture Cl = new Culture(); // Один объект вспомогательного класса
        private profCulture pC = new profCulture(); // Один объект производного класса
        private String Name; // Название деревни

        /// Метод для инициализации Деревни
        /// \param[in] n1 Название деревни
        /// \param[in] c1 Стоимость затрат для объекта вспомогательного класса
        /// \param[in] i1 Доход для объекта вспомогательного класса
        /// \param[in] c2 Стоимость затрат для объекта производного класса
        /// \param[in] i2 Доход для объекта производного класса
        /// \param[in] p Орашаемость
        public void Init(String n1, double c1, double i1, double c2, double i2, int p)
        {
            Cl.Init(c1, i1);
            pC.Init(c2, i2, p);
            Name = n1;
        }
        /// Вывод на экран информации о деревне
        public void Display()
        {
            Console.WriteLine("Деревня " + Name);
            Cl.Display();
            pC.Display();
        }
        /// Функция, предназначенная для подсчёта общей прибыли \f$\{pC.Profit() + Cl.Profit()}\f$
        /// \param Income стоимость затрат
        /// \param Cost Доход
        /// \param plus30 Орашаемость
        /// <returns> Прибыль с двух культур </returns>
        public double Profit()
        {
            double fp = 0;
            fp += pC.Profit();
            fp += Cl.Profit();
            return fp;
        }


    }
    class Program
    {

        static void Main(string[] args)
        {
            Village Vl = new Village();
            Vl.Init("Бобровка", 20, 40, 30, 50, 1);
            Vl.Display();
            Console.WriteLine("Общая прибыль " + Vl.Profit());
        }
    }


}