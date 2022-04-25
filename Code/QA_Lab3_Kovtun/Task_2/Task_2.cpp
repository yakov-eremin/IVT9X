#include <iostream>

using namespace std;

	/*!
	  \brief Основной класс
	 
	  Содержит метод, вычисляющий ожидаеммую суммы продаж
	 */

class Tour {
public:
	void Init(double price, int sale);
	void Display();
	int GetPlan();
	double GetPrice();

	double Exp_amount();
protected:
	double price;
	int plan_sale;
};

	/*!
	 
	   \brief Метод инициализации переменных
	 
	   \param [in] pr Цена тура
	   \param [in] sale Планируемое кол-во билетов
	 
	 */

void Tour::Init(double pr, int sale) {
	price = pr;
	plan_sale = sale;
}

	/*!
	 
	  \brief Метод, который выводит в консоль данных из класса
	 
	 */

void Tour::Display() {
	cout << "Стоимость билета - " << price << "\nПланируемое кол-во билетов - " << plan_sale << endl;
}

	/*!
	 
	  \brief Метод вычисление ожидаеммой суммы от продаж билетов
	 
	   \param [out] Suma Ожидаеммая сумма от продаж билетов
	 
	 */

double Tour::Exp_amount() {
	double summ = price * plan_sale;

	return floor(summ * 100) / 100;
}

	/*!
	 
	  \brief Метод, возвращающий планируемое кол-во билетов
	 
	 */

int Tour::GetPlan() {
	return plan_sale;
}

	/*!
	 
	  \brief Метод, возвращающий цену тура
	 
	 */

double Tour::GetPrice() {
	return price;
}

	/*!
	  \brief Дочерний класс от Tour
	 
	  Содержит дополнительное поле, обозначающие с "горящей" ли путевкой тур
	 
      @image{inline} html hotTours.jpg "Горящая путевка"
	 
	 */

class Permit : public Tour {
private:
	int hot_per;
public:
	void Init(double price, int sale, int hotPer);
	void Display();
	int Get_hot_per();
	double Exp_amount();

};

	/*!
	 
	  \brief Метод, возвращающий 1 или 0, что говорит горящая ли путевка
	 
	 */

int Permit::Get_hot_per() {
	return hot_per;
}

	/*!
	
	  \brief Метод инициализации переменных
	
	  \param [in] pr Цена тура
	  \param [in] sale Планируемое кол-во билетов
	  \param [in] hotper С "горящей" ли путевуой тур 1 или 0
	 
	*/

void Permit::Init(double price, int sale, int hotPer) {
	Tour::Init(price, sale);

	hot_per = hotPer;
}

	/*!
	 
	  \brief Метод, который выводит в консоль данных из класса
	 
	 */

void Permit::Display() {
	Tour::Display();

	if (hot_per == 1) {
		cout << "Тур с горящей путевкой" << endl;
	}
	else {
		cout << "Тур с обычной путевкой" << endl;
	}
}

	/*!
	 
	   \brief Метод вычисление ожидаеммой суммы от продаж билетов
	 
	   \param [out] summ Ожидаеммая сумма от продаж билетов
	 
	   Если тур горячий, то будет скидка 30% и вычисляется по след. формуле
	 
	   \f$Summ = (Price - Price * 0.3) * PlanSale\f$
	 
	   т.е. мы стоимость уменьшили на 30 %
	 
	 */


double Permit::Exp_amount() {
	double summ = price * plan_sale;

	if (hot_per == 1) {
		summ -= summ * 0.3;
	}


	return floor(summ * 100) / 100;
}

	/*!
	  \brief Вспомогательный класс
	 
	  Содержит метод, вычисляющий сумму денег от продаж всех туров
	 
	 */

class Travel_agency {
	
public:
	void Init(char* n, double pr1, int sale1, double pr2, int sale2, int hotPer, int RealProcFirst1, int RealProcSecond2);
	void Display();

	double Summ_mn();
private:
	char Name[30];
	Tour Tour;
	Permit FtPermit;

	int RealProcFirst, RealProcSecond;
};

	/*!
	 
	   \brief Метод инициализации переменных
	 
	   \param [in] n Название тур. агентсва
	   \param [in] pr1 Цена первого тура
	   \param [in] sale1 Планируемое кол-во билетов первого тура
	   \param [in] pr2 Цена второго тура
	   \param [in] sale2 Планируемое кол-во билетов второго тура
	   \param [in] hotPer С "горящей" ли путевкой тур
	   \param [in] RealProcFirst1 Реальных процент продаж первого тура
	   \param [in] RealProcSecond2 Реальных процент продаж второго тура
	 
	 */

void Travel_agency::Init(char* n, double pr1, int sale1, double pr2, int sale2,int hotPer, int RealProcFirst1, int RealProcSecond2) {
	strcpy_s(Name, n);

	Tour.Init(pr1, sale1);
	FtPermit.Init(pr2, sale2, hotPer);

	RealProcFirst = RealProcFirst1;
	RealProcSecond = RealProcSecond2;

}

	/*!
	 
	  \brief Метод, который выводит в консоль данных из класса
	 
	 */

void Travel_agency::Display() {
	cout << "Название турагенства: " << Name << "\nПервый тур:\n";
	Tour.Display();

	cout << "Реальный процент продаж первого тура: " << RealProcFirst << "\nВторой тур : \n";
	FtPermit.Display();

	cout << "Реальный процент продаж второго тура: " << RealProcSecond << endl;

}

	/*!
	 
	  \brief Метод, вычисляющий сумму денег от продаж всех туров
	 
	   \param [out] summ Сумма денег от продаж всех туров
	 
	 */

double Travel_agency::Summ_mn() {
	double summ = 0;
	double k;

	k = (RealProcFirst * Tour.GetPlan()) / 100;
	summ += k * Tour.GetPrice();

	k = (RealProcSecond * FtPermit.GetPlan()) / 100;

	if (FtPermit.Get_hot_per() == 1) {
		summ += k * (FtPermit.GetPrice() - (FtPermit.GetPrice() * 0.3));
	}
	else {
		summ += k * FtPermit.GetPrice();
	}

	return floor(summ * 100) / 100;
}

int main() {
	setlocale(LC_ALL, "Russian");

	Tour a;
	a.Init(120, 20);
	a.Display();
	
	cout << endl;


	Permit pr;
	pr.Init(250, 18, 1);
	pr.Display();
	double exp = pr.Exp_amount();
	cout << "Ожидаемая сумма от продажи путевки - " << exp << endl;

	cout << endl;

	Travel_agency Tr1;
	Tr1.Init((char*)"Путешествие рядом", 520, 120, 410, 70, 1, 60, 20);
	Tr1.Display();

	double SummAll = Tr1.Summ_mn();
	cout << "Сумма денег от прдажи всех туров: " << SummAll << " рублей\n" << endl;


	Travel_agency Tr2;
	Tr2.Init((char*)"Путешествие быстро", 120, 29, 270, 30, 0, 40, 50);
	Tr2.Display();

	SummAll = Tr2.Summ_mn();
	cout << "Сумма денег от прдажи всех туров: " << SummAll << " рублей\n" << endl;
}