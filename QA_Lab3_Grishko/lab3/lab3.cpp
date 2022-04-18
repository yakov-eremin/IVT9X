#include<iostream>
#include <math.h>
using namespace std;

/*!
	\brief Основной класс

	В нем находится метод, который вычисляет какую-то одну сумму денег за билеты по одной цене
*/

class Performance
{
private:
	double cena;
	int kol;
public:
	void display();
	void init(double c1, int k1);
	double summ();
};

/*!
	\brief Эта функция присваивает начальное значение для цены билета и количества билетов
	\param [in] c1 входящий параметр цена билета
	\param [in] k1 входящий параметр количество билетов
*/

void Performance::init(double c1, int k1)
{
	cena = c1;
	kol = k1;
}

/*!
	\brief Общая сумма денег за билеты

	Эта функция возвращает произведение цены билета на количество билетов
*/

double Performance::summ()
{
	return cena * kol;
}

	///Эта функция выводит в консоль цену билета и его количество

void Performance::display()
{
	cout << "Цена билета: " << cena << endl;
	cout << "Количество билетов: " << kol << endl;
}

/*!
	\brief Вспомогательный класс
	
	Имеет объекты основного класса для определения суммы денег за конкретный период времени. Имеет методы, определяющие минимальную сумму денег, общую сумму денег за сутки и проценты заполнения мест.
*/


class Spectacl
{
private:
	char n[50];
	Performance ut, dn, vech;
	int zapoln_ut, zapoln_dn, zapoln_vech;
public:
	Performance minprofit(); 
	void proc();
	double realprofit();
	void init(double c1, int k1, double c2, int k2, double c3, int k3, double z1, double z2, double z3);
	char* getname();
	void putname(char* s);
    double average();
};

/*!

	\brief Период дня с минимальной суммой заработанных денег

	@image{inline} html image.png "Вот как это работает"
	\details Метод сравнивает суммы денег за каждый из 3-х периодов суток (утро, день, вечер)
	\return объект с минимальной суммой
*/

Performance Spectacl::minprofit()
{
	if (ut.summ() < dn.summ())
	{
		if (ut.summ() < vech.summ())
		{
			return ut;
		}
		else if (vech.summ() < dn.summ())
		{
			return vech;
		}
	}
	else if (dn.summ() < vech.summ())
	{
		return dn;
	}

	else
	{
		return vech;
	}
}

/*!
	\brief Эта функция инициализирует входящие данные
	\param [in] c1 цена утреннего билета
	\param [in] k1 количество утренних билетов
	\param [in] c2 цена дневного билета
	\param [in] k2 количество дневных билетов
	\param [in] c3 цена вечернего билета
	\param [in] k3 количество вечерних билетов
	\param [in] z1 процент заполнения зала утром
	\param [in] z2 процент заполнения зала днем
	\param [in] z3 процент заполнения зала вечером
*/

void Spectacl::init(double c1, int k1, double c2, int k2, double c3, int k3, double z1, double z2, double z3)
{
	ut.init(c1, k1);
	zapoln_ut = z1;

	dn.init(c2, k2);
	zapoln_dn = z2;

	vech.init(c3, k3);
	zapoln_vech = z3;
}

/*!
	\return общую сумму денег за весь день (утро, день, вечер)
*/

double Spectacl::realprofit()
{
	return ut.summ() + dn.summ() + vech.summ();  //сумма1 + сумма2 + сумма3
}

	/// Эта функция выводит в консоль проценты заполнения партера за каждую часть дня (утро, день, вечер)

void Spectacl::proc()
{
	cout << "Процент заполнения партера утром: " << zapoln_ut << endl;
	cout << "Процент заполнения партера днём: " << zapoln_dn << endl;
	cout << "Процент заполнения партера вечером: " << zapoln_vech << endl;
}

/*!
	\return название спектакля n
*/
char* Spectacl::getname()
{
	return n;
}

/*!
	\brief Эта функция получает название спектакля и копирует в новую переменную

	\param [in] s название спектакля
*/

void Spectacl::putname(char* s)
{
	strcpy_s(n, s);
}

/*!
	\return среднюю сумму денег за сутки

	\f[
		Средняя.сумма = \frac{Сумма.утром + Сумма.днем + Сумма.вечером}{3}
	\f]
*/
double Spectacl::average() {
	return (ut.summ() + dn.summ() + vech.summ())/3;
}

/// \callergraph

int main()
{
	system("chcp 1251>>void");
	setlocale(LC_ALL, "rus");
	int zapoln_ut, zapoln_dn, zapoln_vech;
	double c1, c2, c3;
	int k1, k2, k3;
	Performance ut, dn, vech, minprofit;
	Spectacl sp;
	char n[50];
	cout << "Введите цену утреннего билета: ";
	cin >> c1;
	cout << "Введите количество билетов утром: ";
	cin >> k1;
	ut.init(c1, k1);
	cout << "Введите цену дневного билета: ";
	cin >> c2;
	cout << "Введите количество билетов днем: ";
	cin >> k2;
	dn.init(c2, k2);
	cout << "Введите цену вечернего билета: ";
	cin >> c3;
	cout << "Введите количество билетов вечером: ";
	cin >> k3;
	vech.init(c3, k3);
	cout << endl;
	cout << "Утренний спектакль: " << endl;
	ut.display();
	cout << endl;
	cout << "Дневной спектакль: " << endl;
	dn.display();
	cout << endl;
	cout << "Вечерний спектакль: " << endl;
	vech.display();
	cout << endl;
	cout << "Введите проценты заполнения партеров: " << endl;
	cin >> zapoln_ut >> zapoln_dn >> zapoln_vech;
	sp.init(c1, k1, c2, k2, c3, k3, zapoln_ut, zapoln_dn, zapoln_vech);
	cout << endl;
	cout << "Введите название спектакля: ";
	cin >> n;
	sp.putname(n);
	cout << "\nСпектакль - " << sp.getname() << endl;
	cout << "Сумма денег от продажи билетов за день: " << sp.realprofit() << endl;
	cout << endl;
	cout << "Спектакль с минимальной ожидаемой суммой продаж: " << endl;
	minprofit = sp.minprofit();
	minprofit.display();
	cout << endl;
	sp.proc();
	system("pause>>void");
}