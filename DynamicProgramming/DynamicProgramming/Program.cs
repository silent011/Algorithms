using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] memo = new int[N + 1];

        Fib(N);
        Console.WriteLine(memo[N]);

        int Fib(int n)
        {
            if (n <= 0) return memo[n] = 0;
            if (n == 1) return memo[n] = 1;
            if (memo[n] > 0) return memo[n];

            return memo[n] = Fib(n - 1) + Fib(n - 2);
        }

    }
}

