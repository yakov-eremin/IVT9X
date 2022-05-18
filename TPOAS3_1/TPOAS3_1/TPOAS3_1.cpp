#include<iostream>
using namespace std;

/*!
		\brief Основной класс

		В нём находится метод, вычисляющий стоимость помещения
*/


class pom
{
private:
	double c;
	int a;
public:
	void display();
	void init(double c1, int a1);
	double p();
};

/*!
		\brief Эта функция присваивает начальное значение для стоимости квадратного метра помещения и его площади
		\param [in] c1 входящий параметр стоимости квадратного метра
		\param [in] k1 входящий параметр площади помещения
*/

void pom::init(double с1, int a1)
{
	c = с1;
	a = a1;
}


///Функция выводит в консоль стоимость квадратного метра и площадь помещения 


void pom::display()
{
	cout << "Стоимость квадратного метра:\t\t" << c << endl;
	cout << "Площадь помещения:\t\t" << a << endl;
}

/*!
		\brief Стоимость помещения

		Функция возвражает произведение стоимости квадратного метра и площади помещения
*/

double pom::p()
{
	return c * a;
}

/*!
		\brief Вспомогательный класс

		Имеет объекты основного класса для определения конкретной стоимости комнаты. Имеет методы, определяющие
		стоимость самой дорогой комнаты, общую стоимость агенства и название агенства.
*/

class agen
{
public:
	pom dorpom();
	double totcost();
	char* getname();
	void putname(char* s);
	void init(double a1, int b1, double a2, int b2, double a3, int b3, double z1);
private:
	char n[50];
	double z;
	pom p1;
	pom p2;
	pom p3;
};

/*!
		\brief Данная функция инициализирует входящие данные
		\param [in] a1 площадь первой комнаты
		\param [in] c1 стоимость квадратного метра первой комнаты
		\param [in] a2 площадь второй комнаты
		\param [in] c2 стоимость квадратонго метра второй комнаты
		\param [in] a3 площадь третьей комнаты
		\param [in] c3 стоимость квадратного метра третьей комнаты
		\param [in] z1 расходы
*/

void agen::init(double a1, int c1, double a2, int c2, double a3, int c3, double z1)
{
	p1.init(a1, c1);
	p2.init(a2, c2);
	p3.init(a3, c3);
	z = z1;
}

/*!
		\brief Стоимость самой дорогой комнаты

		@image{inline} html image.png "Вот как это работает"
		\details метод сравнивает стоимость каждой из 3-х комнат
		\return объект с максимальной стоимостью
*/

pom agen::dorpom()
{
	if (p1.p() > p2.p() && p1.p() > p3.p())
	{
		return p1;
	}
	else
	{
		if (p2.p() > p3.p() && p2.p() > p1.p())
		{
			return p2;
		}
		else return p3;
	}
}

/*!
		/return название агенства (n)
*/

char* agen::getname()
{
	return n;
}

/*!
		\brief функция получает название агенства и копирует в новую переменную

		\param [in] s название агенства
*/

void agen::putname(char* s)
{
	strcpy_s(n, s);
}

/*! 
		\return общую стоимость агенства с учётом расходов

		\f[
			Стоимость = Комната1 + Комната2 + Комната3 - Расходы
		\f]]

		
*/

double agen::totcost()
{
	return p1.p() + p2.p() + p3.p() - z;
}

/// \callergraph

/*!
	@mainpage
	Данная утилита предназначена для быстрого поиска в файле формата csv. 
*/


int main()
{
	setlocale(LC_ALL, "rus");
	double c1, c2, c3, z;
	int a1, a2, a3;
	pom p1, p2, p3, dorpom;
	agen ag;
	char n[50];
	cout << "Первая комната\nВведите стоимость квадратного метра:\t";
	cin >> c1;
	cout << "Введите площадь помещения:\t\t";
	cin >> a1;
	p1.init(c1, a1);
	cout << "\nВторая комната\nВведите стоимость квадратного метра:\t";
	cin >> c2;
	cout << "Введите площадь помещения:\t\t";
	cin >> a2;
	p2.init(c2, a2);
	cout << "\nТретья комната\nВведите стоимость квадратного метра:\t";
	cin >> c3;
	cout << "Введите площадь помещения:\t\t";
	cin >> a3;
	p3.init(c3, a3);
	cout << "\nКомната 1\n";
	p1.display();
	cout << "\nКомната 2\n";
	p2.display();
	cout << "\nКомната 3\n";
	p3.display();
	cout << "\nВведите расходы:\t\t";
	cin >> z;
	cout << "Введите название агенства: ";
	cin >> n;
	ag.putname(n);
	ag.init(c1, a1, c2, a2, c3, a3, z);
	cout << "\nАгенство - " << ag.getname() << "\nОбщая стоимость агенства:\t\t" << ag.totcost() << endl;
	dorpom = ag.dorpom();
	cout << "Самая дорогая комната:\t" << dorpom.p() << endl;
	system("pause>>void");
}

