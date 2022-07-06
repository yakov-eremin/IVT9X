using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3
{
    /// \brief Основной класс Окружность
    /// 
    /// Класс имеет поля: координата центра окружности - x,y и радиус - r 
    /// В классе описаны методы инициализации, вывода данных, подсчета расстояния до центра
    /// 
    class Circle
    {
        protected double x; // Координата центра x
        protected double y; // Координата центра y
        protected double r; // Радиус окружности r

        /// Метод для инициализации полей класс
        /// \param[in] a координата x
        /// \param[in] b координата y
        /// \param[in] с радиус r
        /// 
        /// Пример использования картинки в документации:
        /// \image html pic.png
        public void Init(double a, double b, double c)
        {
            x = a;
            y = b;
            r = c;
        }
        /// Вывод на экран информации об окружности
        public void Display()
        {
            Console.Write("Окружность с координатой (" + x + ";" + y + ") с радиусом " + r);
        }
        /// Функция, предназначенная для подсчёта расстояния от центра окружности до начала координат \f$\sqrt{x^2+y^2}\f$
        ///       
        /// \param x координата x
        /// \param y координата y
        /// <returns> Расстояние от центра окружности до (0;0) </returns>
        public double DistanceFromCenterToO()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }

    /// \brief Производный класс: Цилиндр
    /// 
    /// Этот класс наследуется от вспомогательного класса, имеет дополнительное поле - длина стороны z.
    class Cylinder : Circle
    {
        private double z; // Координата z

        /// Метод для инициализации цилиндра
        /// \param[in] a координата x
        /// \param[in] b координата y
        /// \param[in] с радиус r
        /// \param[in] d длина стороны z
        public void Init(double a, double b, double c, double d)
        {
            base.Init(a, b, c);
            z = d;
        }

        /// Вывод на экран информации о цилиндре

        public void Display()
        {
            Console.Write("Цилиндр с длиной стороны - " + z + ".А в основании - ");
            base.Display();
        }

        /// Функция, предназначенная для подсчёта расстояния от центра цилиндра до начала координат \f$\sqrt{x^2+y^2}+0.5*z\f$
        ///       
        /// \param x координата x
        /// \param y координата y
        /// \param z длина стороны цилиндра z
        /// <returns> Расстояние от центра цилиндра до (0;0) </returns>

        public double DistanceFronCenterToOCylinder()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) + 0.5 * z;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle a = new Circle();
            a.Init(3, 4, 5);
            a.Display();
            Console.WriteLine();
            Console.WriteLine(a.DistanceFromCenterToO());
            Cylinder b = new Cylinder();
            b.Init(6, 8, 10, 12);
            b.Display();
            Console.WriteLine();
            Console.WriteLine(b.DistanceFronCenterToOCylinder());
            b.Init(12, 16, 18, 19);
            b.Display();
            Console.WriteLine();
        }
    }
}
