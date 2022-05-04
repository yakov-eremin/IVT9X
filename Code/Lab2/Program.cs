using System;
using System.Collections.Generic;

namespace Project
{
    public class Class
    {
        //Работа с классом
        public double Var1 { get; set; }
        public int Var2 { get; set; }

        public Class(double var1, int var2)
        {
            Var1 = var1;
            Var2 = var2;
        }

        public Class Best(Class some)
        {
            if (((int)this.Var1 + this.Var2) > ((int)some.Var1 + some.Var2))
            {
                return this;
            }
            else
            {
                return some;
            }
        }

        //Работа с числами
        public static int Number(string number)
        {
            if (double.TryParse(number, out double res))
            {
                if (Convert.ToDouble(number) < 0)
                    return -1;
                if (Convert.ToDouble(number) > 0)
                    return 1;
                if (Convert.ToDouble(number) == 0)
                    return 0;
                return -1;
            }
            else
            {
                throw new ArgumentNullException("Не число.");
            }
        }
        //Работа со строками
        public static void EachLetter(string String, List<char> Symbol, List<int> Count)
        {
            if (String == null)
            {
                throw new ArgumentNullException("Срока пустая.");
            }
            for (int i = 0; i < String.Length; i++)
            {
                if (!Symbol.Contains(String[i]))
                {
                    Symbol.Add(String[i]);
                    Count.Add(1);
                }
                else
                {
                    Count[Symbol.IndexOf(String[i])]++;
                }
            }
        }

        //Работа с массивами
        public static void Sort(double[] array, int mode)
        {
            if (mode == 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            double temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            if (mode == -1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j] < array[j + 1])
                        {
                            double temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
