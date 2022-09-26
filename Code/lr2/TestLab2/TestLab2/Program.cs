using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			Train tr1 = new Train();
			tr1.Init("Поезд 1", 25, 64, 187, 18, 23, 46, 100, 50, 25);
			Train tr2 = new Train();
			tr2.Read();
			tr1.Display();
			tr2.Display();
			double inc1, inc2;
			Van worst = new Van();
			worst = tr2.Worst();
			inc1 = tr1.Income();
			inc2 = worst.Income();
			Console.WriteLine("Реальный доход маршута: " + inc1);
			Console.WriteLine("Худший вагон");
			worst.Display();
			Console.WriteLine("Доход от худшего вагона: " + inc2);
			Console.ReadKey();
		}
	}
}