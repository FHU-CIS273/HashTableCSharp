using System;
using System.Collections.Generic;

namespace HashTable
{
    public interface IHashTable<K,V>
    {
        bool ContainsKey(K key);
        bool ContainsValue(V value);

        bool Add(K key, V value);
        bool Remove(K key);
        V Get(K key);

        List<K> GetKeys();
        List<V> GetValues();

    }
}
