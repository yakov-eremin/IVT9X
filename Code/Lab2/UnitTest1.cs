using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System.Collections.Generic;
using System;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
    [TestClass]
    public class WorkWithNumbers
    {
        [TestMethod]
        public void PositiveNumber()
        {
            string number = "1";
            int actual = Class.Number(number);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            string number = "-1";
            int actual = Class.Number(number);
            Assert.AreEqual(-1, actual);
        }
        [TestMethod]
        public void Zero()
        {
            string number = "0";
            int actual = Class.Number(number);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullExcepstion()
        {
            string str = "";
            int actual = Class.Number(str);
        }
    }
    [TestClass]
    public class WorkWithSrings
    {
        [TestMethod]
        public void EachLetterCount()
        {
            string str = "asdfs";
            List<char> list = new List<char>();
            List<int> listint = new List<int>();

            List<int> expected = new List<int> { 1, 2, 1, 1 };

            Class.EachLetter(str, list, listint);
            for (int i = 0; i < listint.Count; i++)
            {
                Assert.AreEqual(expected[i], listint[i]);
            }
        }
    }
    [TestClass]
    public class WorkWithArray
    {
        [TestMethod]
        public void PositiveSortingDouble()
        {
            double[] array = { 3.5, 4.7, 3.1, 9.5, 6.2, 0.6 };
            int mode = 1;
            Class.Sort(array, mode);
            double[] expected = { 0.6, 3.1, 3.5, 4.7, 6.2, 9.5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }
        [TestMethod]
        public void NegativeSortingDouble()
        {
            double[] array = { -3.5, -4.7, -3.1, -9.5, -6.2, -0.6 };
            int mode = -1;
            Class.Sort(array, mode);
            double[] expected = { -0.6, -3.1, -3.5, -4.7, -6.2, -9.5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }

        [TestMethod]
        public void MixSortingDouble()
        {
            double[] array = { 3.5, -4.7, 3.1, -9.5, -6.2, 0.6 };
            int mode = -1;
            Class.Sort(array, mode);
            double[] expected = { 3.5, 3.1, 0.6, -4.7, -6.2, -9.5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }
    }
    [TestClass]
    public class WorkWithClass
    {

        Class someObject;

        [TestInitialize]
        public void Initialize()
        {
            someObject = new Class(7.4, 2);
        }

        [TestMethod]
        public void BestPositive()
        {
            Class some = new Class(9.1, 1);
            Class actual = some.Best(someObject);
            Assert.AreEqual(some, actual);
        }

    }
}
