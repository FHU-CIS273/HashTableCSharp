using System;

namespace HashTable
{
    public enum BucketState
    {
        EmptySinceStart,
        EmptyAfterRemoval,
        Full
    }

    public class Bucket<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public BucketState State { get; set; }

        public Bucket()
        {
            State = BucketState.EmptySinceStart;
        }

        public Bucket(K key, V value)
        {
            Key = key;
            Value = value;

            if( key == null || value == null)
            {
                State = BucketState.EmptySinceStart;
            }
            else
            {
                State = BucketState.Full;
            }
        }

        public void Remove()
        {
            Key = default(K);
            Value = default(V);

            State = BucketState.EmptyAfterRemoval;
        }
    }
}
