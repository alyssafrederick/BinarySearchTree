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

            HeapifyUp(value);
        }

        public void HeapifyUp(T value)
        {
            
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
