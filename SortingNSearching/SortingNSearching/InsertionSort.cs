using System;
using System.Collections;

class InsertionSort<T> where T: IComparable
{
    
    public void Run(T[] arr)
    {
        ReversedLink sorted = new ReversedLink();
        sorted.Add(arr[0]);

        for (int i = 1; i < arr.Length; i++)
        {
            sorted.InsertSort(arr[i]);
        }

        Console.WriteLine(string.Join(" ", sorted.ToAscArray()));

    }

    private static bool IsLess(T a, T b)
    {
        return a.CompareTo(b) < 1;
    }

    class ReversedLink: IEnumerable
    {
        public Node Last { get; private set; }
        public int Count;
        public ReversedLink()
        {
            Last = null;
            Count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            Node current = Last;
            while(current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add(T val)
        {
            if (Last == null) Last = new Node(val);
            else
            {
                Node newLast = new Node(val);
                newLast.Prev = Last;
                Last = newLast;
            }
            Count++;
        }

        public void InsertSort(T value)
        {
            if(IsLess(Last.Value, value))
            {
                Add(value);
                return;
            }

            Node current = Last;
            Node insertionNode = new Node(value);
            while(current != null)
            {
                if(current.Prev == null)
                {
                    current.Prev = insertionNode;
                    break;
                }
                if(IsLess(current.Prev.Value, value))
                {
                    insertionNode.Prev = current.Prev;
                    current.Prev = insertionNode;
                    break;
                }

                current = current.Prev;
            }
            Count++;
        }

        public T[] ToAscArray()
        {
            T[] ascArr = new T[Count];
            Node current = Last;
            int counter = ascArr.Length - 1;
            while(current != null)
            {
                ascArr[counter] = current.Value;
                counter--;
                current = current.Prev;
            }
            return ascArr;
        }
    }

    class Node
    {
        public T Value;
        public Node Prev;

        public Node(T val)
        {
            Value = val;
            Prev = null;
        }
    }
}