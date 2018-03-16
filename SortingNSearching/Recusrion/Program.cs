using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string[] arr = Console.ReadLine().Split(' ');

            var result = InvertingArray<string>.Inverse(arr);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
