#include <iostream>
#include <math.h>

using namespace std;

/*!
	\brief Основной класс

	В нем находится метод, который вычисляет окупаемость фльма
*/

class film
{
public:
	void Init(int cost1, int gain1);
	void Display(); // Вывод на консоль
	void Read();
	float okup_f(); //окупаемость фильма
	double GetGain();//доход от фильма
	double GetCost();//затраты на фильм
	int summ(film X);


protected:int cost, gain;//затраты

};

/*!
	\return прибль gain
*/

double film::GetGain() {
	return gain;
}

/*!
	\return затраты cost
*/


double film::GetCost()
{
	return cost;
}

/*!
	\brief Сумма прибыли за флильм

	\param [in] х входящий параметр объект класса (фильм)

	\return сумма к

*/

int film::summ(film X)
{
	int k;
	k = X.GetGain() + X.GetGain();
	return k;
}

/*!
	\brief Метод инициализации значений для стоимости и зарат

	\param [in] cost1 входящий параметр затраты
	\param [in] gain1 входящий параметр прибль

*/

void film::Init(int cost1, int gain1) {
	cost = cost1;
	gain = gain1;
}

/*!
	\brief Метод расчета окупаемости

	\f[
		окупаемость = \frac{Расходы }{Доходы }\times {100}
	\f]

	\return Окупаемость к
*/

float film::okup_f()
{
	float k;
	k = ((float)gain / (float)cost) * 100;
	return k;
}


/// Эта функция выводит в консоль затраты на фильм и прибль за фильм
void film::Display() {
	cout << "Затраты на фильм - " << cost << "\n Прибыль за фильм - " << gain << endl;
}




/*!

	\brief Период дня с минимальной суммой заработанных денег

	@image{inline} html pic.jpg "Вот как это работает"
	\details Метод сравнивает суммы денег за каждый из 3-х периодов суток (утро, день, вечер)
	\return объект с минимальной суммой
*/


void film::Read() {
	cout << "Введите затраты на фильм - ";
	cin >> cost;

	cout << "Введите прибыль с фильма - ";
	cin >> gain;
}

/*!
	\brief Вспомогательный класс

	Имеет объекты основного класса для определения затрат и прибыли. Имеет метод, для расчета суммы.
*/


class FL :private film
{
public:
	void Init(int cost1, int gain1, int z1); // Перегруженный метод в произвольном классе
	int summ();
private:
	int z = 0.1;
};

/// Функция считает сумму
int FL::summ()
{
	double k;
	if (z == 1)
		k = gain * (1.1);
	return k;
}

/*!
	\brief Сумма прибыли за флильм

	\param [in] cost1 входящий параметр озатраты на фильм
	\param [in] gain1 входящий параметр доход с фильма
	\param [in] z1 входящий параметр рейтинг фильма

	

*/
void FL::Init(int cost1, int gain1, int z1)
{
	film::Init(cost1, gain1);
	z = z1;
}

/*!
	\brief Вспомогательный класс

	Имеет объекты основного класса для определения затрат и прибыли. Имеет метод, для расчета суммы.
*/
class film_studio
{
public:
	void Display();
	void Read();
	void Init(char* n, int cost1, int gain1, int cost2, int gain2, int cost3, int gain3, int first_income1, int two_income2, int third_income3);
	
	

private:
	char Name[30]; // Название киностудии
	film FirstFilm; // Первый фильм
	film SecondFilm; // Второй фильм
	film ThirdFilm; // Третий фильм

	int first_income, two_income, third_income; //доход от проката в других странах


};
/*!
	\brief Эта функция инициализирует входящие данные
	\param [in] n колличество киностудий
	\param [in] cost1 траты киностудии 1
	\param [in] gain1 прибль киностудии 1
	\param [in] cost2 траты киностудии 2
	\param [in] gain2 прибль киностудии 2
	\param [in] cost3 траты киностудии 3
	\param [in] gain3 прибль киностудии 3
	\param [in] first_income1 прибль киностудии 1
	\param [in] two_income2 прибль киностудии 2
	\param [in] third_income3 прибль киностудии 3
*/

void film_studio::Init(char* n, int cost1, int gain1, int cost2, int gain2, int cost3, int gain3,
	int first_income1, int two_income2, int third_income3)
{
	strcpy_s(Name, n);
	FirstFilm.Init(cost1, gain1);
	SecondFilm.Init(cost2, gain2);
	ThirdFilm.Init(cost3, gain3);

	first_income = first_income1;
	two_income = two_income2;
	third_income = third_income3;

}

///функция выводит в консоль данные о киностудии и их фильмах
void film_studio::Display() {
	cout << "Название киностудии: " << Name << "\nПервый тур:\n";
	FirstFilm.Display();

	cout << "Доход от проката первого фильма за рубежом: " << first_income << "\nВторой тур : \n";
	SecondFilm.Display();

	cout << "Доход от проката второго фильмаза рубежом: " << two_income << "\nТретий тур:\n";
	ThirdFilm.Display();

	cout << "Доход от проката третьего фильма за рубежом: " << third_income << endl;

}
///функция считывает данные о киностудии и фильмах этой киностудии

void film_studio::Read() {
	cout << "Введите название киностудии :";
	cin >> Name;
	cin.sync();

	FirstFilm.Read();
	cout << "Введите доход от проката в других странах первого фильма: ";
	cin >> first_income;
	cin.sync();

	SecondFilm.Read();
	cout << "Введите доход от проката в других странах второго фильма: ";
	cin >> two_income;

	ThirdFilm.Read();
	cout << "Введите доход от проката в других странах третьего фильма: ";
	cin >> third_income;
}

/// \callergraph
int main()
{
	setlocale(LC_ALL, "Russian");

	film f1;
	FL f2;
	f1.Read();
	f1.Init(156000, 295666);
	f2.Init(685132, 89562, 1);
	f1.summ(f1);
	cout << "Прибль увеличенa, новая прибль : " << f2.summ();


	return 0;
}
