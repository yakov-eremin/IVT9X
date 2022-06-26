namespace ConsoleApp7
{
    public class Job
    {
        protected double salary;
        protected double k;

        public Job()
        {
            salary = 0.0;
            k = 1.0;
        }

        public Job(double salary_, double k_)
        {
            salary = salary_;
            k = k_;
        }

        public double getFullSalary()
        {
            return salary * k;
        }
    }
}
