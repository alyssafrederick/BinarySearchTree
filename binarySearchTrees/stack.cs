using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    class Stack<T> where T : IComparable
    {
        LinkedList<T> linkedList;
        
        public int Size => linkedList.Size+1;
        public bool IsEmpty => linkedList.First == null;

        public Stack ()
        {
            linkedList = new LinkedList<T>();
        }

        public void Push (T value)
        {
            linkedList.Add(value);
        }

        public T Pop ()
        {
            T t = linkedList.Last.Value;
            
            linkedList.DeleteLast();

            Console.WriteLine(t);
            return t;
        }
        
        public T Peek ()
        {
            T t = linkedList.Last.Value;

            Console.Write(t);
            return t;
        }

    }   
}       
        