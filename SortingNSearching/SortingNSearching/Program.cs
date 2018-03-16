using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int[] arr = Console.ReadLine().Split(' ')
                .Select(x => int.Parse(x)).ToArray();

            //var sorted = MergingSort<int>.Sort(arr);
            //var sorted = Quick<int>.Sort(arr);
            int el = int.Parse(Console.ReadLine());
            int index = BinarySearch.IndexOf(arr, el);
            Console.WriteLine("Index is: " + index);
            //Console.WriteLine(string.Join(" ", sorted));
        }
    }
}

