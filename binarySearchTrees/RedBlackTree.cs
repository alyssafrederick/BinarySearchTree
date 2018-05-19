using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class RedBlackTree<T> where T : IComparable
    {
        public RedBlackNode<T> Root;

        private void FlipColor(RedBlackNode<T> node)
        {
            node.Red = !node.Red;

            if (node.Right != null)
            {
                node.Right.Red = !node.Red;
            }
            if (node.Left != null)
            {
                node.Left.Red = !node.Red;
            }
        }

        private bool isBlack(RedBlackNode<T> node)
        {
            if (node != null)
            {
                return !node.Red;
            }

            return true;
        }

        private RedBlackNode<T> RotateLeft(RedBlackNode<T> current)
        {

            var temp = current.Right;
            current.Right = temp.Left;
            temp.Left = current;
            temp.Red = current.Red;
            current.Red = true;

            return temp;
        }

        private RedBlackNode<T> RotateRight(RedBlackNode<T> current)
        {
            var temp = current.Left;
            current.Left = temp.Right;
            temp.Right = current;
            temp.Red = current.Red;
            current.Red = true;

            return temp;
        }

        public void Add(T value)
        {
            Root = add(Root, value);

            Root.Red = false;
        }

        private RedBlackNode<T> add(RedBlackNode<T> current, T value)
        {
            if (current == null)
            {
                return new RedBlackNode<T>(value);
            }

            //if a 4-node is found, split it
            if (current.Left?.Red == true && current.Right?.Red == true)
            {
                FlipColor(current);
            }

            //if the current's value is greater than that of the Tvalue, Tvalue will continue along Left
            if (current.Value.CompareTo(value) >= 0)
            {
                current.Left = add(current.Left, value);
            }
            //if the current's value is less than that of the Tvalue, Tvalue will continue along Right
            else
            {
                current.Right = add(current.Right, value);
            }


            //rotate left to make the 3-node left leaning
            if (isBlack(current.Left) && current.Right?.Red == true)
            {
                current = RotateLeft(current);
            }

            //rotate right to correct the unbalanced 4-node
            if (current.Left?.Red == true && current.Left?.Left?.Red == true)
            {
                current = RotateRight(current);
            }

            // TODO: fix this
            return current;
        }

        public RedBlackNode<T> MoveRedLeft(RedBlackNode<T> current)
        {
            FlipColor(current);
            current.Right = RotateRight(current.Right);
            current = RotateLeft(current);
            FlipColor(current);
        }

        public void Remove(T value)
        {
            while (Root.Left != null)
            {
                
            }
        }

    }
}
