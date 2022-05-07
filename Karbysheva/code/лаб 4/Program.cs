using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    public class Cities
    {
        private string[] _allCities;
        public string[] AllCities { get => _allCities; }
        public void readCitiesfromfile(string path)
        {
            string _string = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (true)
                {
                    string _temp = sr.ReadLine();
                    if (_temp == null) break;
                    _string += _temp;
                }
            }
            _allCities = _string.Split(' ');
        }

        public bool compareWithAllCities(string city)
        {
            for (int i = 0; i < _allCities.Length; i++)
            {
                if (city == _allCities[i])
                    return true;
            }
            return false;
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string _city = Console.ReadLine();
            
        }
    }
}
