using System;

namespace lab2_3_csharp
{
    public class angle
    {
		public double Sec // свойство к полю sec
		{
			get
			{
				return s; // извлечение значения sec
			}
			set
			{
				if (value >= 0 && value < 60)
				{
					s = value; // задание значения sec, но только если значение 
								// от нуля до 59
				}
			}
		}

		public double gradround()
		{
			double q, w;
			q = s / 60;
			q += m;
			q /= 60;
			if (q >= 0.5)
				w = g + 1;
			else
				w = g;
			return w;
		}

        public void init(double g1, double m1, double s1)
		{
			g = g1;
			m = m1;
			s = s1;
		}

		public void InitG(double g1)
		{
			g = g1;
		}

		public double MinType()
		{
			double min = g;
			if (min > m) min = m;
			if (min > s) min = s;
			return (int)min;
		}

		public void read()
		{
			Console.Write("Введите градусы: ");
			g = Convert.ToDouble(Console.ReadLine());
			Console.Write("Введите минуты: ");
			m = Convert.ToDouble(Console.ReadLine());
			Console.Write("Введите секунды: ");
			s = Convert.ToDouble(Console.ReadLine());
		}
		public void display()
		{
			Console.WriteLine(g + " градусов " + m + " минут " + s + " секунд");
		}
		public angle add(angle a1, angle a2)
		{
			angle a3 = new angle();
			a3.g = a1.g + a2.g;
			a3.m = a1.m + a2.m;
			a3.s = a1.s + a2.s;
			if (a3.s >= 60)
			{
				a3.m++;
				a3.s -= 60;
			}
			if (a3.m >= 60)
			{
				a3.g++;
				a3.m -= 60;
			}
			return a3;
		}

		private double g, m, s;
		public int Numbersec()
		{
			return (int)((g * 3600) + (m * 60) + s);
		}
    }
}




	
	















