using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
     
            string[] arr = Console.ReadLine().Split(' ');
            //Array.Sort(arr);

            //Perm.PermWRep(arr, 0, arr.Length - 1);
            Perm.PermRepHash(arr, 0);
       
    }

    static class Perm
    {
        static int count = 0;
        public static void PermWRep(string[] arr, int start, int end)
        {
            Print(arr, count);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if(arr[left] != arr[right])
                    {
                        Swap(arr, left, right);
                        PermWRep(arr, left + 1, end);
                    }
                }

                string firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[end] = firstElement;
            }
        }

        public static void PermRepHash(string[] arr, int index)
        {
            if(index >= arr.Length)
            {
                count++;
                Print(arr, count);
                return;
            }
            HashSet<string> swapped = new HashSet<string>();
            for (int i = index; i < arr.Length; i++)
            {
                if (!swapped.Contains(arr[i]))
                {
                    Swap(arr, index, i);
                    PermRepHash(arr, index + 1);
                    Swap(arr, index, i);
                    swapped.Add(arr[i]);
                }
            }
            
        }

        static void Swap(string[] arr, int i1, int i2)
        {
            string temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
        }

        static void Print(string[] arr, int count)
        {
            Console.WriteLine(string.Join(" ", arr));
        }

    }
}

