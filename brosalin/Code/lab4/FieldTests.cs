using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4;

namespace Field.Tests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void FieldCreation_Test()
        {
            MyField field1 = new MyField();
            Assert.IsNotNull(field1);
        }

        [TestMethod]
        public void init_Test()
        {
            MyField field1 = new MyField();
            char[,] expected = new char[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    expected[i, j] = 'o';
            field1.init();
            char[,] actual = new char[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    actual[i, j] = field1.get(i, j);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }

        [TestMethod]
        public void Display_Test()
        {

        }

        [TestMethod]
        public void Install_Test()
        {
            Warships wr1 = new Warships();
            MyField field1 = new MyField();
            field1.Install_One(wr1, 1, 1);
            char expected = '*';
            char actual;
            actual = field1.get(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRight_Test()
        {
            MyField field1 = new MyField();
            bool expected = true;
            bool actual;
            actual = field1.IsRight_Two(1, 1, 1, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Location_Test()
        {
            MyField field1 = new MyField();
            Warships wr1 = new Warships();
            bool expected = false;
            bool actual;
            field1.init();
            field1.Install_One(wr1, 1, 1);
            actual = field1.Location_One(2, 2);
            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class WarshipsTests
    {
        [TestMethod]
        public void WarshipsCreation_Test()
        {
            Warships warship1 = new Warships();
            Assert.IsNotNull(warship1);
        }

        [TestMethod]
        public void minus_Test()
        {
            Warships wr1 = new Warships();
            int expected;
            expected = 4 - 1;
            int actual;
            wr1.minus_one();
            actual = wr1.get_one();
            Assert.AreEqual(expected, actual);
        }

    }
}
