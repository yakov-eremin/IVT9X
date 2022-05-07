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
        public void readCitiesTest()
        {
            _cities = new Cities();
            _cities.readCitiesfromfile("C:\\Users\\Katya\\Desktop\\Cities.txt");
            Assert.IsNotNull(_cities);
        }

        [TestMethod]
        public void compareWithAllCitiesTest()
        {
            string _city = "Астрахань";
            bool _expected = true;
            bool _actual = _cities.compareWithAllCities(_city);
            Assert.AreEqual(_expected, _actual);
        }

    }

}
