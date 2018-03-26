using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HotPotato
{
    static void Main()
    {
        var kids = Console.ReadLine().Split(' ').ToList();
        var number = int.Parse(Console.ReadLine());
        Queue<string> queue = new Queue<string>(kids);
        while(queue.Count!=1)
        {
            for (int i = 1; i < number; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            Console.WriteLine($"Removed {queue.Dequeue()}");
        }
        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}

