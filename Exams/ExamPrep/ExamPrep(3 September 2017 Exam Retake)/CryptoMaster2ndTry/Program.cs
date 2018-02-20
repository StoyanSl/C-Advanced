using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {

        var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        int maxCounter = 0;
        for (int step = 1; step < numbers.Count; step++)
        {
            for (int index = 0; index < numbers.Count; index++)
            {
                int currentLengthCounter = 1;
                int startIndex = index;
                int nextIndex = (index + step) % numbers.Count;
                while (true)
                {
                    if (numbers[startIndex]<numbers[nextIndex])
                    {
                        startIndex = nextIndex;
                        nextIndex = (startIndex + step) % numbers.Count();
                        currentLengthCounter++;
                        continue;
                    }
                        break;
                }
                if (currentLengthCounter>maxCounter)
                {
                    maxCounter = currentLengthCounter;
                }
            }
        }
        Console.WriteLine(maxCounter);
    }
}

