using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using lab4;

namespace lab4 { 
    public class Calculate
    {
        public double Summ(double x1, double y1)
        {
            double summ = x1 + y1;
            return summ;
        }
        public double Subtraction(double x1, double y1)
        {
            double summ = x1 - y1;
            return summ;
        }
        public double Multiplication(double x1, double y1)
        {
            double summ = x1 * y1;
            return summ;
        }
        public double Division(double x1, double y1)
        {
            double summ = x1 / y1;
            return summ;
        }
        public double SortingMax(double[] arr, int m)
        {
            double max = 0;
            for (int i = 0; i < m; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        public double SortingMin(double[] arr, int m)
        {
            double min = arr[0];
            for (int i = 0; i < m; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public double SortingSumm(double[] arr, int m)
        {
            double summ = 0;
            for (int i = 0; i < m; i++)
            {
                summ += arr[i];
            }
            return summ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            string name = "";
            Console.Write("Введите свое имя: ");
            name = Console.ReadLine();
            while (true)
            {
                Console.WriteLine(" ");
                Console.Write("--- " + name + ", задайте мне вопрос: ");
                command = Console.ReadLine();
                if (command == "Что ты умеешь?")
                {
                    Console.WriteLine("1. Показать сегодняшнюю дату");
                    Console.WriteLine("2. Открыть простой калькулятор");
                    Console.WriteLine("3. Найти элементы в массиве");
                    Console.Write("> ");
                    command = Console.ReadLine();
                    if (command == "1")
                    {
                        DateTime thisDay = DateTime.Today;
                        Console.WriteLine("Сегодня " + thisDay.ToString("D"));
                    }
                    else if (command == "2")
                    {
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Простой калькулятор \nВыберите операцию:");
                        Console.WriteLine("1. Сложение");
                        Console.WriteLine("2. Вычитание");
                        Console.WriteLine("3. Умножение");
                        Console.WriteLine("4. Деление");
                        Console.WriteLine(new string('-', 30));
                        Console.Write("> ");
                        command = Console.ReadLine();
                        if (command == "1")
                        {
                            Console.Write("Введите первый операнд: ");
                            Console.Write("> ");
                            double s1 = double.Parse(Console.ReadLine());
                            Console.Write("Введите второй операнд: ");
                            Console.Write("> ");
                            double s2 = double.Parse(Console.ReadLine());
                            Calculate addition = new Calculate();
                            double summ1 = addition.Summ(s1, s2);
                            Console.WriteLine(s1 + " + " + s2 + " = " + summ1);
                        }
                        if (command == "2")
                        {
                            Console.Write("Введите первый операнд: ");
                            Console.Write("> ");
                            double s1 = double.Parse(Console.ReadLine());
                            Console.Write("Введите второй операнд: ");
                            Console.Write("> ");
                            double s2 = double.Parse(Console.ReadLine());
                            Calculate subtraction = new Calculate();
                            double summ1 = subtraction.Subtraction(s1, s2);
                            Console.WriteLine(s1 + " - " + s2 + " = " + summ1);
                        }
                        if (command == "3")
                        {
                            Console.Write("Введите первый операнд: ");
                            Console.Write("> ");
                            double s1 = double.Parse(Console.ReadLine());
                            Console.Write("Введите второй операнд: ");
                            Console.Write("> ");
                            double s2 = double.Parse(Console.ReadLine());
                            Calculate multiplication = new Calculate();
                            double summ1 = multiplication.Multiplication(s1, s2);
                            Console.WriteLine(s1 + " * " + s2 + " = " + summ1);
                        }
                        if (command == "4")
                        {
                            Console.Write("Введите первый операнд: ");
                            Console.Write("> ");
                            double s1 = double.Parse(Console.ReadLine());
                            Console.Write("Введите второй операнд: ");
                            Console.Write("> ");
                            double s2 = double.Parse(Console.ReadLine());
                            Calculate division = new Calculate();
                            double summ1 = division.Division(s1, s2);
                            Console.WriteLine(s1 + " / " + s2 + " = " + summ1);
                        }
                    }
                    else if (command == "3")
                    {
                        Console.Write("Введите количество элементов: ");
                        int m = Int32.Parse(Console.ReadLine());
                        double[] arr = new double[m];
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write("Введите " + (i + 1) + " элемент: ");
                            arr[i] = double.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Заданный массив: ");
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write(arr[i] + " ");
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Выберите операцию:");
                        Console.WriteLine("1. Найти максимальное число");
                        Console.WriteLine("2. Найти минимальное число");
                        Console.WriteLine("3. Найти сумму элементов");
                        Console.WriteLine(new string('-', 30));
                        Console.Write("> ");
                        command = Console.ReadLine();
                        if (command == "1")
                        {
                            Calculate sortingMax = new Calculate();
                            double sort = sortingMax.SortingMax(arr, m);
                            Console.WriteLine("Максимальный элемент в массиве - " + sort);
                        }
                        if (command == "2")
                        {
                            Calculate sortingMin = new Calculate();
                            double sort = sortingMin.SortingMin(arr, m);
                            Console.WriteLine("Минимальный элемент в массиве - " + sort);
                        }
                        if (command == "3")
                        {
                            Calculate sortingSumm = new Calculate();
                            double sort = sortingSumm.SortingSumm(arr, m);
                            Console.WriteLine("Сумма элементов в массиве - " + sort);
                        }
                    }
                    else Console.WriteLine("Такой команды не найдено.");
                }
                else if (command == "Что такое гитхаб?")
                {
                    using (StreamReader sr = new StreamReader(@"D:\test_po\IVT9X\lab4\read.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] text = line.Split('*');
                            Console.WriteLine(text[0]);
                        }
                    }
                }
                else if (command == "Площадь России")
                {
                    using (StreamReader sr = new StreamReader(@"D:\test_po\IVT9X\lab4\read.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] text = line.Split('*');
                            Console.WriteLine(text[1]);
                        }
                    }
                }
                else if (command == "Курс доллара")
                {
                    using (StreamReader sr = new StreamReader(@"D:\test_po\IVT9X\lab4\read.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] text = line.Split('*');
                            Console.WriteLine(text[2]);
                        }
                    }
                }
                else if (command == "Привет!")
                {
                    using (StreamReader sr = new StreamReader(@"D:\test_po\IVT9X\lab4\read.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] text = line.Split('*');
                            Console.WriteLine(text[3] + name);
                        }
                    }
                }
                else if (command == "Что такое пузырьковая сортировка?")
                {
                    using (StreamReader sr = new StreamReader(@"D:\test_po\IVT9X\lab4\read.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] text = line.Split('*');
                            Console.WriteLine(text[4]);
                        }
                    }
                }
                else if (command == "Выход")
                {
                    Console.Write("До свидания, " + name + "! Нажмите любую клавишу...");
                    Console.ReadLine();
                    break;
                }
                else Console.WriteLine("Непонятен вопрос :(");
            }
        }
    }
}