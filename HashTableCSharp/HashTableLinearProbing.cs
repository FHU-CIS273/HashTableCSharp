using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class HashTableLinearProbing<K, V>
    {
        private Bucket<K, V>[] buckets;

        private const double MaxLoadFactor = 0.75;

        private int capacity = 10;

        public double LoadFactor {
            get
            {
                int fullBuckets = buckets.Count(b => b.State == BucketState.Full);

                /*int fullBuckets = 0;
                foreach( var b in buckets)
                {
                    if (b.State == BucketState.Full)
                    {
                        fullBuckets++;
                    }
                }*/

                return (double)fullBuckets / buckets.Length;
            }
        }

        public HashTableLinearProbing()
        {
            buckets = new Bucket<K, V>[capacity];

            for(int i=0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K,V>();
            }
        }


        public bool Add(K key, V value)
        {
            if( LoadFactor > MaxLoadFactor)
            {
                Resize();
            }

            // make a new Bucket to contain key, value
            Bucket<K,V> bucket = new Bucket<K, V>(key, value);

            // get hash of the key
            int hashValue = Hash(key);
            int initialBucketIndex = hashValue % capacity;
            int bucketIndex = initialBucketIndex;

            // find the right spot in the array
            while( buckets[bucketIndex].State == BucketState.Full  )
            {
                bucketIndex = (bucketIndex + 1) % capacity;

                if( bucketIndex == initialBucketIndex)
                {
                    // THIS SHOULD NEVER HAPPEN
                    return false;
                }
            }

            // put the new bucket at the "right spot" in the array
            buckets[bucketIndex] = bucket;

            return true;
        }

        // if key is not in hash table throw missing key exeception
        public bool Remove(K key)
        {
            // find bucket


            return true;
        }

        // if key is not in hash table throw missing key exeception
        public V Get(K key)
        {
            if(!ContainsKey(key))
            {
                throw new MissingKeyException();
            }


            return default(V);
        }


        public bool ContainsKey(K key)
        {

            return false;
        }

        public bool ContainsValue(V value)
        {
            foreach (var bucket in buckets)
            {
                if (bucket.State == BucketState.Full)
                {
                    if (bucket.Value.Equals(value)) {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<K> GetKeys()
        {
            var keys = new List<K>();

            foreach(var bucket in buckets)
            {
                if( bucket.State == BucketState.Full)
                {
                    keys.Add(bucket.Key);
                }
            }

            return keys;
        }

        public List<V> GetValues()
        {
            var values = new List<V>();

            foreach (var bucket in buckets)
            {
                if (bucket.State == BucketState.Full)
                {
                    values.Add(bucket.Value);
                }
            }

            return values;
        }



        private void Resize()
        {
            // create new array with double the capacity
            capacity = capacity * 2;
            var newArray = new Bucket<K, V>[capacity];

            // initialize all elements to empty buckets
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = new Bucket<K, V>();
            }

            // TODO 
            // rehash every bucket and save to new array


        }

        private int Hash(K key)
        {
            int hash = key.GetHashCode();

            return hash > 0 ? hash : -hash; 
        }
    }
}
