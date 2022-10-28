using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3test
{
   
    
        /// \brief  вспомогательный класс Специя
        ///
        ///  Класс имеет поля: Цена, вес и название. В классе описаны методы инициализации, извлечения стоимости, ввода данных, вывода данных.

        public class Spice 
        {
            protected double cost; // Цена изделия
            protected int count; // Вес изделия
            protected string name; // Название изделия

            /// Метод для описания стандартной специи
            public Spice()
            {
                name = "Специя";
                cost = 10;
                count = 1;
            }
            /// Метод для инициализации полей класса
            /// \param[in] coun Вес изделия
            /// \param[in] cos Цена изделия
            /// \param[in] nm Название изделия

            public Spice(string nm, double cos, int coun)
            {
                name = nm;
                cost = cos;
                count = coun;
            }
            /// Метод взятия названия специи 
            public string getname()
            {
                return name;
            }
            /// Метод для инициализации полей класса
            /// \param[in] coun Вес изделия
            /// \param[in] cos Цена изделия
            /// \param[in] nm Название изделия
            public void Init(string nm, double cos, int coun)
            {
                name = nm;
                cost = cos;
                count = coun;
            }
            /// Вывод на экран информации о блюде
            public void Display()
            {
                Console.WriteLine("Название: " + name);
                Console.WriteLine("Цена: " + cost);
                Console.WriteLine("Количество грамм, добавляемое на 1 кг продуктов: " + count);
            }
            /// Метод извлечения стоимости 
            public double Price(double weight)
            {
                double massa;
                double total_cost;
                weight = Math.Round(weight, MidpointRounding.AwayFromZero);
                if (weight == 0)
                    weight++;
                massa = count * weight;
                total_cost = massa * cost;
                return total_cost;
            }
           
        }
        /// \brief Основной класс; //Блюдо
        ///
        /// Этот класс имеет поля: Название специи, количество компонентов в блюде, вес блюда.
        /// Пример использования картинки; \image html 123.jpg
        public class Dish 
        {
            private Spice one = new Spice(); // Название 1 специи
            private Spice two = new Spice(); // Название 2 специи
            private Spice three = new Spice(); // Название 3 специи
            private double weight; // Вес блюда
            private double cost_components; // Стоимость компонентов


            /// Метод для добавления специй в блюдо, позволяет ввести название, цену и количество специи, а также  вес и стоимость остальных компонентов блюда
            
            public Dish(string nm1, double cos1, int coun1, string nm2, double cos2, int coun2, string nm3, double cos3, int coun3, double wei, double cost_comp)
            {
                one.Init(nm1, cos1, coun1);
                two.Init(nm2, cos2, coun2);
                three.Init(nm3, cos3, coun3);
                weight = wei;
                cost_components = cost_comp;
            }

            /// Метод инициализации полей класса
            /// \param[in] wei Вес специи
            /// \param[in] cost_comp Цена специи
            /// \param[in] nm Название специи
            public void Init(string nm1, double cos1, int coun1, string nm2, double cos2, int coun2, string nm3, double cos3, int coun3, double wei, double cost_comp)
            {
                one.Init(nm1, cos1, coun1);
                two.Init(nm2, cos2, coun2);
                three.Init(nm3, cos3, coun3);
                weight = wei;
                cost_components = cost_comp;
            }

            /// Метод для расчета стоимости блюда
            ///  \f$\sqrt{(x_2-x_1)^2+(y_2-y_1)^2}\f$
            public double total_price()
            {
                double s;
                s = cost_components;
                s = s + one.Price(weight);
                s = s + two.Price(weight);
                s = s + three.Price(weight);
                return s;
            }

            /// Метод для выведения самой дешевой специи
            public Spice cheap_spice()
            {
                double a, b, c;
                a = one.Price(weight);
                b = two.Price(weight);
                c = three.Price(weight);
                if (a < b && a < c)
                {
                    Console.WriteLine("Самая дешёвая добавка - " + one.getname());
                    return one;
                }
                if (b < a && b < c)
                {
                    Console.WriteLine("Самая дешёвая добавка - " + two.getname());
                    return two;
                }
                if (c < a && c < b)
                {
                    Console.WriteLine("Самая дешёвая добавка - " + three.getname());
                    return three;
                }
                return null;
            }
        }
       

        /// Метод для добавление новой специи
        public class SpiceFactory
        {
            public Spice CreateSpice(string n, double c, int coun)
            {
                return new Spice(n, c, coun);
            }
        }

         /// Метод добавления нового блюда
        public class DishFactory
        {
            public Dish CreateDish(string n1, double c1, int coun1, string n2, double c2, int coun2, string n3, double c3, int coun3, double w, double c_c)
            {
                return new Dish(n1, c1, coun1, n2, c2, coun2, n3, c3, coun3, w, c_c);
            }
        }
    class testt : Spice
    {

    }
    public class Program
    {

        static void Main(string[] args)
        {
            SpiceFactory sf = new SpiceFactory();
            Spice sp = sf.CreateSpice("Перец", 30, 2);
            Console.WriteLine("Расчёт приправы");
            sp.Display();
            Console.WriteLine("Стоимость приправы на 5 кг блюда: " + sp.Price(5));
            Console.WriteLine("Расчёт блюда");
            DishFactory df = new DishFactory();
            Dish ds = df.CreateDish("Первая", 100, 10, "Вторая", 200, 3, "Третья", 50, 5, 5, 500);
            Console.WriteLine("Полная цена блюда: " + ds.total_price());
            ds.cheap_spice();

            Console.ReadKey();
        }
    }

}
