#include <iostream>
#include <crtdbg.h>
#define _CRTDBG_MAP_ALLOC


class Base
{
    public:
        virtual void foo() const { std::cout << "A's foo!" << std::endl; }
};

class Derived : public Base
{
    public:
        void foo() { std::cout << "B's foo!" << std::endl; } //переопределение виртуального константного родительского метода
};

int main()
{
    _CrtMemState ms;
	_CrtMemCheckpoint(&ms);

	_CrtSetReportMode(_CRT_WARN, _CRTDBG_MODE_FILE);
	_CrtSetReportFile(_CRT_WARN, _CRTDBG_FILE_STDOUT);

    Base* o1 = new Base();
    Base* o2 = new Derived();
    Derived* o3 = new Derived();

    o1->foo();
    o2->foo();
    o3->foo();


    Base* tmp = nullptr;
    for(int i=0; i<1000; i++){
        tmp = new Base();
        if(i == 666)
            continue;// пропуск уничтожения объекта, возможная утечка памяти
        delete tmp;
    }

    delete o1;
    delete o2;
    delete o3;

    _CrtMemDumpAllObjectsSince(&ms);
}