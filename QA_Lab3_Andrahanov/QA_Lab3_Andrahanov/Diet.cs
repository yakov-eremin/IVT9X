using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3_Andrahanov
{
    /// \brief Основной класс: Диета
    /// 
    /// Этот класс имеет поля: название диеты, один объект вспомогательного класса, один объект производного класса
    class Diet
    {
        private string nameDiet; // Название диеты
        private Product p = new Product(); // Один объект вспомогательного класса
        private ProductBread pB = new ProductBread(); // Один объект производного класса

        /// Метод для инициализации Диеты
        /// \param[in] nameDiet Название диеты
        /// \param[in] calorieContent1 Калорийность для объекта вспомогательного класса
        /// \param[in] prise1 Стоимость для объекта вспомогательного класса
        /// \param[in] calorieContent2 Калорийность для объекта производного класса
        /// \param[in] prise2 Стоимость для объекта производного класса
        /// \param[in] amountBear Кол-во хлебных единиц
        public void Init(String nameDiet, int calorieContent1, double prise1, int calorieContent2, double prise2, int amountBear)
        {
            this.nameDiet = nameDiet;
            p.Init(calorieContent1, prise1);
            pB.Init(calorieContent2, prise2, amountBear);
        }

        /// Вывод на экран информации о диете
        public void Display()
        {
            Console.WriteLine(nameDiet + ":\nПродукт 1:");
            p.Display();
            Console.WriteLine("Продукт 2:");
            pB.Display();
        }

        /// Функция, предназначенная для подсчёта общей ценности \f${p.Val() + pB.Val()}\f$
        /// <returns> Ценность диеты </returns>
        public double Val()
        {
            return p.Val() + pB.Val();
        }
    }
}
