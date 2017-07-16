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


                while (current != null)
                {

                    //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                    if (current.Value.CompareTo(value) > 0)
                    {
                        if (current.leftChild == null)
                        {
                            current.leftChild = new AVLnode<T>(value);
                            current.leftChild.parent = current;
                            return;
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
                            return;
                        }

                        current = current.rightChild;
                    }
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

        public int Balance()
        {
            return Root.rightChild.Height - Root.leftChild.Height;
        }

    }
}
