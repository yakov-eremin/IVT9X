using System;
using System.Collections.Generic;
using System.Text;




namespace ConsoleApp1
{
    public class film
    {
        protected int cost;//затраты
        protected int gain;//доход
        protected string name;
        int [] X = new int [10];
        protected float raiting;

        public void Init_mass(int [] r)
        {
           

            for (int i = 0; i < 3; i++)
            {
                X[i] = new int();  // инициализация каждого элемента
            }
            for (int i = 0; i < 3; i++)
            {
                X[i] = r[i];
                Console.WriteLine(X[i] );
            }

        }

        public float raiting_calculation()
        {
            raiting = 0;

            for (int i = 0; i < 3; i++)
            {
                raiting += X[i];
            }
            raiting = raiting / 3;

            return raiting;
        }

        public string name_rate()
        {
            string k= "";
            if (raiting < 10) k = "Низкий";
            if (raiting > 10 && raiting < 30) k = "Средний";
            if ( raiting > 30) k = "Выоский";
            return k;
        }

        public int get_mass(int i1)
        {
            
                return X[i1];           
            

        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name1)
        {
            name = "Название фильма " + name1; 
        }

        public double GetGain()
        {
            return gain;
        }

        public double GetCost()
        {
            return cost;
        }
        public double summ(film X)
        {
            double k;
            k = X.GetGain() + X.GetCost();
                return k;
        }
        public void Init(int cost1, int gain1)
        {
            cost = cost1;
            gain = gain1;
        }
        public float okup_f()
        {
            float k;
            if ((float)cost == 0)
            {
                k = 0;
                return k;
            }
            else { 
            k = ((float)gain / (float)cost) * 100;
            return k;
            }
        }
        public void Display()
        {
            Console.WriteLine("\n Затраты на фильм - " + cost + "\n Прибыль за фильм - " + gain + "\n" + "\n Название фильма - " +  "\n");
        }

        public void Read()
        {
            string s = "";
            Console.WriteLine("\nВведите затраты на фильм - ");
            s = Console.ReadLine();
            cost = Convert.ToInt32(s);
            Console.WriteLine("Введите прибыль с фильма - ");
            s = Console.ReadLine();
            gain = Convert.ToInt32(s);
            Console.WriteLine("Введите прибыль с фильма - ");
            
        }

       
    }

    class FL : film
    {
        public void Init(int m, int s, int d)
        {
            base.Init(m, s);
            z = d;
        }

        public double summ()
        {

            double k = gain;
            if (z == 1)
                k = gain * (1.1);
            return k;

        }
        private double z = 0.1;
    };

}
