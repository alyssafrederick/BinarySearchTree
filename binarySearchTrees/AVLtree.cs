using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    class AVLtree<T> where T : IComparable
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
                AVLnode<T> current = Root;
                Stack<AVLnode<T>> stack = new Stack<AVLnode<T>>();

                while (current != null)
                {
                    stack.Push(current);

                    //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                    if (current.Value.CompareTo(value) > 0)
                    {
                        if (current.leftChild == null)
                        {
                            current.leftChild = new AVLnode<T>(value);
                            current.leftChild.parent = current;
                            break;
                        }

                        current = current.leftChild;

                    }
                    //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                    else if (current.Value.CompareTo(value) <= 0)
                    {
                        if (current.rightChild == null)
                        {
                            current.rightChild = new AVLnode<T>(value);
                            current.rightChild.parent = current;
                            break;
                        }

                        current = current.rightChild;
                    }
                }

                while (stack.IsEmpty == false)
                {
                    Rotate(stack.Pop());
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

                        current = current.leftChild;
                    }

                    //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                    else if (current.Value.CompareTo(value) <= 0)
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            nodeToRemove = current;
                        }

                        current = current.rightChild;
                    }
                }

                if (nodeToRemove != null)
                {
                    if (nodeToRemove.leftChild == null && nodeToRemove.rightChild == null)
                    {
                        //if the nodeToRemove is a left child then delete the parents connection to the left child
                        if (nodeToRemove.parent.leftChild == nodeToRemove)
                        {
                            nodeToRemove.parent.leftChild = null;
                        }

                        //if the nodeToRemove is a right child then delete the parents connection to the right child 
                        else if (nodeToRemove.parent.rightChild == nodeToRemove)
                        {
                            nodeToRemove.parent.rightChild = null;
                        }

                        nodeToRemove.parent = null;
                    }

                    //if the nodeToRemove only has a rightchild
                    else if (nodeToRemove.leftChild == null)
                    {
                        nodeToRemove.rightChild.parent = nodeToRemove.parent;
                        nodeToRemove.parent.leftChild = nodeToRemove.rightChild;

                    }

                    //if the nodeToRemove only has a leftchild
                    else if (nodeToRemove.rightChild == null)
                    {
                        nodeToRemove.leftChild.parent = nodeToRemove.parent;
                        nodeToRemove.parent.rightChild = nodeToRemove.leftChild;
                    }

                    //if the nodeToRemove has both a leftchild and a rightchild
                    else
                    {
                        bool movedRight = false;

                        current = nodeToRemove.leftChild;

                        while (current.rightChild != null)
                        {
                            current = current.rightChild;
                            movedRight = true;
                        }

                        if (movedRight == true)
                        {
                            current.leftChild = nodeToRemove.leftChild;
                            current.leftChild.parent = current;
                        }

                        //if the node is as leftchild
                        if (nodeToRemove.parent.leftChild == nodeToRemove)
                        {
                            current.parent = nodeToRemove.parent;
                            nodeToRemove.parent.leftChild = current;
                        }

                        //if the node is a rightchild
                        else if (nodeToRemove.parent.rightChild == nodeToRemove)
                        {
                            current.parent = nodeToRemove.parent;
                            nodeToRemove.parent.rightChild = current;
                        }

                        current.rightChild = nodeToRemove.rightChild;
                        current.rightChild.parent = current;



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

                    current = current.leftChild;
                }

                //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                else if (current.Value.CompareTo(value) <= 0)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        //Console.WriteLine(current.Value);
                        return current;
                    }

                    current = current.rightChild;
                }
            }

            return null;
        }


        public void Rotate(AVLnode<T> node)
        {
            //if its balanced ... balance will be -1, 0, 1
            if (node.Balance() == -1 || node.Balance() == 0 || node.Balance() == 1)
            {
                return;
            }

            //if tree is leaning towards right ... balance will be >1
            else if (node.Balance() > 1)
            {
                AVLnode<T> parent = node.parent;
                AVLnode<T> middle = node.rightChild;
                AVLnode<T> right = middle.rightChild;

                bool isroot = false;
                bool leftchild = false;

                if (parent == null)
                {
                    isroot = true;
                }
                else
                {
                    if (parent.leftChild == node)         //if we are a leftchild 
                    {
                        leftchild = true;
                    }
                    else if (parent.rightChild == node)   //if we are a rightchild
                    {
                        leftchild = false;
                    }
                }

                if (isroot == true)
                {
                    Root = middle;
                    node.rightChild = null;
                    Root.leftChild = node;
                    node.parent = Root;
                }
                else
                {
                    if (leftchild == true)    //leftchild
                    {
                        node.rightChild = null;
                        middle.leftChild = node;
                        node.parent = middle;
                        parent.leftChild = middle;                      
                        middle.parent = parent;
                    }
                    else                      //rightchild
                    {
                        node.rightChild = null;
                        middle.leftChild = node;
                        node.parent = middle;
                        parent.rightChild = middle;                   
                        middle.parent = parent;

                    }
                }

            }

            //if tree is leaning towards left ... balance will be <1
            else
            {
                AVLnode<T> parent = node.parent;
                AVLnode<T> middle = node.leftChild;
                AVLnode<T> left = middle.leftChild;

                bool isroot = false;
                bool leftchild = false;

                if (parent == null)
                {
                    isroot = true;
                }
                else
                {
                    if (parent.leftChild == node)         //if we are a leftchild 
                    {
                        leftchild = true;
                    }
                    else if (parent.rightChild == node)   //if we are a rightchild
                    {
                        leftchild = false;
                    }
                }


                if (isroot == true)
                {
                    Root = middle;
                    node.leftChild = null;
                    Root.rightChild = node;
                    node.parent = Root;
                }
                else
                {
                    if (leftchild == true)   //leftchild
                    {
                        node.leftChild = null;
                        middle.rightChild = node;
                        node.parent = middle;
                        parent.leftChild = middle;
                        middle.parent = parent;
                    }
                    else                      //rightchild 
                    {
                        node.leftChild = null;
                        middle.rightChild = node;
                        node.parent = middle;
                        parent.rightChild = middle;
                        middle.parent = parent;
                    }
                }

            }
        }
    }
}
