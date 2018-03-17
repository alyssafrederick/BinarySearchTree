using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class RedBlackTree<T> where T : IComparable
    {
        public void FlipColor(RedBlackNode<T> node)
        {
            node.Red = !node.Red;
            if (node.Right != null)
            {
                node.Right.Red = !node.Red;
            }
            if (node.Left != null)
            {
                node.Left.Red = !node.Red;
            }
        }

        public void Add(T value)
        {

        }
    }
}
