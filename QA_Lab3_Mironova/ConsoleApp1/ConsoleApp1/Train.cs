using System;

namespace ConsoleApp1
{
	/**
	    @brief Основной класс Поезд
        
        Класс, содержащий два поля типа вагонов и процент заполнения каждого вагона (два целых поля)
		@image html train.png
    */
	public class Train
	{
		/// Название поезда
		private String name;
		/// Вагон (обычный класс)
		private Van van = new Van();
		/// Вагон (производный класс с указанием типа вагона)
		private Van_Type vt = new Van_Type();

		/// <summary>
		/// Вывод информации в консоль
		/// </summary>
		public void Display()
		{
			Console.WriteLine("Название: " + name);
			van.Display();
			vt.Display();

		}

		/// <summary>
		/// Метод инициализации
		/// </summary>
		/// <param name="n">Название вагона</param>
		/// <param name="s1">Кол-во мест, первый вагон</param>
		/// <param name="p1">Цена билета, первый вагон</param>
		/// <param name="s2">Кол-во мест, второй вагон</param>
		/// <param name="p2">Цена билета, второй вагон</param>
		/// <param name="t">Тип второго вагона</param>
		public void Init(String n, int s1, float p1, int s2, float p2, int t)
		{
			name = n;
			van.Init(s1, p1);
			vt.Init(s2, p2, t);

		}

		/// <summary>
		/// Реальный доход с маршрута
		/// </summary>
		/// <returns>Сумма реального дохода</returns>
		public double Income()
		{
			return (van.Income() + vt.Income());
		}
	}
}
