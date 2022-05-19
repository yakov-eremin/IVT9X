#include <iostream>
#include <math.h>
using namespace std;
/*!
	\brief Основной класс.

	В нем находится метод, который вычисляет цену всех специй.
*/
class spec
{
private:
	double ves, stoimed;
public:
	void displayspec();
	void init(double c1, double k1);
	void read();
	double summ();
};

/*!
	\brief Эта функция присваивает начальное значение для цены специи за грамм и вес специи в граммах.

	\param [in] c1 входящий параметр цена специи.
	\param [in] k1 входящий параметр вес специи.
*/


void spec::init(double c1, double k1)
{
	stoimed = c1;
	ves = k1;
}

/*!
	\brief Общая сумма денег за специи.

	Эта функция возвращает произведение цены специи на количество граммов специи.
*/


double spec::summ()
{
	return stoimed * ves;
}

///Эта функция выводит в консоль стоимость 1 грамма и количество грамм специи.

void spec::displayspec()
{
	cout << "Стоимость 1 грамма: \n" << stoimed << endl;
	cout << "Количество грамм: \n" << ves << endl;
}

///Эта фйнкция вводит цену одного грамма специи и вес специи.

void spec::read()
{
	cout << "Введите цену одного грамма специи: ";
	cin >> stoimed;
	cout << "Введите вес специи: ";
	cin >> ves;
}

/*!
	\brief Вспомогательный класс.

	Имеет объекты основного класса для определения суммы денег за конкретное блюдо. Имеет методы, определяющие самую дешевую специю и стоимость блюда.
*/

class bludo
{
private:
	char name[50];
	spec dob1, dob2, dob3;
	double stoimvsex;
	int vess;
public:
	spec deshdob(); //самая дешевая добавка
	void display();
	void read();
	double realprofit(); //общая стоимость блюда
	void init(spec dobb1, spec dobb2, spec dobb3, double stoimvsexx, int vessd, const char* nn);
	char* getname();
	void putname(char* s);
};

/*!

	\brief Самая дешевая добавка

	@image{inline} html image.png "Вот как это работает"
	\details Метод сравнивает стоимость добавок и возвращает добавку с минимальной стоимостью
	\return объект с минимальной стоимостью
*/


spec bludo::deshdob()
{
	if (dob1.summ() < dob2.summ())
	{
		if (dob1.summ() < dob3.summ())
		{
			return dob1;
		}
		else if (dob3.summ() < dob2.summ())
		{
			return dob3;
		}
	}
	else if (dob2.summ() < dob3.summ())
	{
		return dob2;
	}

	else
	{
		return dob3;
	}
}

///Эта функция записывает информацию о блюде

void bludo::read()
{
	cout << "Введите название блюда:\n";
	cin >> name;
	cout << "Специя 1:\n";
	dob1.read();
	cout << "Специя 2:\n";
	dob2.read();
	cout << "Специя 3:\n";
	dob3.read();
	cout << "Введите вес блюда\n";
	cin >> vess;
	cout << "Введите стоимость единицы основных компонент блюда\n";
	cin >> stoimvsex;
}

/*!
	\brief Эта функция инициализирует входящие данные
	\param [in] dobb1 первая добавка
	\param [in] dobb2 вторая добавка
	\param [in] dobb2 третья добавка
	\param [in] stoimvsex общая стоимость добавок
	\param [in] vess вес блюда
*/


void bludo::init(spec dobb1, spec dobb2, spec dobb3, double stoimvsexx, int vessd, const char* nn)
{
	dob1 = dobb1;

	dob2 = dobb2;

	dob3 = dobb3;
	stoimvsex = stoimvsexx;
	vess = vessd;
	strcpy_s(name, nn);
}

/*!
	\return общую стоимость добавок

	\f[
			Стоимость = Добавка1 + Добавка2 + Добавка3.
	\f]]
*/

double bludo::realprofit()
{
	return dob1.summ() + dob2.summ() + dob3.summ();
}

/// Эта функция выводит в консоль информацию о добавках которые содержаться в блюде, о самом блюде и самую дешевую добавку.

void bludo::display()
{
	cout << "Первая специя:\n";
	dob1.displayspec();
	cout << "Вторая специя:\n";
	dob2.displayspec();
	cout << "Третья специя:\n";
	dob3.displayspec();
	cout << "Название блюда: " << name << endl;
	cout << "Общая стоимость блюда: " << realprofit() << endl;
	cout << "Самая дешевая добавка\n";
	deshdob().displayspec();
}



int main()
{
	system("chcp 1251>>void");
	setlocale(LC_ALL, "rus");
	spec dob1, dob2, dob3;
	bludo bluddo;
	spec specc;
	char name[50];


	dob1.init(5, 300);
	dob2.read();
	dob3.read();

	bluddo.init(dob1, dob2, dob3, 20, 900, "борщь");
	bluddo.display();
	bluddo.read();
	bluddo.display();
	system("pause>>void");
}
