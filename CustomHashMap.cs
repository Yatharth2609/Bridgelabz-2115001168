using System;
using System.Collections.Generic;

public class CustomHashMap<K, V>
{
    private const int Capacity = 16;
    private LinkedList<KeyValuePair<K, V>>[] buckets;

    public CustomHashMap()
    {
        buckets = new LinkedList<KeyValuePair<K, V>>[Capacity];
    }

    private int GetBucketIndex(K key)
    {
        return Math.Abs(key.GetHashCode()) % Capacity;
    }

    public void Put(K key, V value)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null)
        {
            buckets[index] = new LinkedList<KeyValuePair<K, V>>();
        }

        var bucket = buckets[index];
        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
            {
                bucket.Remove(pair);
                break;
            }
        }

        bucket.AddLast(new KeyValuePair<K, V>(key, value));
    }

    public V Get(K key)
    {
        int index = GetBucketIndex(key);
        var bucket = buckets[index];
        if (bucket != null)
        {
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }
        throw new KeyNotFoundException();
    }

    public void Remove(K key)
    {
        int index = GetBucketIndex(key);
        var bucket = buckets[index];
        if (bucket != null)
        {
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    bucket.Remove(pair);
                    return;
                }
            }
        }
        throw new KeyNotFoundException();
    }
}

class Program
{
    static void Main()
    {
        CustomHashMap<string, int> map = new CustomHashMap<string, int>();
        map.Put("one", 1);
        map.Put("two", 2);
        Console.WriteLine(map.Get("one"));
        map.Remove("two");
    }
}