using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    class AVLnode<T> where T : IComparable
    {
        public T Value;

        public int Height => Math.Max(leftChild?.Height ?? 0, rightChild?.Height ?? 0) + 1;

        public AVLnode<T> leftChild;
        public AVLnode<T> rightChild;
        public AVLnode<T> parent;

        public AVLnode (T value)
        {
            Value = value;            
        }

    }
}
