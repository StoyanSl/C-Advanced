using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BasicStackOperations
{
    static void Main()
    {
        var firstLineInput = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
        var secondLineInput = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
        var numberPushs = firstLineInput[0];
        var numberPops = firstLineInput[1];
        var lookForNumber = firstLineInput[2];
        int lowest = 0;
        bool flag = false;
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < numberPushs; i++)
        {
            stack.Push(secondLineInput[i]);
        }
        for (int i = 0; i < numberPops; i++)
        {
            stack.Pop();
        }
        foreach (var number in stack)
        {
            if(lowest==0)
            {
                lowest = number;
            }
            if(lowest>number)
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

