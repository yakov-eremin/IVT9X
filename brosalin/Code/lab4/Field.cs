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
        private char[,] fire = new char[10, 10];
        public int fin = 0;

        public void init() //инициализация поля
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    mas[i, j] = 'o';
                    fire[i, j] = 'o';
                }
        }

        public char get(int y, int x)
        {
            return mas[y, x];
        }

        public void set(int x, int y)
        {
            mas[y, x] = 'X';
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

        public void Display_Attack() //вывод поля атаки
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
                    Console.Write(fire[i, j] + "   ");
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
            bool f;
            f = Location_One(x1, y1);
            if (f == true)
            {
                mas[y1 - 1, x1 - 1] = '*';
                ws.minus_one();
                ws.Loc1(x1 - 1, y1 - 1);
            }
            else
            {
                Console.WriteLine("Корабль расположен слишком близком к остальным!!!");
                Install_One(ws,x1,y1);
            }
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

            bool f, f2;
            f = IsRight_Two(x1, y1, x2, y2);
            f2 = Location_many(x1, y1, x2, y2);
            if (f == true && f2 == true)
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
                ws.Loc2(x1 - 1, y1 - 1, x2 - 1, y2 - 1);
            }
            else
            {
                if (f2 == false)
                    Console.WriteLine("Корабль расположен слишком близком к остальным!!!");
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
            bool f, f2;
            f = IsRight_Three(x1, y1, x2, y2);
            f2 = Location_many(x1, y1, x2, y2);
            if (f == true && f2 == true)
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
                ws.Loc3(x1 - 1, y1 - 1, x2 - 1, y2 - 1);
            }
            else
            {
                if (f2 == false)
                    Console.WriteLine("Корабль расположен слишком близком к остальным!!!");
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
            bool f, f2;
            f = IsRight_Four(x1, y1, x2, y2);
            f2 = Location_many(x1, y1, x2, y2);
            if (f == true && f2 == true)
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
                ws.Loc4(x1 - 1, y1 - 1, x2 - 1, y2 - 1);
            }
            else
            {
                if (f2 == false)
                    Console.WriteLine("Корабль расположен слишком близком к остальным!!!");
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

        public bool Location_One(int x1, int y1)//Проверка правильности размещения (между кораблями должно быть свободное пространство - 1 клетка)
        {

            x1 = x1 - 1;
            y1 = y1 - 1;

            if (y1 - 1 >= 0 && x1 - 1 >= 0)
                if (mas[y1 - 1, x1 - 1] == '*')
                    return false;
            if (x1 - 1 >= 0)
                if (mas[y1, x1 - 1] == '*')
                    return false;
            if (y1 + 1 <= 9 && x1 - 1 >= 0)
                if (mas[y1 + 1, x1 - 1] == '*')
                    return false;

            if (y1 - 1 >= 0 && x1 + 1 <= 9)
                if (mas[y1 - 1, x1 + 1] == '*')
                    return false;
            if (x1 + 1 <= 9)
                if (mas[y1, x1 + 1] == '*')
                    return false;
            if (y1 + 1 <= 9 && x1 + 1 <= 9)
                if (mas[y1 + 1, x1 + 1] == '*')
                    return false;
            if (y1 - 1 >= 0)
                if (mas[y1 - 1, x1] == '*')
                    return false;
            if (y1 + 1 <= 9)
                if (mas[y1 + 1, x1] == '*')
                    return false;
            return true;

        }

        public bool Location_many(int x1, int y1, int x2, int y2) //Проверка правильности размещения (между кораблями должно быть свободное пространство - 1 клетка)
        {
            int checkx;
            int checky;

            checkx = x1 - x2;
            checky = y1 - y2;

            x1 = x1 - 1;
            x2 = x2 - 1;
            y1 = y1 - 1;
            y2 = y2 - 1;


            if (y1 - 1 >= 0 && x1 - 1 >= 0)
                if (mas[y1 - 1, x1 - 1] == '*')
                    return false;
            if (x1 - 1 >= 0)
                if (mas[y1, x1 - 1] == '*')
                    return false;
            if (y1 + 1 <= 9 && x1 - 1 >= 0)
                if (mas[y1 + 1, x1 - 1] == '*')
                    return false;

            if (y2 - 1 >= 0 && x2 - 1 >= 0)
                if (mas[y2 - 1, x2 - 1] == '*')
                    return false;
            if (x2 - 1 >= 0)
                if (mas[y2, x2 - 1] == '*')
                    return false;
            if (y2 + 1 <= 9 && x2 - 1 >= 0)
                if (mas[y2 + 1, x2 - 1] == '*')
                    return false;

            if (y1 - 1 >= 0 && x1 + 1 <= 9)
                if (mas[y1 - 1, x1 + 1] == '*')
                    return false;
            if (x1 + 1 <= 9)
                if (mas[y1, x1 + 1] == '*')
                    return false;
            if (y1 + 1 <= 9 && x1 + 1 <= 9)
                if (mas[y1 + 1, x1 + 1] == '*')
                    return false;

            if (y2 - 1 >= 0 && x2 + 1 <= 9)
                if (mas[y2 - 1, x2 + 1] == '*')
                    return false;
            if (x2 + 1 <= 9)
                if (mas[y2, x2 + 1] == '*')
                    return false;
            if (y2 + 1 <= 9 && x2 + 1 <= 9)
                if (mas[y2 + 1, x2 + 1] == '*')
                    return false;
            if (checkx == 0)
            {
                if (y1 - 1 >= 0)
                    if (mas[y1 - 1, x1] == '*')
                        return false;
                if (y1 + 1 <= 9)
                    if (mas[y1 + 1, x1] == '*')
                        return false;
                if (y2 - 1 >= 0)
                    if (mas[y2 - 1, x2] == '*')
                        return false;
                if (y2 + 1 <= 9)
                    if (mas[y2 + 1, x2] == '*')
                        return false;
            }

            if (checky == 0)
            {
                if (x1 - 1 >= 0)
                    if (mas[y1, x1 - 1] == '*')
                        return false;
                if (x1 + 1 <= 9)
                    if (mas[y1, x1 + 1] == '*')
                        return false;
                if (x2 - 1 >= 0)
                    if (mas[y2, x2 - 1] == '*')
                        return false;
                if (x2 + 1 <= 9)
                    if (mas[y2, x2 + 1] == '*')
                        return false;
            }
            return true;

        }

        public bool Attack(MyField field, Warships wr)
        {
            bool f;
            int x1 = 0, y1 = 0;
            String s;
            char A;
            Console.WriteLine("Выберите позицию для Атаки");
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
            x1 = x1 - 1;
            y1 = y1 - 1;
            A = field.get(y1, x1);
            if (A == 'X')
            {
                Console.WriteLine("Вы уже атаковали данную точку");
                Attack(field, wr);
            }

            if (A == '#')
            {
                Console.WriteLine("Вы уже атаковали данную точку");
                Attack(field, wr);
            }
            if (A == '*')
            {
                fire[y1, x1] = 'X';
                field.set(x1, y1);
                f = wr.compare_Loc(x1, y1, field);
                if (f == true)
                {
                    Console.WriteLine("Корабль уничтожен!");
                    fin++;
                }
                else
                    Console.WriteLine("Попал!");
                return true;
            }

            else
            {
                Console.WriteLine("Промах");
                fire[y1, x1] = '#';
                return false;
            }
        }

        public int win(int a)
        {
            if (fin == 10)
            {
                a = 1;
            }

            return a;
        }
    }
    public class Warships
    {
        private int one = 4;  // Катер
        private int two = 3;  // Эсминец
        private int three = 2;// Крейсер
        private int four = 1; // Линкор
        public int[,] coord1 = new int[4, 2];
        private int[,] coord2 = new int[3, 4];
        private int[,] coord3 = new int[2, 4];
        private int[,] coord4 = new int[1, 4];
        private int i1 = 0, j1 = 0;
        private int i2 = 0, j2 = 0;
        private int i3 = 0, j3 = 0;
        private int i4 = 0, j4 = 0;

        public void Init()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 2; j++)
                    coord1[i, j] = -1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    coord2[i, j] = -1;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++)
                    coord3[i, j] = -1;
            for (int i = 0; i < 1; i++)
                for (int j = 0; j < 4; j++)
                    coord4[i, j] = -1;
        }
        public void Loc1(int x, int y)
        {
            j1 = 0;
            coord1[i1, j1] = x;
            j1 = 1;
            coord1[i1, j1] = y;
            if (i1 < 3)
                i1++;
        }

        public void Loc2(int x1, int y1, int x2, int y2)
        {
            j2 = 0;
            coord2[i2, j2] = x1;
            j2 = 1;
            coord2[i2, j2] = y1;
            j2 = 2;
            coord2[i2, j2] = x2;
            j2 = 3;
            coord2[i2, j2] = y2;
            if (i2 < 2)
                i2++;
        }
        public void Loc3(int x1, int y1, int x2, int y2)
        {
            j3 = 0;
            coord3[i3, j3] = x1;
            j3 = 1;
            coord3[i3, j3] = y1;
            j3 = 2;
            coord3[i3, j3] = x2;
            j3 = 3;
            coord3[i3, j3] = y2;
            if (i3 < 1)
                i3++;
        }
        public void Loc4(int x1, int y1, int x2, int y2)
        {
            j4 = 0;
            coord4[i4, j4] = x1;
            j4 = 1;
            coord4[i4, j4] = y1;
            j4 = 2;
            coord4[i4, j4] = x2;
            j4 = 3;
            coord4[i4, j4] = y2;
        }

        public bool compare_Loc(int x, int y, MyField mf)
        {
            int check_x, check_y;
            for (int i = 0; i < 4; i++)
                if (x == coord1[i, 0] && y == coord1[i, 1])
                    return true;
            for (int i = 0; i < 3; i++)
            {
                check_x = coord2[i, 0] - coord2[i, 2];
                check_y = coord2[i, 1] - coord2[i, 3];
                if (check_x == 0)
                {
                    if (x == coord2[i, 0] & y == coord2[i, 1])
                        if (mf.get(coord2[i, 3], coord2[i, 2]) == 'X')
                            return true;
                    if (x == coord2[i, 2] && y == coord2[i, 3])
                        if (mf.get(coord2[i, 1], coord2[i, 0]) == 'X')
                            return true;
                }
                if (check_y == 0)
                {
                    if (x == coord2[i, 0] && y == coord2[i, 1])
                        if (mf.get(coord2[i, 1], coord2[i, 2]) == 'X')
                            return true;
                    if (x == coord2[i, 2] && y == coord2[i, 3])
                        if (mf.get(coord2[i, 3], coord2[i, 0]) == 'X')
                            return true;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                check_x = coord3[i, 0] - coord3[i, 2];
                check_y = coord3[i, 1] - coord3[i, 3];
                if (check_x == 0)
                {
                    if (check_y < 0)
                    {
                        if (x == coord3[i, 0] && y == coord3[i, 1])
                            if (mf.get(coord3[i, 1] + 1, coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 3], coord3[i, 0]) == 'X')
                                    return true;

                        if (x == coord3[i, 0] && y == coord3[i, 3])
                            if (mf.get(coord3[i, 1] + 1, coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                    return true;

                        if (x == coord3[i, 0] && y == (coord3[i, 1] + 1))
                            if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 3], coord3[i, 0]) == 'X')
                                    return true;
                    }
                    if (check_y > 0)
                    {
                        if (x == coord3[i, 0] && y == coord3[i, 1])
                            if (mf.get(coord3[i, 1] - 1, coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 3], coord3[i, 0]) == 'X')
                                    return true;

                        if (x == coord3[i, 0] && y == (coord3[i, 1] - 1))
                            if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 3], coord3[i, 0]) == 'X')
                                    return true;

                        if (x == coord3[i, 0] && y == coord3[i, 3])
                            if (mf.get(coord3[i, 1] - 1, coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                    return true;
                    }
                }
                if (check_y == 0)
                {
                    if (check_y < 0)
                    {
                        if (x == coord3[i, 0] && y == coord3[i, 1])
                            if (mf.get(coord3[i, 1], coord3[i, 0] + 1) == 'X')
                                if (mf.get(coord3[i, 1], coord3[i, 2]) == 'X')
                                    return true;

                        if (x == coord3[i, 0] + 1 && y == coord3[i, 1])
                            if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 2], coord3[i, 1]) == 'X')
                                    return true;

                        if (x == coord3[i, 2] && y == (coord3[i, 1]))
                            if (mf.get(coord3[i, 1], coord3[i, 0] + 1) == 'X')
                                if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                    return true;
                    }
                    if (check_y > 0)
                    {
                        if (x == coord3[i, 0] && y == coord3[i, 1])
                            if (mf.get(coord3[i, 0] - 1, coord3[i, 1]) == 'X')
                                if (mf.get(coord3[i, 2], coord3[i, 1]) == 'X')
                                    return true;

                        if (x == coord3[i, 0] - 1 && y == (coord3[i, 1]))
                            if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                if (mf.get(coord3[i, 1], coord3[i, 2]) == 'X')
                                    return true;

                        if (x == coord3[i, 2] && y == coord3[i, 1])
                            if (mf.get(coord3[i, 1], coord3[i, 0] - 1) == 'X')
                                if (mf.get(coord3[i, 1], coord3[i, 0]) == 'X')
                                    return true;
                    }
                }
            }

            check_x = coord4[0, 0] - coord4[0, 2];
            check_y = coord4[0, 1] - coord4[0, 3];
            if (check_x == 0)
            {
                if (check_y < 0)
                {
                    if (x == coord4[0, 0] && y == coord4[0, 1])
                        if (mf.get(coord4[0, 1] + 1, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1] + 2, coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 3], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] && y == coord4[0, 3])
                        if (mf.get(coord4[0, 1] + 1, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1] + 2, coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] && y == (coord4[0, 1] + 1))
                        if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1] + 2, coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 3], coord4[0, 0]) == 'X')
                                    return true;
                    if (x == coord4[0, 0] && y == coord4[0, 1] + 2)
                        if (mf.get(coord4[0, 1] + 1, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 3], coord4[0, 0]) == 'X')
                                    return true;
                }

                if (check_y > 0)
                {
                    if (x == coord4[0, 0] && y == coord4[0, 1])
                        if (mf.get(coord4[0, 1] - 1, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1] - 2, coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 3], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] && y == (coord4[0, 1] - 1))
                        if (mf.get(coord4[0, 1] - 2, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 3], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] && y == coord4[0, 3])
                        if (mf.get(coord4[0, 1] - 1, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1] - 2, coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] && y == coord4[0, 1] - 2)
                        if (mf.get(coord4[0, 1] - 1, coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 3], coord4[0, 0]) == 'X')
                                    return true;
                }
            }

            if (check_y == 0)
            {
                if (check_y < 0)
                {
                    if (x == coord4[0, 0] && y == coord4[0, 1])
                        if (mf.get(coord4[0, 1], coord4[0, 0] + 1) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0] + 2) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 2]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] + 1 && y == coord4[0, 1])
                        if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0] + 2) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 2]) == 'X')
                                    return true;

                    if (x == coord4[0, 2] && y == (coord4[0, 1]))
                        if (mf.get(coord4[0, 1], coord4[0, 0] + 1) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0] + 2) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] + 2 && y == (coord4[0, 1]))
                        if (mf.get(coord4[0, 1], coord4[0, 0] + 1) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 2]) == 'X')
                                    return true;
                }

                if (check_y > 0)
                {
                    if (x == coord4[0, 0] && y == coord4[0, 1])
                        if (mf.get(coord4[0, 1], coord4[0, 0] - 1) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0] - 2) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 2]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] - 1 && y == coord4[0, 1])
                        if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0] - 2) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 2]) == 'X')
                                    return true;

                    if (x == coord4[0, 2] && y == (coord4[0, 1]))
                        if (mf.get(coord4[0, 1], coord4[0, 0] - 1) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0] - 2) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                    return true;

                    if (x == coord4[0, 0] - 2 && y == (coord4[0, 1]))
                        if (mf.get(coord4[0, 1], coord4[0, 0] - 1) == 'X')
                            if (mf.get(coord4[0, 1], coord4[0, 0]) == 'X')
                                if (mf.get(coord4[0, 1], coord4[0, 2]) == 'X')
                                    return true;
                }
            }

            return false;
        }

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

    class Program
    {
        static void Main(string[] args)
        {
            bool f;
            Console.WriteLine("Расстановка кораблей для игрока №1");
            Console.WriteLine();
            MyField field1 = new MyField();
            field1.init();
            field1.Display();
            Warships wr1 = new Warships();
            wr1.Init();
            for (int i = 0; i < 1; i++)
            {
                field1.Install_Warships(wr1);
                field1.Display();
            }
            Console.WriteLine("Корабли успешно расставлены!");
            Console.WriteLine("Для передачи хода игроку №2 нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Расстановка кораблей для игрока №2");
            MyField field2 = new MyField();
            field2.init();
            field2.Display();
            Warships wr2 = new Warships();
            wr2.Init();
            for (int i = 0; i < 1; i++)
            {
                field2.Install_Warships(wr2);
                field2.Display();
            }
            Console.WriteLine("Корабли успешно расставлены!");
            Console.WriteLine("Для начала игры нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            int a = 0;
            while (a == 0)
            {
                Console.WriteLine("Ход игрока №1, для продолжения нажмите любую клавишу");
                Console.ReadKey();
                Console.WriteLine("Ваше поле");
                field1.Display();
                Console.WriteLine("Поле атаки");
                field1.Display_Attack();
                f = field1.Attack(field2, wr2);
                a = field1.win(a);
                if (a == 1)
                    goto Win1;
                while (f == true)
                {
                    Console.WriteLine("Поле атаки");
                    field1.Display_Attack();
                    f = field1.Attack(field2, wr2);
                    a = field1.win(a);
                    if (a == 1)
                        goto Win1;
                }
                Console.WriteLine("Для передачи хода нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Ход игрока №2, для продолжения нажмите любую клавишу");
                Console.ReadKey();
                Console.WriteLine("Ваше поле");
                field2.Display();
                Console.WriteLine("Поле атаки");
                field2.Display_Attack();
                f = field2.Attack(field1, wr1);
                a = field2.win(a);
                if (a == 1)
                    goto Win2;
                while (f == true)
                {
                    Console.WriteLine("Поле атаки");
                    field2.Display_Attack();
                    f = field2.Attack(field1, wr1);
                    a = field2.win(a);
                    if (a == 1)
                        goto Win2;
                }
                Console.WriteLine("Для передачи хода нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        Win1:
            Console.WriteLine("Игра окончена, победил игрок №1!!!");
            Console.ReadKey();
            goto endgame;
        Win2:
            Console.WriteLine("Игра окончена, победил игрок №2!!!");
            Console.ReadKey();
        endgame:
            Console.Write("");
        }
    }
}
