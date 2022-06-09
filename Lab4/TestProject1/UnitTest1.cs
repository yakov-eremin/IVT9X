using Lab4;
using NUnit.Framework;
using System.IO;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckStringTest()
        {
            CheckString check = new CheckString();
            Assert.IsNotNull(check);
        }

        [Test]
        public void TestStringBack1()
        {
            StreamReader sr = new StreamReader(@"D:\therapist.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.back(20, "1");
            while ((line = sr.ReadLine()) != null)
            {
                string[] text = line.Split('*');
                Assert.AreEqual(text[1], check);
            }
        }


        [Test]
        public void TestStringBack2()
        {
            int years = 0;
            string command = "qw";
            CheckString check = new CheckString();
            string a = "qwerty";
            Assert.AreEqual(a, check.back(years, command));
        }
        [Test]
        public void TestStringHead1()
        {
            CheckString check = new CheckString();
            string a = "qwerty";
            Assert.AreEqual(a, check.head());
        }
        [Test]
        public void TestStringHead2()
        {
            CheckString check = new CheckString();
            string a = "qwerty";
            Assert.AreEqual(a, check.head());
        }
        [Test]
        public void TestStringLeg1()
        {
            CheckString check = new CheckString();
            string a = "qwerty132";
            Assert.AreEqual(a, check.leg());
        }
        [Test]
        public void TestStringLeg2()
        {
            CheckString check = new CheckString();
            string a = "qwerty132";
            Assert.AreEqual(a, check.leg());
        }
        [Test]
        public void TestStringArm1()
        {
            CheckString check = new CheckString();
            string a = "qwerty321";
            Assert.AreEqual(a, check.arm());
        }
        [Test]
        public void TestStringArm2()
        {
            CheckString check = new CheckString();
            string a = "qwerty321";
            Assert.AreEqual(a, check.arm());
        }
        [Test]
        public void TestStringBellyrm1()
        {
            CheckString check = new CheckString();
            string a = "qwerty123";
            Assert.AreEqual(a, check.belly());
        }
        [Test]
        public void TestStringBellyrm2()
        {
            CheckString check = new CheckString();
            string a = "qwerty123";
            Assert.AreEqual(a, check.belly());
        }


    }

}
