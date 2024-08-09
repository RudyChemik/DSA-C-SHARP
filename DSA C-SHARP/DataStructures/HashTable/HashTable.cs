using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.HashTable
{
    /// <summary>
    /// HashTable implementation where k is key and type t is value represantation
    /// </summary>
    public class HashTable<K, T>
    {
        //Def cap of the hashtable
        private const int DefaultCapacity = 8;
        //Def load factor, will be used as a threshold for rezising, it is more conventionall to use 0.75f
        private const float Load = 0.5f;

        private LinkedList<KeyValuePair<K, T>>[] buckets;

        // Number of pairs in hashtable (pair as key-value).
        private int count;

        private readonly float load;
        private int capacity;

        /// <summary>
        /// Constructor of hashtable
        /// </summary>
        /// <param name="capacity">If not provided def cap will be used.</param>>
        /// /// <param name="loadFactor">If not provided def load will be used.</param>>
        public HashTable(int capacity = DefaultCapacity, float loadFactor = Load)
        {
            //Cap cant be lower than zero for obv reasons.
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "must be greater than 0");
            }

            //Load factor need to be beetwen 0-1 values as for 0-100% load.
            if (loadFactor <= 0 || loadFactor > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(loadFactor), "must be greater than 0 and less than 1");
            }

            // Initialize variables with the provided or default values
            this.capacity = capacity;
            this.load = loadFactor;
            buckets = new LinkedList<KeyValuePair<K, T>>[capacity];
            count = 0;
        }

        /// <summary>
        /// Calculating index value based on given key
        /// </summary>
        /// <param name="key">Key to calculate</param>
        /// <returns>The index of the bucket where the pair should be stored</returns>
        private int GetBucketIndex(K key)
        {
            // Use the hash code of the key and ensure it's positive, then take modulo by capacity
            // 0x7FFFFFFF is a bitmask that clears the sign bit (in case its negative)
            return (key.GetHashCode() & 0x7FFFFFFF) % capacity;
        }

        /// <summary>
        /// Adding to the hashtable
        /// </summary>
        /// <param name="key">Key to add</param>
        /// <param name="value">Value to add</param>
        public void Add(K key, T value)
        {
            // If the num of elems exceeded -> resize.
            if (count >= capacity * load)
            {
                Resize();
            }

            // Get the index for provided key.
            int bucketIndex = GetBucketIndex(key);

            // if the bucket is empty, init new one
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new LinkedList<KeyValuePair<K, T>>();
            }

            // Check if the key alrd exists in the bucket
            foreach (var pair in buckets[bucketIndex])
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("SAME KEY!");
                }
            }

            //add to the bucket
            buckets[bucketIndex].AddLast(new KeyValuePair<K, T>(key, value));
            count++;
        }

        /// <summary>
        /// Remove from hash table
        /// </summary>
        /// <param name="key">Key to remove</param>
        public bool Remove(K key)
        {
            //get the bucket index
            int bucketIndex = GetBucketIndex(key);
            
            if (buckets[bucketIndex] != null)
            {
                var node = buckets[bucketIndex].First;
                while (node != null)
                {
                    // If the key is found, remove the node from the list
                    if (node.Value.Key.Equals(key))
                    {
                        buckets[bucketIndex].Remove(node);
                        count--;
                        return true;
                    }
                    node = node.Next;
                }
            }

            //key not found
            return false;
        }

        /// <summary>
        /// Tries to Get the value by the key.
        /// </summary>
        /// <param name="key">Used for searching</param>
        /// <param name="value">Value searched for</param>
        public bool TryGetValue(K key, out T value)
        {
            int bucketIndex = GetBucketIndex(key);

            if (buckets[bucketIndex] != null)
            {
                foreach (var pair in buckets[bucketIndex])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }
            value = default;
            return false;
        }

        /// <summary>
        /// Resizing the hashtable cap
        /// </summary>
        private void Resize()
        {
            //Calc new cap 
            int newCapacity = capacity * 2;
            //new linkedlist with new cap
            var newBuckets = new LinkedList<KeyValuePair<K, T>>[newCapacity];

            // Rehash
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        // Calculate the new bucket for each key
                        int newBucketIndex = (pair.Key.GetHashCode() & 0x7FFFFFFF) % newCapacity;

                        if (newBuckets[newBucketIndex] == null)
                        {
                            newBuckets[newBucketIndex] = new LinkedList<KeyValuePair<K, T>>();
                        }
                        // Add pair to the new bucket
                        newBuckets[newBucketIndex].AddLast(pair);
                    }
                }
            }

            // Replace the old bucket array with the new one and update the cap
            buckets = newBuckets;
            capacity = newCapacity;
        }
    }
}
