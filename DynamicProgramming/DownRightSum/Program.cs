using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        long[,] sum = new long[rows, cols];
        List<string> coords = new List<string>();

        ReadInputMatrix();
        Solution();
        Print();

        void Solution()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    long maxPrevCell = long.MinValue;
                    if (col > 0 && sum[row, col - 1] > maxPrevCell)
                        maxPrevCell = sum[row, col - 1];

                    if (row > 0 && sum[row - 1, col] > maxPrevCell)
                        maxPrevCell = sum[row - 1, col];

                    sum[row, col] = matrix[row, col];
                    if (maxPrevCell != long.MinValue)
                        sum[row, col] += maxPrevCell;
                }
            }

            GetPath();
        }

        void ReadInputMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                int[] entry = Console.ReadLine().Split(' ')
                    .Select(int.Parse).ToArray();

                for (int i1 = 0; i1 < cols; i1++)
                {
                    matrix[i, i1] = entry[i1];
                }
            }
        }

        void GetPath()
        {
            long currentCell = sum[rows - 1, cols - 1];
            coords.Add(Stringify(rows - 1, cols - 1));

            int x = cols - 1;
            int y = rows - 1;
            while(true)
            {
                long sumUp = long.MinValue;
                long sumLeft = long.MinValue;
                if (x - 1 >= 0) sumLeft = sum[y, x - 1];
                if (y - 1 >= 0) sumUp = sum[y - 1, x];

                if (sumUp > sumLeft) y--;
                else x--;

                if (x == -1) break;
                coords.Add(Stringify(y, x));
            }

            coords.Reverse();
        }

        string Stringify(int y, int x)
        {
            return $"[{y}, {x}]";
        }

        void Print()
        {
            Console.WriteLine(string.Join(" ", coords));
        }
    }
}

