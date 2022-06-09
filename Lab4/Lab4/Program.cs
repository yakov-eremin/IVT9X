using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab4
{
    public class CheckString
    {
        StreamReader sr = new StreamReader(@"D:\therapist.txt");
        string line;
        public string back(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    if (years >= 12)
                        return text[1];
                    if (years < 12)
                        return text[0];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    return text[2];
                }
                else if (command == "3")
                {
                    string[] text = line.Split('*');
                    if (years > 14)
                        return text[4];
                    if (years < 14)
                        return text[3];
                }
            }
            return "0";
        }

        public string head(int years, string command)
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (command == "1")
                {
                    string[] text = line.Split('*');
                    if (years >= 12)
                        return text[6];
                    if (years < 12)
                        return text[5];
                }
                else if (command == "2")
                {
                    string[] text = line.Split('*');
                    if (years >= 12)
                        return text[8];
                    if (years < 12)
                        return text[7];
                }
            }
            return "0";
        }

        public string leg()
        {
            string a = "qwerty132";
            return a;
        }

        public string arm()
        {
            string a = "qwerty321";
            return a;
        }

        public string belly()
        {
            string a = "qwerty123";
            return a;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
        }
    }


}
