using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var mQueue = new Queue<string>();
            var kQueue = new Queue<string>();
            var pQueue = new Queue<string>();
            var sQueue = new Queue<string>();

            bool thereIsYoda = false;
           
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    var jedi = input[j];
                    switch (jedi[0])
                    {
                        case 'm':
                            mQueue.Enqueue(jedi + " ");
                            break;
                        case 'k':
                            kQueue.Enqueue(jedi + " ");
                            break;
                        case 'p':
                            pQueue.Enqueue(jedi + " ");
                            break;
                        case 't':
                        case 's':
                            sQueue.Enqueue(jedi + " ");
                            break;
                        case 'y':
                            thereIsYoda = true;
                            break;
                        default:
                            break;
                    }
                }
            }
           
            if (!thereIsYoda)
            {
                StringBuilder output = new StringBuilder();
                output.Append(string.Join("",sQueue));
                output.Append(string.Join("", mQueue));
                output.Append(string.Join("", kQueue));
                output.Append(string.Join("", pQueue));
                Console.WriteLine(output.ToString().Trim());
            }
            else
            {
                StringBuilder output = new StringBuilder();
               
                output.Append(string.Join("", mQueue));
                output.Append(string.Join("", kQueue));
                output.Append(string.Join("", sQueue));
                output.Append(string.Join("", pQueue));
                Console.WriteLine(output.ToString().Trim());
            }

        }
    }
}
