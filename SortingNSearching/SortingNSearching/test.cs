using System;
using System.Collections.Generic;
using System.Linq;


class test
{
    private static int Counter;
    private static List<string> usedCombinations;
    public static void Run()
    {
        char[] input = Console.ReadLine().ToCharArray();
        usedCombinations = new List<string>();
        Counter = 0;

        int[] prevIndexes = GetDefaultArr(input.Length, -1);
        GetCombinations(input, 0, prevIndexes, new char[input.Length]);
        Console.WriteLine("Counter: " + Counter);
    }

    private static int[] GetDefaultArr(int length, int defaultVal)
    {
        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = defaultVal;
        }

        return result;
    }

    private static void GetCombinations(char[] input,int depth, int[] prevIndexes, char[] result)
    {
        if (depth == input.Length) return;
        for (int i = 0; i < input.Length; i++)
        {
            if (prevIndexes.Contains(i))
                continue;
            if (depth > 0 && input[i] == result[depth - 1])
                continue;

            prevIndexes[depth] = i;
            result[depth] = input[i];
            if(depth == input.Length - 1 && !usedCombinations.Contains(new string(result)))
            {
                Counter++;
                Console.WriteLine(result);
                usedCombinations.Add(new string(result));
            }
            else
            {
                GetCombinations(input, depth + 1, prevIndexes, result);
            }

            prevIndexes[depth] = -1;
        }

    }
}

