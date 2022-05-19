#include <iostream>
#include <math.h>
using namespace std;

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

void spec::init(double c1, double k1)
{
	stoimed = c1;
	ves = k1;
}

double spec::summ()
{
	return stoimed * ves;
}

void spec::displayspec()
{
	cout << "Стоимость 1 грамма: \n" << stoimed << endl;
	cout << "Количество грамм: \n" << ves << endl;
}

void spec::read()
{
	cout << "Введите цену одного грамма специи: ";
	cin >> stoimed;
	cout << "Введите вес специи: ";
	cin >> ves;
}

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

void bludo::init(spec dobb1, spec dobb2, spec dobb3, double stoimvsexx, int vessd, const char* nn)
{
	dob1 = dobb1;

	dob2 = dobb2;

	dob3 = dobb3;
	stoimvsex = stoimvsexx;
	vess = vessd;
	strcpy_s(name, nn);
}
double bludo::realprofit()
{
	return dob1.summ() + dob2.summ() + dob3.summ();
}
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

//char* bludo::getname()
//{
//	return n;
//}

//void bludo::putname(char* s)
//{
//	strcpy_s(n, s);
//}

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
	//cout << endl;
	//cout << "Общая стоимость блюда: " << sp.realprofit() << endl;
	//cout << endl;
	//cout << "Самая дешевая добавка: " << endl;
	//deshdob = sp.deshdob();
	//deshdob.displayspec();
	//cout << endl;
	//sp.init(dob1, dob2, dob3, stoimvsex, vess, n);
	//sp.display();
	system("pause>>void");
}
