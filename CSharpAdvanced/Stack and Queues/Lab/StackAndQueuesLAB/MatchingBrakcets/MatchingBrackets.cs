using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MatchingBrackets
{
    static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<int>();
        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];
            if(ch=='(')
            {
                stack.Push(i);
            }
            else if (ch==')')
            {
                int startIndex = stack.Pop();
                string contents = input.Substring(startIndex,i-startIndex+1);
                Console.WriteLine(contents);
            }
        }
    }
}

