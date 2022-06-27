using System;

namespace ConsoleApp1
{
    public class TagsGame
    {
        private const int size = 4;
        private int count;
        private int[,] board;

        public TagsGame()
        {
            count = 0;
            board = new int[size, size];
        }

        public void SetBoard(int[,] values)
        {
            if (values.GetLength(0) != values.GetLength(1) || values.GetLength(0) != 4)
                throw new ArgumentException("Неверная размерность массива");
            board = new int[values.GetLength(0), values.GetLength(1)];
            board = values;
        }
    }
}
