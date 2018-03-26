using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WordCount
{
    static void Main()
    {
        var wordsAndCounts = new Dictionary<string, int>();
        using (var reader = new StreamReader(@"words.txt"))
        {
            while (true)
            {
                string word = reader.ReadLine();
                if (word == null)
                {
                    break;
                }
                word = word.ToLower();
                if (!wordsAndCounts.ContainsKey(word))
                {
                    wordsAndCounts.Add(word, 0);
                }
            }
        }
        using (var reader = new StreamReader(@"text.txt"))
        {
            while (true)
            {

                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var currentWords = line
                         .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                         .Select(x => x.ToLower())
                         .ToList();
                foreach (var word in currentWords)
                {
                    if (wordsAndCounts.ContainsKey(word))
                    {
                        wordsAndCounts[word]++;
                    }
                }
            }
        }
        using (var writer = new StreamWriter("result.txt"))
        {
            foreach(var line in wordsAndCounts)
            {
                writer.WriteLine($"{line.Key} - {line.Value}");
            }
        }
    }
}

