using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Array<T>
{
    public int size { get; set; }
    public T[] list { get; set; }

    public Array(int Size)
    {
        this.size = Size;
        this.list = new T[size];
    }
    public void AddElement()
    {
        Console.WriteLine("Введите элемент, который хотите добавить");
        var input = Console.ReadLine();
        T n = (T)Convert.ChangeType(input, typeof(T));

        int lastNonNullIndex = -1;
        for (int i = list.Length - 1; i >= 0; i--)
        {
            if (EqualityComparer<T>.Default.Equals(list[i], default(T))) // колхоз, нужный для обхода ограничения по null
            {
                lastNonNullIndex = i;
                break;
            }
        }
        if (lastNonNullIndex != -1)
        {
            list[lastNonNullIndex] = n;
        }
        else
        {
            Console.WriteLine("Ошибка: массив полон, нельзя добавить новый элемент.");
        }
        Console.WriteLine($"Получившийся массив: {string.Join(",", list)}");

    }
    public void IndexOutput()
    {
        Console.WriteLine("Введите индекс элемента для вывода");
        var n = Convert.ToInt32(Console.ReadLine());
        if (n >= size) { Console.WriteLine("Ошибка: выход за пределы массива"); }
        for (int i = 0; i < list.Length; i++)
        {
            if (i == n) { Console.WriteLine($"Элемент с индексом {n}: {list[i]}"); }
        }
    }
    public void DeleteElement()
    {
        Console.WriteLine("Введите индекс элемента для удаления");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < list.Length; i++)
        {
            if (i == list.Length - 1) { list[list.Length - 1] = default(T); break; }
            if (i >= n) { list[i] = list[i + 1]; }
        }
        Console.WriteLine($"Получившийся массив: {string.Join(",", list)}");
    }
}
class App
{
    public static void Main()
    {
        Array<int> array = new Array<int>(5);
        array.AddElement();
        array.AddElement();
        array.AddElement();
        array.IndexOutput();
        array.DeleteElement();
    }
}
