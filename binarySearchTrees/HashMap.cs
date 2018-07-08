using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue> where TValue : IComparable
    {
        System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>>[] head = new System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>>[10];
        public int length => head.Length;
        public int itemNumber = 0;

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get { return length; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEqualityComparer<KeyValuePair<TKey, TValue>> Comparer
        {

            get;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(TKey key, TValue value)
        {
            //make a resize

            int hashCode = key.GetHashCode();
            int Index2Insert = hashCode % length;

            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);

            if (head[Index2Insert] == null)
            {
                //insert a new linked list into the array
                System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>> linkedList = new System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>>();
                head[Index2Insert] = linkedList;
                head[Index2Insert].AddFirst(pair);
            }
            else
            {
                //insert the value into the already there linked list
                if (head[Index2Insert].Contains(pair))
                {
                    throw new Exception("you inserted a duplicate and that is not allowed");
                }
                else
                {
                    head[Index2Insert].AddFirst(pair);
                }
            }

            itemNumber++;
        }

        public void Clear()
        {
            head = null;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
