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

    }

    [TestClass]
    public class WarshipsTests
    {
        [TestMethod]
        public void WarshipsCreationTest()
        {
            Warships warship1 = new Warships();
            Assert.IsNotNull(warship1);
        }
    }
}
