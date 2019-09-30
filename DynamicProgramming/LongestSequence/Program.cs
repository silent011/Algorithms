using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(' ')
            .Select(x => int.Parse(x)).ToArray();

        int[] len = new int[arr.Length];
        int[] prev = new int[arr.Length];

        int maxLen = 0;
        int lastIndex = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            prev[i] = -1;
            len[i] = 1;
            for (int i1 = 0; i1 < i; i1++)
            {
                if(arr[i1] < arr[i] && len[i1] >= len[i])
                {
                    len[i] = len[i1] + 1;
                    prev[i] = i1;
                }
            }

            if(len[i] > maxLen)
            {
                maxLen = len[i];
                lastIndex = i;
            }
        }

        List<int> longest = new List<int>();
        while(lastIndex != -1)
        {
            longest.Add(arr[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        longest.Reverse();

        Console.WriteLine(string.Join(" ", longest));
    }
}

