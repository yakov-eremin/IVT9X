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
            return dt.Year - date.Year;
        }
    }
}
