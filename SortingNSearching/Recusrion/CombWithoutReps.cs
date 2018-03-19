using System;


class CombWithoutReps
{
    private int n;
    private int m;
    public void Run()
    {
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());

        int[] arr = new int[m];

        for (int i = 1; i <= n; i++)
        {
            Reps(arr, i, 1);
        }
        
    }

    private void Reps(int[] arr,int current, int pos)
    {
        arr[pos - 1] = current;
        if(pos == m)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        
        for (int i = current + 1; i <= n; i++)
        {
            Reps(arr, i, pos + 1);
        }
    }
}

