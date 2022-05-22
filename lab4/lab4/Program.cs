using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace lab4 
{
    public class Calculate
    {
        public double dollarinrub(double kursdollar, double amountdollar)
        {
            double konvert = kursdollar * amountdollar;
            return konvert;
        }

        public double rubindollar(double amountrub, double kursdollar)
        {
            double konvert = amountrub / kursdollar;
            return konvert;
        }

        public double rubineuro(double amountrub, double kurseuro)
        {
            double konvert = amountrub / kurseuro;
            return konvert;
        }

        public double euroinrub(double kurseuro, double amounteuro)
        {
            double konvert = kurseuro * amounteuro;
            return konvert;
        }

        public double euroindollar(double ratio, double amounteuro)
        {
            double konvert = ratio * amounteuro;
            return konvert;
        }

        public double dollarineuro(double ratio, double amountdollar)
        {
            double konvert = amountdollar / ratio;
            return konvert;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while (true)
            {
                Console.WriteLine("Что вы хотите конвертировать?");
                Console.WriteLine("1. Конвертировать доллары в рубли");
                Console.WriteLine("2. Конвертировать рубли в доллары");
                Console.WriteLine("3. Конвертировать рубли в евро");
                Console.WriteLine("4. Конвертировать евро в рубли");
                Console.WriteLine("5. Конвертировать евро в доллары");
                Console.WriteLine("6. Конвертировать доллары в евро");
                command = Console.ReadLine();
                if (command == "1")
                {
                    Console.WriteLine("Введите курс доллара: ");
                    double kursdollar = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество долларов: ");
                    double amountdollar = double.Parse(Console.ReadLine());
                    Calculate konvert = new Calculate();
                    double result = konvert.dollarinrub(kursdollar, amountdollar);
                    Console.WriteLine("Количество рублей = " + result);
                }

                else if (command == "2")
                {
                    Console.WriteLine("Введите курс доллара: ");
                    double kursdollar = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество рублей: ");
                    double amountrub = double.Parse(Console.ReadLine());
                    Calculate konvert = new Calculate();
                    double result = konvert.rubindollar(amountrub, kursdollar);
                    Console.WriteLine("Количество долларов = " + result);
                }

                else if (command == "3")
                {
                    Console.WriteLine("Введите курс евро: ");
                    double kurseuro = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество рублей: ");
                    double amountrub = double.Parse(Console.ReadLine());
                    Calculate konvert = new Calculate();
                    double result = konvert.rubineuro(amountrub, kurseuro);
                    Console.WriteLine("Количество евро = " + result);
                }

                else if (command == "4")
                {
                    Console.WriteLine("Введите курс евро: ");
                    double kurseuro = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество евро: ");
                    double amounteuro = double.Parse(Console.ReadLine());
                    Calculate konvert = new Calculate();
                    double result = konvert.euroinrub(kurseuro, amounteuro);
                    Console.WriteLine("Количество рублей = " + result);
                }

                else if (command == "5")
                {
                    Console.WriteLine("Введите коэффициент отношения доллара к евро: ");
                    double ratio = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество евро: ");
                    double amounteuro = double.Parse(Console.ReadLine());
                    Calculate konvert = new Calculate();
                    double result = konvert.euroindollar(ratio, amounteuro);
                    Console.WriteLine("Количество долларов = " + result);
                }

                else if (command == "6")
                {
                    Console.WriteLine("Введите коэффициент отношения доллара к евро: ");
                    double ratio = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество долларов: ");
                    double amountdollar = double.Parse(Console.ReadLine());
                    Calculate konvert = new Calculate();
                    double result = konvert.dollarineuro(ratio, amountdollar);
                    Console.WriteLine("Количество евро = " + result);
                }
            }
        }
    }
}