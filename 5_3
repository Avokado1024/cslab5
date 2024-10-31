using System;
using System.Collections;
using System.Collections.Generic;
class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private KeyValuePair<TKey, TValue>[] array;
    private int count;
    public int Count => count;
    public MyDictionary()
    {
        array = new KeyValuePair<TKey, TValue>[4];
        count = 0;
    }
    public void Add(TKey key, TValue value)
    {
        if (ContainsKey(key))
        {
            throw new ArgumentException("Ключ уже существует в словаре.");
        }

        if (count == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }

        array[count] = new KeyValuePair<TKey, TValue>(key, value);
        count++;
    }
    public TValue this[TKey key]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Key.Equals(key))
                {
                    return array[i].Value;
                }
            }
            throw new KeyNotFoundException("Ключ не найден в словаре.");
        }
        set
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Key.Equals(key))
                {
                    array[i] = new KeyValuePair<TKey, TValue>(key, value);
                    return;
                }
            }
            throw new KeyNotFoundException("Ключ не найден в словаре.");
        }
    }
    private bool ContainsKey(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i].Key.Equals(key))
            {
                return true;
            }
        }
        return false;
    }
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return array[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class Program
{
    static void Main()
    {
        MyDictionary<string, int> myDict = new MyDictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        myDict.Add("four", 4);
        foreach (var kvp in myDict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        Console.WriteLine("Значение для ключа 'two': " + myDict["two"]);
        myDict["two"] = 22;
        Console.WriteLine("Значение для ключа 'two' после изменения: " + myDict["two"]);
        Console.WriteLine("Общее количество элементов: " + myDict.Count);
    }
}
