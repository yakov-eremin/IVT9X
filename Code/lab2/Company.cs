using System;
using System.IO;

namespace ConsoleApp6
{
    public class Company
    {
        private Building b1;
        private Building b2;
        private Building b3;

        public Company()
        {
            b1 = new Building();
            b2 = new Building();
            b3 = new Building();
        }

        public Company(Building building1, Building building2, Building building3)
        {
            b1 = building1;
            b2 = building2;
            b3 = building3;
        }

        public double AllCost()
        {
            if (b1 == null || b2 == null || b3 == null) throw new NullReferenceException();
            return b1.AllCost() + b2.AllCost() + b3.AllCost();
        }

        public Building GetMax()
        {
            Building max;
            if (b1.AllCost() > b2.AllCost())
                max = b1;
            else
                max = b2;
            if (b3.AllCost() > max.AllCost())
                max = b3;
            return max;
        }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                StreamReader r = new StreamReader(path);
                b1 = new Building(double.Parse(r.ReadLine()), double.Parse(r.ReadLine()), int.Parse(r.ReadLine()));
                b2 = new Building(double.Parse(r.ReadLine()), double.Parse(r.ReadLine()), int.Parse(r.ReadLine()));
                b3 = new Building(double.Parse(r.ReadLine()), double.Parse(r.ReadLine()), int.Parse(r.ReadLine()));
                r.Close();
            }
            else throw new FileNotFoundException("Файл не обнаружен");
        }
    }
}
