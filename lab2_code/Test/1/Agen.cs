using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    public class Agen
    {
        private double z1;
        protected string nameAgen;
        protected int cost;
        protected int gain;
        private Pom[] p;


        public void init(Pom[] pp, double z11)
        {
            p = pp;
            z1 = z11;
        }

        public Pom dorpom()
        {
            Pom max = p[0];
            for (int i = 1; i < 3; i++)
            {
                if (p[i].p() > max.p()) max = p[i];
            }
            return max;
        }

        public double totcost()
        {
            double cost = 0;
            for (int i = 0; i < 3; i++)
            {
                cost += p[i].p();
            }
            return cost - z1;
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int multiplication(int x, int y, int c)
        {
            return (x * y)/(c * 100);
        }

        public int rental_price(int days, int price, int deposit, int human)
        {
            return (days * price) + (deposit * human);
        }

        public string GetName()
        {
            return nameAgen;
        }

        public void SetName(string name1)
        {
            nameAgen = "Агенство: " + name1;
        }
        public void Init(int cost1, int gain1)
        {
            cost = cost1;
            gain = gain1;
        }

        public float payback()
        {
            float r;
            if ((float)cost == 0)
            {
                r = 0;
                return r;
            }
            else
            {
                r = (gain / cost) * 100;
                return r;
            }
        }

    }
}