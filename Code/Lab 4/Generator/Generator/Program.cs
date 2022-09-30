using System;

namespace Generator
{
    public class Accords
    {
        public static string c1, c2, c3, c4, nab;

        public string getch(string a1, string a2, string a3, string a4, string nab2)
        {
            if (a1 == "" || a2 == "" || a3 == "" || a4 == "")
            {
                Console.WriteLine("Введите аккорды из гаммы Am");
                Console.WriteLine("Доступны аккорды: Am, F, E, Dm, G");
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

            nab2 = c1 + " " + c2 + " " + c3 + " " + c4;
            nab = nab2;
            return nab;
        }

    }
    public class Melody
    {
        public string[] Am = { "A", "C", "E" };
        public string[] G = { "G", "B", "D" };
        public string[] F = { "F", "A", "C" };
        public string[] E = { "G#", "B", "E" };
        public string[] Dm = { "A", "D", "F" };
        public string n1, n2, n3, n4, n5, n6, n7, n8;

        public string mm;
        public string getm(string h1, string h2, string h3, string h4)
        {
            if (h1 == "Am" || h1 == "G" || h1 == "F" || h1 == "E" || h1 == "Dm")
            {
                if (h1 == "Am")
                {
                    n1 = Am[new Random().Next(0, Am.Length)];
                    n2 = Am[new Random().Next(0, Am.Length)];
                }
                if (h1 == "G")
                {
                    n1 = G[new Random().Next(0, Am.Length)];
                    n2 = G[new Random().Next(0, Am.Length)];
                }
                if (h1 == "F")
                {
                    n1 = F[new Random().Next(0, Am.Length)];
                    n2 = F[new Random().Next(0, Am.Length)];
                }
                if (h1 == "E")
                {
                    n1 = E[new Random().Next(0, Am.Length)];
                    n2 = E[new Random().Next(0, Am.Length)];
                }
                if (h1 == "Dm")
                {
                    n1 = Dm[new Random().Next(0, Am.Length)];
                    n2 = Dm[new Random().Next(0, Am.Length)];
                }
            }
            if (h2 == "Am" || h2 == "G" || h2 == "F" || h2 == "E" || h2 == "Dm")
            {
                if (h2 == "Am")
                {
                    n3 = Am[new Random().Next(0, Am.Length)];
                    n4 = Am[new Random().Next(0, Am.Length)];
                }
                if (h2 == "G")
                {
                    n3 = G[new Random().Next(0, Am.Length)];
                    n4 = G[new Random().Next(0, Am.Length)];
                }
                if (h2 == "F")
                {
                    n3 = F[new Random().Next(0, Am.Length)];
                    n4 = F[new Random().Next(0, Am.Length)];
                }
                if (h2 == "E")
                {
                    n3 = E[new Random().Next(0, Am.Length)];
                    n4 = E[new Random().Next(0, Am.Length)];
                }
                if (h2 == "Dm")
                {
                    n3 = Dm[new Random().Next(0, Am.Length)];
                    n4 = Dm[new Random().Next(0, Am.Length)];
                }
            }
            if (h3 == "Am" || h3 == "G" || h3 == "F" || h3 == "E" || h3 == "Dm")
            {
                if (h3 == "Am")
                {
                    n5 = Am[new Random().Next(0, Am.Length)];
                    n6 = Am[new Random().Next(0, Am.Length)];
                }
                if (h3 == "G")
                {
                    n5 = G[new Random().Next(0, Am.Length)];
                    n6 = G[new Random().Next(0, Am.Length)];
                }
                if (h3 == "F")
                {
                    n5 = F[new Random().Next(0, Am.Length)];
                    n6 = F[new Random().Next(0, Am.Length)];
                }
                if (h3 == "E")
                {
                    n5 = E[new Random().Next(0, Am.Length)];
                    n6 = E[new Random().Next(0, Am.Length)];
                }
                if (h3 == "Dm")
                {
                    n5 = Dm[new Random().Next(0, Am.Length)];
                    n6 = Dm[new Random().Next(0, Am.Length)];
                }
            }
            if (h4 == "Am" || h4 == "G" || h4 == "F" || h4 == "E" || h4 == "Dm")
            {
                if (h4 == "Am")
                {
                    n7 = Am[new Random().Next(0, Am.Length)];
                    n8 = Am[new Random().Next(0, Am.Length)];
                }
                if (h4 == "G")
                {
                    n7 = G[new Random().Next(0, Am.Length)];
                    n8 = G[new Random().Next(0, Am.Length)];
                }
                if (h4 == "F")
                {
                    n7 = F[new Random().Next(0, Am.Length)];
                    n8 = F[new Random().Next(0, Am.Length)];
                }
                if (h4 == "E")
                {
                    n7 = E[new Random().Next(0, Am.Length)];
                    n8 = E[new Random().Next(0, Am.Length)];
                }
                if (h4 == "Dm")
                {
                    n7 = Dm[new Random().Next(0, Am.Length)];
                    n8 = Dm[new Random().Next(0, Am.Length)];
                }
            }
            mm = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8;
            return mm;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
