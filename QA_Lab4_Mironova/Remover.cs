using System;
using System.IO;

namespace lr4
{
    public class Remover
    {
        public static int CountFiles(string path, string mask)
        {
            FileInfo[] p = new DirectoryInfo(path).GetFiles(mask, SearchOption.AllDirectories);
            return p.Length;
        }

        public static void DeleteFiles(string path, string mask)
        {
            FileInfo[] p = new DirectoryInfo(path).GetFiles(mask, SearchOption.AllDirectories);
            foreach (FileInfo file in p)
            {
                File.Delete(file.FullName);
            }
        }

        public static int CountFilesByDate(string path, DateTime from, DateTime to)
        {
            int count = 0;
            FileInfo[] p = new DirectoryInfo(path).GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in p)
            {
                if (file.CreationTime >= from && file.CreationTime <= to)
                    count++;
            }
            return count;
        }

        public static void DeleteFilesByDate(string path, DateTime from, DateTime to)
        {
            FileInfo[] p = new DirectoryInfo(path).GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in p)
            {
                if (file.CreationTime >= from && file.CreationTime <= to)
                    file.Delete();
            }
        }
    }
}
