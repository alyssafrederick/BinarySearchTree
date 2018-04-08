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
            if (node.Right != null)
            {
                node.Right.Red = !node.Red;
            }
            if (node.Left != null)
            {
                node.Left.Red = !node.Red;
            }
        }

        public void Add(T value)
        {
            RedBlackNode<T> current = Root;

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
                        //if a 4-node is found, split it
                        if (current.Left?.Red == true && current.Right?.Red == true)
                        {
                            FlipColor(current);
                        }

                        if (current.Right == null)
                        {
                            current.Right = new RedBlackNode<T>(value);
                            current.Right.Parent = current;
                            return;
                        }

                        current = current.Right;
                    }
                }
            }
        }
    }
}
