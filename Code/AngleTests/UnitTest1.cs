using NUnit.Framework;
using lab2_3_csharp;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AngleTests
{
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            angle a = new angle();
            a.init(15, 40, 12);
            int first = a.Numbersec();
            Assert.AreEqual(56412, first);
        }
    }

    public class UnitTest2
    {
        [Test]
        public void Test2()
        {
            angle a = new angle();
            a.init(40, 31, 18);
            int first = a.Numbersec();
            Assert.AreEqual(145878, first);
        }
    }

    public class UnitTest3
    {
        [Test]
        public void Test3()
        {
            angle a = new angle();
            a.init(56, 32, 1);
            int first = a.Numbersec();
            Assert.AreEqual(203521, first);
        }
    }

    public class UnitTest4
    {
        [Test]
        public void Test4()
        {
            angle a1 = new angle();
            a1.init(40, 31, 18);
            angle a2 = new angle();
            a2.init(56, 32, 1);
            angle a3 = new angle();
            a3 = a1.add(a1, a2);
            angle comparison = new angle();
            comparison.init(97, 3, 19);
            double grad = comparison.gradround();
            Assert.AreEqual(grad, a3.gradround());
        }
    }

    public class UnitTest5
    {
        [Test]
        public void Test5()
        {
            angle a1 = new angle();
            a1.init(5, 31, 72);
            angle a2 = new angle();
            a2.init(12, 45, 31);
            angle a3 = new angle();
            a3 = a1.add(a1, a2);
            angle comparison = new angle();
            comparison.init(18, 16, 31);
            double grad = comparison.gradround();
            Assert.AreEqual(grad, a3.gradround());
        }
    }

    public class UnitTest6
    {
        [Test]
        public void Test6()
        {
            angle a1 = new angle();
            a1.init(4, 66, 8);
            angle a2 = new angle();
            a2.init(34, 7, 36);
            angle a3 = new angle();
            a3 = a1.add(a1, a2);
            angle comparison = new angle();
            comparison.init(39, 13, 44);
            double grad = comparison.gradround();
            Assert.AreEqual(grad, a3.gradround());
        }
    }

    public class UnitTest7
    {
        [Test]
        public void Test7()
        {
            angle min = new angle();
            min.init(63, 11, 34);
            min.MinType();
            Assert.AreEqual(11, min.MinType());
        }
    }

    public class UnitTest8
    {
        [Test]
        public void Test8()
        {
            angle min = new angle();
            min.init(18, 8, 3);
            min.MinType();
            Assert.AreEqual(3, min.MinType());
        }
    }
    public class UnitTest9
    {
        [Test]
        public void Test9()
        {
            angle min = new angle();
            min.init(75, 4, 12);
            min.MinType();
            Assert.AreEqual(4, min.MinType());
        }
    }

    public class UnitTest10
    {
        [Test]
        public void Test10()
        {
            angle min = new angle();
            min.init(1, 24, 108);
            min.MinType();
            Assert.AreEqual(1, min.MinType());
        }
    }

}