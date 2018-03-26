using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LineNumbers
{
    static void Main()
    {
        var listOfLines = new List<string>();
        using (var reader = new StreamReader(@"text.txt"))
        {
            int numberLine = 1;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                listOfLines.Add($"Line {numberLine}: {line}");
                numberLine++;
            }
        }
        using (var writer = new StreamWriter("kaching.txt"))
        {
            for (int i = 0; i < listOfLines.Count; i++)
            {
                writer.WriteLine(listOfLines[i]);
            }
        }
    }
}

