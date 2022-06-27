using System;
using System.Linq;

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

        public int[,] GetBoard()
        {
            return board;
        }

        public void FillBoard()
        {
            int[] rndArray = new int[size * size];
            for (int i = 0; i < rndArray.Length; i++)
                rndArray[i] = i;

            Random rnd = new Random();
            rndArray = rndArray.OrderBy(x => rnd.Next()).ToArray();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = rndArray[size * i + j];
        }

        public bool CheckBoard()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if ((i != size - 1 && j != size - 1) && board[i, j] != size * i + j + 1) return false;
            return true;
        }

        public void MoveLeft()
        {
            int position_i = 0;
            int position_j = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == 0)
                    {
                        position_i = i;
                        position_j = j;
                    }
                }
            }

            if (position_j == size - 1)
                return;

            int tmp = board[position_i, position_j];
            board[position_i, position_j] = board[position_i, position_j + 1];
            board[position_i, position_j + 1] = tmp;
            count++;
        }

        public void MoveRight()
        {
            int position_i = 0;
            int position_j = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == 0)
                    {
                        position_i = i;
                        position_j = j;
                    }
                }
            }

            if (position_j == 0)
                return;

            int tmp = board[position_i, position_j];
            board[position_i, position_j] = board[position_i, position_j - 1];
            board[position_i, position_j - 1] = tmp;
            count++;
        }
    }
}
