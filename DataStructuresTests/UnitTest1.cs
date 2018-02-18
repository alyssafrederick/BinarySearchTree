using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using binarySearchTrees;

namespace DataStructuresTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AVLTreeConstructorTest()
        {
            AVLtree<int> practice = new AVLtree<int>();
            Assert.AreNotEqual(null, practice.Root);



        }

        [TestMethod]
        public void dfkjdf()
        {
            AVLtree<int> practice = new AVLtree<int>();
            practice.Add(9);
            Assert.AreEqual(9, practice.Root.Value);
        }
    }
}
