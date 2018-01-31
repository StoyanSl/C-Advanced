using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddLines
{
    static void Main()
    {
        using (var reader = new StreamReader("text.txt"))
        {
            int numberLine = 0;
            while (true)
            {
                string line =reader.ReadLine();
                if (line==null)
                {
                    break;
                }
                if (numberLine%2!=0)
                {
                    Console.WriteLine(line);
                }
                numberLine++;
            }
        }
    }
}

