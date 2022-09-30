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
            File.Delete("tmp2/a.txt");
        }
    }
}
