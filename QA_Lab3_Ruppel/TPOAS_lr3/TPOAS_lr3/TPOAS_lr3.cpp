#include <iostream>
#include <math.h>
using namespace std;

/*!
	\brief Основной класс

	В нем находится метод, который вычисляет какую-то одну сумму денег за вес ископаемого по одной цене
*/

class Iskop
{
private:
	double ves;
	double cena;

public:
	void display();
	void init(double v1, double c1);
	double summ();
};

/*!
	\brief Эта функция присваивает начальное значение для веса ископаемого и цены грамма ископаемого
	\param [in] v1 входящий параметр вес ископаемого
	\param [in] c1 входящий параметр цена грамма ископаемого
*/

void Iskop::init(double v1, double c1)
{
	ves = v1;
	cena = c1;
}

/*!
	\brief Общая сумма денег ископаемого

	Эта функция возвращает произведение веса ископаемого на цену грамма ископаемого
*/

double Iskop::summ()
{
	return ves * cena;
}

///Эта функция выводит в консоль вес ископаемого и его цену за грамм

void Iskop::display()
{
	cout << "Вес добытого: " << ves << endl;
	cout << "Цена грамма добытого: " << cena << endl;
}

/*!
	\brief Вспомогательный класс

	Имеет объекты основного класса для определения суммы денег за конкретное ископаемое. Имеет методы, определяющие самое ценное полезное ископаемого, доходность рудника и затраты ископаемых.
*/

class Rugazik
{
private:
	char n[50];
	Iskop ugol, gaz, torf;
	int zatrat_ugol, zatrat_gaz, zatrat_torf;

public:
	Iskop maxprofit(); //самое ценное полезное ископаемое 
	void proc();
	double realprofit(); //доходность
	void init(double v1, double c1, double v2, double c2, double v3, double c3, double z1, double z2, double z3);
	char* getname();
	void pugolname(char* s);
	double average();
};

/*!

	\brief Самое ценное полезное ископаемое 

	@image{inline} html image.jpg "Вот как это работает"
	\details Метод сравнивает самое ценное ископаемое из 3-х ископаемых (уголь, газ, торф)
	\return объект с самым ценным полезным ископаемым 
*/

Iskop Rugazik::maxprofit()

{
	if (ugol.summ() > gaz.summ())
	{
		if (ugol.summ() > torf.summ())
		{
			return ugol;
		}
		else if (torf.summ() > gaz.summ())
		{
			return torf;
		}
	}
	else if (gaz.summ() > torf.summ())
	{
		return gaz;
	}
	else
	{
		return torf;
	}
}

/*!
	\brief Эта функция инициализирует входящие данные
	\param [in] v1 вес угля
	\param [in] c1 цена грамма угля
	\param [in] v2 вес газа
	\param [in] c2 цена грамма газа
	\param [in] v3 вес торфа
	\param [in] c3 цена грамма торфа
	\param [in] z1 затраты угля
	\param [in] z2 затраты газа
	\param [in] z3 затраты торфа
*/

void Rugazik::init(double v1, double c1, double v2, double c2, double v3, double c3, double z1, double z2, double z3)
{
	ugol.init(v1, c1);
	zatrat_ugol = z1;

	gaz.init(v2, c2);
	zatrat_gaz = z2;

	torf.init(v3, c3);
	zatrat_torf = z3;
}

/*!
	\return доходность рудника (уголь, газ, торф)
*/

double Rugazik::realprofit() //доходность = стоимость добытого - затраты
{
	return (ugol.summ() + gaz.summ() + torf.summ()) - (zatrat_ugol + zatrat_gaz + zatrat_torf); //(сумма1 + сумма2 + сумма3) - (затраты1 + затраты2 + затраты3)
}

/// Эта функция выводит в консоль затраты каждого ископаемого (уголь, газ, торф)

void Rugazik::proc()
{
	cout << "Затраты угля: " << zatrat_ugol << endl;
	cout << "Затраты газа: " << zatrat_gaz << endl;
	cout << "Затраты торфа: " << zatrat_torf << endl;
}

/*!
	\return Название рудника n
*/

char* Rugazik::getname()
{
	return n;
}

/*!
	\brief Эта функция получает название рудника и копирует в новую переменную

	\param [in] s название рудника
*/

void Rugazik::pugolname(char* s)
{
	strcpy_s(n, s);
}

/*!
	\return Доходность

	\f[
		Доходность = {(Сумма.угля + Сумма.газа + Сумма.торфа) - (Затраты.угля + Затраты.газа + Затраты.торфа)}
	\f]
*/

double Rugazik::average() {
	return ((ugol.summ() + gaz.summ() + torf.summ()) - (zatrat_ugol + zatrat_gaz + zatrat_torf));
}

/// \callergraph

int main()
{
	system("chcp 1251<<void");
	setlocale(LC_ALL, "rus");
	int zatrat_ugol, zatrat_gaz, zatrat_torf;
	double v1, v2, v3;
	double c1, c2, c3;
	Iskop ugol, gaz, torf, maxprofit;
	Rugazik sp;
	char n[50];
	cout << "Введите вес угля: ";
	cin >> v1;
	cout << "Введите цену грамма угля: ";
	cin >> c1;
	ugol.init(v1, c1);
	cout << "Введите вес газа: ";
	cin >> v2;
	cout << "Введите цену грамма газа: ";
	cin >> c2;
	gaz.init(v2, c2);
	cout << "Введите вес торфа: ";
	cin >> v3;
	cout << "Введите цену грамма торфа: ";
	cin >> c3;
	torf.init(v3, c3);
	cout << endl;
	cout << "Уголь: " << endl;
	ugol.display();
	cout << endl;
	cout << "Газ: " << endl;
	gaz.display();
	cout << endl;
	cout << "Торф: " << endl;
	torf.display();
	cout << endl;
	cout << "Введите затраты ископаемых: " << endl;
	cin >> zatrat_ugol >> zatrat_gaz >> zatrat_torf;
	sp.init(v1, c1, v2, c2, v3, c3, zatrat_ugol, zatrat_gaz, zatrat_torf);
	cout << endl;
	cout << "Введите название рудника: ";
	cin >> n;
	sp.pugolname(n);
	cout << "\nРудник - " << sp.getname() << endl;
	cout << "Доходность рудника: " << sp.realprofit() << endl;
	cout << endl;
	cout << "Самое ценное полезное ископаемое: " << endl;
	maxprofit = sp.maxprofit();
	maxprofit.display();
	cout << endl;
	sp.proc();
	system("pause<<void");
}