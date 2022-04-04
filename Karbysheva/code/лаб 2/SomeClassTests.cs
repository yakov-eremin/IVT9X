using Microsoft.VisualStudio.TestTools.UnitTesting;
using KProject;
using System.Collections.Generic;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class SomeClassTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
    [TestClass]
    public class WorkWithNumbersTests
    {
        [TestMethod]
        public void SingOfNumberPositive()
        {
            string number = "1";
            int actual = SomeClass.SingOfNumber(number);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void SingOfNumberNegative()
        {
            string number = "-1";
            int actual = SomeClass.SingOfNumber(number);
            Assert.AreEqual(-1, actual);
        }
        [TestMethod]
        public void SingOfNumberZero()
        {
            string number = "0";
            int actual = SomeClass.SingOfNumber(number);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SingOfNumberNullExcepstion()
        {
            string str = "";
            int actual = SomeClass.SingOfNumber(str);
        }
    }
    [TestClass]
    public class WorkWithSringsTests
    {
        [TestMethod]
        public void EachLetterCount()
        {
            string str = "asdfs";
            List<char> list = new List<char>();
            List<int> listint = new List<int>();

            List<int> expected = new List<int> { 1, 2, 1, 1 };

            SomeClass.EachLetter(str,list,listint);
            for (int i = 0; i < listint.Count; i++)
            {
                Assert.AreEqual(expected[i],listint[i]);
            }            
        }
    }
    [TestClass]
    public class WorkWithArrayTests
    {
        [TestMethod]
        public void BubbleSortPositiveDouble()
        {
            double[] array = { 3.5, 4.7, 3.1, 9.5, 6.2, 0.6 };
            int mode = 1;
            SomeClass.BubbleSort(array, mode);
            double[] expected = { 0.6, 3.1, 3.5, 4.7, 6.2, 9.5};
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }
        [TestMethod]
        public void BubbleSortNegativeDouble()
        {
            double[] array = { -3.5, -4.7, -3.1, -9.5, -6.2, -0.6 };
            int mode = -1;
            SomeClass.BubbleSort(array, mode);
            double[] expected = { -0.6, -3.1, -3.5, -4.7, -6.2, -9.5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }

        [TestMethod]
        public void BubbleSortMixDouble()
        {
            double[] array = { 3.5, -4.7, 3.1, -9.5, -6.2, 0.6 };
            int mode = -1;
            SomeClass.BubbleSort(array, mode);
            double[] expected = { 3.5, 3.1, 0.6, -4.7, -6.2, -9.5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }
    }
    [TestClass]
    public class WorkWithClassTests
    {

        SomeClass someObject;

        [TestInitialize]
        public void Initialize()
        {
            someObject = new SomeClass(7.4, 2);
        }
         
        [TestMethod]
        public void BestWithPositive()
        {
            SomeClass some = new SomeClass(9.1, 1);
            SomeClass actual = some.Best(someObject);
            Assert.AreEqual(some,actual);
        }
        
    }
}
