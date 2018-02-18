using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class AVLtree<T> where T : IComparable
    {
        public AVLnode<T> Root;
        public bool IsEmpty => Root == null;



        public void Add(T value)
        {
            //if there is no root, insert the BSTNode as the root
            if (Root == null)
            {
                Root = new AVLnode<T>(value);
                return;
            }

            //if there is a root
            if (Root != null)
            {
                Root.SetRoot();
                AVLnode<T> current = Root;
                Stack<AVLnode<T>> stack = new Stack<AVLnode<T>>();

                while (current != null)
                {
                    stack.Push(current);

                    //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                    if (current.Value.CompareTo(value) > 0)
                    {
                        if (current.LeftChild == null)
                        {
                            current.LeftChild = new AVLnode<T>(value);
                            break;
                        }

                        current = current.LeftChild;

                    }
                    //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                    else if (current.Value.CompareTo(value) <= 0)
                    {
                        if (current.RightChild == null)
                        {
                            current.RightChild = new AVLnode<T>(value);
                            break;
                        }

                        current = current.RightChild;
                    }
                }

                while (stack.IsEmpty == false)
                {
                    Fix(stack.Pop());
                }

            }
        }

        public bool Remove(T value)
        {
            if (Root == null)
            {
                return false;
            }

            else if (Root != null)
            {
                AVLnode<T> current = Root;
                AVLnode<T> nodeToRemove = null;

                while (current != null)
                {
                    //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                    if (current.Value.CompareTo(value) > 0)
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            nodeToRemove = current;
                        }

                        current = current.LeftChild;
                    }

                    //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                    else if (current.Value.CompareTo(value) <= 0)
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            nodeToRemove = current;
                        }

                        current = current.RightChild;
                    }
                }

                if (nodeToRemove != null)
                {
                    if (nodeToRemove.LeftChild == null && nodeToRemove.RightChild == null)
                    {
                        //if the nodeToRemove is a left child then delete the parents connection to the left child
                        if (nodeToRemove.Parent.LeftChild == nodeToRemove)
                        {
                            nodeToRemove.Parent.LeftChild = null;
                        }

                        //if the nodeToRemove is a right child then delete the parents connection to the right child 
                        else if (nodeToRemove.Parent.RightChild == nodeToRemove)
                        {
                            nodeToRemove.Parent.RightChild = null;
                        }
                    }

                    //if the nodeToRemove only has a rightchild
                    else if (nodeToRemove.LeftChild == null)
                    {
                        nodeToRemove.Parent.LeftChild = nodeToRemove.RightChild;

                    }

                    //if the nodeToRemove only has a leftchild
                    else if (nodeToRemove.RightChild == null)
                    {
                        nodeToRemove.Parent.RightChild = nodeToRemove.LeftChild;
                    }

                    //if the nodeToRemove has both a leftchild and a rightchild
                    else
                    {
                        bool movedRight = false;

                        current = nodeToRemove.LeftChild;

                        while (current.RightChild != null)
                        {
                            current = current.RightChild;
                            movedRight = true;
                        }

                        if (movedRight == true)
                        {
                            current.LeftChild = nodeToRemove.LeftChild;
                        }

                        //if the node is as leftchild
                        if (nodeToRemove.Parent.LeftChild == nodeToRemove)
                        {
                            nodeToRemove.Parent.LeftChild = current;
                        }

                        //if the node is a rightchild
                        else if (nodeToRemove.Parent.RightChild == nodeToRemove)
                        {
                            nodeToRemove.Parent.RightChild = current;
                        }

                        current.RightChild = nodeToRemove.RightChild;


                    }

                    return true;
                }

            }

            return false;
        }

        public AVLnode<T> Search(T value)
        {
            AVLnode<T> current = Root;

            while (current != null)
            {
                //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                if (current.Value.CompareTo(value) > 0)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        //Console.WriteLine(current.Value);
                        return current;
                    }

                    current = current.LeftChild;
                }

                //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                else if (current.Value.CompareTo(value) <= 0)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        //Console.WriteLine(current.Value);
                        return current;
                    }

                    current = current.RightChild;
                }
            }

            return null;
        }

   
        public void Fix(AVLnode<T> node)
        {
            //if its balanced ... balance will be -1, 0, 1
            if (node.Balance() == -1 || node.Balance() == 0 || node.Balance() == 1)
            {
                return;
            }

            //if tree is leaning towards right ... balance will be >1
            else if (node.Balance() > 1 && (node.RightChild.Balance() > 0))
            {

                RotateLeft(node);
            }

            //if tree is leaning towards left ... balance will be <1
            else if (node.Balance() < 1 && (node.LeftChild.Balance() < 0))
            {
                RotateRight(node);
            }

            //if tree is a right-left rotation
            else if (node.Balance() > 1 && (node.RightChild.LeftChild != null && node.RightChild.RightChild == null))
            {
                RotateRightLeft(node);
            }

            //if tree is a left-right rotation 
            else if (node.Balance() < 1 && (node.LeftChild.RightChild != null && node.LeftChild.LeftChild == null))
            {
                RotateLeftRight(node);
            }

        }

        public void RotateLeft(AVLnode<T> node)
        {
            AVLnode<T> child = node.RightChild;
            node.RightChild = null;
            if (node == Root)
            {
                Root = child;
                Root.SetRoot();
            }
            child.LeftChild = node;

        }

        public void RotateRight(AVLnode<T> node)
        {
            AVLnode<T> child = node.LeftChild;
            node.LeftChild = null;
            if (node == Root)
            {
                Root = child;
                Root.SetRoot();
            }
            child.RightChild = node;
        }

        public void RotateLeftRight(AVLnode<T> node)
        {
            //could just call other rotates
            RotateLeft(node.LeftChild);
            RotateRight(node);
        }

        public void RotateRightLeft(AVLnode<T> node)
        {
            //could just call other rotates
            RotateRight(node.RightChild);
            RotateLeft(node);
        }

    }
}
