using System;
using System.Collections.Generic;
using System.IO;


namespace TestProject
{
     ///
    /// @brief Интерфейс для создания инструментов.
    /// 
    ///Создает общие методы для инструментов, которые можно применить на роботе.
    ///
    interface IInstrument
    {
        /// <summary>
        /// Метод обновления инструмента.
        /// </summary>
        void Renew();
        /// <summary>
        /// Метод использования инструмента.
        /// </summary>
        /// <param name="com">Команда использования.</param>
        void Use(int com);
    }
    ///
    /// @brief Интерфейс для создания реакторов.
    /// 
    /// Создает общие методы для реаторов, которые можно применить на роботе.
    ///
    interface IEnergyGenerator
    {
        /// <summary>
        /// Метод, вырабатывающий энергию.
        /// </summary>
        void Generate();
        /// <summary>
        /// Метод загрузки топлива.
        /// </summary>
        void Load_fuel();
    }

    ///
    /// @brief Класс для описания лопаты
    /// 
    /// Реализует интерфейс инструмента, делая из него лопату
    /// 
    class Shovel : IInstrument
    {
        /// прочность инструмента
        private int durability;

        public Shovel()
        {
            this.Renew();
        }

        /// <summary>
        /// Метод, обновляющий прочность интсрумента
        /// </summary>
        public void Renew()
        {
            this.durability = 10;
        }
        /// <summary>
        /// Метод, реализующий задачу лопаты, в зависимости от команды, и тратит соответсвующую прочность
        /// </summary>
        /// <param name="com">Номер комады для использования.</param>
        public void Use(int com)
        {
            if (com == 0)
            {
                this.durability--;
            }
            if (com == 1)
            {
                this.durability -= 2;
            }
        }

    }
    ///
    /// @brief Класс для описания ножниц
    /// 
    /// Реализует интерфейс инструмента, делая из него ножницы
    /// 
    class Scissors : IInstrument
    {
        ///Прочность инструмента.
        private int durability;
        /// <summary>
        /// Конструктор для ножниц.
        /// </summary>
        public Scissors()
        {
            this.Renew();
        }
        /// <summary>
        /// Метод, обновляющий прочность.
        /// </summary>
        public void Renew()
        {
            this.durability = 5;
        }
        /// <summary>
        /// Метод, реализующий дествие, согласно команде.
        /// </summary>
        /// <param name="com">Номер комады для использования.</param>
        public void Use(int com)
        {
            if (com == 0)
            {
                this.durability--;
            }
        }
    }
    ///
    /// @brief Класс реализующий ядерный генератор.
    /// 
    /// Реализует интерфейс генератора. Даннынй генератор более мощный, но менее долговечный.
    /// 
    class NuclearReactor :IEnergyGenerator
    {
        ///Поле значения текущей энергии.
        private int energy;
        ///Поле значения текущего топлива.
        private int fuel;
        /// <summary>
        /// Метод вырабатывающий энергую, тратя топливо.
        /// </summary>
        public void Generate()
        {
            energy += 2;
            fuel--;
        }
        /// <summary>
        /// Метод, обновляющий запас топлива.
        /// </summary>
        public void Load_fuel()
        {
            fuel = 15;
        }
    }
    ///
    /// @brief Класс реализующий солнечный генератор.
    /// 
    /// Реализует интерфейс генератора. Даннынй генератор более долговечный, но менее мощный
    /// 
    class SolarReactor : IEnergyGenerator
    {
        ///Поле значения текущей энергии.
        private int energy;
        ///Поле значения текущего топлива.
        private int fuel;
        /// <summary>
        /// Метод вырабатывающий энергую, тратя топливо.
        /// </summary>
        public void Generate()
        {
            energy ++;
            fuel--;
        }
        /// <summary>
        /// Метод, обновляющий запас топлива.
        /// </summary>
        public void Load_fuel()
        {
            fuel = 20;
        }   
    }

    ///
    /// @brief Класс для реализации робота.
    /// 
    /// Описывает робота, включающий в себя два объекта, реализующих интерфейс инструментов, и один объект, реализующий генератор. 
    /// Так же имеет поле для комманды.
    /// Робот имеет следующую структуру: 
    /// @image{inline} html abstraction.png "Описание"
    /// 
    class Robot
    {
        /// Текущая команда.
        protected int command;
        ///Инструмет левой руки.
        protected IInstrument left_instrument;
        ///Инструмет правой руки.
        protected IInstrument right_instrument;
        ///Тип генератрора
        protected IEnergyGenerator energy_generator;
        /// <summary>
        /// Метод, устанавливающий левый инстумент для робота.
        /// </summary>
        /// <param name="instrument">Объект, реализующий интерфейс инструмента.</param>
        public void install_instrument_left(IInstrument instrument)
        {
            left_instrument = instrument;
        }
        /// <summary>
        /// Метод, устанавливающий правый инстумент для робота.
        /// </summary>
        /// <param name="instrument">Объект, реализующий интерфейс инструмента.</param>
        public void install_instrument_right(IInstrument instrument)
        {
            right_instrument = instrument;
        }
        /// <summary>
        /// Метод, устанавливающий генератор для робота.
        /// </summary>
        /// <param name="energyGenerator">Объект, реализующий интерфейс генератора.</param>
        public void install_generator(IEnergyGenerator energyGenerator)
        {
           energy_generator = energyGenerator;
        }
        /// <summary>
        /// Метод для инициализации всех полей объекта
        /// </summary>
        /// <param name="left_instrument">Объект, реализующий интерфейс инструмента, левой руки.</param>
        /// <param name="right_instrument">Объект, реализующий интерфейс инструмента, правой руки.</param>
        /// <param name="energyGenerator">Объект, реализующий интерфейс генератора.</param>
        public void Init(IInstrument left_instrument, IInstrument right_instrument, IEnergyGenerator energyGenerator)
        {
            command = 0;
            this.left_instrument = left_instrument;
            this.right_instrument = right_instrument;
            this.energy_generator = energyGenerator;
        }
        /// <summary>
        /// Метод, реализующий задачу, соотвествующую заданной команде.
        /// </summary>
        public void Use()
        {
            this.left_instrument.Use(command);
            this.right_instrument.Use(command);
            this.energy_generator.Generate();
        }
        /// <summary>
        /// Метод, обновляющий состояния состовных объектов.
        /// </summary>
        public void Reload()
        {
            this.left_instrument.Renew();
            this.right_instrument.Renew();
            this.energy_generator.Load_fuel();
        }
        /// <summary>
        /// Метод, переключающий команду на следующую.
        /// </summary>
        public void NextCom()
        {
            command++;
        }
        /// <summary>
        /// Метод, переключающий команду на предыдущую.
        /// </summary>
        public void PrevCom()
        {
            command--;
        }

    }
    /// @brief Класс для реализации робота-садовода
    /// 
    /// Дочерний класс для описания робота-строителя. 
    /// Имеет метод для вычисления нужного количества семян на площадь, чтобы они не конфликтовали.
    class GardenR : Robot
    {
        /// <summary>
        /// Метод для инициализации полей объекта
        /// </summary>
        /// <param name="left_instrument">Инструмент левой руки</param>
        /// <param name="right_instrument">Инструмент правой руки</param>
        /// <param name="energyGenerator">Используемый генератор</param>
        public void Init(IInstrument left_instrument, IInstrument right_instrument, IEnergyGenerator energyGenerator) 
        {
            base.Init(left_instrument, right_instrument, energyGenerator);
        }
        /// <summary>
        /// Вычисление количества семян на данную площадь.
        /// Формула вычислений \f$\frac{x*y}{4}\f$
        /// </summary>
        /// <param name="lenght">Длинна участка</param>
        /// <param name="width">Ширина участка</param>
        /// <returns>Максимальное количество семян</returns>
        public int AmountOfSeeds(double lenght, double width)
        {
            return (int)(lenght * width / 4);
        }
    }
    ///
    /// @brief Класс для реализации робота-строителя
    /// 
    /// Дочерний класс для описания робота-строителя. 
    /// Имеет метод для вычисления нужного объема цемента.
    /// 
    class BuildR : Robot
    {
        /// <summary>
        /// Метод для инициализации полей объекта
        /// </summary>
        /// <param name="left_instrument">Инструмент левой руки</param>
        /// <param name="right_instrument">Инструмент правой руки</param>
        /// <param name="energyGenerator">Используемый генератор</param>
        public void Init(IInstrument left_instrument, IInstrument right_instrument, IEnergyGenerator energyGenerator) 
        {
            base.Init(left_instrument, right_instrument, energyGenerator);
        }
        /// <summary>
        /// Вычисление необходимого количества цемента на данный объем.
        /// Формула вычислений \f$x*y*z*1.1\f$
        /// </summary>
        /// <param name="lenght">Длинна участка</param>
        /// <param name="width">Ширина участка</param>
        /// <param name="height">Высота участка</param>
        /// <returns></returns>
        public double AmountOfCement(double lenght, double width, double height)
        {
            return 1.1 * lenght * width * height;
        }
    }
    ///
    /// @brief Класс-затычка для создания более большого графа-наследования
    /// 
    
    class UberR :  GardenR
    {

    }

    ///
    /// @brief Класс для создания роботов
    /// 
    /// Имеет метод для удобного создания робота в других частях программы
    ///
    class Factory
    {
        /// <summary>
        /// Метод для создания робота с заданной конфигурацией.
        /// </summary>
        /// <param name="conf_1">Параметр, отвечающий за инструмент в левой руке: 1 - Лопата; 2 - Ножницы</param>
        /// <param name="conf_2">Параметр, отвечающий за инструмент в правой руке: 1 - Лопата; 2 - Ножницы</param>
        /// <param name="conf_3">Параметр, отвечающий за тип установленного генератора: 1 - Ядерный; 2 - Солнечный</param>
        /// <returns>Объект класса Robot с заданными параметрами</returns>
        public Robot Build(int conf_1, int conf_2, int conf_3)
        {
            Robot robot = new Robot();
            if (conf_1 == 1)
            {
                Shovel shovel = new Shovel();
                robot.install_instrument_left(shovel);
            }
            else
            {
                Scissors scissors = new Scissors();
                robot.install_instrument_left(scissors);
            }
            if (conf_2 == 1)
            {
                Shovel shovel = new Shovel();
                robot.install_instrument_right(shovel);
            }
            else
            {
                Scissors scissors = new Scissors();
                robot.install_instrument_right(scissors);
            }
            if (conf_3 == 1)
            {
                NuclearReactor reactor = new NuclearReactor();
                robot.install_generator(reactor);
            }
            else
            {
                SolarReactor reactor = new SolarReactor();
                robot.install_generator(reactor);
            }
            return robot;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            Robot robot1 = factory.Build(1, 2, 1);
            Robot robot2 = factory.Build(2, 2, 2);
            
        }
    }
}
