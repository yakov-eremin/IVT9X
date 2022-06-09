using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab4
{
    public class CheckString
    {
        StreamReader sr = new StreamReader(@"D:\therapist.txt");
        string line;
        public string back(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    if (years >= 12)
                        return text[1];
                    if (years < 12)
                        return text[0];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    return text[2];
                }
                else if (command == "3")
                {
                    string[] text = line.Split('*');
                    if (years > 14)
                        return text[4];
                    if (years < 14)
                        return text[3];
                }
            }
            return "0";
        }

        public string head(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    if (years >= 12)
                        return text[6];
                    if (years < 12)
                        return text[5];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    if (years >= 12)
                        return text[8];
                    if (years < 12)
                        return text[7];
                }
            }
            return "0";
        }

        public string leg(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    return text[9];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    if (years >= 15)
                        return text[11];
                    if (years < 15)
                        return text[10];
                }
                else if (command == "3")
                {
                    string[] text = line.Split('*');
                    return text[12];
                }
            }
            return "0";
        }


        public string arm(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    return text[9];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    if (years >= 15)
                        return text[11];
                    if (years < 15)
                        return text[10];
                }
                else if (command == "3")
                {
                    string[] text = line.Split('*');
                    return text[12];
                }
            }
            return "0";
        }

        public string belly(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    return text[13];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    return text[14];
                }
                else if (command == "3")
                {
                    if (years >= 10)
                    {
                        string[] text = line.Split('*');
                        return text[16];
                    }
                    if (years < 10)
                    {
                        string[] text = line.Split('*');
                        return text[15];
                    }
                }
            }
            return "0";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            string name = "";
            int years;
            Console.Write("Здравствуйте, введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Сколько вам лет? ");
            years = int.Parse(Console.ReadLine());
            while (true)
            {
                Console.WriteLine(" ");
                Console.Write(name + ", опишите вашу проблему: ");
                command = Console.ReadLine();

                if (command == "Болит спина")
                {
                    Console.WriteLine("Какая боль вас беспокоит?");
                    Console.WriteLine("1. Ноющая");
                    Console.WriteLine("2. Режущая");
                    Console.WriteLine("3. Стреляющая");
                    Console.Write("--> ");
                    command = Console.ReadLine();
                    CheckString checkstring = new CheckString();
                    string x = checkstring.back(years, command);
                    Console.WriteLine(x);
                }

                else if (command == "Болит голова")
                {
                    Console.WriteLine("Какая боль вас беспокоит?");
                    Console.WriteLine("1. Пульсирующая");
                    Console.WriteLine("2. Резкая");
                    Console.Write("--> ");
                    command = Console.ReadLine();
                    CheckString checkstring = new CheckString();
                    string x = checkstring.head(years, command);
                    Console.WriteLine(x);
                }

                else if (command == "Болит нога")
                {
                    Console.WriteLine("Какая у вас травма");
                    Console.WriteLine("1. Ушиб");
                    Console.WriteLine("2. Перелом");
                    Console.WriteLine("3. Растяжение");
                    Console.Write("--> ");
                    command = Console.ReadLine();
                    CheckString checkstring = new CheckString();
                    string x = checkstring.leg(years, command);
                    Console.WriteLine(x);
                }

                else if (command == "Болит рука")
                {
                    Console.WriteLine("Какая у вас травма");
                    Console.WriteLine("1. Ушиб");
                    Console.WriteLine("2. Перелом");
                    Console.WriteLine("3. Растяжение");
                    Console.Write("--> ");
                    command = Console.ReadLine();
                    CheckString checkstring = new CheckString();
                    string x = checkstring.arm(years, command);
                    Console.WriteLine(x);
                }

                else if (command == "Болит живот")
                {
                    Console.WriteLine("В какой области боль?");
                    Console.WriteLine("1. Кишечник");
                    Console.WriteLine("2. Печень");
                    Console.WriteLine("3. Желудок");
                    Console.Write("--> ");
                    command = Console.ReadLine();
                    CheckString checkstring = new CheckString();
                    string x = checkstring.belly(years, command);
                    Console.WriteLine(x);
                }

                else if (command == "Выйти")
                {
                    Console.Write("Всего доброго, " + name + "! Нажмите любую клавишу...");
                    Console.ReadLine();
                    break;
                }

                else Console.WriteLine("К сожалению, такая проблема мне неизвестна...");
            }
        }
    }
}
