using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];
        bool[,] bMatrix = new bool[N, N];

        MoveKnight();
        Print();

        void MoveKnight()
        {
            int movesCount = 0;
            Pos currentPos = new Pos(0, 0);

            while (true)
            {
                movesCount++;
                matrix[currentPos.Y, currentPos.X] = movesCount;
                bMatrix[currentPos.Y, currentPos.X] = true;

                Pos[] possiblePos = GetPossibleMoves(currentPos);
                if (possiblePos.Length == 0) break; 

                Pos minPos = possiblePos[0];
                int minDegree = GetPossibleMoves(minPos).Length;

                for (int i = 1; i < possiblePos.Length; i++)
                {
                    Pos temp = possiblePos[i];
                    int tempDegree = GetPossibleMoves(temp).Length;

                    if(tempDegree < minDegree)
                    {
                        minDegree = tempDegree;
                        minPos = temp;
                    }
                }

                currentPos = minPos;
            }
        }

        void Print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int i1 = 0; i1 < N; i1++)
                {
                    Console.Write(matrix[i, i1].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        Pos[] GetPossibleMoves(Pos pos)
        {
            int row = pos.Y;
            int col = pos.X;
            List<Pos> result = new List<Pos>();

            if (col + 2 < N && row + 1 < N && !isVisited(col + 2, row + 1))
                result.Add(new Pos(col + 2, row + 1));
            if (col + 2 < N && row - 1 >= 0 && !isVisited(col + 2, row - 1))
                result.Add(new Pos(col + 2, row - 1));
            if (col - 2 >= 0 && row + 1 < N && !isVisited(col - 2, row + 1))
                result.Add(new Pos(col - 2, row + 1));
            if (col - 2 >= 0 && row - 1 >= 0 && !isVisited(col - 2, row - 1))
                result.Add(new Pos(col - 2, row - 1));

            if (row + 2 < N && col + 1 < N && !isVisited(col + 1, row + 2))
                result.Add(new Pos(col + 1, row + 2));
            if (row + 2 < N && col - 1 >= 0 && !isVisited(col - 1, row + 2))
                result.Add(new Pos(col - 1, row + 2));
            if (row - 2 >= 0 && col + 1 < N && !isVisited(col + 1, row - 2))
                result.Add(new Pos(col + 1, row - 2));
            if (row - 2 >= 0 && col - 1 >= 0 && !isVisited(col - 1, row - 2))
                result.Add(new Pos(col - 1, row - 2));

            return result.ToArray();
        }

        bool isVisited(int x, int y)
        {
            return bMatrix[y, x];
        }
    }

    class Pos
    {
        public int X;
        public int Y;

        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"[{X} {Y}]";
        }
    }
}

