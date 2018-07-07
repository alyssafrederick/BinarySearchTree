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
        Random rand = new Random();
        SkipListNode<T> head;
        public int maxHeight => head.Height + 1;

        public SkipList()
        {
            SkipListNode<T> actualHead = new SkipListNode<T>(default(T), 1);
            actualHead.neighbors = new SkipListNode<T>[1];
            head = actualHead;
        }


        //SkipListNode<T> startNode = new SkipListNode<T>(default(T));

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

            for (int i = 0; i < theHeight; i++)
            {
                SkipListNode<T> temp = head;
                while (temp.neighbors[i] != null)
                {
                    temp = temp.neighbors[i];
                }

                temp.neighbors[i] = toInsert;
            }


            //resize
            //SkipListNode<T>[] temp = new SkipListNode<T>[ChooseRandomHeight(maxHeight)];
            //for (int i = 0; i < ChooseRandomHeight(maxHeight); i++)
            //{
            //    temp[i] = head.neighbors[i];
            //}
            //head.neighbors = temp;



            // toInsert.height = ChooseRandomHeight(1);
            //     head.neighbors[0] = toInsert;



            //toInsert.height = ChooseRandomHeight(1);

        }

        public void Clear()
        {
            head = null;
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] list, int index)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            //throw new NotImplementedException();
            get { return head.Height; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Remove(T value)
        {

        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
