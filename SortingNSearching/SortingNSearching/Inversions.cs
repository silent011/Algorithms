using System;
using System.Collections.Generic;
using System.Linq;

class Inversions
{
    public static void Run()
    {
        int[] input = Console.ReadLine().Split(' ')
             .Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(MergeSortWithInv.Sort(input));
    }
}

class MergeSortWithInv
{
    public static int Sort(int[] arr)
    {
        int result = 0;
        result = Sort(arr, 0, arr.Length - 1);

        return result;
    }

    private static int Sort(int[] arr, int low, int high)
    {
        if (low >= high) return 0;


        int mid = (low + high) / 2;
        int count = Sort(arr, low, mid);
        count += Sort(arr, mid + 1, high);
        count += Merge(arr, low, mid, high);

        return count;
    }

    private static int Merge(int[] arr, int low, int mid, int high)
    {
        if (IsLess(arr[mid], arr[mid + 1])) return 0;
        int[] aux = new int[high - low + 1];
        CopyArrToAux(arr, aux, low, high);

        int invCount = 0;
        int lo = 0;
        int mi = (aux.Length - 1) / 2;
        int hi = mi + 1;
        for (int i = low; i <= high; i++)
        {
            if (lo > mi) arr[i] = aux[hi++];
            else if (hi > aux.Length - 1) arr[i] = aux[lo++];
            else if (IsLess(aux[lo], aux[hi]))
            {
                arr[i] = aux[lo++];
            }
            else
            {
                invCount += mi + 1 - lo;
                arr[i] = aux[hi++];
            }
        }

        return invCount;
    }

    private static void CopyArrToAux(int[] arr, int[] aux, int low, int high)
    {
        int j = 0;
        for (int i = low; i <= high; i++)
        {
            aux[j++] = arr[i];
        }
    }

    private static bool IsLess(int a, int b)
    {
        return a <= b;
    }
}

