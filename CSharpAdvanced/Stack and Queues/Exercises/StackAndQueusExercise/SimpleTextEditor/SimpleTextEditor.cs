using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SimpleTextEditor
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var textVersions = new Stack<string>();
        var text = string.Empty;
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Trim().Split(' ').ToList();
            int command = int.Parse(input[0]);
            switch (command)
            {
                case 1:
                    textVersions.Push(text);
                    text += input[1];
                    break;
                case 2:
                    textVersions.Push(text);
                    int chars = int.Parse(input[1]);
                    text = text.Substring(0, text.Length - chars);
                    break;
                case 3:
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index-1]);
                    break;
                case 4:
                    text = textVersions.Pop();
                    break;
            }
        }
    }
}

