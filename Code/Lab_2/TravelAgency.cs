using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency1
{
    public class TravelAgency
    {
        private String Name;

        private Tour Tour = new Tour();
        private Permit FtPermit = new Permit();

        private int RealProcFirst, RealProcSecond;

        public TravelAgency(String n, double pr1, double sale1, double pr2, double sale2, int hotPer, int RealProcFirst1, int RealProcSecond2)
        {
            Name = n;
            Tour.Init(pr1, sale1);
            FtPermit.Init(pr2, sale2, hotPer);

            RealProcFirst = RealProcFirst1;
            RealProcSecond = RealProcSecond2;
        }

        public void Display()
        {
            Console.WriteLine("Название турагенства: " + Name + "\nПервый тур:");
            Tour.Display();

            Console.WriteLine("Реальный процент продаж первого тура: " + RealProcFirst + "\nВторой тур:");
            FtPermit.Display();
            Console.WriteLine("Реальный процент продаж второго тура: " + RealProcSecond);
        }

        public double Summ_mn()
        {
            double summ = 0;
            double k;

            k = (RealProcFirst * Tour.Plan_sale) / 100;
            summ += k * Tour.Price;

            k = (RealProcSecond * FtPermit.Plan_sale) / 100;

            if (FtPermit.Hot_per == 1)
            {
                summ += k * (FtPermit.Price - (FtPermit.Plan_sale * 0.3));
            }
            else
            {
                summ += k * FtPermit.Price;
            }

            return Math.Floor(summ * 100) / 100;
        }

    }
}
