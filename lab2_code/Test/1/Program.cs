using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            double c1;
            double z1;
            int a1;
            Pom[] p = new Pom[3];
            Agen ag = new Agen();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\n Введите стоимость квадратного метра: ");
                c1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите площадь помещения: ");
                a1 = int.Parse(Console.ReadLine());
                p[i] = new Pom();
                p[i].init(c1, a1);
            }


            Console.WriteLine("Введите расходы: ");
            z1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите название агенства: ");
            string n = (Console.ReadLine());
            Console.WriteLine("Агенство: " + n);
            ag.init(p, z1);
            Console.WriteLine("Общая стоимость агенства: " + ag.totcost() + "\n");
            Pom dorpom = ag.dorpom();
            Console.WriteLine("Самая дорогая комната: " + dorpom.p() + "\n");
        }
    }

}
