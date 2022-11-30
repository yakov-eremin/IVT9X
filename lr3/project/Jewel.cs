using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    /// Драгоценность
    /// @image html jewel.jpg
    class Jewel
    {
        /// Вес в граммах
        private double Weight;
        /// Цена за грамм
        private double Price;
        
        /** 
         * устанавливает вес и цену
         * @param w - Вес в граммах
         * @param p - Цена за грамм
         */
        public void Init(double w, double p)
        {
            Weight = w;
            Price = p;
        }
        
        /// выводит содержимое класса
        public void Display()
        {
            Console.WriteLine("Вес изделия - " + Weight + " гр. Цена - " + Price);
        }
        
        /**
         * Полная стоимость драгоценности
         * @f$ Weight * Price @f$
         * @return Полная стоимость драгоценности
         */
        public double Cost()
        {
            return Weight * Price;
        }
    }
}
