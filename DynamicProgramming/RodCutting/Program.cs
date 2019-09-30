using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] prices = Console.ReadLine().Split(' ')
            .Select(int.Parse).ToArray();
        int length = int.Parse(Console.ReadLine());

        int[] bestPrices = new int[prices.Length];
        int[] bestCombo = new int[prices.Length];

        SolutionRec(length);
        Print();

        int SolutionRec(int n)
        {
            if (bestPrices[n] > 0) return bestPrices[n];
            if (n == 0) return 0;

            int currentBest = bestPrices[n];
            for (int i = 1; i <= n; i++)
            {
                currentBest = Math.Max(currentBest, prices[i] +
                    SolutionRec(n - i));

                if(currentBest > bestPrices[n])
                {
                    bestPrices[n] = currentBest;
                    bestCombo[n] = i;
                }
            }

            return bestPrices[n];
        }

        void Print()
        {
            Console.WriteLine(bestPrices[length]);
            List<int> priceIDs = new List<int>();

            int currentID = bestCombo[length];
            int diff = length;

            while (diff != 0)
            {
                priceIDs.Add(currentID);
                diff -= currentID;
                currentID = bestCombo[diff];
            }

            Console.WriteLine(string.Join(" ", priceIDs));
        }
    }
}
