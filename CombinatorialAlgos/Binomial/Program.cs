using System;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        int limit = int.Parse(Console.ReadLine());
        decimal[,] memo = new decimal[count + 1, limit + 1];

        Console.WriteLine(Binom(count, limit));


        decimal Binom(int n, int k)
        {
            if (k > n) return 0;

            if (k == 0 || k == n)
            {
                return 1;
            }

            if (memo[n, k] != 0)
            {
                return memo[n, k];
            } 

            decimal result = Binom(n - 1, k - 1) + Binom(n - 1, k);

            memo[n, k] = result;

            return result;
        }
    }
}

