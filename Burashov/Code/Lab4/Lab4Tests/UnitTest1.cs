using Lab4;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab4Tests
{
    [TestClass]
    public class Lab4Tests
    {
        [TestInitialize]
        public void PersonInitTest()
        {
            Person p = new Person("Ivan Ivanov", new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void PersonGetAgeTest()
        {
            Person p = new Person("Ivan Ivanov", new DateTime(2000, 1, 1));
            Assert.AreEqual(20, p.GetAge(new DateTime(2020, 2, 2)));
        }

        [TestMethod]
        public void PersonGetAgeTest2()
        {
            Person p = new Person("Petr Petrov", new DateTime(1990, 4, 4));
            Assert.AreEqual(29, p.GetAge(new DateTime(2020, 1, 2)));
        }

        [TestMethod]
        public void PersonGetAgeTest3()
        {
            Person p = new Person("Fedor Fedorov", new DateTime(1995, 7, 7));
            Assert.AreEqual(0, p.GetAge(new DateTime(1990, 1, 1)));
        }

        [TestMethod]
        public void PersonToStringTest()
        {
            Person p = new Person("Test", new DateTime(1990, 1, 1));
            Assert.AreEqual("Test (01.01.1990)", p.ToString());
        }

        [TestMethod]
        public void CalendarLoadTest()
        {
            Calendar.Load("calendar.data");
        }
    }
}
