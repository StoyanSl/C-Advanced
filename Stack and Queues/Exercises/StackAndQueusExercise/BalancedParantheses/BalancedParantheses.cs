using System;
using System.Collections.Generic;


class BalancedParantheses
{
    static void Main()
    {
        var input = Console.ReadLine();
        if (input.Length % 2 == 1)
        {
            Console.WriteLine("NO");
            return;
        }
        var leftParantheses = new Stack<char>();
        bool flag = false;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '{' || input[i] == '(' || input[i] == '[') { leftParantheses.Push(input[i]);}
            else
            {
                if((leftParantheses.Peek()=='{'&&input[i]!='}') ||
                     (leftParantheses.Peek() == '[' && input[i] != ']') ||
                    (leftParantheses.Peek() == '(' && input[i] != ')')||
                     (leftParantheses.Peek() == ')' && input[i] != '('))
                { 
                     Console.WriteLine("NO"); 
                    flag = true;
                    break;
                }
                else { leftParantheses.Pop(); }
            }
        }
        if (flag == false) Console.WriteLine("YES");
    }
}

