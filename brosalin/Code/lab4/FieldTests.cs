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

        public void init_Test()
        {
            MyField field1 = new MyField();
            char [,] expected = new char[10,10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    expected[i, j] = 'o';
            char[,] actual = new char[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    actual[i, j] = field1.get(i, j);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(expected[i,j], actual[i,j]);
        }

        public void Display_Test()
        {

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
    }
}
