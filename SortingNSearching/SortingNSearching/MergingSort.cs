using System;

public class MergingSort<T> where T: IComparable
{
    private static T[] aux;
    public static T[] Sort(T[] arr)
    {
        aux = new T[arr.Length];
        Sort(arr, 0, arr.Length - 1);
        return arr;
    }

    private static void Sort(T[] arr, int low, int high)
    {
        if(low >= high)
        {
            return;
        }

        int mid = (high + low)/2;
        Sort(arr, low, mid);
        Sort(arr, mid + 1, high);
        Merge(arr, low, mid, high);
    }

    private static void Merge(T[] arr, int low, int mid, int high)
    {
        if(IsLess(arr[mid], arr[mid + 1]))
        {
            return;
        }
        for (int index = low; index < high + 1; index++)
        {
            aux[index] = arr[index];
        }

        int i = low;
        int j = mid + 1;
        for (int k = low; k <= high; k++)
        {
            if (i > mid)
            {
                arr[k] = aux[j++];
            } 
            else if (j > high)
            {
                arr[k] = aux[i++];
            }
            else if (IsLess(aux[i], aux[j]))
            {
                arr[k] = aux[i++];
            }
            else
            {
                arr[k] = aux[j++];
            }
        }
    }

    private static bool IsLess(T a, T b)
    {
        return a.CompareTo(b) < 1;
    }
}

