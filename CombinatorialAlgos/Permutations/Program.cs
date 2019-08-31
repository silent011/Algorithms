using System;

class Program
{
    static void Main(string[] args)
    {
        string[] inputArr = Console.ReadLine().Split(' ');

        // Permutate.Run(0, inputArr);


    }

    static class Permutate
    {
        public static void Run(int index, string[] inputArr)
        {
            if (index >= inputArr.Length)
            {
                Console.WriteLine(string.Join(" ", inputArr));
                return;
            }

            Run(index + 1, inputArr);
            for (int i = index + 1; i < inputArr.Length; i++)
            {
                Swap(index, i, inputArr);
                Run(index + 1, inputArr);
                Swap(i, index, inputArr);
            }
        }

        static void Swap(int i1, int i2, string[] inputArr)
        {
            string temp = inputArr[i1];
            inputArr[i1] = inputArr[i2];
            inputArr[i2] = temp;
        }
    }
}
