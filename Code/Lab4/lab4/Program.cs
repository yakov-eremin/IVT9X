using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lab4
{
    public class CheckString
    {
        StreamReader sr = new StreamReader(@"C:\lab4.txt");
        string line;
        public string vopros1(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[1];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros2(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[2];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros3(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[3];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros4(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[4];
                }
            }
            return "";
        }
        public string vopros5(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[5];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros6(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[6];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros7(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[7];
                }
            }
            return "";
        }

        public string vopros8(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[8];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros9(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[9];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }

        public string vopros10(string otvet)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (otvet == "a")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "b")
                {
                    string[] text = line.Split('*');
                    return text[10];
                }
                else if (otvet == "c")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
                else if (otvet == "d")
                {
                    string[] text = line.Split('*');
                    return text[0];
                }
            }
            return "";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string otvet = string.Empty;
            string name = "";
            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Здравствуйте, " + name + "! Вас приветствует игра “Кто хочет стать миллионером?”. \nНаши правила просты: 10 вопросов могут принести 1 млн. руб.,\nЖелаем удачи, игра началась!!! ");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 1: Дели, столица какого государства?\na - Индия\nb - Китай\nc - Япония\nd - Россия\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros1(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 2: Под каким названием известна единица с последующими ста нулями?\na - Мегатрон\nb - Гигабит\nc - Гугол\nd - Наномоль\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros2(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 3: Какое насекомое вызвало короткое замыкание в ранней версии вычислительной машины, тем самым породив термин \n“компьютерный баг”?\na - Таракан\nb - Мотылёк\nc - Муха\nd - Японский хрущик\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros3(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 4: Какой химический элемент составляет более половины массы тела человека?\na - Углерод\nb - Кальций\nc - Железо\nd - Кислород\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros4(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 5: Какую часть тела также называют “атлант”?\na - Шейный позвонок\nb - Головной мозг\nc - Шестая пара ребёр\nd - Часть плеча\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros5(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 6: Сколько кубиков в кубике Рубика?\na - 24\nb - 26\nc - 28\nd - 30\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros6(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 7: Какого цвета крайнее правое кольцо в олимпийской символике?\na - Синее\nb - Жёлтое\nc - Зелёное\nd - Красное\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros7(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 8: Что изображено на заднем плане картины Леонардо да Винчи “Мона Лиза”?\na - Драпировка\nb - Город\nc - Пейзаж\nd - Стадо овец\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros8(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 9: Какая картина Малевича находится в Русском музее?\na - Красный квадрат\nb - Чёрный квадрат\nc - Белый квадрат\nd - “Точильщик”\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros9(otvet);
                Console.WriteLine(x);
                break;
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("\nВопрос 10: Как называется самая глубокая точка поверхности Земли, находящаяся на дне Марианской впадины?\na - Филиппинская плита\nb - Бездна Челленджера\nc - Кермадек\nd - Чёрное Логово\n\n");
                Console.Write(name + ", введите букву с Вашим ответом: ");
                otvet = Console.ReadLine();
                CheckString checkstring = new CheckString();
                string x = checkstring.vopros10(otvet);
                Console.WriteLine(x);
                break;
            }
        }
    }
}
