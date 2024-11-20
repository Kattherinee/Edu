

public class Program
{
    public static void Main()
    {
        IQueue<int> queue = new KatyQueue<int>();

        Random random = new Random();

        for (int i = 1; i <= 10; i++)
        {
            int value = random.Next(1, 101); 
            queue.Enqueue(value);
            Console.WriteLine($" {value} добавлен в очередь.");
        }

        for (int i = 0; i < 10; i++)
        {
            int? dequeuedValue = queue.Dequeue();
          
                Console.WriteLine(dequeuedValue);
            
        }

    }

}



// using Stack_queue_list;

// public class Program
// {
//     public static void Main()
//     {
//         IStack<int> stack = new KatyStack<int>();
//         while (true)
//         {
//             Console.WriteLine("Выберите действие: 1 - Push, 2 - Pop, 3 - Выход");
//             string? input = Console.ReadLine();

//             if (input == "1")
//             {
//                 Console.Write("Введите значение для добавления в стек: ");
//                 if (int.TryParse(Console.ReadLine(), out int value))
//                 {
//                     stack.Push(value);
//                     Console.WriteLine($"Элемент {value} добавлен в стек.");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Некорректное значение.");
//                 }
//             }
//             else if (input == "2")
//             {
//                 int? poppedValue = stack.Pop();
//                 if (poppedValue == null)
//                 {
//                     Console.WriteLine("Стек пуст.");
//                 }
//                 else
//                 {
//                     Console.WriteLine($"Извлечен элемент: {poppedValue}");
//                 }
//             }
//             else if (input == "3")
//             {
//                 break;
//             }
//             else
//             {
//                 Console.WriteLine("Некорректное действие. Повторите ввод.");
//             }
//         }
//     }
// }