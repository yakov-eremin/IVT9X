using System;

namespace Lab_2
{
   public class Complex
    {
        public int ic; //Вещественное число
        public int mc; // Мнимое число

        public int Mc //property
        {
            get
            {
                return mc; // извлечение значения Mc
            }
            set
            {
                mc = value;
            }

        }

        public void Init(int i, int m) //Инициализация комплексного числа
        {
            ic = i;
            mc = m;
        }
        public double Modul() //Модуль комплексного числа
        {
            double k;
            k = Math.Sqrt(ic * ic + mc * mc);
            return k;
        }
        public void Read() //Чтение комплексного числа
        {
            string s = "", s1 = "";
            Console.WriteLine("Введите вещественную часть: ");
            s = Console.ReadLine();
            Console.WriteLine("Введите мнимую часть: ");
            s1 = Console.ReadLine();
            ic = Convert.ToInt32(s);
            mc = Convert.ToInt32(s1);

        }
        public void Display() // Вывод комплексного числа
        {
            string s, s1;
            s1 = Convert.ToString(ic);
            s = Convert.ToString(mc);
            Console.WriteLine("z = " + s1 + " + " + s + "i");
        }
        public Complex Add(Complex a, Complex b) // Сложение комплексных чисел
        {
            Complex c = new Complex();
            c.ic = a.ic + b.ic;
            c.mc = a.mc + b.mc;
            return c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int g;
            double k;
            Complex a = new Complex();
            Complex b = new Complex();
            Complex c = new Complex();
            Console.WriteLine("Ввод 1 комплексного числа");
            a.Read();
            a.Mc = 30; // property
            g = a.Mc;  //
            Console.WriteLine("Ввод 2 комплексного числа");
            b.Read();
            c = c.Add(a, b);
            k = a.Modul();
            Console.WriteLine("Модуль комплексного числа:" + k);
            Console.WriteLine("Результат сложения комплексных чисел: ");
            c.Display();
        }
    }
}

