using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class Heap<T> where T : IComparable
    {
        //min heap 
        public T[] Root;
        public int Size = 0;

        public Heap()
        {
            //set the array to have 30 slots so we don't have to constantly resize
            Root = new T[30];
        }


        /*
        public T Parent (int index)
        {
            get
            {
                return Root[(Size - 2) / 2];
            }
            set
            {
                Root[(Size - 2) / 2] = value;
            }
        }*/

        public T Parent(int index)
        {
            return Root[(index - 2) / 2];
        }

        public void Add(T value)
        {
            Size++;
            if (Size >= Root.Length)
            {
                //double the slots in the array when we reach that amount
                Resize(Root.Length * 2);
            }
            //adding value to the next available slot
            Root[Size - 1] = value;

            int valuesIndex = 0;
            while (Root[valuesIndex].CompareTo(value) != 0)
            {
                valuesIndex++;
            }

            while (Parent(valuesIndex).CompareTo(value) > 0)
            {
                HeapifyUp(value);
            }
        }

        public void HeapifyUp(T value)
        {
            int valuesIndex = 0;
            while (Root[valuesIndex].CompareTo(value) != 0)
            {
                valuesIndex++;
            }

            if (Parent(valuesIndex).CompareTo(value) > 0)
            {
                //switching value and its parent
                Root[Size - 1] = Parent(valuesIndex);
                Root[(valuesIndex - 2) / 2] = value;
            }
        }

        private void Resize(int size)
        {
            T[] temp = new T[size];
            if (size > 1)
            {
                for (int i = 0; i < size; i++)
                {
                    temp[i] = Root[i];
                }
            }
            Root = temp;
        }
    }
}
