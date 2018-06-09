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
            if (isBlack(current.Right.Left) == false)
            {
                current.Right = RotateRight(current.Right);
                current = RotateLeft(current);
                FlipColor(current);
            }
            return current;
        }

        public RedBlackNode<T> MoveRedRight(RedBlackNode<T> current)
        {
            FlipColor(current);
            if (isBlack(current.Left.Left) == false)
            {
                current = RotateRight(current);
                FlipColor(current);
            }
            return current;
        }

        private RedBlackNode<T> FixUp(RedBlackNode<T> current, T value)
        {
            //enforce left leaning policy
            if (isBlack(current.Right) == false)
            {
                current = RotateLeft(current);
            }

            //split 4nodes
            if (isBlack(current.Right) == false && isBlack(current.Left) == false)
            {
                FlipColor(current);
            }

            //balance 4nodes


            //avoid leaving behind right leaning nodes
        } 

        public void Remove(T value)
        {
            Root = remove(Root, value);
            Root.Red = false;
        }

        private RedBlackNode<T> remove(RedBlackNode<T> current, T value)
        {
            if (Root == null)
            {
                return null;
            }

            else
            {
                //searching left
                if (current.Value.CompareTo(value) < 0)
                {
                    if (current.Left != null)
                    {
                        if (isBlack(current.Left) == true && isBlack(current.Left.Left) == true)
                        {
                            current = MoveRedLeft(current);
                        }

                        current.Left = remove(current.Left, value);
                    }

                }


                //searching right/value found
                else
                {
                    if (isBlack(current.Left) == false)
                    {
                        current = RotateRight(current);
                    }

                    if (current.Value.CompareTo(value) == 0 && current.Left == null && current.Right == null)
                    {
                        return null;
                    }

                    if (isBlack(current.Right) == true && isBlack(current.Right.Left) == true)
                    {
                        current = MoveRedRight(current);
                    }

                    if (current.Value.CompareTo(value) == 0)
                    {
                        RedBlackNode<T> temp = current.Right;
                        while (temp.Left != null)
                        {
                            temp = temp.Left;
                        }
                        current.Value = temp.Value;

                        current.Right = remove(current.Right, temp.Value);
                    }

                    else
                    {
                        current.Right = remove(current.Right, value);
                    }
                }
            }

            return FixUp(current);
        }
    }
}
