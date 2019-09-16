using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        List<char> values = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
                    values.Add(input[i]);
        }

        Solution s = new Solution();

        s.Run(values.ToArray());

    }

    class Solution
    {
        int count = 0;
        HashSet<string> allPossible = new HashSet<string>();
        Dictionary<string, int> edges;
        public Solution() { }
     
        public void Run(char[] arr)
        {
            MapEdgesToIndex();
            PermRepHash(arr, 0);

            Print();
        }
        //1 2 2 2 2 2 2 2 2 2 2 2
        //1 1 2 2 2 3 3 3 3 3 3 3
        private void Print()
        {
            Console.WriteLine(count);
        }

        private void MapEdgesToIndex()
        {
            edges = new Dictionary<string, int>(12);
            edges.Add("FD", 0);
            edges.Add("FR", 1);
            edges.Add("FU", 2);
            edges.Add("FL", 3);
            edges.Add("MDR", 4);
            edges.Add("MUR", 5);
            edges.Add("MUL", 6);
            edges.Add("MDL", 7);
            edges.Add("BD", 8);
            edges.Add("BR", 9);
            edges.Add("BU", 10);
            edges.Add("BL", 11);
        }

        void PermRepHash(char[] arr, int index)
        {
            if (index >= arr.Length)
            {
                if(!allPossible.Contains(new string(arr)))
                {
                    count++;
                    RenderPermutation(arr);
                }
                return;
            }
            HashSet<char> swapped = new HashSet<char>();
            for (int i = index; i < arr.Length; i++)
            {
                if (!swapped.Contains(arr[i]))
                {
                    Swap(arr, index, i);
                    PermRepHash(arr, index + 1);
                    Swap(arr, index, i);
                    swapped.Add(arr[i]);
                }
            }

        }

        private void RenderPermutation(char[] arr)
        {
            char[] copy = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
            }

            for (int i = 0; i < 4; i++)
            {
                if(!allPossible.Contains(new string(copy)))
                {
                    allPossible.Add(new string(copy));
                }

                for (int i1 = 0; i1 < 4; i1++)
                {
                    RotateY(copy);
                    if (!allPossible.Contains(new string(copy)))
                    {
                        allPossible.Add(new string(copy));
                    }
                }

                for (int i2 = 0; i2 < 4; i2++)
                {
                    RotateZ(copy);
                    if(!allPossible.Contains(new string(copy)))
                    {
                        allPossible.Add(new string(copy));
                    }
                }
                RotateX(copy);
            }

        }

        private void RotateZ(char[] arr)
        {
            //Down
            Swap(arr, I("MDR"), I("FD"));
            Swap(arr, I("FD"), I("MDL"));
            Swap(arr, I("MDL"), I("BD"));

            //Middle
            Swap(arr, I("FR"), I("BR"));
            Swap(arr, I("FL"), I("FR"));
            Swap(arr, I("FL"), I("BL"));

            //Top
            Swap(arr, I("FU"), I("MUR"));
            Swap(arr, I("FU"), I("MUL"));
            Swap(arr, I("MUL"), I("BU"));
        }

        private void RotateX(char[] arr)
        {
            //Left
            Swap(arr, I("MDL"), I("FL"));
            Swap(arr, I("FL"), I("MUL"));
            Swap(arr, I("MUL"), I("BL"));

            //Middle
            Swap(arr, I("FD"), I("FU"));
            Swap(arr, I("FU"), I("BU"));
            Swap(arr, I("BU"), I("BD"));

            //Right
            Swap(arr, I("MDR"), I("FR"));
            Swap(arr, I("FR"), I("MUR"));
            Swap(arr, I("MUR"), I("BR"));

        }

        private void RotateY(char[] arr)
        {
            //Front
            Swap(arr, I("FD"), I("FL"));
            Swap(arr, I("FL"), I("FU"));
            Swap(arr, I("FU"), I("FR"));

            //Middle
            Swap(arr, I("MDR"), I("MDL"));
            Swap(arr, I("MDL"), I("MUL"));
            Swap(arr, I("MUL"), I("MUR"));

            //Back
            Swap(arr, I("BD"), I("BL"));
            Swap(arr, I("BL"), I("BU"));
            Swap(arr, I("BU"), I("BR"));
        }

        private int I(string edge)
        {
            return edges[edge];
        }

        void Swap(char[] arr, int i1, int i2)
        {
            char temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
        }
    }
}
