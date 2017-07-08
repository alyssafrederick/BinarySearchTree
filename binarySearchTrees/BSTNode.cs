using System;

namespace binarySearchTrees
{
    class BSTNode<T> where T : IComparable
    {
        public T Value;
        public BSTNode<T> parent;
        public BSTNode<T> leftChild;
        public BSTNode<T> rightChild;

        public BSTNode (T value)
        {
            Value = value;
        }
    }
}
