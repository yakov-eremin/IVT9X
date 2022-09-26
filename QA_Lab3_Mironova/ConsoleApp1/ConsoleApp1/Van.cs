using System;

namespace ConsoleApp1
{
	/**
	    @brief Вспомогательный класс Вагон
        
        Вагон, содержит поле - количество мест (целое число) и цена билета по данному маршруту (вещественная).
    */
	public class Van
	{
		/// Кол-во мест (целое число)
		protected int seat = 0;
		/// Цена билета по данному маршруту (вещественная)
		protected double price = 0.0;

		/// <summary>
		/// Вывод информации в консоль
		/// </summary>
		public void Display()
		{
			Console.WriteLine("Количество мест в вагоне: " + seat);
			Console.WriteLine("Цена места: " + price);

		}

		/// <summary>
		/// Метод инициализации
		/// </summary>
		/// <param name="s">Кол-во мест</param>
		/// <param name="p">Цена билета</param>
		public void Init(int s, float p)
		{
			seat = s;
			price = p;
		}

		/// <summary>
		/// Метод, вычисляющий общую ожидаемую сумму от продаж билетов в вагоне по формуле \f$I = S * P\f$ (I - сумма, S - кол-во мест, P - цена за билет)
		/// </summary>
		/// <returns>Ожидаемая сумма от продаж билетов</returns>
		public double Income()
		{
			return (seat * price);
		}
	}
}
