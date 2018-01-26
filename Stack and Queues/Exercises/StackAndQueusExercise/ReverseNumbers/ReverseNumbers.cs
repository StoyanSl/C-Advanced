using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {

        var input = Console.ReadLine().Split(' ').Select(s => long.Parse(s));
        Stack<long> stack = new Stack<long>(input);
        while (stack.Count != 0)
        {
            Console.Write(stack.Pop() + " ");
        }
    }
}

