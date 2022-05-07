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
        private List<string> _usedCities = new List<string>();
        public List<string> UsedCities { get { return _usedCities; } }
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

        public bool IsUsed(string city)
        {
            for (int i = 0; i < _usedCities.Count; i++)
            {
                if (city == _usedCities[i])
                    return true;
            }
            return false;
        }

        public bool compareFirstLetterAndLast(string city)
        {
            if (_usedCities.Count != 0)
            {
                string _lastCity = _usedCities[_usedCities.Count - 1];
                char _lastLetter;
                if (_lastCity[_lastCity.Length - 1].Equals('ь') || _lastCity[_lastCity.Length - 1].Equals("ъ") || _lastCity[_lastCity.Length - 1].Equals("ы"))
                    _lastLetter = _lastCity[_lastCity.Length - 2];
                else
                    _lastLetter = _lastCity[_lastCity.Length - 1];
                if (city[0] != _lastLetter)
                    return false;
            }
            _usedCities.Add(city);
            return true;
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
