using System;


class CombWithRepetitions
{
    private int n;
    private int m;
    public void Start()
    {
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());

        int[] arr = new int[m];

        for (int i = 1; i <= n; i++)
        {
            Combinations(arr, i, 1);
        }
    }

    private void Combinations(int[] arr, int current, int pos)
    {
        arr[pos - 1] = current;
        if (pos == m)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        } 

        for (int i = current; i <= n; i++)
        {
            Combinations(arr, i, pos + 1);
        }
    }
}

