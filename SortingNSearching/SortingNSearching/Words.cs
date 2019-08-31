using System;
using System.Collections.Generic;
using System.Linq;


class Words
{
    public static void Run()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Dictionary<char, int> chars = GetCharDict(input);
        chars.OrderBy(x => x.Value);

        long numWords = GetNumOfWords(chars);
    }

    private static long GetNumOfWords(Dictionary<char, int> chars)
    {
        if (isImpossible(chars)) return 0;

        return 1;
    }

    private static bool isImpossible(Dictionary<char, int> chars)
    {
        return chars.Last().Value > Math.Ceiling(chars.Count / 2.0);
    }

    private static Dictionary<char, int> GetCharDict(char[] input)
    {
        Dictionary<char, int> result = new Dictionary<char, int>(input.Length);
        foreach (char ch in input)
        {
            if (result.ContainsKey(ch)) result[ch]++;
            else result.Add(ch, 1);
        }

        return result;
    }
}
