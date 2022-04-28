
#include <iostream>

#include <stdio.h>
#include <cstring>
using namespace std;


/*!
    \brief Вспомогательный класс, полезное ископаемое


    Данный класс имеет поля вес и цена чтобы расщитать стоимость полезного ископаемого
*/

class Mineralz_resource
{
    public:

        double  Cost_of_mining();
        void Init(double w, double p);
        void Read();
        void Display();
    private:
        double weight;//вес
        double price;//цена
};

/*!
Инициализация
\param[in] weight  Вес полезного ископаемого 
\param[in] price Цена за грамм
*/
void Mineralz_resource::Init(double weight, double price)
{
    weight = weight;
    price = price;
}
/*!
Находит стоимость
\param weight, price Произведение чисел
цена полезного ископаемого \f${(weight*price)}\f$
\return Произведение чисел
*/
double Mineralz_resource::Cost_of_mining()
{
    return weight * price;
}
/*!
Позволяет пользователю ввести вес и цену

*/
void Mineralz_resource::Read()
{
    cout << "Введите вес и цену за грамм" << endl;
    cin >> weight >> price;
    cout << endl;

}
/*!
Вывод на экран всех полей

*/
void Mineralz_resource::Display()
{
    cout << "Вывод вес и цена за грамм"<<endl;
    printf(" %f, %f", weight, price);
    cout << endl;
}
/*!
    \brief Основной класс, рудник


    Данный класс имеет три полезный ископаемых
*/
class Mine
{
    public:

        Mineralz_resource Best();
        void Init(const char* title, double weight_1, double price_1, double weight_2, double price_2, double weight_3, double price_3, double total_cost);
        void Read();

        void Display();

       double Mine_profitability();


    private:
        char Title[30];  
        Mineralz_resource FirstMineral;   ///< Первое полезное ископаемое
        Mineralz_resource SecondMineral;  ///< Второе полезное ископаемое
        Mineralz_resource ThirdMinera;    ///< Третье полезное ископаемое

        double Total_cost;


};
/*!
Инициализация, из трёх полезных ископаемых состоит рудник, добавлено нащвание и затраты
\param[in] title, Название рудника
\param[in] weight_1, price_1, Вес и цена первого полезного ископаемого
\param[in] weight_2, price_2, Вес и цена второго полезного ископаемого
\param[in] weight_3, price_3, Вес и цена третьего полезного ископаемого
\param[in] Total_cost, затраты
*/
void Mine::Init(const char* title, double weight_1, double price_1, double weight_2, double price_2, double weight_3, double price_3, double total_cost)
{
    strcpy(Title, title);
    FirstMineral.Init(weight_1, price_1);
    SecondMineral.Init(weight_2, price_2);
    ThirdMinera.Init(weight_3, price_3);
    Total_cost = total_cost;
}
/*!
Находит самое ценное полезное ископае из трех
\param a,b Складываемые числа
\return Объект самого ценного ископаемого
*/
Mineralz_resource Mine::Best()
{
    double ris1, ris2, ris3;
    ris1 = FirstMineral.Cost_of_mining();
    ris2 = SecondMineral.Cost_of_mining();
    ris3 = ThirdMinera.Cost_of_mining();

    if (ris1>ris2)
    {
        if(ris1>ris3) return FirstMineral;
        else
        {
            return ThirdMinera;
        }
    }
    else
    {
        if (ris2 > ris3) return SecondMineral;
        else
        {
            return ThirdMinera;
        }
    }
}
/*!
Находит доходность
\param ris1, ris2, ris3 Складываемые числа
\param Total_cost вычитаемое
\return Доходность
![Описание функции](C:/Git/1.PNG)
*/
double Mine::Mine_profitability()
{
    double ris1, ris2, ris3, profitability;
    ris1 = FirstMineral.Cost_of_mining();
    ris2 = SecondMineral.Cost_of_mining();
    ris3 = ThirdMinera.Cost_of_mining();

    profitability = (ris1 + ris2 + ris3) - Total_cost;
    return profitability;
}
/*!
Ввод с клавиатуры всех

*/
void Mine::Read()
{
    cout << "Название"<<endl;
    cin >> Title;
    FirstMineral.Read();
    SecondMineral.Read();
    ThirdMinera.Read();
    cout << "Сумма затрат"<<endl;
    cin >> Total_cost;

}
/*!
Вывод на экран всех полей
*/
void Mine::Display()
{

    cout << "Название ,вес и цена за 3 ископоемых" << endl;
    cout << Title<<endl;
    FirstMineral.Display();
    SecondMineral.Display();
    ThirdMinera.Display();
    cout << "Затраты"<<endl;
    cout << Total_cost<<endl;
    cout << "Доходность рудника" << endl;
    cout << Mine_profitability()<<endl;
}

int main()
{
    setlocale(LC_ALL, "Russian");

    Mine first_mine, second_mine;
    Mineralz_resource first_mineral, second_mineral;
 


    first_mine.Init("Железо",125.9,243,90.9,45,900,100,100);

    first_mine.Display();

    first_mineral = first_mine.Best();
    cout << "Лучший"<<endl;
    first_mineral.Display();

    second_mine.Read();
    second_mineral.Display();
    cout << "Лучший"<<endl;
    second_mineral = second_mine.Best();
    second_mineral.Display();


}
