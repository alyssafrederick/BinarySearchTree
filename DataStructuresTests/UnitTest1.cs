using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using binarySearchTrees;

namespace DataStructuresTests
{
    [TestClass]
    public class UnitTest1
    {
        //testing right left rotation
        [TestMethod]
        public void rlrRoot()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(1);
            practice.Add(3);
            practice.Add(2);
            Assert.AreEqual(2, practice.Root.Value);
        }
        [TestMethod]
        public void rlrRight()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(1);
            practice.Add(3);
            practice.Add(2);
            Assert.AreEqual(3, practice.Root.RightChild.Value);
        }
        [TestMethod]
        public void rlrLeft()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(1);
            practice.Add(3);
            practice.Add(2);
            Assert.AreEqual(1, practice.Root.LeftChild.Value);
        }


        //testing left right rotation
        [TestMethod]
        public void lrrRoot()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(3);
            practice.Add(1);
            practice.Add(2);
            Assert.AreEqual(2, practice.Root.Value);
        }
        [TestMethod]
        public void lrrRight()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(3);
            practice.Add(1);
            practice.Add(2);
            Assert.AreEqual(3, practice.Root.RightChild.Value);
        }
        [TestMethod]
        public void lrrLeft()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(3);
            practice.Add(1);
            practice.Add(2);
            Assert.AreEqual(1, practice.Root.LeftChild.Value);
        }


        //testing right rotation when node==root
        [TestMethod]
        public void rrRoot()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(3);
            prac.Add(2);
            prac.Add(1);
            Assert.AreEqual(2, prac.Root.Value);
        }
        [TestMethod]
        public void rrLeft()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(3);
            prac.Add(2);
            prac.Add(1);
            Assert.AreEqual(1, prac.Root.LeftChild.Value);
        }
        [TestMethod]
        public void rrRight()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(3);
            prac.Add(2);
            prac.Add(1);
            Assert.AreEqual(3, prac.Root.RightChild.Value);
        }


        //testing left rotation when node==root
        [TestMethod]
        public void lrRoot()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(1);
            prac.Add(2);
            prac.Add(3);
            Assert.AreEqual(2, prac.Root.Value);
        }
        [TestMethod]
        public void lrLeft()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(1);
            prac.Add(2);
            prac.Add(3);
            Assert.AreEqual(1, prac.Root.LeftChild.Value);
        }
        [TestMethod]
        public void lrRight()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(1);
            prac.Add(2);
            prac.Add(3);
            Assert.AreEqual(3, prac.Root.RightChild.Value);
        }


    }
}
