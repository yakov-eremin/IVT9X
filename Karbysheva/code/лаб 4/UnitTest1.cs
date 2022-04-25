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
        public void setCityTest()
        {

            string _expected = "Астрахань";
            _cities.setCity();
            string _actual = _cities.AllCities;
            Assert.AreEqual(_expected, _actual);
        }
    }

}
