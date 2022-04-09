using System;

namespace ConsoleApp4
{
    public static class StringLibrary
    {
        // Поиск самой длинной строки в массиве
        public static string GetMaxLengthString(string[] array)
        {
            if(array != null)
            {
                string max = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length > max.Length) max = array[i];
                }
                return max;
            }
            else throw new ArgumentNullException("Массив строк пуст");
        }

        // Поиск самой короткой строки в массиве
        public static string GetMinLengthString(string[] array)
        {
            if(array != null)
            {
                string min = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length < min.Length) min = array[i];
                }
                return min;
            }
            else throw new ArgumentNullException("Массив строк пуст");
        }
    }
}
