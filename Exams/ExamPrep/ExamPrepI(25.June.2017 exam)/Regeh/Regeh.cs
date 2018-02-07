using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Regeh
{
    private const string pattern = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+]";
    private static int index=0;
    static void Main()
    {
        var output = new List<string>();
        var input = Console.ReadLine();
        var matches = Regex.Matches(input, pattern);
        foreach (Match match in matches)
        {
           int currentIndex = getIndex(input, match.Groups[1].Value);
            output.Add(input[currentIndex].ToString());
            currentIndex = getIndex(input, match.Groups[2].Value);
            output.Add(input[currentIndex].ToString());
        }
        Console.WriteLine(string.Join("",output));
    }

    private static int getIndex(string input, string number)
    {
        int requiredIndex = int.Parse(number);
        if (index+requiredIndex>input.Length-1)
        {
            requiredIndex -= input.Length - 1 - index;
            index = 0;

        }
        index = index + requiredIndex;
        return index;
        throw new NotImplementedException();
    }
}

