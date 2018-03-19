using System;
using System.Linq;
using System.Collections.Generic;


class TowerOfHanoi
{
    private int n;
    private int moves;
    private Stack<int> Source;
    private Stack<int> Dest;
    private Stack<int> Spare;

    public void Run()
    {
        n = int.Parse(Console.ReadLine());

        var source = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            source.Push(n - i);
        }

        var spare = new Stack<int>();
        var dest = new Stack<int>();

        Source = source;
        Spare = spare;
        Dest = dest;

        Print();

        MoveDisc(n , source, spare, dest);
    }

    private void Print()
    {
        Console.WriteLine($"Source: {string.Join(", ", Source.Reverse())}");
        Console.WriteLine($"Destination: {string.Join(", ", Dest.Reverse())}");
        Console.WriteLine($"Spare: {string.Join(", ", Spare.Reverse())}");
        Console.WriteLine();
    }

    private void MoveDisc(int topDisc, 
        Stack<int> source, Stack<int> spare, Stack<int> dest)
    {
        if(topDisc == 1)
        {
            moves++;
            dest.Push(source.Pop());
            Console.WriteLine($"Step #{moves}: Moved disk {topDisc}");
            Print();
        }
        else
        {
            MoveDisc(topDisc - 1, source , dest, spare);
            dest.Push(source.Pop());
            moves++;
            Console.WriteLine($"Step #{moves}: Moved disk");
            Print();
            MoveDisc(topDisc - 1, spare, source, dest);
        }

    }
}

