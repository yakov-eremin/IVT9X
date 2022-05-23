using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    
    public class MyField
    {
        private char[,] mas = new char[10, 10];

        public void init() //инициализация поля
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    mas[i, j] = 'o';
                }
        }

        public char get(int y, int x)
        {
            return mas[y, x];
        }

        public void Display() //вывод поля
        {
            Console.WriteLine("      1   2   3   4   5   6   7   8   9   10");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(i + 1);
                if (i == 9)
                    Console.Write("    ");
                else
                    Console.Write("     ");
                for (int j = 0; j < 10; j++)
                    Console.Write(mas[i, j] + "   ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public class Warships
    {
        private int one = 4;  // Катер
        private int two = 3;  // Эсминец
        private int three = 2;// Крейсер
        private int four = 1; // Линкор

        public int get_one()
        {
            return one;
        }

        public int get_two()
        {
            return two;
        }

        public int get_three()
        {
            return three;
        }

        public int get_four()
        {
            return four;
        }

        public void minus_one()
        {
            one = one - 1;
        }
        public void minus_two()
        {
            two = two - 1;
        }
        public void minus_three()
        {
            three = three - 1;
        }
        public void minus_four()
        {
            four = four - 1;
        }
    }
}
