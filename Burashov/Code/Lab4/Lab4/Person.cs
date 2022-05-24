using System;

namespace Lab4
{
    public class Person
    {
        public string name { get; set; }
        public DateTime date { get; set; }

        public Person(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
        }

        public int GetAge(DateTime dt)
        {
            if (dt.Year <= date.Year)
                return 0;
            return (date.DayOfYear > dt.DayOfYear) ? (dt.Year - date.Year - 1) : (dt.Year - date.Year);
        }
    }
}
