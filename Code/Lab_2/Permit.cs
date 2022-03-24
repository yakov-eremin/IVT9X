using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency1
{
    public class Permit : Tour
    {
        private int hot_per;

        public Permit(int pr, int sale, int hotper) : base(pr, sale)
        {
            hot_per = hotper;
        }

        public Permit() { }

        public int Hot_per
        {
            get
            {
                return hot_per;
            }
        }

        public void Init(double pr, double sale, int hotper)
        {
            base.Init(pr, sale);

            hot_per = hotper;
        }

        public void Display()
        {
            base.Display();

            if (hot_per == 1)
            {
                Console.WriteLine("Тур с горящей путевкой");
            }
            else
            {
                Console.WriteLine("Тур с обычной путевкой");
            }
        }

        public double Exp_amount()
        {
            double summ = 0;

            if (hot_per == 1)
            {
                summ = (Price - Price * 0.3) * Plan_sale;
            }
            else
            {
                summ = Price * Plan_sale;
            }

            return Math.Floor(summ * 100) / 100;
        }

    }
}
