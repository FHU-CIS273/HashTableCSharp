using System;
using System.Collections.Generic;
using System.Linq;

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
                int fullBuckets = listsOfBuckets.Count(l => l.Count > 0);

                return (double)fullBuckets / listsOfBuckets.Length;
            }
        }

        public HashTableChaining()
        {
        }
    }
}
