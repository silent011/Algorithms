using System;


class NestedLoops
{
    private int n;
    public void Start()
    {
        n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 1; i <= n; i++)
        {
            Nest(arr, i, 1);
        }

    }

    private void Nest(int[] arr, int current, int pos)
    {
        if(pos > n)
        {
            return;
        }

        arr[pos - 1] = current;

        if (pos == n)
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        for (int i = 1; i <= n; i++)
        {
            Nest(arr, i, pos + 1);
        }
      
    }
}
