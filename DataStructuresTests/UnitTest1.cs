using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using binarySearchTrees;

namespace DataStructuresTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void rightLeftRotation()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(1);
            practice.Add(3);
            practice.Add(2);
            Assert.AreEqual(2, practice.Root.Value);
        }

        [TestMethod]
        public void rrRoot()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(1);
            prac.Add(2);
            prac.Add(3);
            Assert.AreEqual(2, prac.Root.Value);
        }
        [TestMethod]
        public void rrLeft()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(1);
            prac.Add(2);
            prac.Add(3);
            Assert.AreEqual(1, prac.Root.LeftChild.Value);
        }
        [TestMethod]
        public void rrRight()
        {
            AVLtree<int> prac = new AVLtree<int>();
            prac.Add(1);
            prac.Add(2);
            prac.Add(3);
            Assert.AreEqual(3, prac.Root.RightChild.Value);
        }


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
