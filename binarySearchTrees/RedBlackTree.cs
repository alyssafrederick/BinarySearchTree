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
        public void FlipColor(RedBlackNode<T> node)
        {
            node.Red = !node.Red;
            node.Black = !node.Black;

            if (node.Right != null)
            {
                node.Right.Red = !node.Red;
                node.Right.Red = node.Black;
            }
            if (node.Left != null)
            {
                node.Left.Red = !node.Red;
                node.Left.Red = node.Black;
            }
        }

        //private void SearchDown(T value)
        //{
        //    RedBlackNode<T> current = Root;

        //    //if a 4-node is found, split it
        //    if (current.Left?.Red == true && current.Right?.Red == true)
        //    {
        //        FlipColor(current);
        //    }

        //    if (current.Right == null)
        //    {
        //        current.Right = new RedBlackNode<T>(value);
        //        current.Right.Parent = current;
        //        return;
        //    }

        //    current = current.Right;
        //}

        public void Add(T value)
        {
            Root = add(Root, value);

            Root.Red = false;
            Root.Black = true;


         //   Root = add(add(Root, value), value);
            /*RedBlackNode<T> current = Root;

            //if there was previously nothing in the tree
            if (Root == null)
            {
                Root = new RedBlackNode<T>(value);
                return;
            }

            //if anything is in the tree
            else
            {
                //searching down to bottom of tree
                while (current != null)
                {
                    //if the current's value is greater than that of the Tvalue, Tvalue will continue along Left
                    if (current.Value.CompareTo(value) >= 0)
                    {
                        //if a 4-node is found, split it
                        if (current.Left?.Red == true && current.Right?.Red == true)
                        {
                            FlipColor(current);
                        }

                        if (current.Left == null)
                        {
                            current.Left = new RedBlackNode<T>(value);
                            current.Left.Parent = current;
                            return;
                        }


                        //////////////////////////////////////////////////not left leaning.... make 3-nodes left leaning

                        current = current.Left; 

                    }

                    //if the current's value is less than that of the Tvalue, Tvalue will continue along Right
                    else if (current.Value.CompareTo(value) < 0)
                    {
                        SearchDown(value);
                    }
                }
            }*/
        }

        public RedBlackNode<T> RotateLeft(RedBlackNode<T> current)
        {
            //RedBlackNode<T> child = current.Right;
            //current.Right = null;
            //if (current == Root)
            //{
            //    Root = child;
            //    current = null;
            //}
            //else
            //{
            //    current = current.Parent;
            //    current.Parent.LeftChild = child;
            //    child.LeftChild = current;
            //    current.Parent = child;
            //}

            //if (child != null)
            //{
            //    child.Left = current;
            //}

            ///////////////////////////////////////////////////

            /*if (current == Root)
            {
                Root = current.Right;
                current.Right = Root.Left;
                Root.Left = current;
            }
            else
            {
                RedBlackNode<T> tempNode = current;
                current = current.Right;
                tempNode.Right = current.Left;
                current.Left = tempNode;                
            }*/

            var temp = current.Right;
            current.Right = temp.Left;
            temp.Left = current;
            temp.Red = current.Red;
            current.Red = true;

            return temp;
        }

        public void RotateRight(RedBlackNode<T> current)
        {
            if(current == Root)
            {
                Root = current.Left;
                current.Left = Root.Right;
                Root.Right = current;
            }
            else
            {
                RedBlackNode<T> tempNode = current;
                current = current.Left;
                tempNode.Left = current.Right;
                current.Left = tempNode;
            }


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
            if ((current.Left == null || current.Left?.Black == true) && current.Right?.Red == true)
            {
                RotateLeft(current);
            }

            //rotate right to correct the unbalanced 4-node
            if (current.Left?.Red == true && current.Left?.Left?.Red == true)
            {
                RotateRight(current);
            }

            // TODO: fix this
            return current;
        }
    }
}
