using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(' ')
            .Select(int.Parse).ToArray();

        int[] prevs = new int[arr.Length];
        int[] seqs = new int[arr.Length];
    
       // int[] prevsB = new int[arr.Length];
        //int[] seqsB = new int[arr.Length];

        List<int> result = new List<int>();

        Solution();
        Print();
        
        void Solution()
        {
            int maxPrev = -1;
            int maxSeq = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                prevs[i] = -1;
                seqs[i] = 1;

                for (int i1 = 0; i1 < i; i1++)
                {
                    int prevPrevEl = prevs[i1] == -1 ? -1 : arr[prevs[i1]]; 
                    if(arr[i1] < arr[i] && seqs[i] <= seqs[i1])
                    {
                        if(prevPrevEl == -1 || prevPrevEl > arr[i1])
                        {
                            seqs[i] = seqs[i1] + 1;
                            prevs[i] = i1;
                        }
                    }
                    else if(arr[i1] > arr[i] && seqs[i] <= seqs[i1])
                    {
                        if (prevPrevEl == -1 || prevPrevEl < arr[i1])
                        {
                            seqs[i] = seqs[i1] + 1;
                            prevs[i] = i1;
                        }
                    }
                }

                if(maxSeq < seqs[i])
                {
                    maxSeq = seqs[i];
                    maxPrev = i;
                }
            }

            BuildResult(maxPrev, prevs);
        }

        void BuildResult(int maxPrev, int[] prevIndexes)
        {
            int current = maxPrev;

            while(current > -1)
            {
                result.Add(arr[current]);
                current = prevIndexes[current];
            }

            result.Reverse();
        }

        void Print()
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
