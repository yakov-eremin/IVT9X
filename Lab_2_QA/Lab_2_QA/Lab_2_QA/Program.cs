namespace lab_2_QA
{
    public class FunctionClass // В данном классе будут описаны математические функции, которые будут позже тестироваться 
    {
        public static int SumOfSquares(int n) // Метод, вычисляющий сумму всех квадратов чисел в промежутке [0;n]
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += (i * i);
            }
            return sum;
        }

        public static int Factorial(int n) // Метод, вычисляющий факториал числа
        {
            if (n == 0) return 1;
            else return n*Factorial(n-1);
        }

        public static int Fibonachi(int n) // Метод, вычисляющий n-ный член последовательности Фибоначчи
        {
            if (n == 0 || n == 1)
                return n;
            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
    }

    public class ArrayClass // В данном классе будут описаны стандартные методы для работы с массивом, которые будут позже тестироваться
    {
        // Работать будем с int массивами
        public static int ArrayMaxElement(int[] array) // Метод, который возвращает максимальный элемент в массиве
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        public static int ArrayMinElement(int[] array) // Метод, который возвращает минимальный элемент в массиве
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }

        public static double ArrayAverage(int[] array) // Метод, который возвращает среднее значение 
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return (sum / array.Length);
        }

        public static int ArraySum(int[] array) // Метод, который возвращает сумму всех элементов массива
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static int ArrayMultiplication(int[] array) // Метод, который возвращает произведение всех элементов
        {
            int multiplication = 1;
            for (int i = 0; i < array.Length; i++)
            {
                multiplication *= array[i];
            }
            return multiplication;
        }
    }

    public class StringClass // В данном классе будут описаны методы для работы со строками, которые будут позже тестироваться
    {
        public static string SumString(string str1, string str2) // Метод, возвращает строку - сумму двух других строк
        {
            string str3;
            str3 = str1 + " " + str2;
            return str3;
        }

        public static int FindSymbol(string str1, char symbol) // Метод, возвращает количество повторений символа в строке
        {
            int num = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == symbol)
                    num++;
            }
            return num;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
