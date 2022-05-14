using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpolab3
{
    /// \brief Вспомогательный класс Спектакль
    /// 
    /// Класс имеет поля: количество, цена и время. В классе описаны методы инициализации, извлечения времени, установки времени, ввода данных, вывод данных, а также подсчёт общей суммы от продажи билетов
    /// 
    class Spectacle
    {
        private int count;   // количество проданных билетов
        private float price; // цена одного билета
        private string time; // время проведения спектакля

        /// Метод для инициализации полей класса
        /// \param[in] c Количество проданных билетов
        /// \param[in] p Цена одного билета
        /// \param[in] tm Время проведения спектакля
        public void init(int c, float p, string tm)
        {
            time = tm;
            count = c;
            price = p;
        }

        /// Метод для получения времени спектакля
        /// <returns>Время спектакля</returns>
        public string gettime()
        {
            return time;
        }

        /// Метод для задания времени спектакля
        /// \param tm Время спектакля
        public void settime(string tm)
        {
            time = tm;
        }

        /// Метод предназначен для взаимодействия с пользователем, позволяет ввести цену билета и количество проданных билетов
        public void read()
        {
            string s;
            Console.Write("Введите цену билета:");
            s = Console.ReadLine();
            price = Convert.ToInt32(s);
            Console.Write("Введите количество проданных билетов:");
            s = Console.ReadLine();
            count = Convert.ToInt32(s);
        }

        /// Вывод на экран информации о спектакле
        public void display()
        {
            Console.WriteLine("Цена билета  Количество проданных билетов");
            Console.WriteLine(price + "           " + count);
        }

        /// Функция, предназначенная для подсчёта цены всех проданных билетов  \f$ {price*count}\f$
        /// \param price Цена одного билета
        /// \param count Количество проданных билетов
        /// <returns>Сумма цен всех проданных билетов </returns>
        public float sum()
        {
            float k;
            k = price * count;
            return k;
        }
    }

    /// \brief Основной класс: Спектакль за день
    /// 
    /// Этот класс имеет поля: название спектакля, три объекта вспомогательного класса spectacle (утро, день и вечер), процент заполнения в разное время суток (утро, день и вечер)
    class Spectacle_per_day
    {
        private String name; // Название спектакля
        private int proc_zap_utro; // Процент заполнения зала
        private int proc_zap_day;  // Процент заполнения зала
        private int proc_zap_vecher;// Процент заполнения зала
        private Spectacle utro = new Spectacle(); // Объект класса Спектакль
        private Spectacle day = new Spectacle();  // Объект класса Спектакль
        private Spectacle vecher = new Spectacle();// Объект класса Спектакль

        /// Метод позволяет получить название спектакля
        /// <returns>Название спектакля</returns>
        public string getname()
        {
            return name;
        }

       /// Метод для изменения название спектакля
       /// \param[in] s Новое название
        public void putname(string s)
        {
            name = s;
        }

        /// Метод для инициализации спектакля за день
        /// \param[in] v Название спектакля
        /// \param[in] p1 Цена билета на утреннюю постановку
        /// \param[in] c1 Количество проданных билетов на утро
        /// \param[in] pzu Процент заполнения зала утром
        /// \param[in] p2 Цена билета на дневную постановку
        /// \param[in] c2 Количество проданных билетов на день
        /// \param[in] pzd Процент заполнения зала днём
        /// \param[in] p3 Цена билета на вечернюю постановку
        /// \param[in] c3 Количество проданных билетов на вечер
        /// \param[in] pzv Процент заполнения зала вечером
        public void init(String v, float p1, int c1, int pzu, float p2, int c2, int pzd, float p3, int c3, int pzv)
        {
            name = v;

            //для работы заданий 1-4
            utro.init(c1, p1, "Утро");
            proc_zap_utro = pzu;
            day.init(c2, p2, "День");
            proc_zap_day = pzd;
            vecher.init(c3, p3, "Вечер");
            proc_zap_vecher = pzv;

        }

        /// Вывод на экран информации о спектаклях за день

        public void display()
        {
            Console.WriteLine(name);

            //для работы заданий 1-4
            Console.WriteLine("УТРО");
            utro.display();
            Console.WriteLine("ДЕНЬ");
            day.display();
            Console.WriteLine("ВЕЧЕР");
            vecher.display();

        }


        /// Метод предназначен для взаимодействия с пользователем, позволяет ввести информацию о спектаклях

        public void read()
        {
            Console.Write("Введите название спектакля:");
            name = Console.ReadLine();

            //для работы заданий 1-4
            Console.WriteLine("Введите информацию о спектаклях за день:");
            Console.WriteLine("УТРО");
            utro.settime("Утро");
            utro.read();
            Console.Write("Процент заполнения: ");
            proc_zap_utro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ДЕНЬ");
            day.settime("День");
            day.read();
            Console.Write("Процент заполнения: ");
            proc_zap_day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ВЕЧЕР");
            vecher.settime("Вечер");
            vecher.read();
            Console.Write("Процент заполнения: ");
            proc_zap_vecher = Convert.ToInt32(Console.ReadLine());

        }

        /// Функция для подсчёта дохода
        /// \param  u, d, v Складываемые числа
        /// \param[out] s Сумма за утро, день и вечер
        /// <returns>Сумма денег от продажи билетов за весь день</returns>
        public float daysale()
        {
            float u, d, v, s;
            u = (utro.sum() * proc_zap_utro) / 100;
            d = (day.sum() * proc_zap_day) / 100;
            v = (vecher.sum() * proc_zap_vecher) / 100;
            s = u + d + v;
            return s;
        }

        /// Функция находит спектакль, который принёс наименьший доход
        /// <returns>Спектакль с наименьшим доходом</returns>
        public Spectacle minsale()
        {
            float sumu, sumd, sumv;
            sumu = utro.sum();
            sumd = day.sum();
            sumv = vecher.sum();
            if (sumu <= sumd & sumu <= sumv)
                return utro;
            if (sumd <= sumu & sumd <= sumv)
                return day;
            else
                return vecher;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Spectacle_per_day a = new Spectacle_per_day();
            Spectacle_per_day b = new Spectacle_per_day();
            Spectacle aa = new Spectacle();
            string str;
            //для работы заданий 1-4
            a.init("Первый", 50, 70, 80, 150, 100, 40, 250, 80, 90);
            a.display();
            float su;
            su = a.daysale();
            Console.WriteLine("сумма денег от продажи билетов за день: " + su);
            aa = a.minsale();
            str = aa.gettime();
            Console.WriteLine("спектакль с минимальной ожидаемой суммы продаж: " + str);
            b.read();
            b.display();
            su = b.daysale();
            Console.WriteLine("сумма денег от продажи билетов за день: " + su);
            aa = b.minsale();
            str = aa.gettime();
            Console.WriteLine("спектакль с минимальной ожидаемой суммы продаж: " + str);
            Console.ReadKey();

        }
    }
}
