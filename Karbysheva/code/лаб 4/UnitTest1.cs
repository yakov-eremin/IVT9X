using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp8;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        Cities _cities;
        [TestInitialize]
        public void CitiesCreateTest()
        {
            _cities = new Cities();
            Assert.IsNotNull(_cities);
        }

        [TestMethod]
        public void readCitiesTest()
        {

            string[] _expected = new string[] {"Астрахань", "Новгород", "Барнаул"};
            _cities.readCitiesfromfile("C:\\Users\\Katya\\Desktop\\Cities.txt");
            string[] _actual = _cities.AllCities;
            for (int i = 0; i < _expected.Length; i++)
            {
                Assert.AreEqual(_expected[i], _actual[i]);
            }
        }
    }

}
