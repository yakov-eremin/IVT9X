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
    }
}
