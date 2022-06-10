namespace ConsoleApp6
{
    public class Building
    {
        private double Cost;
        private double Square;
        private int Count;

        public Building()
        {
            Cost = 0;
            Square = 0;
            Count = 0;
        }

        public Building(double c, double s, int co)
        {
            Cost = c;
            Square = s;
            Count = co;
        }

        public double AllCost()
        {
            return Cost * Square;
        }

        public double AreaPerPerson()
        {
            if (Count == 0) return 0;
            return Square / Count;
        }
    }
}
