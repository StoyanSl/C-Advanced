using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StackFibonacci
{
    static void Main()
    {
        var fibonacciStack = new Stack<long>();
        fibonacciStack.Push(0);
        fibonacciStack.Push(1);
        var n = int.Parse(Console.ReadLine());
        while(fibonacciStack.Count<=n)
        {
            long popedVar = 0;
            long peekVar = 0;
            popedVar = fibonacciStack.Pop();
            peekVar = fibonacciStack.Peek();
            fibonacciStack.Push(popedVar);
            fibonacciStack.Push(popedVar+peekVar);
        }
        Console.WriteLine(fibonacciStack.Peek());
    }
}

