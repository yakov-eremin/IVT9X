// ConsoleApplication2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <math.h>
#pragma warning(disable:4996)
using namespace std;
class Van {
private:
    int seat = 0;
    float price = 0.0;

public:
    void Init(int seat, float price) {
        this->seat = seat;
        this->price = price;
    }
    void Display() {
        cout << "Количество мест: " << seat << endl;
        cout << "Цена: " << price << endl;
    }
    void Read() {
        cout << "Введите количество мест:" << endl;
        scanf_s("%d", &seat);
        cout << "Введите цену за место:" << endl;
        scanf_s("%f", &price);
    }
    float Income() {
        return (seat * price);
    }
};
class Train {
private:
    char name[30];
    Van van1;
    Van van2;
    Van van3;
    int fill1 = 0;
    int fill2 = 0;
    int fill3 = 0;
public:
    void Display() {
        cout << "Название: " << name << endl;
        this->van1.Display();
        this->van2.Display();
        this->van3.Display();
        cout << "Заполненость вагонов: " << fill1 << ' ' << fill2 << ' ' << fill3 << ' ' << endl;
    }
    void Init(const char* v, int s1, float p1, int s2, float p2, int s3, float p3, int f1, int f2, int f3) {
        strcpy(name, v);
        van1.Init(s1, p1);
        van2.Init(s2, p2);
        van3.Init(s3, p3);
        this->fill1 = f1;
        this->fill2 = f2;
        this->fill3 = f3;

    }
    void Read() {
        cout << "Введите название поезда:" << endl;
        scanf_s("%s", &name);
        van1.Read();
        van2.Read();
        van3.Read();
        cout << "Заполненость первого вагона:" << endl;
        scanf_s("%d", &fill1);
        cout << "Заполненость второго вагона:" << endl;
        scanf_s("%d", &fill2);
        cout << "Заполненость третьего вагона:" << endl;
        scanf_s("%d", &fill3);
    }
    float Income() {
        return (this->van1.Income() * (this->fill1 / 100) + this->van2.Income() * (this->fill2 / 100) + this->van3.Income() * (this->fill3 / 100));
    }

    Van Worst() {
        float inc1 = this->van1.Income();
        float inc2 = this->van2.Income();
        float inc3 = this->van3.Income();
        if (inc1 > inc2) {
            if (inc1 > inc3) {
                return this->van1;
            }
            else {
                return this->van3;
            }
        }
        else {
            if (inc2 > inc3) {
                return this->van2;
            }
            else {
                return this->van3;
            }
        }
    }
};
int main()
{
    setlocale(LC_ALL, "Russian");
    Van van1;
    van1.Display();
    Train train;
    train.Init("Поезд", 19, 110, 30, 20, 45, 34, 67, 89, 98);
    train.Display();
    float inc = train.Income();
    cout << "Доход от маршрута: " << inc << endl;
    Van worst;
    worst = train.Worst();
    worst.Display();
}


// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
