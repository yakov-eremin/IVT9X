using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            film f1 = new film();
            FL f2 = new FL();
            f1.Init(0,0);
            f2.Init(0,0);
            int[] theArray = { 1, 3, 5 };
            f1.Init_mass(theArray);
            Console.WriteLine("Прибль увеличенa, новая прибль : " + f1.raiting_calculation());
            f1.okup_f();
        }
    }
}

