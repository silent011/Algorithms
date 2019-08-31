using System;

class Program
{
    static void Main(string[] args)
    {
        string[] arr = Console.ReadLine().Split(' ');

        Array.Sort(arr);

        PermWRep(0, arr.Length - 1);
        void PermWRep(int start, int end)
        {
            Console.WriteLine(string.Join(" ", arr));

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if(arr[left] != arr[right])
                    {
                        Swap(left, right);
                        PermWRep(left + 1, end);
                    }
                }

                string firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[end] = firstElement;
            }
        }
        
        void Swap(int i1, int i2)
        {
            string temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
        }
    }
}

