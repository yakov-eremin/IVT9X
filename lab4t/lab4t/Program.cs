using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace lab4
{
    public class Calculate
    {
        public double dollarinrub(double kursdollar, double amountdollar)
        {
            double konvert = kursdollar * amountdollar;
            return konvert;
        }

        public double rubindollar(double amountrub, double kursdollar)
        {
            double konvert = amountrub / kursdollar;
            return konvert;
        }

        
    }
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}