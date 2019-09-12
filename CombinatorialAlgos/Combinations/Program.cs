using System;

class Program
{
    static void Main(string[] args)
    {
        string[] inputArr = Console.ReadLine().Split(' ');
        int k = int.Parse(Console.ReadLine());

        // Comb.CombsNoReps(inputArr, k);
        Comb.CombsWReps(inputArr, k);
    }

    static class Comb
    {
        static string[] input = new string[0];
        static int k = 0;
        public static void CombsNoReps(string[] inputArr,int limit)
        {
            SetInternals(inputArr, limit);
            string[] arr = new string[k];
            CombsNoRepsRec(arr, 0, 0);

            ResetInternals();
        }

        private static void SetInternals(string[] inputArr, int limit)
        {
            input = inputArr;
            k = limit;
        }

        private static void CombsNoRepsRec(string[] arr, int start, int index)
        {
            if(index >= k)
            {
                Print(arr);
                return;
            }

            for (int i = start; i < input.Length; i++)
            {
                arr[index] = input[i];
                CombsNoRepsRec(arr, i + 1, index + 1);
            }
        }

        public static void CombsWReps(string[] inputArr, int limit)
        {
            SetInternals(inputArr, limit);

            string[] arr = new string[k];
            CombsWRepsRec(arr, 0, 0);

            ResetInternals();
        }

        private static void CombsWRepsRec(string[] arr, int index, int start)
        {
            if(index >= k)
            {
                Print(arr);
                return;
            }

            for (int i = start; i < input.Length; i++)
            {
                arr[index] = input[i];
                CombsWRepsRec(arr, index + 1, i);
            }
        }

        static void ResetInternals()
        {
            input = new string[0];
            k = 0;
        }

        static void Print(string[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}

