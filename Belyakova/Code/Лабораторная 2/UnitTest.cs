using Lab4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using R1;
using System;

namespace TestProject
{
    [TestClass]
    public class MyClassTest
    {
        [TestMethod]
        public void sum_squares_test()
        {
            double expected = 30;
            double actual = MyClass.sum_squares(5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void cube_volume_test()
        {
            double expected = 30;
            double[] mass = new double[] { 2, 7.5, 2 };
            double actual = MyClass.cube_volume(mass);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void cube_exception_test()
        {
            double[] mass = null;
            double actual = MyClass.cube_volume(mass);
        }

        [TestMethod]
        public void swap_double_test()
        {
            object expected = 17.5;
            object a = 9.8;
            object b = 17.5;
            MyClass.swap(ref a, ref b);
            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void swap_int_test()
        {
            object expected = 17;
            object a = 9;
            object b = 17;
            MyClass.swap(ref a, ref b);
            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void swap_string_test()
        {
            object expected = "Hello";
            object a = "Word";
            object b = "Hello";
            MyClass.swap(ref a, ref b);
            Assert.AreEqual(expected, a);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void swap_exception()
        {
            object a = 9;
            object b = "Hello";
            MyClass.swap(ref a, ref b);
        }

        [TestMethod]
        public void over_double_test()
        {
            bool expected = true;
            object a = 17.8;
            object b = 17.5;
            bool actual = MyClass.over(a,b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void over_string_test()
        {
            bool expected = false;
            object a = "Word";
            object b = "Hello";
            bool actual =  MyClass.over(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void over_exception()
        {
            object a = 9;
            object b = "Hello";
            MyClass.over(a, b);
        }
    }

}