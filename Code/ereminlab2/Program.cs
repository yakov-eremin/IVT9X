using System;

namespace ereminlab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pryam a1 = new Pryam();
            Pryam a2 = new Pryam();
            Pryam a3 = new Pryam();
            int vlxx, vlyy, npxx, npyy;
            Console.WriteLine("Введите координаты верхнего левого угла по оси х, потом по оси у");
            vlxx = int.Parse(Console.ReadLine());
            vlyy = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты нижнего правого угла по оси х, потом по оси у");
            npxx = int.Parse(Console.ReadLine());
            npyy = int.Parse(Console.ReadLine());

            a1.init(vlxx, vlyy, npxx, npyy);
            Console.WriteLine("Координаты первого прямоугольника:\n");
            a1.display();
            Console.WriteLine("\n площадь первого прямоугольника: ");
            a1.plohad();
            Console.WriteLine("\n Второй пряомугольник\n");
            a2.read();
            Console.WriteLine("Координаты второго прямоугольника:\n");
            a2.display();
            Console.WriteLine("\nПлощадь второго прямоугольника");
            a2.plohad();
            a3 = a1.add(a1, a2);
            Console.WriteLine("\nКоординаты третьего прямоугольника: \n");
            a3.display();
            Console.WriteLine("\nПлощадь третьего прямоугольника = ");
            a3.plohad();
        }
    }
}
