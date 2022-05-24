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
    }
}
