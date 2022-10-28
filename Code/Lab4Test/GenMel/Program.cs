using System;
namespace GenMel
{
    public class Accord
    {
        public static string c1, c2, c3, c4, nab;

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

            nab2 = c1 + " " + c2 + " " + c3 + " " + c4;
            nab = nab2;
            return nab;
        }

    }
    public class MelodyGen
    {
        public string[] C = { "C", "E", "G" };
        public string[] D = { "D", "F#", "A" };
        public string[] F = { "F", "A", "C" };
        public string[] E = { "E", "G#", "H" };
        public string[] G = { "G", "H", "D" };
        public string n1, n2, n3, n4, n5, n6, n7, n8;

        public string mm;
        public string getm(string h1, string h2, string h3, string h4)
        {
            if (h1 == "C" || h1 == "D" || h1 == "F" || h1 == "E" || h1 == "G")
            {
                if (h1 == "C")
                {
                    n1 = C[new Random().Next(0, C.Length)];
                    n2 = C[new Random().Next(0, C.Length)];
                }
                if (h1 == "D")
                {
                    n1 = D[new Random().Next(0, D.Length)];
                    n2 = D[new Random().Next(0, D.Length)];
                }
                if (h1 == "F")
                {
                    n1 = F[new Random().Next(0, F.Length)];
                    n2 = F[new Random().Next(0, F.Length)];
                }
                if (h1 == "E")
                {
                    n1 = E[new Random().Next(0, E.Length)];
                    n2 = E[new Random().Next(0, E.Length)];
                }
                if (h1 == "G")
                {
                    n1 = G[new Random().Next(0, G.Length)];
                    n2 = G[new Random().Next(0, G.Length)];
                }
            }
            if (h2 == "C" || h2 == "D" || h2 == "F" || h2 == "E" || h2 == "G")
            {
                if (h2 == "C")
                {
                    n3 = C[new Random().Next(0, C.Length)];
                    n4 = C[new Random().Next(0, C.Length)];
                }
                if (h2 == "D")
                {
                    n3 = D[new Random().Next(0, D.Length)];
                    n4 = D[new Random().Next(0, D.Length)];
                }
                if (h2 == "F")
                {
                    n3 = F[new Random().Next(0, F.Length)];
                    n4 = F[new Random().Next(0, F.Length)];
                }
                if (h2 == "E")
                {
                    n3 = E[new Random().Next(0, E.Length)];
                    n4 = E[new Random().Next(0, E.Length)];
                }
                if (h2 == "G")
                {
                    n3 = G[new Random().Next(0, G.Length)];
                    n4 = G[new Random().Next(0, G.Length)];
                }
            }
            if (h3 == "C" || h3 == "D" || h3 == "F" || h3 == "E" || h3 == "G")
            {
                if (h3 == "C")
                {
                    n5 = C[new Random().Next(0, C.Length)];
                    n6 = C[new Random().Next(0, C.Length)];
                }
                if (h3 == "D")
                {
                    n5 = D[new Random().Next(0, D.Length)];
                    n6 = D[new Random().Next(0, D.Length)];
                }
                if (h3 == "F")
                {
                    n5 = F[new Random().Next(0, F.Length)];
                    n6 = F[new Random().Next(0, F.Length)];
                }
                if (h3 == "E")
                {
                    n5 = E[new Random().Next(0, E.Length)];
                    n6 = E[new Random().Next(0, E.Length)];
                }
                if (h3 == "G")
                {
                    n5 = G[new Random().Next(0, G.Length)];
                    n6 = G[new Random().Next(0, G.Length)];
                }
            }
            if (h4 == "C" || h4 == "D" || h4 == "F" || h4 == "E" || h4 == "G")
            {
                if (h4 == "C")
                {
                    n7 = C[new Random().Next(0, C.Length)];
                    n8 = C[new Random().Next(0, C.Length)];
                }
                if (h4 == "D")
                {
                    n7 = D[new Random().Next(0, D.Length)];
                    n8 = D[new Random().Next(0, D.Length)];
                }
                if (h4 == "F")
                {
                    n7 = F[new Random().Next(0, F.Length)];
                    n8 = F[new Random().Next(0, F.Length)];
                }
                if (h4 == "E")
                {
                    n7 = E[new Random().Next(0, E.Length)];
                    n8 = E[new Random().Next(0, E.Length)];
                }
                if (h4 == "G")
                {
                    n7 = G[new Random().Next(0, G.Length)];
                    n8 = G[new Random().Next(0, G.Length)];
                }
            }
            mm = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8;
            return mm;
        }
    }
    class Program
    {
        static void Main()
        {
            

        }

    }
}