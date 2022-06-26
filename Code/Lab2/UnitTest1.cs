using ConsoleApp7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void Job_init()
        {
            Job job = new Job(10000, 1.0);
            Assert.IsNotNull(job);
        }

        [TestMethod]
        public void Job_getSalary()
        {
            Job job = new Job(10000, 1);
            double expected = 10000;
            double result = job.getFullSalary();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Job_getSalary_2()
        {
            Job job = new Job(10000, 1.5);
            double expected = 15000;
            double result = job.getFullSalary();
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class AnotherJobTests
    {
        [TestMethod]
        public void AnotherJob_init()
        {
            AnotherJob job = new AnotherJob(10000, 1.0, 1);
            Assert.IsNotNull(job);
        }

        [TestMethod]
        public void AnotherJob_getSalary()
        {
            AnotherJob job = new AnotherJob(10000, 1.1, 0);
            double expected = 11000;
            double result = job.getFullSalary();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnotherJob_getSalary_2()
        {
            AnotherJob job = new AnotherJob(10000, 1.1, 1);
            double expected = 22000;
            double result = job.getFullSalary();
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class EmployerTest
    {
        [TestMethod]
        public void Employer_init()
        {
            Employer e = new Employer(new Job(), new AnotherJob(), 10, 15);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Employer_null_init()
        {
            Employer e = new Employer(null, null, 0, 0);
            e.FullPay();
        }

        [TestMethod]
        public void Employer_fullPay()
        {
            Employer e = new Employer(new Job(30000, 1), new AnotherJob(50000, 1, 0), 3, 1);
            double expected = 140000;
            double result = e.FullPay();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Employer_load()
        {
            Employer e = new Employer();
            e.LoadFromFile("file.txt");
            double expected = 240000;
            double result = e.FullPay();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Employer_load2()
        {
            Employer e = new Employer();
            e.LoadFromFile("-");
        }
    }
}
