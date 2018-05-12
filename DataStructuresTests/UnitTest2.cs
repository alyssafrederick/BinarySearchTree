using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using binarySearchTrees;

namespace DataStructuresTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            RedBlackTree<int> rbtre = new RedBlackTree<int>();
            rbtre.Add(8);
            rbtre.Add(4);
            rbtre.Add(10);

            Assert.AreEqual(8, rbtre.Root.Value);

        }
    }
}
