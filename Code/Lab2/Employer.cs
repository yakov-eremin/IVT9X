using System.IO;

namespace ConsoleApp7
{
    public class Employer
    {
        private Job job1;
        private AnotherJob job2;
        private int empl1;
        private int empl2;

        public Employer()
        {
            job1 = new Job();
            job2 = new AnotherJob();
        }

        public Employer(Job j1, AnotherJob j2, int e1, int e2)
        {
            job1 = j1;
            job2 = j2;
            empl1 = e1;
            empl2 = e2;
        }

        public double FullPay()
        {
            return job1.getFullSalary()*empl1 + job2.getFullSalary()*empl2;
        }

        public void LoadFromFile(string p)
        {
            if (File.Exists(p))
            {
                StreamReader r = new StreamReader(p);

                double s1 = double.Parse(r.ReadLine());
                double k1 = double.Parse(r.ReadLine());
                double s2 = double.Parse(r.ReadLine());
                double k2 = double.Parse(r.ReadLine());
                int t = int.Parse(r.ReadLine());

                job1 = new Job(s1, k1);
                job2 = new AnotherJob(s2, k2, t);
                empl1 = int.Parse(r.ReadLine());
                empl2 = int.Parse(r.ReadLine());
                r.Close();
            }
            else 
                throw new FileNotFoundException("файл не найден!");
        }
    }
}
