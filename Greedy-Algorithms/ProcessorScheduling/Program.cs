using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine().Split(' ')[1]);
        Pair[] pairs = new Pair[N];

        //split and add get the data into pair classes which are then
        //collected to pairs array
        int maxSteps = 0;
        for (int i = 0; i < N; i++)
        {
            int[] entries = Console.ReadLine()
                .Split(new string[] { " - " }, StringSplitOptions.None)
                .Select(x => int.Parse(x))
                .ToArray();

            int step = entries[1];
            int value = entries[0];
            
            if (step > maxSteps) maxSteps = step;

            pairs[i] = new Pair(value, step, i + 1);
        }

        Pair[] sortedValues = pairs.OrderByDescending(x => x.Value).ToArray();

        List<Pair> pickedPairs = new List<Pair>();
        int totalValue = 0;
        int currentStep = 0;
        for (int i = 0; i < sortedValues.Length; i++)
        {
            int value = sortedValues[i].Value;
            int stepsNeeded = sortedValues[i].Steps;

            pickedPairs.Add(sortedValues[i]);
            currentStep++;
            totalValue += value;

            if (currentStep == maxSteps) break;
        }

        string[] sorted = pickedPairs.OrderBy(x => x.Steps)
            .ThenByDescending(x => x.Value)
            .Select(x => x.ToString())
            .ToArray();

        Console.WriteLine("Optimal schedule: {0}",
                    string.Join(" -> ", sorted));
        Console.WriteLine("Total value: " + totalValue);
    }

    class Pair
    {
        public int Value;
        public int Steps;
        public int TaskID;
        public Pair(int value, int steps, int taskID)
        {
            Value = value;
            Steps = steps;
            TaskID = taskID;
        }

        public override string ToString()
        {
            return TaskID.ToString();
        }
    }
}

