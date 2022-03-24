using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle_lib1;
using TravelAgency1;
using WorkMassiv;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Perimetr13point12Returned()
        {
            double extecded = 13.12;

            Triangle tr = new Triangle(4, 2, 1, 6, 0, 2);
            double actual = tr.Perimetr();

            Assert.AreEqual(extecded, actual);

        }
        
        [TestMethod]
        public void SummaTwoTriangle()
        {
            Triangle tr1 = new Triangle(7, 0, 1, 5, 5, 3);
            Triangle tr2 = new Triangle(3, 1, 0, 5, 7, 4);

            Triangle symma = new Triangle();
            
            symma = tr1.Add(tr1, tr2);

            int[] Mass_Extexded = { 10, 1, 1, 10, 12, 7 };

            int[] MassActual = { symma.X1, symma.Y1, symma.X2, symma.Y2, symma.X3, symma.Y3 };


            CollectionAssert.AreEqual(Mass_Extexded, MassActual);
        }

        [TestMethod]
        public void PerimentParallTriangle25Returned()
        {
            int extecded = 25;

            Parall_Triangle ptr = new Parall_Triangle(4, 2, 1, 6, 0, 2, 12);

            double actual = ptr.Perimetr();

            Assert.AreEqual(extecded, actual);
        }  

        [TestMethod]
        public void ExpAmount25000Returned()
        {
            int extecded = 25000;

            Tour tr1 = new Tour(250, 100);

            double actual = tr1.Exp_amount();

            Assert.AreEqual(extecded, actual);
        }

        [TestMethod]
        public void ExpAmountPermit9639Returned()
        {
            int extecded = 9639;

            Permit pr1 = new Permit(270, 51, 1);

            double actual = pr1.Exp_amount();

            Assert.AreEqual(extecded, actual);
        }

        [TestMethod]
        public void SumnMN_NoHot25460Returned()
        {
            int extecded = 25460;

            TravelAgency ta = new TravelAgency("Путешествие рядом", 620, 70, 120, 90, 0, 40, 75);

            double actual = ta.Summ_mn();

            Assert.AreEqual(extecded, actual);
        }

        [TestMethod]
        public void PoismaksReturned()
        {
            Massive ms = new Massive(5);
            ms.Mas[0] = 10;
            ms.Mas[1] = 1;
            ms.Mas[2] = 18;
            ms.Mas[3] = 5;
            ms.Mas[4] = 7;

            int extecded = 18;
            int actual = ms.Poismaks();

            Assert.AreEqual(extecded, actual);
        }

        [TestMethod]
        public void PoisminReturned()
        {
            Massive ms = new Massive(5);
            ms.Mas[0] = 10;
            ms.Mas[1] = 1;
            ms.Mas[2] = 18;
            ms.Mas[3] = 5;
            ms.Mas[4] = 7;

            int extecded = 1;
            int acteal = ms.Poiskmin();

            Assert.AreEqual(extecded, acteal);
        }

        [TestMethod]
        public void PoiskMinSredPolReturned()
        {
            Massive ms = new Massive(5);
            ms.Mas[0] = -10;
            ms.Mas[1] = -1;
            ms.Mas[2] = 18;
            ms.Mas[3] = 2;
            ms.Mas[4] = -7;


            int extended = 2;
            int actual = ms.PoiskMinSredPol();

            Assert.AreEqual(extended, actual);

        }

        [TestMethod]
        public void PoiskMaxSredOtr()
        {
            Massive ms = new Massive(5);
            ms.Mas[0] = -10;
            ms.Mas[1] = -1;
            ms.Mas[2] = 18;
            ms.Mas[3] = 2;
            ms.Mas[4] = -7;

            int extended = -1;
            int actual = ms.PoiskMaxSredOtr();

            Assert.AreEqual(extended, actual);
        }
    }
}