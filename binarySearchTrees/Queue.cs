using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    class Queue<T> where T : IComparable
    {
        LinkedList<T> linkedList;

        public int Size => linkedList.Size;

        public bool IsEmpty => linkedList.First == null;
        public Queue ()
        {
            linkedList = new LinkedList<T>();
        }

        public void Enqueue (T value)
        {
            linkedList.AddToStart(value);
        }

        public T Dequeue ()
        {
            T t = linkedList.Last.Value;
            linkedList.DeleteLast();

            // Console.WriteLine(t);
            return t;
        }


    }
}
