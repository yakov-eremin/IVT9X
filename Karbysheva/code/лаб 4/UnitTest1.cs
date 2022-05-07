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
            string _city = "Астрахань".ToLower();
            bool _expected = true;
            bool _actual = _cities.compareWithAllCities(_city);
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void IsUsedTest()
        {
            string _city = "Астрахань".ToLower();
            bool _expected = false;
            bool _actual = _cities.IsUsed(_city);
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void compareFirstLetterAndLastTest()
        {
            _cities.UsedCities.Add("Астрахань");
            string _city = "Новгород".ToLower();
            bool _expected = true;
            bool _actual = _cities.compareFirstLetterAndLast(_city);
            Assert.AreEqual(_expected, _actual);
        }
        [TestMethod]
        public void compareFirstLetterAndLastAddTest()
        {
            _cities.UsedCities.Add("Новгород");
            string _city = "Добрый".ToLower();
            bool _expected = true;
            _cities.compareFirstLetterAndLast(_city);
            bool _actual = _cities.UsedCities.Contains(_city);
            Assert.AreEqual(_expected, _actual);
        }
        [TestMethod]
        public void compareFirstLetterAndLastAddFirstTest()
        {
            string _city = "Добрый".ToLower();
            bool _expected = true;
            _cities.compareFirstLetterAndLast(_city);
            bool _actual = _cities.UsedCities.Contains(_city);
            Assert.AreEqual(_expected, _actual);
        }
    }

}
