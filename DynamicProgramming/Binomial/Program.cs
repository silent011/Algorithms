using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        long[,] memo = new long[N + 1, K + 1];

        Console.WriteLine(GetBinomial(N, K));
         
        long GetBinomial(int n, int k)
        {
            if (k == 0) return 1;
            if (n == 0) return 0;

            if (memo[n, k] > 0) return memo[n, k];

            return memo[n, k] = GetBinomial(n - 1, k -1)
                + GetBinomial(n - 1, k);
        }
    }
}
