using System;
using System.IO;
using System.Collections.Generic;

namespace Lab4
{
    public static class Calendar
    {
        private static List<Person> list = new List<Person>();

        public static void Load(string path)
        {
            StreamReader reader = new StreamReader(path);
            list.Clear();

            string[] line;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Split(';');
                list.Add(new Person(line[0], DateTime.Parse(line[1])));
            }
            reader.Close();
        }

        public static void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            for (int i = 0; i < list.Count; i++)
            {
                writer.WriteLine(String.Join(";", list[i].name, list[i].date));
            }
            writer.Close();
        }

        public static void Add(Person person)
        {
            if (person == null) throw new ArgumentNullException("Person is null");
            list.Add(person);
        }

        public static void Remove(int index)
        {
            list.RemoveAt(index);
        }

        public static List<Person> GetCalendar()
        {
            return list;
        }

        public static List<Person> Check(DateTime date)
        {
            return list.FindAll(d => (d.date.Month == date.Month && d.date.Day == date.Day));
        }
    }
}
