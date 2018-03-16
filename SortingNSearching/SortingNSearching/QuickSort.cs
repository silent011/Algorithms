using System;

public class Quick<T> where T: IComparable
{
    public static T[] Sort(T[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
        return arr;
    }

    private static void Sort(T[] arr, int low, int high)
    {
        if(low >= high)
        {
            return;
        }

        int p = Partition(arr, low, high);
        Sort( arr, low, p - 1);
        Sort( arr, p + 1, high);
    }

    private static int Partition(T[] arr, int low, int high)
    {
        if(low >= high)
        {
            return low;
        }

        int i = low;
        int j = high + 1;
        while (true)
        {
            while(IsLess(arr[++i], arr[low]))
            {
                if (i == high) break;
            }

            while(IsLess(arr[low], arr[--j]))
            {
                if (j == low) break;
            }

            if (i >= j) break;
            Swap(arr, i, j);
        }

        Swap(arr, low, j);

        return j;
    }

    private static void Swap(T[] arr, int index1, int index2)
    {
        T el = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = el;
    }

    private static bool IsLess(T a, T b)
    {
        return a.CompareTo(b) < 1;
    }
}

