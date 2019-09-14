using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        MySolution solution1 = new MySolution(N);
        solution1.Run();

        //SampleSolution solution2 = new SampleSolution(N);
        //HashSet<string> result2 = solution2.Run();

        //Console.WriteLine($"count1: {result1.Count} count2: {result2.Count}");
    }

    class MySolution
    {
        int N = 0;
        HashSet<string> snakes;
        HashSet<string> stereoisomers;
        HashSet<string> visitedCells = new HashSet<string>();

        public MySolution(int length)
        {
            N = length;
        }

        public void Run()
        {
            snakes = new HashSet<string>();
            stereoisomers = new HashSet<string>();

            string start = "S";
            GenSnakes(start, 0, 0);

            Print();
        }

        void Print()
        {
            Console.WriteLine(string.Join("\n", snakes));
            Console.WriteLine($"Snakes count = {snakes.Count}");
        }

        void GenSnakes(string temp, int row, int col)
        {
            string cell = $"{row} {col}";
            if (visitedCells.Contains(cell)) return;

            if (temp.Length >= N)
            {
                if (!snakes.Contains(temp) && !ContainsRotated(temp))
                {
                    snakes.Add(temp);
                    AddAllRotations(temp);
                }

                return;
            }

            visitedCells.Add(cell);

            //Go Right
            GenSnakes(temp + "R", row, col + 1);
            //Go Down
            GenSnakes(temp + "D", row + 1, col);
            //Go Left
            GenSnakes(temp + "L", row, col - 1);
            //Go Up
            GenSnakes(temp + "U", row - 1, col);

            visitedCells.Remove(cell);

        }

        bool ContainsRotated(string temp)
        {
            return stereoisomers.Contains(temp);
        }

        void AddAllRotations(string str)
        {
            string mirror = str;
            AddAllZRotations(mirror);

            mirror = GenXRotation(str);
            AddAllZRotations(mirror);

        }

        string GenXRotation(string str)
        {
            char[] chArr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'D': chArr[i] = 'U'; break;
                    case 'U': chArr[i] = 'D'; break;
                    default: chArr[i] = str[i]; break;
                }
            }

            return new string(chArr);
        }

        string GenYRotation(string str)
        {
            string result = str;

            char[] chArr = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                switch (chArr[i])
                {
                    case 'R': chArr[i] = 'L'; break;
                    case 'L': chArr[i] = 'R'; break;
                }
            }

            result = string.Join("", chArr);

            return result;
        }

        void AddAllZRotations(string str)
        {
            string rotated = str;
            for (int i = 0; i < 4; i++)
            {
                char[] rotArr = new char[rotated.Length];
                rotArr[0] = 'S';
                for (int i1 = 1; i1 < rotated.Length; i1++)
                {
                    switch (rotated[i1])
                    {
                        case 'R': rotArr[i1] = 'D'; break;
                        case 'D': rotArr[i1] = 'L'; break;
                        case 'L': rotArr[i1] = 'U'; break;
                        case 'U': rotArr[i1] = 'R'; break;
                    }
                }
                rotated = new string(rotArr);
                //Console.WriteLine($"rotated: {rotated}");
                if (!stereoisomers.Contains(rotated)) 
                    stereoisomers.Add(rotated);

                // change perspective relative to the other end
                char[] rotArrReversed = new char[rotated.Length];
                rotArrReversed[0] = 'S';
                for (int i2 = rotated.Length - 1; i2 >= 1; i2--)
                {
                    switch (rotated[i2])
                    {
                        case 'R': rotArrReversed[rotated.Length - i2] = 'L'; break;
                        case 'D': rotArrReversed[rotated.Length - i2] = 'U'; break;
                        case 'L': rotArrReversed[rotated.Length - i2] = 'R'; break;
                        case 'U': rotArrReversed[rotated.Length - i2] = 'D'; break;
                    }
                }

                string reversedRotated = new string(rotArrReversed);
                if (!stereoisomers.Contains(reversedRotated)) stereoisomers.Add(reversedRotated);
            }
        }

    }

    class SampleSolution { 
        int N = 0;
        char[] currentSnake;
        HashSet<string> visitedCells = new HashSet<string>();
        HashSet<string> snakes = new HashSet<string>();
        HashSet<string> allRotations = new HashSet<string>();

        public SampleSolution(int length)
        {
            N = length;
        }

        public HashSet<string> Run()
        {
            currentSnake = new char[N];
            GenSnakes(0, 0, 0, 'S');

            return snakes;
            // Print();
        }

        void Print()
        {
            foreach (string snake in snakes)
            {
                Console.WriteLine(snake);
            }

            Console.WriteLine($"Snakes count = {snakes.Count}");
        }

        void GenSnakes(int index, int row, int col, char direction)
        {
            if (index >= currentSnake.Length)
            {
                RenderSnake();
                return;
            }
            string cell = $"{row} {col}";
            if (visitedCells.Contains(cell))
            {
                return;
            }

            visitedCells.Add(cell);

            currentSnake[index] = direction;

            GenSnakes(index + 1, row, col + 1, 'R');
            GenSnakes(index + 1, row + 1, col, 'D');
            GenSnakes(index + 1, row, col - 1, 'L');
            GenSnakes(index + 1, row - 1, col, 'U');

            visitedCells.Remove(cell);

        }

        void RenderSnake()
        {
            string snake = new string(currentSnake);

            if (allRotations.Contains(snake)) return;

            snakes.Add(snake);

            string flipped = FlipSnake(snake);
            string reversed = ReverseSnake(snake);
            string reverseFlipped = FlipSnake(reversed);

            for (int i = 0; i < 4; i++)
            {
                allRotations.Add(snake);
                snake = Rotate(snake);

                allRotations.Add(flipped);
                flipped = Rotate(flipped);

                allRotations.Add(reversed);
                reversed = Rotate(reversed);

                allRotations.Add(reverseFlipped);
                reverseFlipped = Rotate(reverseFlipped);
            }
        }

        private string ReverseSnake(string snake)
        {
            char[] result = new char[snake.Length];
            result[0] = 'S';
            for (int i = 1; i < snake.Length; i++)
            {
                result[i] = snake[snake.Length - i];
            }

            return new string(result);
        }

        private string Rotate(string snake)
        {
            char[] result = new char[snake.Length];
            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': result[i] = 'D'; break;
                    case 'D': result[i] = 'L'; break;
                    case 'L': result[i] = 'U'; break;
                    case 'U': result[i] = 'R'; break;
                    default: result[i] = snake[i]; break;
                }
            }

            return new string(result);
        }

        private string FlipSnake(string snake)
        {
            char[] result = new char[snake.Length];
            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'D': result[i] = 'U'; break;
                    case 'U': result[i] = 'D'; break;
                    default: result[i] = snake[i];break;
                }
            }

            return new string(result);
        }
    }
}

