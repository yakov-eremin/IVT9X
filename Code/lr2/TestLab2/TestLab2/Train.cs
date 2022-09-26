using System;

namespace ConsoleApp3
{
	public class Train
	{
		private String name;
		private Van van1 = new Van();
		private Van van2 = new Van();
		private Van van3 = new Van();
		private int fill1 = 0;
		private int fill2 = 0;
		private int fill3 = 0;

		public void Display()
		{
			Console.WriteLine("Название: " + name);
			van1.Display();
			van2.Display();
			van3.Display();
			Console.WriteLine("Заполненость вагонов : " + fill1 + " " + fill2 + " " + fill3);
		}

		public void Init(String n, int s1, float p1, int s2, float p2, int s3, float p3, int f1, int f2, int f3)
		{
			if (f1 < 0 || f2 < 0 || f3 < 0)
				throw new ArgumentException("Процент не может быть отрицательным!");

			name = n;
			van1.Init(s1, p1);
			van2.Init(s2, p2);
			van3.Init(s3, p3);
			fill1 = f1;
			fill2 = f2;
			fill3 = f3;
		}

		public void Init(String n, Van v1, Van v2, Van v3, int f1, int f2, int f3)
		{
			if (f1 < 0 || f2 < 0 || f3 < 0)
				throw new ArgumentException("Процент не может быть отрицательным!");
			if (v1 == null || v2 == null || v3 == null)
				throw new ArgumentNullException();

			name = n;
			van1 = v1;
			van2 = v1;
			van3 = v1;
			fill1 = f1;
			fill2 = f2;
			fill3 = f3;
		}

		public void Read()
		{
			Console.WriteLine("Введите название поезда: ");
			name = Console.ReadLine();
			van1.Read();
			van2.Read();
			van3.Read();
			Console.WriteLine("Заполненость первого вагона: ");
			fill1 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Заполненость второго вагона: ");
			fill2 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Заполненость третьего вагона: ");
			fill3 = Convert.ToInt32(Console.ReadLine());
		}

		public double Income()
		{
			return ((van1.Income() * (fill1 / 100)) + (van2.Income() * (fill2 / 100)) + (van3.Income() * (fill3 / 100)));
		}

		public Van Worst()
		{
			double inc1 = van1.Income();
			double inc2 = van2.Income();
			double inc3 = van3.Income();
			if (inc1 > inc2)
			{
				if (inc1 > inc3)
				{
					return van1;
				}
				else
				{
					return van3;
				}
			}
			else
			{
				if (inc2 > inc3)
				{
					return van2;
				}
				else
				{
					return van3;
				}
			}
		}
	}
}
