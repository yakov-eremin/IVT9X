using System;
using System.Collections.Generic;
using System.Text;

namespace stp2lab2_1
{
    /*!
     * \brief Основной класс Дом
     * 
     * Класс имеет поле: дополнительная площадь.В классе описаны методы инициализации, вывода информации на экран, определения наименьшей площади на одного человека. 
     */
    public class House
    {
        private double SS;///< Дополнительная площадь
        private Room house1 = new Room();///< объект класса Дом 
        private Room house2 = new Room();///< объект класса Дом 
        private Room house3 = new Room();///< объект класса Дом 
        /*!
        * \brief метод инициализации полей класса
        * \param x1 площадь первой комнаты
        * \param y1 кол-во человек первой комнаты
        * \param x2 площадь второй комнаты
        * \param y2 кол-во человек второй комнаты
        * \param x3 площадь третьей комнаты
        * \param y3 кол-во человек третьей комнаты
        * \param z3 дополнительная площадь
        */
        public House(double x1, int y1, double x2, int y2, double x3, int y3, double z3)
        {
            house1.Init(x1, y1);
            house2.Init(x2, y2);
            house3.Init(x3, y3);
            SS = z3;
        }
        /// метод вывода данных на экран
        public void Display()
        {
            house1.Display();
            house2.Display();
            house3.Display();
            Console.WriteLine("Дополнительная площадь комнаты: " + SS);
        }
        /// метод вычисления наименьшей площади
        /// \return наименьшую площадь
        public double Lowest()
        {
            double plosh1, plosh2, plosh3;
            plosh1 = house1.ForOne() + SS;
            plosh3 = house2.ForOne() + SS;
            plosh2 = house3.ForOne() + SS;
            if ((plosh1 < plosh2) && (plosh1 < plosh3)) return plosh1;
            else if ((plosh3 < plosh1) && (plosh3 < plosh2)) return plosh3;
            else return plosh2;
        }
    }
    /// \brief вспомогательный класс Построение дома
    /// 
    /// Класс имеет поля: площади и кол-ва людей. В классе описан метод создания дома.
    public class HouseFabric
    {
        /*!
         * метод создания дома
         * \param x1 площадь первой комнаты
         * \param y1 кол-во человек первой комнаты
         * \param x2 площадь второй комнаты
         * \param y2 кол-во человек второй комнаты
         * \param x3 площадь третьей комнаты
         * \param y3 кол-во человек третьей комнаты
         * \param z3 дополнительная площадь
         */
        public House CreateHouse(double x1, int y1, double x2, int y2, double x3, int y3, double z3)
        {
            return new House(x1, y1, x2, y2, x3, y3, z3);
        }
    }
}
