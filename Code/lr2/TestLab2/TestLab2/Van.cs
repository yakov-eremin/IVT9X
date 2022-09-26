using System;

namespace ConsoleApp3
{
	public class Van
	{
		private int seat = 0;
		private double price = 0.0;

		public void Init(int s, float p)
		{
			seat = s;
			price = p;
		}
		public void Display()
		{
			Console.WriteLine("Количество мест в вагоне: " + seat);
			Console.WriteLine("Цена места: " + price);

		}
		public void Read()
		{
			seat = Convert.ToInt32(Console.ReadLine());
			price = Convert.ToInt32(Console.ReadLine());
		}
		public double Income()
		{
			return (seat * price);
		}
	}
}