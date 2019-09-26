using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] entry = Console.ReadLine().Split('/')
            .Select(x => int.Parse(x))
            .ToArray();

        int p = entry[0];
        int q = entry[1];

        double target = 1.0*p / q;
        if(target >= 1)
        {
            Console.WriteLine("Error (fraction is equal to or greater than 1)");
            return;
        }

        List<int> denominators = new List<int>();

        int currentDenom = 2;
        double currentSum = 0.0;
        while (true)
        {
            double fraction = 1.0 / currentDenom;
            if (currentSum + fraction <= target)
            {
                denominators.Add(currentDenom);
                currentSum += fraction;
            }

            if ((float)currentSum >= (float)target) break;
            currentDenom++;
        }

        Console.WriteLine("{0}/{1} = {2}", p, q, string.Join(" + ",
            denominators.Select(x => $"1/{x}")));
    }
}

