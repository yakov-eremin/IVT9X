using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgForTest
{
    [TestClass]
    public class MyCalcTests
    {
        [TestMethod]
        public void TestRad()
        {
            int a = 25;
            int expected = 5;
            ProgForTest c = new ProgForTest();
            double actual = c.Rad(a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSq()
        {
            int a = 5;
            int expected = 25;
            ProgForTest c = new ProgForTest();
            double actual = c.Sq(a);

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class MasTests
    {
        [TestMethod]
        public void Test_most_repeated()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 5, 3, 2, 7, 3, 4, 7, 2, 3 };
            int expected = 3;
            Mas m = new Mas();
            int actual = m.most_repeated(a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Sum()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 5, 3, 2, 7, 3, 4, 7, 2, 3 };
            int expected = 57;

            Mas m = new Mas();
            int actual = m.Sum(a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SearchMax_div_2()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int expected = 10;

            Mas m = new Mas();
            int actual = m.SearchMax_div_2(a);

            Assert.AreEqual(expected, actual);

        }
    }

    [TestClass]
    public class UgolTests
    {
        [TestMethod]
        public void Test_round()//тестирование округления угла до градусов
        {
            Ugol a = new Ugol();
            a.Init(10, 29, 40);
            int expected = 11;
            float actual = a.round();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Add()//тестирование сложения углов
        {
            Ugol a = new Ugol();
            Ugol b = new Ugol();
            Ugol c = new Ugol();
            Ugol d = new Ugol();
            a.Init(10, 20, 30);
            b.Init(5, 15, 25);
            d.Init(15, 35, 55);
            c = c.add(a, b);
            float expected = d.getdeg();
            float actual = c.getdeg();
            Assert.AreEqual(expected, actual);

            expected = d.getmin();
            actual = c.getmin();
            Assert.AreEqual(expected, actual);

            expected = d.getsec();
            actual = c.getsec();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]//проверка сложения углов с переполнением градусов и минут (градусы и минуты > 60)
        public void Test_Add_60()
        {
            Ugol a = new Ugol();
            Ugol b = new Ugol();
            Ugol c = new Ugol();
            Ugol d = new Ugol();
            a.Init(10, 40, 20);
            b.Init(5, 55, 47);
            d.Init(16, 36, 7);
            c = c.add(a, b);
            float expected = d.getdeg();
            float actual = c.getdeg();
            Assert.AreEqual(expected, actual);

            expected = d.getmin();
            actual = c.getmin();
            Assert.AreEqual(expected, actual);

            expected = d.getsec();
            actual = c.getsec();
            Assert.AreEqual(expected, actual);
        }
    }


    [TestClass]
    public class StringclassTests
    {
        [TestMethod]
        public void Test_findstr()//тест поиска подстроки в строке
        {
            string a = "The quick brown fox jumps over the lazy dog";
            string b = "fox";
            string expected = "The quick brown [fox] jumps over the lazy dog";
            stringclass m = new stringclass();
            string actual = m.findstr(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_findstr_0()//тест поиска несуществующей подстроки в строке
        {
            string a = "The quick brown fox jumps over the lazy dog";
            string b = "cat";
            string expected = "";
            stringclass m = new stringclass();
            string actual = m.findstr(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
