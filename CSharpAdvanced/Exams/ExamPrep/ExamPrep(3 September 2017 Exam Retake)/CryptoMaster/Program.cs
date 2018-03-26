using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        var inputSequence = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        var sequence = new Queue<int>(inputSequence);
        int maxCount = int.MinValue;
        int step = 0;
        int startIndex = 0;
        while (startIndex < sequence.Count)
        {
            var modsSequence = new Queue<int>(sequence);
            for (int i = 0; i < startIndex; i++)
            {
                modsSequence.Enqueue(modsSequence.Dequeue());
            }
            while (true)
            {
                var modSequence = new Queue<int>(modsSequence);
                int currentCount = 0;
                if (step >= modSequence.Count)
                {
                    break;
                }
                while (true)
                {
                    int startNumber = modSequence.Dequeue();
                    modSequence.Enqueue(startNumber);
                 
                    for (int i = 0; i < step; i++)
                    {
                        modSequence.Enqueue(modSequence.Dequeue());
                    }
                    int nextNumber = modSequence.Peek();
                    if (startNumber < nextNumber )
                    {
                        currentCount++;
                    }
                    else
                    {
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }
                        break;
                    }
                }
                step++;
            }
            startIndex++;
            step = 0;
        }
        Console.WriteLine(maxCount+1);
    }
}

