using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgForTest
{
    public class ProgForTest
    {
        public double Rad(int x)
        {
            return Math.Sqrt(x);
        }

        public int Sq(int x)
        {
            return x * x;
        }

    }

    public class Mas
    {

        public int SearchMax_div_2(int[] mas)// поиск максимального чётного числа
        {
            int max = 2;

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0)
                    if (mas[i] > max)
                        max = mas[i];
            }
          
            return max;
        }

        public int Sum(int[] mas) // сумма всех эл-тов массива
        {
            int s=0;
            for (int i = 0; i < mas.Length; i++)
                s = s + mas[i];
            return s;
        }

        public int most_repeated(int[] mas)//Поиск эллемента, который встречается в массиве чаще, чем остальные
        {
            int a=0;
            int count=0;
            int elem=0;
            for (int i = 0; i < mas.Length; i++)
            {
                a = 0;
                for (int j = 0; j < mas.Length; j++)
                {
                    if (mas[i] == mas[j])
                        a++;
                }
                if (a > count)
                {
                    count = a;
                    elem = mas[i];
                }
            }
            return elem;
        }
    }

    public class Ugol
    {
        private float degree;
        private float min;
        private float sec;
        public void Init(float d, float m, float s)
        {
            degree = d;
            min = m;
            sec = s;
        }

        public float getdeg()
        {
            return degree;
        }
        public float getmin()
        {
            return min;
        }
        public float getsec()
        {
            return sec;
        }
        public float round()//округление до градусов
        {
            if (sec >= 30)
            {
                min++;
            }
            sec = 0;
            if (min >= 30)
            {
                degree++;
            }
            min = 0;
            return degree;
        }

        public Ugol add(Ugol a, Ugol b)//сложение углов
        {
            Ugol c;
            c = new Ugol();
            c.degree = a.degree + b.degree;
            c.min = a.min + b.min;
            c.sec = a.sec + b.sec;
            if (c.sec >= 60)
            {
                c.min++;
                c.sec = c.sec - 60;
            }
            if (c.min >= 60)
            {
                c.degree++;
                c.min = c.min - 60;
            }
            return c;
        }
    }

    public class stringclass //поиск слов
    {
        public String findstr(string a, string b)
        {
            string s="";
            bool f;
            int k, count;
            count = b.Length;
            f = a.Contains(b);
            if (f == true)
            {
                s = a;
                k = s.IndexOf(b);
                s = s.Insert(k, "[");
                s = s.Insert(k + 1 + count, "]");
            }
            return s;
        }
    }
}

