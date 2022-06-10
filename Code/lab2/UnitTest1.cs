using ConsoleApp6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class BuildingTests
    {
        [TestMethod]
        public void Building_init()
        {
            Building building = new Building(10, 20, 30);
            Assert.IsNotNull(building);
        }

        [TestMethod]
        public void Building_allcost()
        {
            Building b = new Building(10, 20, 30);
            double result = b.AllCost();
            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public void Building_area()
        {
            Building b = new Building(50, 100, 10);
            double result = b.AreaPerPerson();
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Building_area2()
        {
            Building b = new Building(50, 100, 0);
            double result = b.AreaPerPerson();
            Assert.AreEqual(0, result);
        }
    }

    [TestClass]
    public class CompanyTests
    {
        [TestMethod]
        public void Company_init()
        {
            Company company = new Company(new Building(), new Building(), new Building());
            Assert.IsNotNull(company);
        }

        [TestMethod]
        public void Company_allcost()
        {
            Building b1 = new Building(10, 10, 10);
            Building b2 = new Building(20, 20, 20);
            Building b3 = new Building(30, 30, 30);
            Company company = new Company(b1, b2, b3);
            double result = company.AllCost();
            Assert.AreEqual(1400, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Company_allcost_null()
        {
            Company company = new Company(null, null, null);
            company.AllCost();
        }

        [TestMethod]
        public void Company_getmax()
        {
            Building b1 = new Building(10, 10, 10);
            Building b2 = new Building(20, 20, 20);
            Building b3 = new Building(30, 30, 30);
            Company company = new Company(b1, b2, b3);
            Building max = company.GetMax();

            double result = max.AllCost();

            Assert.AreEqual(900, result);
        }

        [TestMethod]
        public void Company_load()
        {
            Company company = new Company();
            company.Load("test.txt");
            double result = company.AllCost();
            Assert.AreEqual(1400, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Company_load2()
        {
            Company company = new Company();
            company.Load("");
        }
    }
}
