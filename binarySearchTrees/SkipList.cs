using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class SkipList<T> : ICollection<T> where T : IComparable
    {
        Random rand = new Random(7);
        SkipListNode<T> head;
        public int maxHeight => head.Height + 1;

        public SkipList()
        {
            SkipListNode<T> actualHead = new SkipListNode<T>(default(T), 1);
            actualHead.neighbors = new SkipListNode<T>[1];
            head = actualHead;
        }

        public int ChooseRandomHeight(int max)
        {
            int headORtail = rand.Next(0, 2);
            int height = 1;

            while (headORtail != 1 && height < max)
            {
                //heads
                height++;
                headORtail = rand.Next(0, 2);
            }

            //tails
            return height;
        }

        public void Add(T value)
        {
            int theHeight = ChooseRandomHeight(maxHeight);

            if (theHeight > head.Height)
            {
                //resize the array
                SkipListNode<T>[] temp = new SkipListNode<T>[theHeight];
                for (int i = 0; i < head.Height; i++)
                {
                    temp[i] = head.neighbors[i];
                }
                head.neighbors = temp;
            }


            SkipListNode<T> toInsert = new SkipListNode<T>(value, theHeight);
            for (int level = 0; level < theHeight; level++)
            {
                SkipListNode<T> temp = head;
                while (temp.neighbors[level] != null && temp.neighbors[level].Value.CompareTo(value) < 0)
                {
                    temp = temp.neighbors[level];
                }
                if (temp.neighbors[level] != null)
                {
                    toInsert.neighbors[level] = temp.neighbors[level];
                }
                temp.neighbors[level] = toInsert;
            }
        }

        public void Clear()
        {
            head = null;
        }

        bool ICollection<T>.Contains(T value)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] list, int index)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get { return head.Height; }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T value)
        {
            bool hasRemoved = false;
            int theHeight = head.Height - 1;
            SkipListNode<T> temp = head;
            for (int level = theHeight; level >= 0; level--)
            {
                while (temp.neighbors[level] != null && temp.neighbors[level].Value.CompareTo(value) < 0)
                {
                    temp = temp.neighbors[level];
                }
                if (temp.neighbors[level] != null && temp.neighbors[level].Value.CompareTo(value) == 0)
                {
                    temp.neighbors[level] = temp.neighbors[level].neighbors[level];
                    hasRemoved = true;
                }
            }

            return hasRemoved;
        }

        bool ICollection<T>.Remove(T item)
        {
            return Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
