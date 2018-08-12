using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class SkipListNode<T> where T : IComparable
    {

        public T Value;
        public SkipListNode<T>[] neighbors;
        public int Height => neighbors.Length;

        public SkipListNode(T value, int height)
        {
            Value = value;
            neighbors = new SkipListNode<T>[height];
        }

    }
}
