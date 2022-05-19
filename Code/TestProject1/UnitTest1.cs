using NUnit.Framework;
using ereminlab2;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int c;
            Pryam calc = new Pryam();
            c = calc.calculate(2, 3);
            Assert.AreEqual(5, c);
        }

        [Test]
        public void Test2()
        {
            Pryam a1 = new Pryam();
            a1.init(0, 10, 10, 0);
            Pryam a2 = new Pryam();
            a2.init(0, 20, 20, 0);
            Pryam a3 = new Pryam();
            a3 = a1.add(a1, a2);
            Pryam a4 = new Pryam();
            a4.init(0, 30, 30, 0);
            double ploh = a4.plohad();
            Assert.AreEqual(ploh, a3.plohad());
        }

        [Test]
        public void Test3()
        {
            int c;
            Pryam calc = new Pryam();
            c = calc.calculate(5, 5);
            Assert.AreEqual(10, c);
        }

        [Test]
        public void Test4()
        {
            Pryam a1 = new Pryam();
            a1.init(0, 20, 20, 0);
            Pryam a2 = new Pryam();
            a2.init(0, 20, 20, 0);
            Pryam a3 = new Pryam();
            a3 = a1.add(a1, a2);
            Pryam a4 = new Pryam();
            a4.init(0, 40, 40, 0);
            double ploh = a4.plohad();
            Assert.AreEqual(ploh, a3.plohad());
        }

        [Test]
        public void Test5()
        {
            int c;
            Pryam calc = new Pryam();
            c = calc.calculate(10, 10);
            Assert.AreEqual(20, c);
        }

        [Test]
        public void Test6()
        {
            int c;
            Pryam calc = new Pryam();
            c = calc.div(10, 10);
            Assert.AreEqual(1, c);
        }

        [Test]
        public void Test7()
        {
            int c;
            Pryam calc = new Pryam();
            c = calc.div(20, 10);
            Assert.AreEqual(2, c);
        }

        [Test]
        public void Test8()
        {
            int c;
            Pryam calc = new Pryam();
            c = calc.div(30, 10);
            Assert.AreEqual(3, c);
        }

        [Test]
        public void Test9()
        {
            Pryam a1 = new Pryam();
            a1.init(0, 20, 20, 0);
            Pryam a2 = new Pryam();
            a2.init(0, 30, 30, 0);
            Pryam a3 = new Pryam();
            a3 = a1.add(a1, a2);
            Pryam a4 = new Pryam();
            a4.init(0, 50, 50, 0);
            double ploh = a4.plohad();
            Assert.AreEqual(ploh, a3.plohad());
        }

        [Test]
        public void Test10()
        {
            Pryam a1 = new Pryam();
            a1.init(0, 20, 20, 0);
            Pryam a2 = new Pryam();
            a2.init(0, 40, 40, 0);
            Pryam a3 = new Pryam();
            a3 = a1.add(a1, a2);
            Pryam a4 = new Pryam();
            a4.init(0, 60, 60, 0);
            double ploh = a4.plohad();
            Assert.AreEqual(ploh, a3.plohad());
        }
    }
}