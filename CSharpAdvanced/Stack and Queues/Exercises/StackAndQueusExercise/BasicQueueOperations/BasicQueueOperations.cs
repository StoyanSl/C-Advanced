using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BasicQueueOperations
{
    static void Main(string[] args)
    {
        var firstLineInput = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
        var secondLineInput = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
        var numberEnqueues = firstLineInput[0];
        var numberDequeues = firstLineInput[1];
        var lookForNumber = firstLineInput[2];
        int lowest = 0;
        bool flag = false;
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numberEnqueues; i++)
        {
            queue.Enqueue(secondLineInput[i]);
        }
        for (int i = 0; i < numberDequeues; i++)
        {
            queue.Dequeue();
        }
        foreach (var number in queue)
        {
            if (lowest == 0)
            {
                lowest = number;
            }
            if (lowest > number)
            {
                lowest = number;
            }
            if (number == lookForNumber)
            {
                flag = true;
                Console.WriteLine("true");
                break;
            }
        }
        if (flag == false) Console.WriteLine(lowest);
    }
}

