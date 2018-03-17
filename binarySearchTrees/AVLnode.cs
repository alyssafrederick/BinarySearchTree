using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class AVLnode<T> : IComparable where T : IComparable
    {
        public T Value;

        int heightCallCount = 0;

        public int Height
        {
            get
            {
                heightCallCount++;

                if(LeftChild == this || RightChild == this)
                {
                    throw new Exception("You cannot be your own child");
                }


                if(heightCallCount > 20)
                {
                    ;
                }

                if(LeftChild == null && RightChild == null)
                {
                    heightCallCount = 0;
                    return 1;
                }
                return Math.Max(LeftChild?.Height ?? 0, RightChild?.Height ?? 0) + 1;
            }
        }


        public AVLnode<T> LeftChild
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
                if (value != null)
                {
                    value.Parent = this;
                }
            }
        }

        public AVLnode<T> RightChild
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
                if (value != null)
                {
                    value.Parent = this;
                }
            }
        }

        public AVLnode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private AVLnode<T> left;
        private AVLnode<T> right;
        private AVLnode<T> parent;

        public int Balance()
        {
            return (RightChild?.Height ?? 0) - (LeftChild?.Height ?? 0);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public AVLnode(T value)
        {
            Value = value;
        }

        public void SetRoot()
        {
            parent = null; 
        }

    }
}
