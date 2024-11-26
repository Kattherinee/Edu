using System;

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        MyLinkedList<int> linkedList = new MyLinkedList<int>();

        Console.WriteLine("Добавление элементов в связанный список:");
        for (int i = 0; i < 10; i++)
        {
            int value = random.Next(1, 101); 
            linkedList.Add(value);
            Console.WriteLine($"Элемент {value} добавлен.");
        }

        Console.WriteLine("\nЭлементы связанного списка:");
        PrintWithIEnumerable(linkedList);

        Console.WriteLine("\nУдаление первых 5 элементов:");
        for (int i = 0; i < 5; i++)
        {
            if (linkedList.Count > 0)
            {
                int valueToRemove = linkedList.GetFirst();
                linkedList.Remove(valueToRemove);
                Console.WriteLine($"Элемент {valueToRemove} удален.");
            }
        }

        Console.WriteLine("\nОставшиеся элементы:");
        PrintWithIEnumerable(linkedList);


    }

    private static void PrintWithIEnumerable<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            
            Console.WriteLine(item);
        }
    }

    private static void TestIEnumerable<T>(IEnumerable<T> collection)
    {
        Console.WriteLine("Тест работы с IEnumerable:");
        using var enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine($"Текущий элемент: {enumerator.Current}");
        }
    }
}
