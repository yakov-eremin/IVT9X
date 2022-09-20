#include <iostream>
#include <string>
using namespace std;
/// \brief Вспомогательный класс Одежда
	/// 
	/// Класс имеет поля: Стоимость единицы ткани, количество ткани. В классе описаны методы инициализации, вывода данных, а также метод, вычисляющий стоимость изделия 
	///
class clothes
{
protected:
	double cost; //Стоимость единицы ткани
	int quantity; // Количество ткани
public:
	void display();
	void init(double c1, int a1);
	double Cost_clothes();
};


/// Метод для инициализации полей класс
		/// \param[in] c1 Стоимость 
		/// \param[in] q1 Количество
void clothes::init(double с1, int q1)
{
	cost = с1;
	quantity = q1;
}

/// Вывод на экран информации об одежде
void clothes::display()
{
	cout << "Стоимость единицы длины ткани:\t\t" << cost << endl;
	cout << "Количество ткани:\t\t\t" << quantity << endl;
}

/// Функция, предназначенная для стоимости одежды \f${cost * quantity}\f$
		/// \param cost стоимость
		/// \param quantity количество
		/// <returns> Стоимость одежды </returns>
double clothes::Cost_clothes()
{
	return cost * quantity;
}


/// \brief Производный класс Коэффициент мастерства пошива одежды
/// 
/// Этот класс имеет поле -  коэффициент мастерства пошивщика. В классе описаны методы инициализации, вывода данных, а также метод, вычисляющий стоимость изделия
class Clothes_ratio : public clothes {
public:
	void Display();
	void init(int c, int q, int m);// // перегруженный метод в производном классе
	double Cost_clothes();// перегруженный  метод в производном классе                
private:
	int Km; // Коэффициент мастерства
};

/// Вывод на экран информации об одежде
void Clothes_ratio::Display() {
	this->display();
	cout << "Коэффициент мастерства: \t\t" << Km<<endl;
}

/// Метод для инициализации полей класс
		/// \param[in] c Стоимость 
		/// \param[in] q Количество
		/// \param[in] m Коэффициент мастерства
void Clothes_ratio::init(int c, int q, int m) {
	clothes::init(c, q);
	Km = m;
}

/// Функция, предназначенная для стоимости одежды \f${cost * quantity}\f$
		/// \param cost стоимость
		/// \param quantity количество
		/// \param Km коэффициент мастерства
		/// <returns> Стоимость одежды </returns>
double Clothes_ratio::Cost_clothes() {// перегрузка метода 
	return cost * quantity * Km;
}

/// \brief Основной класс: Ателье
/// 
/// Этот класс имеет поля: название ателье, три объекта вспомогательного класса, стоимость затрат.
class atelier
{
public:
	double total_cost();
	void init(clothes a, clothes b, clothes c, double z1);
	void set_name(string n);
	string get_name();
protected:
	string name; //Наименование ателье
	double z;	 //Стоимость затрат
	clothes p1; // Одежда 1
	clothes p2; // Одежда 2
	clothes p3; // Одежда 3
};

/// Метод для получения наименования ателье
		/// <returns> name </returns>
string atelier::get_name() {
	return name;
}
/// Метод для установки наименования ателье
		/// \param[in] name Наименование
void atelier::set_name(string n) {
	name = n;
}
/// Метод для инициализации полей класс
		/// \param[in] p1 Одежда 1
		/// \param[in] p2 Одежда 2
		/// \param[in] p3 Одежда 3
		/// \param[in] z Стоимость затрат
void atelier::init(clothes a, clothes b, clothes c, double z1)
{
	p1 = a;
	p2 = b;
	p3 = c;
	z = z1;
}

/// Метод для подсчета суммарной стоимости одежды
double atelier::total_cost()
{
	///Пример использования картинок в документации:
///\image html pol.jpg
///
	return p1.Cost_clothes() + p2.Cost_clothes() + p3.Cost_clothes() - z;
}


int main()
{
	setlocale(LC_ALL, "rus");
	double c1, c2, c3, z;
	int a1, a2, a3;
	Clothes_ratio p1, p2, p3;
	atelier mg;
	string name;
	p1.init(10, 5,3);
	p2.init(15, 9,2);
	p3.init(3, 20,3);

	cout << "\nВещь 1\n";
	p1.Display();
	cout << "\nВещь 2\n";
	p2.Display();
	cout << "\nВещь 3\n";
	p3.Display();

	cout << "\nВведите расходы на дополнительные аксессуары:\t\t";
	cin >> z;
	cout << "Введите название магазина: ";
	cin >> name;

	mg.set_name(name);
	mg.init(p1, p2, p3, z);
	cout << "\nМагазин - " << mg.get_name() << "\nОбщая стоимость магазина:\t\t" << mg.total_cost() << endl;
	system("pause>>void");
}