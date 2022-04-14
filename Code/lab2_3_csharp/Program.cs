using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2_3_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
			angle a = new angle();
			angle a1 = new angle();
			angle a2 = new angle();
			angle a3 = new angle();
			double m, n, k;
			Console.WriteLine("Первый угол:\n");
			Console.Write("Введите градусы: ");
			m = Convert.ToDouble(Console.ReadLine());
			Console.Write("Введите минуты: ");
			n = Convert.ToDouble(Console.ReadLine());
			Console.Write("Введите секунды: ");
			a1.Sec = Convert.ToDouble(Console.ReadLine());
			k = a1.Sec;
			a1.init(m, n, k);
			Console.WriteLine("Первый угол: ");
			a1.display();
			Console.WriteLine("Приблизительно градусов = " + a1.gradround());
            int sec = a1.Numbersec();
            Console.WriteLine("Всего секунд = " + sec);

            Console.Write("\nВторой угол:\n");
			a2.read();
			Console.WriteLine("Второй угол: ");
			a2.display();
			Console.WriteLine("Приблизительно градусов = " + a2.gradround());
            sec = a2.Numbersec();
            Console.WriteLine("Всего секунд = " + sec);

            a3 = a1.add(a1, a2);
			Console.WriteLine("\nСумма: ");
			a3.display();
			Console.WriteLine("Приблизительно градусов = " + a3.gradround() + "\n");

            angle[] ms;
            ms = new angle[5];
            int i, s;
            for (i = 0; i < 5; i++)
            {
                ms[i] = new angle();  // инициализация каждого элемента
            }
            for (i = 0; i < 5; i++)
            {
                ms[i].init(1, 2, i);
            }
            int[] c = new int[5];  // для числового массива инициализация достаточна
            for (i = 0; i < 5; i++)
            {
                c[i] = ms[i].Numbersec();
            }
            
            s = 0;
            for (i = 0; i < 5; i++)
            {
                s += c[i];
            }
            Console.WriteLine("Массив объектов: ");
            Console.WriteLine("Сумма: " + Convert.ToString(s) + " секунд");
        }
    }
}

