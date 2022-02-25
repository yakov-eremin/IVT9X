using System;
using System.Collections.Generic;
using System.IO;


namespace ProjectForTest
{

    public class Manager//класс для работы с массивами
    {
        public static int FindMax(int[] mass)//поиск максимального в массиве
        {
            if (mass == null)
            {
                throw new ArgumentNullException("Массив пустой");
            }

            int max = mass[0];
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > max)
                {
                    max = mass[i];
                }
            }
            return max;
        }

        public static double Avarage (int[] mass)//метод для поиска среднего
        {
            double sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return (sum / mass.Length);
        }
    }

    public class NewArray//класс для создания массива
    {
        public double[] array;

        public NewArray(double[] mass)
        {
            array = mass;
        }

        public NewArray()
        {
            array = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int max = 11;
        }

        public void Init(string path)//инициализация массива из txt
        {
            StreamReader sr = new StreamReader(path);
            List<double> list = new List<double>();
            string[] text = sr.ReadToEnd().Split(' ');
            double num;
            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    bool isNum = double.TryParse(text[i], out num);
                    if (isNum)
                    {
                        list.Add(num);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Документ пустой");
            }
            array = list.ToArray();
        }

        public double Sum()//метод для подсчёта суммы
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public NewArray Add(NewArray arr1)//метод сложения двух объектов класса
        {
            List<double> list = new List<double>();
            double[] ar, ar2;
            if (arr1.array.Length > this.array.Length)
            {
                ar = arr1.array;
                ar2 = this.array;
            }
            else
            {
                ar = this.array;
                ar2 = arr1.array;
            }
            for (int i = 0; i < ar2.Length; i++)
            {
                list.Add(ar[i] + ar2[i]);
            }
            for (int i = ar2.Length; i < ar.Length; i++)
            {
                list.Add(ar[i]);
            }
            NewArray newArray = new NewArray(list.ToArray());
            return newArray;
        }
    }

    public class TypeArray : NewArray
    {
        public int type { get; }//поле показывает какие элементы в массиве: положительные, отрицательные, смешанные

        public TypeArray():base()
        {
            type = TypeArray.DefineType(array);
        }
        public TypeArray(double[] mass) : base(mass)
        {
            type = TypeArray.DefineType(array);
        }

        static public int DefineType(double[] array)//опретеление типа массива
        {
            int type;
            if (array[0] > 0)
            {
                type = 1;
            }
            else
            {
                type = -1;
            }
            for (int i = 0;i < array.Length; i++)
            {
                if (type == 1)
                {
                    if(array[i] < 0)
                    {
                        type = 0;
                        break;
                    }
                }
                if (type == -1)
                {
                    if (array[i] > 0)
                    {
                        type = 0;
                        break;
                    }
                }
            }
            return type;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
