using System;
using System.Collections;
using System.Collections.Generic;
class MyList<T> : IEnumerable<T>
{
    private T[] array;
    private int count;
    public int Count => count;
    public MyList()
    {
        array = new T[4];
        count = 0;
    }
    public void Add(T item)
    {
        if (count == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }
        array[count] = item;
        count++;
    }
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы списка.");
            }
            return array[index];
        }
        set
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы списка.");
            }
            array[index] = value;
        }
    }
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
    public IEnumerator<T> GetEnumerator()
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
        MyList<int> myList = new MyList<int>
        {
            1, 2, 3, 4, 5
        };
        myList.Add(6);
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }
        myList[0] = 200;
        Console.WriteLine("Первый элемент после изменения: " + myList[0]);
        Console.WriteLine("Общее количество элементов: " + myList.Count);
    }
}
