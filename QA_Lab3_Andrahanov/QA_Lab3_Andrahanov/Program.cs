using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3_Andrahanov
{
    class Program
    {
        static void Main(string[] args)
        {
            Diet d = new Diet();
            Product p = new Product();
            ProductBread pB = new ProductBread();
            p.Init(34, 100);
            p.Display();
            Console.WriteLine("Ценность: " + p.Val());
            pB.Init(34, 100, 20);
            pB.Display();
            Console.WriteLine("Ценность: " + pB.Val());
            d.Init("Хлебный", 34, 100, 34, 100, 20);
            d.Display();
            Console.WriteLine("Ценность: " + d.Val());

            Console.ReadKey();
        }
    }
}
