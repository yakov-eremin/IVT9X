using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    /// Ювелирный магазин
    /// @image html Jewerly_shop
    class Jewerly_shop
    {
        /// Драгаценность
        private Jewel FirstJewel = new Jewel();
        /// Драгоценный камень
        private ValuableJewel SecondJewel = new ValuableJewel();
        /// Наименование магазина
        private String Name;
        
        /** 
         * устанавливает вес и цену драгоценностей и наименование магазина
         * @param n1 - Наименование магазина
         * @param w - Вес в граммах
         * @param p - Цена за грамм
         */
        public void Init(String n1, double w, double p)
        {
            FirstJewel.Init(w, p);
            SecondJewel.Init(w, p);
            Name = n1;
        }
        
        /// выводит содержимое класса
        public void Display()
        {
            Console.WriteLine("Магазин " + Name);
            FirstJewel.Display();
            SecondJewel.Display();
        }
        /**
         * Полная стоимость всех драгоценнностей
         * @see Jewel::Cost
         * @see ValuableJewel::Cost
         * @return Полная стоимость всех драгоценнностей
         */
        public double FullProfit()
        {
            double FullProfit = 0.0;
            FullProfit = FirstJewel.Cost() + SecondJewel.Cost();
            return FullProfit;
        }
    }
}
