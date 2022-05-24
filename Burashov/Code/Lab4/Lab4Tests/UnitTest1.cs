﻿using Lab4;
using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void CalendarSaveTest()
        {
            Calendar.Save("calendar.data");
        }

        [TestMethod]
        public void CalendarAddTest()
        {
            Person p = new Person("Ivan Ivanov", new DateTime(1998, 4, 7));
            Calendar.Add(p);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalendarAddTest2()
        {
            Person p = null;
            Calendar.Add(p);
        }

        [TestMethod]
        public void CalendarRemoveTest()
        {
            Calendar.Add(new Person("Test", new DateTime(1999, 1, 1)));
            Calendar.Remove(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalendarRemoveTest2()
        {
            Calendar.Remove(-1);
        }

        [TestMethod]
        public void CalendarGetMethodTest()
        {
            List<Person> list = Calendar.GetCalendar();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void CalendarCheckMethodTest()
        {
            Person p1 = new Person("Test 1", new DateTime(2000, 1, 1));
            Person p2 = new Person("Test 2", new DateTime(2000, 2, 3));
            Person p3 = new Person("Test 3", new DateTime(2000, 1, 1));

            Calendar.Add(p1);
            Calendar.Add(p2);
            Calendar.Add(p3);

            List<Person> expected = Calendar.Check(new DateTime(2000, 1, 1));
            List<Person> result = new List<Person>() { p1, p3 };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
