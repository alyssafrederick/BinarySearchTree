using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class RedBlackNode<T> : IComparable where T : IComparable
    {
        public T Value;
        public bool Red = true;
        public bool Black = false;

        public RedBlackNode<T> Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public RedBlackNode<T> Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }


        private RedBlackNode<T> left;
        private RedBlackNode<T> right;

        public RedBlackNode(T value)
        {
            Value = value;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
