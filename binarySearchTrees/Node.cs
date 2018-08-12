using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class Node<T> where T : IComparable
    {
        public T Value;
        public Node<T> nextnode;
        public Node<T> lastNode;

        public Node(T value)
        {
            Value = value;
        }
    }
}
