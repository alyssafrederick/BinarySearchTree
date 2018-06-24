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

        public SkipListNode(T value)
        {
            Value = value;
        }

        public int height;



    }
}
