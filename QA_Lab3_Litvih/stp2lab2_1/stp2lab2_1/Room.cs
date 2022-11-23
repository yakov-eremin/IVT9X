using System;
using System.Collections.Generic;
using System.Text;

namespace stp2lab2_1
{
    /*!
     * \brief вспомогательный класс Комната
     * 
     * Класс имеет поля: площадь и кол-во людей. В классе описаны методы инициализации, вывода данных, расчета площади.
     */
    public class Room
    {
        protected double S; ///< Площадь комнаты
        protected int count; ///< Кол-во людей
        public Room(double xx, int yy)
        {
            S = xx;
            count = yy;
        }

        public Room()
        {
            S = 0;
            count = 0;
        }
        /*!
         * метод инициализации полей класса
         * \param x Площадь комнаты
         * \param y Кол-во людей
         */
        public void Init(double x, int y)
        {
            S = x;
            count = y;
        }
        /// вывод информации на экран
        public void Display()
        {
            Console.WriteLine("Площадь комнаты: " + S + "; Кол-во людей: " + count);
        }
        /// метод вычисления площади на одного человека
        /// 
        /// \return размер площади приходящуюся на одного человека
        public double ForOne()
        {
            return S / count;
        }
    }
    /// \brief вспомогательный класс Построение комнаты
    /// 
    /// Класс имеет поля: площадь и кол-во людей. В классе описан метод создания комнаты.
    public class RoomFabric
    {
        /// метод создания комнаты
        /// \param x Площадь
        /// \param y Кол-во людей
        public Room CreateRoom(double x, int y)
        {
            return new Room(x, y);
        }
    }

}
