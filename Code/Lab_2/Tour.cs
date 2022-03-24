using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency1
{
    public class Tour
    {
        private double price;
        private double plan_sale;
        public double Plan_sale
        {
            get
            {
                return plan_sale;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
        }

        public Tour(int pr, int sale)
        {
            price = pr;
            plan_sale = sale;
        }

        public Tour() {}

        public void Init(double pr, double sale)
        {
            price = pr;
            plan_sale = sale;
        }


        public void Display()
        {
            Console.WriteLine("Стоимость билета - " + price + "\nПланируемое кол - во билетов - " + plan_sale);
        }

        public double Exp_amount()
        {
            double Suma = price * plan_sale;

            return Math.Floor(Suma * 100) / 100;
        }

    }
}
