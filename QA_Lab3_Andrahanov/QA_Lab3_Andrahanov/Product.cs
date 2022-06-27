using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3_Andrahanov
{
    /// \brief Вспомогательный класс Продукт
    /// 
    /// Класс имеет поля: Калорийность 100 гр., стоимость 100 гр. В классе описаны методы инициализации, вывода данных, а также метод, вычисляющий ценность продукта
    /// 
    class Product
    {
        protected int calorieContent; // Калорийность 100 гр.
        protected double prise; // Стоимость 100 гр.

        /// Метод для инициализации полей класс
        /// \param[in] calorieContent Калорийность 100 гр.
        /// \param[in] prise Стоимость 100 гр.
        public void Init(int calorieContent, double prise)
        {
            this.calorieContent = calorieContent;
            this.prise = prise;
        }

        /// Вывод на экран информации о продукте
        public void Display()
        {
            Console.WriteLine("Калорийность продукта: " + calorieContent
                    + "\nСтоимость продукта: " + prise);
        }

        /// Функция, предназначенная для подсчёта ценности продукта \f${prise/calorieContent}\f$
        /// \image html mem.png
        /// <returns> Ценность продукта </returns>
        public double Val()
        {
            return prise / calorieContent;
        }
    }

    /// \brief Производный класс: Хлебный продукт
    /// 
    /// Этот класс наследуется от вспомогательного класса, имеет дополнительное поле - кол-во хлебных единиц.
    class ProductBread : Product
    {
        private int amountBread; // Кол-во хлебных единиц

        /// Метод для инициализации хлебного продукта
        /// \param[in] calorieContent Калорийность 100 гр.
        /// \param[in] prise Стоимость 100 гр.
        /// \param[in] amountBread Кол-во хлебных единиц
        public void Init(int calorieContent, double prise, int amountBread)
        {
            base.Init(calorieContent, prise);
            this.amountBread = amountBread;
        }

        /// Вывод на экран информации о хлебном продукте
        public void Display()
        {
            base.Display();
            Console.WriteLine("Количество хлебных единиц: " + amountBread);
        }

        /// Функция, предназначенная для подсчёта ценности продукта \f${prise/(calorieContent*amountBread*2)}\f$
        /// <returns> Ценность продукта </returns>
        public double Val()
        {
            return prise / (calorieContent * amountBread * 2);
        }
    }
}
