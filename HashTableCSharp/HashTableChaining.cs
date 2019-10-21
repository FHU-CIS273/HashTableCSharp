using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTableChaining<K, V> : IHashTable<K,V>
    {
        private LinkedList< Bucket<K,V> >[] listsOfBuckets;

        private const double MaxLoadFactor = 0.75;

        private int capacity = 10;

        public double LoadFactor
        {
            get
            {
                int fullBuckets = buckets.Count(b => b.State == BucketState.Full);

                return (double)fullBuckets / buckets.Length;
            }
        }

        public HashTableChaining()
        {
        }
    }
}
