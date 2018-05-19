using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using binarySearchTrees;

namespace DataStructuresTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void RBroot()
        {
            RedBlackTree<int> rbtre = new RedBlackTree<int>();
            rbtre.Add(8);
            rbtre.Add(4);
            rbtre.Add(10);

            Assert.AreEqual(8, rbtre.Root.Value);
        }

        [TestMethod]
        public void RBleft()
        {
            RedBlackTree<int> rbtre = new RedBlackTree<int>();
            rbtre.Add(8);
            rbtre.Add(4);
            rbtre.Add(10);

            Assert.AreEqual(4, rbtre.Root.Left.Value);
        }

        [TestMethod]
        public void RBright()
        {
            RedBlackTree<int> rbtre = new RedBlackTree<int>();
            rbtre.Add(8);
            rbtre.Add(4);
            rbtre.Add(10);
            

            Assert.AreEqual(10, rbtre.Root.Right.Value);
        }
    }
}
