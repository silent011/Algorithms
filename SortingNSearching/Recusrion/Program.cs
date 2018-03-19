using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            //for inverting arrays:
            //string[] arr = Console.ReadLine().Split(' ');

            //var result = InvertingArray<string>.Inverse(arr);

            //Console.WriteLine(string.Join(" ", result));

            //var nested = new NestedLoops();
            //nested.Start();
            //var combsWithReps = new CombWithRepetitions();
            //combsWithReps.Start();
            //var hanoi = new TowerOfHanoi();
            //hanoi.Run();

            var combsWithout = new CombWithoutReps();
            combsWithout.Run();
        }
    }
}
