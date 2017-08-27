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


        public void Rotate(AVLnode<T> node)
        {
            //if its balanced ... balance will be -1, 0, 1
            if (node.Balance() == -1 || node.Balance() == 0 || node.Balance() == 1)
            {
                return;
            }

            //if tree is leaning towards right ... balance will be >1
            else if (node.Balance() > 1 && (node.RightChild.Balance() > 0))
            {
                AVLnode<T> parent = node.Parent;
                AVLnode<T> middle = node.RightChild;
                AVLnode<T> right = middle.RightChild;

                bool isroot = false;
                bool leftchild = false;
                Root.SetRoot();
                if (parent == null)
                {
                    isroot = true;
                }
                else
                {
                    if (parent.LeftChild == node)         //if we are a leftchild 
                    {
                        leftchild = true;
                    }
                    else if (parent.RightChild == node)   //if we are a rightchild
                    {
                        leftchild = false;
                    }
                }

                if (isroot == true)
                {
                    Root = middle;
                    Root.SetRoot();
                    node.RightChild = null;
                    Root.LeftChild = node;

                }
                else
                {
                    if (leftchild == true)    //leftchild
                    {
                        node.RightChild = null;
                        middle.LeftChild = node;
                        parent.LeftChild = middle;
                    }
                    else                      //rightchild
                    {
                        node.RightChild = null;
                        middle.LeftChild = node;
                        parent.RightChild = middle;

                    }
                }

            }

            //if tree is a right-left rotation
            else if (node.Balance() > 1 && (node.RightChild.Balance() < 0))
            {
                AVLnode<T> parent = node.Parent;
                AVLnode<T> middle = node.RightChild;
                AVLnode<T> bottom = middle.LeftChild;
                AVLnode<T> leftbaby = bottom.LeftChild;
                AVLnode<T> rightbaby = bottom.RightChild;
                Root.SetRoot();

                bool isroot = false;
                if (parent == null)
                {
                    isroot = true;
                }


                bottom.RightChild = middle;
                node.RightChild = bottom;


                //middle.parent = null;
                //middle.rightChild = null;
                //middle.leftChild = null;

                //middle.leftChild = newright.leftChild;
                //middle.rightChild = newright.rightChild;

                //middle.parent = newright;
                //newright.rightChild = middle;
                //node.rightChild = newright;
                //newright.parent = node;



                //newright.rightChild = middle;
                //middle.parent = newright;
                //middle.leftChild = newright.leftChild;
                //middle.rightChild = newright.rightChild;
                //node.rightChild = newright;
                //newright.parent = node;






                ////////this is so wrong... maybe i am reassigning in the wrong way. the tree is worse than before
                //node.leftChild = null;

                //middle.parent = null;
                //middle.rightChild = null;
                //middle.leftChild = null;

                //bottom.parent = null;
                //bottom.rightChild = null;
                //bottom.leftChild = null;

                //if (leftbaby != null)
                //{
                //    leftbaby.parent = null;
                //}

                //if (rightbaby != null)
                //{
                //    rightbaby.parent = null;
                //}



                //node.leftChild = bottom;
                //bottom.parent = node;
                //bottom.leftChild = middle;
                //middle.parent = bottom;
                //middle.leftChild = leftbaby;
                //middle.rightChild = rightbaby;






                Rotate(node);
            }


            //if tree is leaning towards left ... balance will be <1
            else if (node.Balance() < 1 && (node.LeftChild.Balance() < 0))
            {
                AVLnode<T> parent = node.Parent;
                AVLnode<T> middle = node.LeftChild;
                AVLnode<T> left = middle.LeftChild;

                bool isroot = false;
                bool leftchild = false;

                if (parent == null)
                {
                    isroot = true;
                }
                else
                {
                    if (parent.LeftChild == node)         //if we are a leftchild 
                    {
                        leftchild = true;
                    }
                    else if (parent.RightChild == node)   //if we are a rightchild
                    {
                        leftchild = false;
                    }
                }


                if (isroot == true)
                {
                    Root = middle;
                    node.LeftChild = null;
                    Root.RightChild = node;
                }
                else
                {
                    if (leftchild == true)   //leftchild
                    {
                        node.LeftChild = null;
                        middle.RightChild = node;
                        parent.LeftChild = middle;
                    }
                    else                      //rightchild 
                    {
                        node.LeftChild = null;
                        middle.RightChild = node;
                        parent.RightChild = middle;
                    }
                }
            }

            //if tree is a left-right rotation 
            else if (node.Balance() < 1 && (node.LeftChild.Balance() > 0))
            {
                AVLnode<T> parent = node.Parent;
                AVLnode<T> middle = node.LeftChild;
                AVLnode<T> newleft = middle.RightChild;

                bool isroot = false;
                if (parent == null)
                {
                    isroot = true;
                }

                newleft.LeftChild = middle;
                middle.LeftChild = newleft.LeftChild;
                middle.RightChild = newleft.RightChild;
                node.LeftChild = newleft;

                Rotate(node);
            }

        }
    }
}
