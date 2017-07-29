using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    class AVLnode<T> : IComparable where T : IComparable
    {
        public T Value;

        public int Height => Math.Max(leftChild?.Height ?? 0, rightChild?.Height ?? 0) + 1;

        public AVLnode<T> leftChild;
        public AVLnode<T> rightChild;
        public AVLnode<T> parent;

        public int Balance()
        {
            return (rightChild?.Height ?? 0) - (leftChild?.Height ?? 0);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public AVLnode (T value)
        {
            Value = value;            
        }

    }
}
