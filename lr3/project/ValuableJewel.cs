using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    /// Драгоценный камень
    /// @image html valuable-jewel.jpg
    class ValuableJewel : Jewel
    {
        
        /** 
         * устанавливает вес и цену
         * @param w - Вес в граммах
         * @param p - Цена за грамм
         */
        public void Init(double w, double p)
        {
            base.Init(w, p);
        }

        /// выводит содержимое класса
        public void Display()
        {
            base.Display();
        }

        
        /**
         * Полная стоимость драгоценного камня
         * @see Jewel::Cost
         * @return Полная стоимость драгоценного камня
         */
        public double Cost()
        {
            return base.Cost();
        }
    }
}
