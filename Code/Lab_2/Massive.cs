using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkMassiv
{
    public class Massive
    {
        public int[] Mas;

        public Massive(int dlina)
        {
            Mas = new int[dlina];
        }

        public int Poismaks()
        {
            int max = Mas[0]; 

            for (int i = 0; i < Mas.Length; i++)
                if (Mas[i] > max)
                    max = Mas[i];

            return max;
        }

        public int Poiskmin()
        {
            int min = Mas[0];

            for (int i = 0; i < Mas.Length; i++) 
                if (Mas[i] < min)
                    min = Mas[i];

            return min;
        }

        public int PoiskMinSredPol()
        {
            int min = 10000000;

            for(int i = 0; i < Mas.Length; i++)
                if(Mas[i] > 0)
                    if (Mas[i] < min)
                        min = Mas[i];

            return min;
        }

        public int PoiskMaxSredOtr()
        {
            int max = -9999999;

            for(int i = 0; i < Mas.Length ; i++)
                if(Mas [i] < 0)
                    if (Mas [i] > max)
                        max = Mas[i];

            return max;
        }

    }
}
