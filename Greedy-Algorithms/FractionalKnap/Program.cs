using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int capacity = int.Parse(Console.ReadLine().Split(' ')[1]);
        int n = int.Parse(Console.ReadLine().Split(' ')[1]);
        PWPair[] priceWeights = new PWPair[n];

        for (int i = 0; i < n; i++)
        {
            int[] entries = Console.ReadLine()
                .Split(new string[] { " -> " }, StringSplitOptions.None)
                .Select(x => int.Parse(x)).ToArray();

            priceWeights[i] = new PWPair(entries[0], entries[1]);
        }

        priceWeights = priceWeights.OrderByDescending(x => (double)x.Price/x.Weight).ToArray();

        decimal currentCapacity = capacity;
        decimal totalPrice = 0;
        for (int i = 0; i < priceWeights.Length; i++)
        {
            if (currentCapacity <= 0) break;

            int weight = priceWeights[i].Weight;
            int price = priceWeights[i].Price;

            decimal temp = currentCapacity / weight;
            if (temp > 1) temp = 1;

            currentCapacity -= weight * temp;

            totalPrice += price * temp;

            string percentage;
            if (temp == 1) percentage = "100";
            else percentage = (temp * 100).ToString("0.00");

            string priceStr = price.ToString("0.00");
            string weightStr = weight.ToString("0.00");
            Console.WriteLine($"Take {percentage}% of item with price " +
                $"{priceStr} and weight {weightStr}");
        }

        Console.WriteLine($"Total price: {totalPrice.ToString("0.00")}");
    }

     class PWPair
    {
        public int Price;
        public int Weight;
        public PWPair(int price,int weight)
        {
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"[{Price},{Weight}]";
        }
    }
}
