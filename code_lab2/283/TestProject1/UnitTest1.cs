using NUnit.Framework;
using ConsoleApp1;
namespace TestProject1
{
    public class Tests
    {
       

        [Test]
        public void get_cost_test()
        {
            int cost = 30;
            int expected = 30;


            film f1 = new film();
            f1.Init(cost, 3);
            double actual = f1.GetCost();

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void summ_test()
        {
            int cost = 30;
            int gain = 30;
            int expected = 60;


            film f1 = new film();
            f1.Init(cost, gain);
            double actual = f1.summ(f1);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void init_test()
        {
            int cost = 30;
            int gain = 30;

            film f1 = new film();
            f1.Init(cost, gain);
            Assert.IsNotNull(f1);

        }

        [Test]
        public void test_okup_f()
        {
            int cost = 5;
            int gain = 100;
            int expected = 2000;

            film f1 = new film();
            f1.Init(cost, gain);
            float actual = f1.okup_f();

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void test_okup_f1_div_null()
        {
            
            float expected = 0;

            film f1 = new film();
            f1.Init(0, 0);
            float actual = f1.okup_f();

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void set_name_not_null()
        {
            

            film f1 = new film();
            f1.SetName("123");
            f1.GetName();

            Assert.IsNotNull(f1);

        }

        [Test]
        public void set_name_test()
        {

            string expected = "Название фильма 123";

            film f1 = new film();
            f1.SetName("123");
            string actual = f1.GetName();

            Assert.AreEqual(expected, actual);

        }


        [Test]
        public void init_mass_test()
        {
            int[] theArray = { 1, 3, 5};
            int[] actualArry = new int[10];

            film f1 = new film();
            f1.Init_mass(theArray);


            for (int i = 0; i < 3; i++)
            {
                actualArry[i] = f1.get_mass(i);
            }

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(theArray[i], actualArry[i]);
            }
        }


        [Test]
        public void raiting_calculation_test()
        {
            int[] theArray = { 1, 3, 5 };
            float expected = 3;

            film f1 = new film();
            f1.Init_mass(theArray);
            float actual = f1.raiting_calculation();

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void name_rate_test()
        {
            int[] theArray = { 1, 3, 5 };
            string expected = "Низкий";

            film f1 = new film();
            f1.Init_mass(theArray);
            f1.raiting_calculation();
            string actual = f1.name_rate();

            Assert.AreEqual(expected, actual);

        }

    }
}