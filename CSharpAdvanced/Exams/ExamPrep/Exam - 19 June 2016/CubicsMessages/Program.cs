using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        while (true)
        {
            var input=Console.ReadLine();
            if (input=="Over!")
            {
                break;
            }
            string cryptedLine = input;
            string n = Console.ReadLine();
            string pattern = @"^(\d+|^)([a-zA-Z]{" + n+ @"})([^a-zA-Z]+|$)$";
            Regex rgx = new Regex(pattern);
            var match=rgx.Match(cryptedLine);
            if (match.Value.Length>=1)
            {
              string firstValues=match.Groups[1].Value;
              string message = match.Groups[2].Value;
              string secondValues= match.Groups[3].Value;
              var verificationCode=new StringBuilder();
                for (int i = 0; i < firstValues.Length; i++)
                {
                    int index = int.Parse(firstValues[i].ToString());
                    if (index>=0&&index<message.Length)
                    {
                        verificationCode.Append(message[index].ToString());
                        continue;
                    }
                    verificationCode.Append(" ");
                }
                for (int i = 0; i < secondValues.Length; i++)
                {
                    Boolean hasParsed= int.TryParse(secondValues[i].ToString(),out int index);
                    if (index >= 0 && index < message.Length&&hasParsed)
                    {
                        verificationCode.Append(message[index].ToString());
                        continue;
                    }
                    verificationCode.Append(" ");
                }
                Console.WriteLine($"{message} == {verificationCode}");
            }
    }
    }
}

