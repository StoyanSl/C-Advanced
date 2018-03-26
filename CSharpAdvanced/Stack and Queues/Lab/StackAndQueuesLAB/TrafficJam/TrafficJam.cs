using System;
using System.Collections.Generic;


class TrafficJam
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Queue<string> queue = new Queue<string>();
        int totalCounter = 0;
        while (true)
        {
            var command = Console.ReadLine();
            if (command == "end") break;
            if (command == "green")
            {
                if (number > queue.Count) number = queue.Count;
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine($"{queue.Dequeue()} passed!");
                    totalCounter++;
                }
                            }
            else { queue.Enqueue(command); }
        }
        Console.WriteLine($"{totalCounter} cars passed the crossroads.");
    }
}

