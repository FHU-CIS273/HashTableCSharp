using System;

namespace HashTable
{
    public class HashTableLinearProbing<K, V>
    {
        private Bucket<K, V>[] buckets;

        private int capacity = 10;

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

        private int Hash(K key)
        {
            return key.GetHashCode();
        }
    }
}
