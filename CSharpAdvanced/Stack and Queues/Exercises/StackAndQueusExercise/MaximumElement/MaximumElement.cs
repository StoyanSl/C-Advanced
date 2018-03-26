using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var linesCount = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        Stack<int> maxValues = new Stack<int>();
        int maxValue = int.MinValue;
        for (int i = 0; i < linesCount; i++)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var command = input[0];
            switch(command)
            {
                case 1:
                    var number = input[1];
                    if (maxValue < number) { maxValue = number; maxValues.Push(maxValue); }
                    stack.Push(number);
                    break;
                case 2:
                    if (stack.Count!=0)
                    {
                        if (stack.Pop() == maxValue)
                        {
                            maxValues.Pop();
                            if (maxValues.Count!=0)
                                maxValue = maxValues.Peek();
                            else maxValue = 0;
                        }
                    }
                    break;
                case 3:
                    
                    Console.WriteLine(maxValue);
                    break;
            }
        }
    }
}

