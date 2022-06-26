namespace ConsoleApp7
{
    public class AnotherJob: Job
    {
        private int type;

        public AnotherJob():base()
        {
            type = 0;
        }

        public AnotherJob(double salary_, double k_, int type_):base(salary_, k_)
        {
            type = type_;
        }

        public double getFullSalary()
        {
            if (type == 1)
                return base.getFullSalary() * 2;
            else
                return base.getFullSalary();
        }
    }
}
