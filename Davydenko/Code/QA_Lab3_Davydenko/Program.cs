using System;
using System.Collections.Generic;
using System.IO;


namespace TestProject
{
    interface IInstrument
    {
        void Renew();
        void Use(int com);
    }

    interface IEnergyGenerator
    {
        void Generate();
        void Load_fuel();
    }

    class Shovel : IInstrument
    {
        private int durability;

        public Shovel()
        {
            this.Renew();
        }

        public void Renew()
        {
            this.durability = 10;
        }

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

    class Scissors : IInstrument
    {
        private int durability;
        public Scissors()
        {
            this.Renew();
        }
        public void Renew()
        {
            this.durability = 5;
        }
        public void Use(int com)
        {
            if (com == 0)
            {
                this.durability--;
            }
        }
    }

    class NuclearReactor :IEnergyGenerator
    {
        private int energy;
        private int fuel;
        public void Generate()
        {
            energy += 2;
            fuel--;
        }
        public void Load_fuel()
        {
            fuel = 15;
        }
    }

    class SolarReactor : IEnergyGenerator
    {
        private int energy;
        private int fuel;
        public void Generate()
        {
            energy ++;
            fuel--;
        }
        public void Load_fuel()
        {
            fuel = 20;
        }   
    }


    class Robot
    {

        private int command;
        private IInstrument left_instrument;
        private IInstrument right_instrument;
        private IEnergyGenerator energy_generator;

        public void install_instrument_left(IInstrument instrument)
        {
            left_instrument = instrument;
        }
        public void install_instrument_right(IInstrument instrument)
        {
            right_instrument = instrument;
        }
        public void install_generator(IEnergyGenerator energyGenerator)
        {
           energy_generator = energyGenerator;
        }
        public void Init(IInstrument left_instrument, IInstrument right_instrument, IEnergyGenerator energyGenerator)
        {
            command = 0;
            this.left_instrument = left_instrument;
            this.right_instrument = right_instrument;
            this.energy_generator = energyGenerator;
        }

        public void Use()
        {
            this.left_instrument.Use(command);
            this.right_instrument.Use(command);
            this.energy_generator.Generate();
        }
        public void Reload()
        {
            this.left_instrument.Renew();
            this.right_instrument.Renew();
            this.energy_generator.Load_fuel();
        }
        public void NextCom()
        {
            command++;
        }
        public void PrevCom()
        {
            command--;
        }

    }
    
    class GardenR : Robot
    {
        public void Init(IInstrument left_instrument, IInstrument right_instrument, IEnergyGenerator energyGenerator) 
        {
            base.Init(left_instrument, right_instrument, energyGenerator);
        }
        
        public int AmountOfSeeds(double lenght, double width)
        {
            return (int)(lenght * width / 4);
        }
    }

    class BuildR : Robot
    {
        public void Init(IInstrument left_instrument, IInstrument right_instrument, IEnergyGenerator energyGenerator) 
        {
            base.Init(left_instrument, right_instrument, energyGenerator);
        }

        public double AmountOfCement(double lenght, double width, double height)
        {
            return 1.1 * lenght * width * height;
        }
    }

    class Factory
    {
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
