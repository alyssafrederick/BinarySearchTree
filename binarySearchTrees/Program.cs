﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> alyssaList = new LinkedList<int>();

            LinkedList<string> stringList = new LinkedList<string>();

            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            Stack<int> stack = new Stack<int>();

            Queue<int> Q = new Queue<int>();

            //stack.Push(2);
            //stack.Push(6);
            //stack.Push(19);
            //stack.Push(14);
            //stack.Pop();
            //stack.Peek();

            //Q.Enqueue(5);
            //Q.Enqueue(7);
            //Q.Enqueue(90);
            //Q.Enqueue(57);
            //Q.Dequeue();



            bst.Add(17);
            bst.Add(20);
            bst.Add(10);
            bst.Add(15);
            bst.Add(12);
            bst.Add(16);
            bst.Add(5);
            bst.Add(6);
            bst.Add(8);
            bst.Add(18);
            bst.Add(19);
            bst.Add(54);

            bst.TraverseInOrder(bst.Root);
            Console.WriteLine("\n");
            bst.TraversePreOrder(bst.Root);
            Console.WriteLine("\n");
            bst.TraversePostOrder(bst.Root);
            Console.WriteLine("\nTraverse starts here");
            bst.TraverseLevelOrder();

            //bst.Maximum();
            //bst.Remove(54);
            //bst.Maximum();

            //stringList.Add("hi");
            //stringList.Add("hey");
            //stringList.Add("hello");
            //stringList.AddAfter("hellooo", 2);



            //alyssaList.Add(1);
            //alyssaList.Add(2);
            //alyssaList.AddToStart(6);
            //alyssaList.Add(3);
            //alyssaList.DeleteLast();
            //alyssaList.Add(4);
            //alyssaList.AddAfter(8, 3);
            //alyssaList.Add(5);
            //alyssaList.AddBefore(7, 2);
            //alyssaList.Add(9);
            // 6 7 1 2 8 4 5 9 YAY



            //////////testing Find and DeleteAllInstances
            //if (alyssaList.Find(3) == true)
            //{
            //    Console.WriteLine("true");
            //}
            //else
            //{
            //    Console.WriteLine("false");
            //}

            //alyssaList.DeleteAllInstances(3);

            //if (alyssaList.Find(3) == true)
            //{
            //    Console.WriteLine("true");
            //}
            //else
            //{
            //    Console.WriteLine("false");
            //}



            Console.ReadLine();

            //for (int i = 0; i < 10; i++)
            //{
            //    alyssaList.Add(i + 1);
            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    alyssaList.Delete(i + 1);
            //}

            //alyssaList.Add(7);
            //alyssaList.Add(90);
        }
    }
}