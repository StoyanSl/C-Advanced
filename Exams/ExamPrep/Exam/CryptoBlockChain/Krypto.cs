using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoBlockChain
{
    class Krypto
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder block = new StringBuilder();
            Regex firstPattern = new Regex(@"{([\D]+|\D?)(\d+)([\D]+|\D?)}|\[([\D]+|\D?)(\d+)([\D]+|\D?)]");
            List<char> output = new List<char>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                block.Append(line);
            }
            var matches = firstPattern.Matches(block.ToString());
            foreach(Match match in matches)
            {
                if (match.Value[0]=='{')
                {
                   string numbers= match.Groups[2].Value;
                    if (numbers.Length<3||numbers.Length%3!=0)
                    {
                        continue;
                    }
                    int patternLength = match.Value.Length;
                    int indexCounter = 0;
                    for (int i = 0; i < numbers.Length/3; i++)
                    {
                        int number = int.Parse(numbers.Substring(indexCounter, 3));
                        number -= patternLength;
                        char asciiNum = (char)number;
                        output.Add(asciiNum);
                        indexCounter += 3;
                    }
                }
                else if (match.Value[0]=='[')
                {
                    string numbers = match.Groups[5].Value;
                    if (numbers.Length < 3 || numbers.Length % 3 != 0)
                    {
                        continue;
                    }
                    int patternLength = match.Value.Length;
                    int indexCounter = 0;
                    for (int i = 0; i < numbers.Length / 3; i++)
                    {
                        int number = int.Parse(numbers.Substring(indexCounter,3));
                        number -= patternLength;
                        char asciiNum = (char)number;
                        output.Add(asciiNum);
                        indexCounter += 3;
                    }
                }
            }
            Console.WriteLine(string.Join("",output));
        }
    }
}
