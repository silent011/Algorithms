using System;

class InvertingArray<T>
{
    private static T[] result;
    public static T[] Inverse(T[] arr)
    {
        result = new T[arr.Length];
        Inverse(arr, 0);
        return result;
    }

    private static void Inverse(T[] arr, int index)
    {
        if(index == arr.Length)
        {
            return;
        }

        Inverse(arr, index + 1);
        result[index] = arr[arr.Length - 1 - index];
    }
}

