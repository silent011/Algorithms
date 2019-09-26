using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine().Split(' ')[1]);
      
       Lecture[] lectures = new Lecture[N];

        for (int i = 0; i < N; i++)
        {
            string[] entry = Console.ReadLine().Split(new string[] { ": ", " - " },
                StringSplitOptions.None).ToArray();

            string name = entry[0];
            int s = int.Parse(entry[1]);
            int f = int.Parse(entry[2]);

            lectures[i] = new Lecture(name, s, f);
        }

        lectures = lectures.OrderBy(x => x.F).ToArray();

        List<Lecture> result = new List<Lecture>();
        for (int i = 0; i < lectures.Length; i++)
        {
            if (lectures[i] == null) continue;
            Lecture current = lectures[i];
            result.Add(current);

            for (int i1 = 0; i1 < lectures.Length; i1++)
            {
                if(lectures[i1] != null && lectures[i1].S < current.F)
                {
                    lectures[i1] = null;
                }
            }
        }

        Console.WriteLine("Lectures ({0}):", result.Count);
        foreach (Lecture lect in result)
        {
            Console.WriteLine($"{lect.S}-{lect.F} -> {lect.Name}");
        }
    }

    class Lecture
    {
        public string Name;
        public int S;
        public int F;
        public int Span;

        public Lecture(string name, int start, int finish)
        {
            Name = name;
            S = start;
            F = finish;
            Span = F - S;
        }
    }
}

