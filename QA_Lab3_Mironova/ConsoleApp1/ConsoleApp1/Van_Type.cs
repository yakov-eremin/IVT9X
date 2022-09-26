using System;

namespace ConsoleApp1
{
	/**
	    @brief Вспомогательный класс Вагон (производный)
        
        В производном классе имеется целое поле, равное 0,1,2. Если оно равно 1 — это плацкарт и стоимость от продажи не меняется, 0 - общий вагон и стоимость уменьшается на 30%, 2 - купе - стоимость возрастает на 50%. Метод основного класса вычисляет сумму денег от продаж.
    */
	public class Van_Type : Van
	{
		/// Тип вагона
		private int type;

		/// <summary>
		/// Вывод информации в консоль
		/// </summary>
		public void Display()
		{
			base.Display();
			Console.WriteLine("Тип: " + type);
		}

		/// <summary>
		/// Метод инициализации
		/// </summary>
		/// <param name="s">Кол-во мест</param>
		/// <param name="p">Цена билета</param>
		/// <param name="t">Тип вагона</param>
		public void Init(int s, float p, int t)
		{
			base.Init(s, p);
			type = t;
		}

		/// <summary>
		/// Метод, возвращающий вагон с наименьшей ожидаемой суммой продаж
		/// </summary>
		/// <returns>Вагон с наименьшей ожидаемой суммой продаж</returns>
		public double Income()
		{
			double a = 0;
			if (type == 0)
			{
				a = (seat * (price * (2 / 3)));
			}
			if (type == 1)
			{
				a = (seat * price);
			}
			if (type == 2)
			{
				a = (seat * (price * 1.5));
			}
			return a;
		}
	}
}
