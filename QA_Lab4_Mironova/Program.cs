using System;
using System.IO;

namespace lr4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 0;
            string path = "";
            string mask = "";
            DateTime from = new DateTime();
            DateTime to = new DateTime();
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Удалить файл или каталог");
                Console.WriteLine("2 - Удалить файлы в каталоге по маске");
                Console.WriteLine("3 - Удалить файлы в каталоге за указанный период");
                Console.WriteLine("4 - Выход");
                Console.Write("Ввод > ");
                n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.Write("\nВведите путь к папке или файлу: ");
                    path = Console.ReadLine();
                    if (!Directory.Exists(path) && !File.Exists(path))
                        Console.WriteLine("Некорректный путь!");
                    else
                    {
                        Console.Write("Введите 1 для подтверждения удаления (или другой символ чтобы отменить): ");
                        n = int.Parse(Console.ReadLine());
                        if (n == 1)
                        {
                            if (Directory.Exists(path))
                                Directory.Delete(path, true);
                            else
                                File.Delete(path);
                            Console.WriteLine("Успешно удалено");
                        }
                    }
                }
                else if (n == 2)
                {
                    Console.WriteLine("\nВведите путь к папке с файлами: ");
                    path = Console.ReadLine();
                    if (!Directory.Exists(path))
                        Console.WriteLine("Некорректный путь!");
                    else
                    {
                        Console.Write("Введите маску для файлов: ");
                        mask = Console.ReadLine();
                        Console.Write("Введите 1 для подтверждения удаления (или другой символ чтобы отменить): ");
                        n = int.Parse(Console.ReadLine());
                        if (n == 1)
                        {
                            n = Remover.CountFiles(path, mask);
                            Remover.DeleteFiles(path, mask);
                            Console.WriteLine("Найдено и удалено " + n + " файлов");
                        }
                    }
                }
                else if (n == 3)
                {
                    Console.WriteLine("\nВведите путь к папке с файлами: ");
                    path = Console.ReadLine();
                    if (!Directory.Exists(path))
                        Console.WriteLine("Некорректный путь!");
                    else
                    {
                        Console.Write("Введите начальую дату: ");
                        from = DateTime.Parse(Console.ReadLine());
                        Console.Write("Введите конечную дату: ");
                        to = DateTime.Parse(Console.ReadLine());
                        Console.Write("Введите 1 для подтверждения удаления (или другой символ чтобы отменить): ");
                        n = int.Parse(Console.ReadLine());
                        if (n == 1)
                        {
                            n = Remover.CountFilesByDate(path, from, to);
                            Remover.DeleteFilesByDate(path, from, to);
                            Console.WriteLine("Найдено и удалено " + n + " файлов");
                        }
                    }
                }
                else if (n == 4)
                {
                    break;
                }
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
