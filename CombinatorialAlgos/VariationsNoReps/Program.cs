using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] arr = Console.ReadLine().Split(' ');
        int k = int.Parse(Console.ReadLine());

        //Vars.VarsNoReps(arr, k);
        //Vars.VarsWReps(arr, k);

        Vars.VarsWRepsIterative(arr, k);
    }

    static class Vars
    {
        static bool[] used = new bool[0];
        static int k = 0;
        static string[] vars = new string[0];

        public static void VarsNoReps(string[] arr, int limit)
        {
            used = new bool[arr.Length];
            vars = new string[limit];
            k = limit;

            for (int i = 0; i < used.Length; i++)
            {
                used[i] = false;
            }

            getVarsNoReps(arr, 0);

            //reset static variables
            ResetVars();
        }

        private static void getVarsNoReps(string[] arr, int index)
        {
            if(index >= k)
            {
                Print(vars);
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    vars[index] = arr[i];
                    getVarsNoReps(arr, index + 1);
                    used[i] = false;
                }
            }
        }

        public static void VarsWReps(string[] arr, int limit)
        {
            k = limit;
            vars = new string[k];

            getVarsWReps(arr, 0);
        }

        public static void VarsWRepsIterative(string[] arr, int limit)
        {
            int n = arr.Length;
            int[] indexes = new int[limit];
            string[] result = new string[limit];
            while (true)
            {
                Print(result.Select((x, i) => x = arr[indexes[i]]).ToArray());

                int index = limit - 1;
                while (index >= 0 && indexes[index] == n - 1)
                {
                    index--;
                }

                if (index < 0) break;
                indexes[index]++;
                for (int i = index + 1; i < limit; i++)
                {
                    indexes[i] = 0;
                }
            }
        }

        private static void getVarsWReps(string[] arr, int index)
        {
            if(index >= k)
            {
                Print(vars);
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                vars[index] = arr[i];
                getVarsWReps(arr, index + 1);
            }
        }

        static void ResetVars()
        {
            used = new bool[0];
            vars = new string[0];
            k = 0;
        }

        static void Print(string[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
