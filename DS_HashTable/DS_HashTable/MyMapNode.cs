using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_HashTable
{
    /// <summary>
    /// To initialize values
    /// </summary>
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValuePair<K, V>>[size];
        }

        /// <summary>
        /// Method to get array position by getting HashCode
        /// </summary>
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        /// <summary>
        /// Method to find the stored location index of key
        /// </summary>
        public V Get (K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValuePair<K, V> item in linkedlist)
            {
                if(item.Key.Equals (key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        /// <summary>
        /// Method to add
        /// </summary>
        public void Add(K key , V value)
        {
            int position = GetArrayPosition (key);
            LinkedList<KeyValuePair<K , V>> linkedlist = GetLinkedList (position);
            //object of keyvalue
            //object initialization at once
            KeyValuePair<K, V> item = new KeyValuePair<K, V>() { Key = key, Value = value };
            linkedlist.AddLast(item);
        }

        /// <summary>
        /// Method to Delete
        /// </summary>
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K,V>> linkedlist = GetLinkedList(position);
            bool itemfound = false;
            KeyValuePair<K, V> FoundItem = default(KeyValuePair<K,V>);
            foreach (KeyValuePair<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    itemfound = true;
                    FoundItem = item;
                }
            }
            if (itemfound)
            {
                linkedlist.Remove(FoundItem);
            }
        }

        /// <summary>
        /// GetLinkedList for return type for linkedlist Key-Value pair
        /// </summary>
        protected LinkedList<KeyValuePair<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValuePair<K, V>> linkedlist = items[position];
            if(linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValuePair<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
    }

    /// <summary>
    /// class for key value pair
    /// </summary>
    public struct KeyValuePair<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
}
