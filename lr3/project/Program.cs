using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Program
    {
        /// точка входа в приложение
        /// @param args - аргументы командной строки
        static void Main(string[] args)
        {
            Jewel Jw1 = new Jewel();
            Jw1.Init(20,20);
            Jw1.Display();
            Console.WriteLine(Jw1.Cost());
            ValuableJewel Jw2 = new ValuableJewel();
            Jw2.Init(20,40);
            Jw2.Display();
            Console.WriteLine(Jw2.Cost());
            Jewerly_shop J = new Jewerly_shop();
            J.Init("Ювелир", 20, 40);
            J.Display();
            Console.WriteLine(J.FullProfit());
        }
    }
}
