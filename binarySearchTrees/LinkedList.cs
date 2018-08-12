using System;

namespace binarySearchTrees
{
    public class LinkedList<T> where T : IComparable
    {
        Node<T> head;
        public int Size;

        public Node<T> First
        {
            get
            {
                return head;
            }
        }

        public Node<T> Last
        {
            get
            {
                return head.lastNode;
            }
        }

        public void Add(T value)
        {
            //if head is null, insert and move on
            if (head == null)
            {
                head = new Node<T>(value);
                head.nextnode = head;
                head.lastNode = head;
                return;
            }

            //if head isn't null find the end of list
            if (head != null)
            {
                //make a temp value
                Node<T> temp = head;

                //you can move back instead of iterating forward
                //while the nextnode is the head then keep going through the list
                while (temp.nextnode != head)
                {
                    temp = temp.nextnode;
                }

                temp.nextnode = new Node<T>(value);

                temp.nextnode.nextnode = head;
                head.lastNode = temp.nextnode;
                temp.nextnode.lastNode = temp;
            }

            Size++;
        }

        public void AddAfter(T value, int index)
        {
            Node<T> temp = head;
            int count = 0; //should be 0

            //find the index to place the newNode after
            while (count < index - 1)
            {
                temp = temp.nextnode;
                count++;
            }

            //just creating a name for the new node
            Node<T> newNode = new Node<T>(value);

            //setting the newNode's nextnode and lastnode
            newNode.nextnode = temp.nextnode;
            newNode.lastNode = temp;

            //connecting the newNode's nextnode and lastnode to the newNode
            temp.nextnode.lastNode = newNode;
            temp.nextnode = newNode;

            Size++;
        }

        public void AddBefore(T value, int index)
        {
            Node<T> temp = head;
            int count = 0; //should be 0

            //find the index to place the newNode after
            while (count < index - 1)
            {
                temp = temp.nextnode;
                count++;
            }

            //just creating a name for the new node
            Node<T> newNode = new Node<T>(value);

            //setting the newNode's nextnode and lastnode 
            newNode.nextnode = temp;
            newNode.lastNode = temp.lastNode;

            //connecting the newNode's nextnode and lastnode to the newNode
            temp.lastNode.nextnode = newNode;
            temp.lastNode = newNode;

            Size++;
        }

        public void AddToStart(T value)
        {
            if (head == null)
            {
                Add(value);
            }

            else
            {
                //just creating a name for the new node
                Node<T> newNode = new Node<T>(value);

                //setting the newNode's nextnode and lastnode 
                newNode.nextnode = head;
                newNode.lastNode = head.lastNode;

                //connecting the newNode's nextnode and lastnode to the newNode
                head.lastNode.nextnode = newNode;
                head.lastNode = newNode;

                //changing the head to the newNode
                head = newNode;
            }
            

            Size++;
        }

        public void Delete(T value)
        {
            Node<T> temp = head;

            //if the head is the only one in the list
            if (head.lastNode == head && head.nextnode == head && head.Value.CompareTo(value) == 0)
            {
                head = null;
                return;
            }

            //after loop we are either at the head of the list or we found the value to remove
            while (temp.nextnode != head && temp.Value.CompareTo(value) != 0)
            {
                temp = temp.nextnode;
            }

            //if the nextNode is head set the second to last nodes lastNode to null
            if (temp.nextnode == head)
            {
                temp.lastNode.nextnode = null;
            }

            //if we found the value then
            if (temp.Value.CompareTo(value) == 0)
            {
                temp.nextnode.lastNode = temp.lastNode;
                temp.lastNode.nextnode = temp.nextnode;

                //if the node is the head
                if (temp == head)
                {
                    temp.nextnode.lastNode = head.lastNode;
                    head = temp.nextnode;
                }
            }

            Size--;
        }

        public void DeleteLast()
        {
            if (head.nextnode == head)
            {
                head = null;
            }
            else
            {
                //setting head's lastNode
                head.lastNode = head.lastNode.lastNode;

                //setting the new tail's nextnode
                head.lastNode.nextnode = head;
            }
            
            Size--;
        }

        public void DeleteAllInstances(T value)
        {
            Node<T> temp = head;

            while (temp.nextnode != head)
            {
                temp = temp.nextnode;
                Delete(value);
            }

        }

        public void Clear()
        {
            head = null;

            Size = 0;
        }

        public bool Find(int value)
        {
            Node<T> temp = head;

            //going through the list until you come back to the head or find the value
            while (temp.nextnode != head && temp.Value.CompareTo(value) != 0)
            {
                temp = temp.nextnode;
            }

            //if you find the number then output true
            if (temp.Value.CompareTo(value) == 0)
            {
                return true;
            }

            //if you are at the head again aka if you did not find the value then output false
            else
            {
                return false;
            }
        }
    }
}
