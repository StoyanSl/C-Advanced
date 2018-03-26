using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitList
{
    class Program
    {
        static void Main()
        {
            var dataDict = new Dictionary<string, Dictionary<string, string>>();
            int infoIndex = int.Parse(Console.ReadLine());
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end transmissions")
                {
                    break;
                }
                var args = input.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string targetName = args[0];
                if (!dataDict.Keys.Contains(targetName))
                {
                    dataDict.Add(targetName, new Dictionary<string, string>());
                    var tokens = args[1].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach (var item in tokens)
                    {
                        var keyValuePair = item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var key = keyValuePair[0];
                        var value = keyValuePair[1];

                        if (!dataDict[targetName].Keys.Contains(key))
                        {
                            dataDict[targetName].Add(key, value);
                        }
                        dataDict[targetName][key] = value;
                    }
                }
                else
                {
                    var tokens = args[1].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach (var item in tokens)
                    {
                        var keyValuePair = item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var key = keyValuePair[0];
                        var value = keyValuePair[1];
                        if (!dataDict[targetName].Keys.Contains(key))
                        {
                            dataDict[targetName].Add(key, value);
                        }
                        dataDict[targetName][key] = value;
                    }
                }

            }
            var command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string target = command[1];

            int targetInfo = 0;
            Console.WriteLine($"Info on {target}:");
            foreach (var dataPair in dataDict[target].OrderBy(x=>x.Key))
            {
                Console.WriteLine($"---{dataPair.Key}: {dataPair.Value}");
                targetInfo += dataPair.Value.Length + dataPair.Key.Length;
            }
            Console.WriteLine($"Info index: {targetInfo}");
            if (targetInfo>=infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex-targetInfo} more info.");
            }

        }
    }
}
