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

        public void Install_Warships(Warships ws) //установка кораблей
        {
            String s;
            int a = 0;
            int count;
            Console.WriteLine("Выберите тип кораблей для установки");
            count = ws.get_one();
            Console.WriteLine("1) Катер (занимает 1 клетку, доступно: " + count + ")");
            count = ws.get_two();
            Console.WriteLine("2) Эсминец (занимает 2 клетки, доступно: " + count + ")");
            count = ws.get_three();
            Console.WriteLine("3) Крейсер (занимает 3 клетки, доступно: " + count + ")");
            count = ws.get_four();
            Console.WriteLine("4) Линкор (занимает 4 клетки, доступно: " + count + ")");

            while (a == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out a))
                {
                    if (a < 0 || a > 4)
                    {
                        a = 0;
                        Console.WriteLine("Введите число от 1 до 4");
                    }

                    if (a == 1)
                    {
                        count = ws.get_one();
                        if (count == 0)
                        {
                            a = 0;
                            Console.WriteLine("Установленно максимальное количество кораблей такого типа");
                        }
                    }
                    if (a == 2)
                    {
                        count = ws.get_two();
                        if (count == 0)
                        {
                            a = 0;
                            Console.WriteLine("Установленно максимальное количество кораблей такого типа");
                        }
                    }
                    if (a == 3)
                    {
                        count = ws.get_three();
                        if (count == 0)
                        {
                            a = 0;
                            Console.WriteLine("Установленно максимальное количество кораблей такого типа");
                        }
                    }
                    if (a == 4)
                    {
                        count = ws.get_four();
                        if (count == 0)
                        {
                            a = 0;
                            Console.WriteLine("Установленно максимальное количество кораблей такого типа");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            if (a == 1)
            {
                int x1 = 0, y1 = 0;
                Console.WriteLine("Выберите позицию для установки");
                Console.WriteLine("Введите цифру по горизонтали (сверху)");
                while (x1 == 0)
                {
                    s = Console.ReadLine();

                    if (int.TryParse(s, out x1))
                    {
                        if (x1 < 1 || x1 > 10)
                        {
                            x1 = 0;
                            Console.WriteLine("Введите число от 1 до 10");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }

                Console.WriteLine("Введите цифру по вертикали(слева)");
                while (y1 == 0)
                {
                    s = Console.ReadLine();

                    if (int.TryParse(s, out y1))
                    {
                        if (y1 < 1 || y1 > 10)
                        {
                            y1 = 0;
                            Console.WriteLine("Введите число от 1 до 10");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
                Install_One(ws,x1,y1);
            }
            if (a == 2)
                Install_Two(ws);
            if (a == 3)
                Install_Three(ws);
            if (a == 4)
                Install_Four(ws);
        }

        public void Install_One(Warships ws, int x1, int y1) //Для установки кораблей, занимающих одну клетку
        {  
                mas[y1 - 1, x1 - 1] = '*';
                ws.minus_one();
        }

        public void Install_Two(Warships ws) //Для установки кораблей, занимающих 2 клетки
        {
            String s;
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            Console.WriteLine("Выберите начальную позицию для установки");
            Console.WriteLine("Введите цифру по горизонтали (сверху)");
            while (x1 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out x1))
                {
                    if (x1 < 1 || x1 > 10)
                    {
                        x1 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.WriteLine("Введите цифру по вертикали(слева)");
            while (y1 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out y1))
                {
                    if (y1 < 1 || y1 > 10)
                    {
                        y1 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Console.WriteLine("Выберите конечную позицию для установки");
            Console.WriteLine("Введите цифру по горизонтали (сверху)");
            while (x2 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out x2))
                {
                    if (x2 < 1 || x2 > 10)
                    {
                        x2 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.WriteLine("Введите цифру по вертикали(слева)");
            while (y2 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out y2))
                {
                    if (y2 < 1 || y2 > 10)
                    {
                        y2 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            bool f;
            f = IsRight_Two(x1, y1, x2, y2);
            if (f == true)
            {
                if ((x1 - x2) == 0 && y1 > y2)
                    for (int i = y2; i < y1 + 1; i++)
                        mas[i - 1, x1 - 1] = '*';
                if ((x1 - x2) == 0 && y1 < y2)
                    for (int i = y1; i < y2 + 1; i++)
                        mas[i - 1, x1 - 1] = '*';
                if ((y1 - y2) == 0 && x1 > x2)
                    for (int i = x2; i < x1 + 1; i++)
                        mas[y1 - 1, i - 1] = '*';
                if ((y1 - y2) == 0 && x1 < x2)
                    for (int i = x1; i < x2 + 1; i++)
                        mas[y1 - 1, i - 1] = '*';
                ws.minus_two();
            }
            else
            {
                Install_Two(ws);
            }
        }

        public void Install_Three(Warships ws) //Для установки кораблей, занимающих 3 клетки
        {
            String s;
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            Console.WriteLine("Выберите начальную позицию для установки");
            Console.WriteLine("Введите цифру по горизонтали (сверху)");
            while (x1 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out x1))
                {
                    if (x1 < 1 || x1 > 10)
                    {
                        x1 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.WriteLine("Введите цифру по вертикали(слева)");
            while (y1 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out y1))
                {
                    if (y1 < 1 || y1 > 10)
                    {
                        y1 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Console.WriteLine("Выберите конечную позицию для установки");
            Console.WriteLine("Введите цифру по горизонтали (сверху)");
            while (x2 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out x2))
                {
                    if (x2 < 1 || x2 > 10)
                    {
                        x2 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.WriteLine("Введите цифру по вертикали(слева)");
            while (y2 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out y2))
                {
                    if (y2 < 1 || y2 > 10)
                    {
                        y2 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            bool f;
            f = IsRight_Three(x1, y1, x2, y2);
         
            if (f == true)
            {
                if ((x1 - x2) == 0 && y1 > y2)
                    for (int i = y2; i < y1 + 1; i++)
                        mas[i - 1, x1 - 1] = '*';
                if ((x1 - x2) == 0 && y1 < y2)
                    for (int i = y1; i < y2 + 1; i++)
                        mas[i - 1, x1 - 1] = '*';
                if ((y1 - y2) == 0 && x1 > x2)
                    for (int i = x2; i < x1 + 1; i++)
                        mas[y1 - 1, i - 1] = '*';
                if ((y1 - y2) == 0 && x1 < x2)
                    for (int i = x1; i < x2 + 1; i++)
                        mas[y1 - 1, i - 1] = '*';
                ws.minus_three();
            }
            else
            {
                Install_Three(ws);
            }
        }

        public void Install_Four(Warships ws) //Для установки кораблей, занимающих 4 клетки
        {
            String s;
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            Console.WriteLine("Выберите начальную позицию для установки");
            Console.WriteLine("Введите цифру по горизонтали (сверху)");
            while (x1 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out x1))
                {
                    if (x1 < 1 || x1 > 10)
                    {
                        x1 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.WriteLine("Введите цифру по вертикали(слева)");
            while (y1 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out y1))
                {
                    if (y1 < 1 || y1 > 10)
                    {
                        y1 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Console.WriteLine("Выберите конечную позицию для установки");
            Console.WriteLine("Введите цифру по горизонтали (сверху)");
            while (x2 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out x2))
                {
                    if (x2 < 1 || x2 > 10)
                    {
                        x2 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.WriteLine("Введите цифру по вертикали(слева)");
            while (y2 == 0)
            {
                s = Console.ReadLine();

                if (int.TryParse(s, out y2))
                {
                    if (y2 < 1 || y2 > 10)
                    {
                        y2 = 0;
                        Console.WriteLine("Введите число от 1 до 10");
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            bool f;
            f = IsRight_Four(x1, y1, x2, y2);
            if (f == true)
            {
                if ((x1 - x2) == 0 && y1 > y2)
                    for (int i = y2; i < y1 + 1; i++)
                        mas[i - 1, x1 - 1] = '*';
                if ((x1 - x2) == 0 && y1 < y2)
                    for (int i = y1; i < y2 + 1; i++)
                        mas[i - 1, x1 - 1] = '*';
                if ((y1 - y2) == 0 && x1 > x2)
                    for (int i = x2; i < x1 + 1; i++)
                        mas[y1 - 1, i - 1] = '*';
                if ((y1 - y2) == 0 && x1 < x2)
                    for (int i = x1; i < x2 + 1; i++)
                        mas[y1 - 1, i - 1] = '*';
                ws.minus_four();
            }
            else
            {
                Install_Four(ws);
            }
        }


        public bool IsRight_Two(int x1, int y1, int x2, int y2)//проверка размерности корабля
        {
            if ((x1 - x2) == 1 || (x2 - x1) == 1)
            {
                if ((y1 - y2) == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбран неправильный размер корабля!");
                    return false;
                }
            }

            else if ((y1 - y2) == 1 || (y2 - y1) == 1)
            {
                if ((x1 - x2) == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбран неправильный размер корабля!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Выбран неправильный размер корабля!");
                return false;
            }
        }
        public bool IsRight_Three(int x1, int y1, int x2, int y2)//проверка размерности корабля
        {
            if ((x1 - x2) == 2 || (x2 - x1) == 2)
            {
                if ((y1 - y2) == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбран неправильный размер корабля!");
                    return false;
                }
            }

            else if ((y1 - y2) == 2 || (y2 - y1) == 2)
            {
                if ((x1 - x2) == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбран неправильный размер корабля!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Выбран неправильный размер корабля!");
                return false;
            }
        }

        public bool IsRight_Four(int x1, int y1, int x2, int y2)//проверка размерности корабля
        {
            if ((x1 - x2) == 3 || (x2 - x1) == 3)
            {
                if ((y1 - y2) == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбран неправильный размер корабля!");
                    return false;
                }
            }

            else if ((y1 - y2) == 3 || (y2 - y1) == 3)
            {
                if ((x1 - x2) == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Выбран неправильный размер корабля!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Выбран неправильный размер корабля!");
                return false;
            }
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
