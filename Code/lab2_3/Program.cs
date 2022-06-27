using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Section s1 = new Section();
            Section s2 = new Section();
            Section s3 = new Section();


            s1.Init(1.2, 2.3, 3.4, 4.5);
            Console.WriteLine("Отрезок s1: ");
            s1.Display();

            double k = s1.X1;// поле x1 у s1 присвоилось через property
            Console.WriteLine("Координата X отрезка s1: " + k);
            s1.X1 = 0;// Получaем значение поля x1 у s1 через property
            Console.WriteLine("Координата X отрезка s1: " + s1.X1);

            s2.Read();
            Console.WriteLine("Отрезок s2: ");
            s2.Display();
            Console.WriteLine("Длинна отрезка s2: " + s2.Length());

            s3 = s3.Add(s1, s2);
            Console.WriteLine("Отрезок s3: ");
            s3.Display();

            Section[] r1 = new Section[5]; ;
            double summ1;

            for (int i = 0; i < 5; i++)
            {
                r1[i] = new Section();
            }

            for (int i = 0; i < 5; i++)
            {
                r1[i].Init(i, 0, 0, 2 * i);
            }

            summ1 = 0;

            for (int i = 0; i < 5; i++)
            {
                summ1 += r1[i].Length();
            }

            Console.WriteLine("\nr1: " + summ1);

            Console.ReadKey();
        }
    }
}
