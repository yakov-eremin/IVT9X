using _1;
using NUnit.Framework;

namespace NUnitTest
{
    public class UnitTest1
    {


        [Test]
        public void pom()
        {
            Pom[] pp = new Pom[3];
            for (int i = 0; i < 3; i++)
            {
                pp[i] = new Pom();
            }
            double z11 = 1;
            double expected = -1;

            Agen p = new Agen();
            p.init(pp, z11);
            double actual = p.totcost();
            System.Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void pom2()
        {
            Pom[] pp = new Pom[5];
            for (int i = 0; i < 5; i++)
            {
                pp[i] = new Pom();
            }
            double z11 = 17;
            double expected = -17;

            Agen p = new Agen();
            p.init(pp, z11);
            double actual = p.totcost();
            System.Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void calculate()
        {
            int x = 10;
            int y = 20;
            int expected = 30;

            Agen c = new Agen();
            int actual = c.Sum(x, y);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void multiplication()
        {
            int x = 100;
            int y = 50;
            int c = 5;
            int expected = 10;

            Agen R = new Agen();
            int actual = R.multiplication(x, y, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void calculate2()
        {
            int x = 1440;
            int y = 2860;
            int expected = 4300;

            Agen c = new Agen();
            int actual = c.Sum(x, y);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void nameAgen_not_null()
        {
            Agen s = new Agen();
            s.SetName("Minasato");
            s.GetName();

            Assert.IsNotNull(s);
        }

        [Test]
        public void nameAgen_set()
        {
            string expected = "Агенство: Chivchan";

            Agen s = new Agen();
            s.SetName("Chivchan");
            string actual = s.GetName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void nameAgen_set2()
        {
            string expected = "Агенство: Kawabata";

            Agen s = new Agen();
            s.SetName("Kawabata");
            string actual = s.GetName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void rental_price()
        {
            int days = 14;
            int price = 2500;
            int deposit = 5000;
            int human = 3;
            int expected = 50000;

            Agen c = new Agen();
            int actual = c.rental_price(days, price, deposit, human);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void payback_test()
        {
            float expected = 0;

            Agen f1 = new Agen();
            f1.Init(0, 0);
            float actual = f1.payback();

            Assert.AreEqual(expected, actual);
        }

    }
}