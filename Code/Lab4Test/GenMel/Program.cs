using System;
namespace GenMel
{
    public class Accord
    {
        public static string c1, c2, c3, c4, nab1;

        public string Vvod(string a1, string a2, string a3, string a4, string nab2)
        {
            if (a1 == "" || a2 == "" || a3 == "" || a4 == "")
            {
                Console.WriteLine("Введите аккорды");
                Console.WriteLine("Доступны аккорды: C, D, F, E, G");
                Console.WriteLine("Введите первый аккорд");
                a1 = Console.ReadLine();
                Console.WriteLine("Введите второй аккорд");
                a2 = Console.ReadLine();
                Console.WriteLine("Введите третий аккорд");
                a3 = Console.ReadLine();
                Console.WriteLine("Введите четвертый аккорд");
                a4 = Console.ReadLine();
            }
            c1 = a1;
            c2 = a2;
            c3 = a3;
            c4 = a4;

            nab1 = c1 + " " + c2 + " " + c3 + " " + c4;
            return nab1;
        }

    }
 
    class Program
    {
        static void Main()
        {
            

        }

    }
}