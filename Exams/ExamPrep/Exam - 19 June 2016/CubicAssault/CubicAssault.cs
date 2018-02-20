using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CubicAssault
{
    private const string black = "Black";
    private const string red = "Red";
    private const string green = "Green";
    private const long border = 1000000;
    static void Main()
    {
        var dataDict = new Dictionary<string, Dictionary<string, long>>();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "Count em all")
            {
                break;
            }
            var tokens = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            string regionName = tokens[0];
            string meteorType = tokens[1];
            long meteorsCount = long.Parse(tokens[2]);
            dataDict = InputData(dataDict, regionName, meteorType, meteorsCount);
            if (dataDict[regionName][green]>=border)
            {
                while (dataDict[regionName][green] >= border)
                {
                    dataDict[regionName][green] -= border;
                    dataDict[regionName][red]++;
                  
                }
                
            }
            if (dataDict[regionName][red] >= border)
            {
                while (dataDict[regionName][red] >= border)
                {
                    dataDict[regionName][red] -= border;
                    dataDict[regionName][black]++;

                }

            }
        }
        PrintOutput(dataDict);
    }
    //    foreach (var region in dataDict)
    //    {
    //        foreach (var meteorKind in region.Value)
    //        {
    //            if (meteorKind.Key == green)
    //            {
    //                long something = meteorKind.Value;
    //                while (something >= border && something > 0)
    //                {
    //                    dataDict[region.Key][green] -= border;
    //                    dataDict[region.Key][red]++;
    //                    something -= border;
    //                }
    //                break;
    //            }
    //
    //        }
    //    }
    //    foreach (var region in dataDict)
    //    {
    //        foreach (var meteorKind in region.Value)
    //        {
    //            if (meteorKind.Key == red)
    //            {
    //                long something = meteorKind.Value;
    //                while (something >= border&&something>0)
    //                {
    //                    dataDict[region.Key][red] -= border;
    //                    dataDict[region.Key][black]++;
    //                    something -= border;
    //                }
    //                break;
    //            }
    //
    //        }
    //    }


    private static void PrintOutput(Dictionary<string, Dictionary<string, long>> dataDict)
    {

        foreach (var region in dataDict.OrderByDescending(x => x.Value[black]).ThenBy(x => x.Key.Count()).ThenBy(x => x.Key))
        {
            Console.WriteLine(region.Key);
            foreach (var dict in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"-> {dict.Key} : {dict.Value}");
            }
        }
    }

    private static Dictionary<string, Dictionary<string, long>> InputData(Dictionary<string, Dictionary<string, long>> dataDict, string regionName, string meteorType, long meteorsCount)
    {
        if (!dataDict.ContainsKey(regionName))
        {
            dataDict.Add(regionName, new Dictionary<string, long>());

            dataDict[regionName].Add(black, 0);
            dataDict[regionName].Add(red, 0);
            dataDict[regionName].Add(green, 0);
        }
        dataDict[regionName][meteorType] += meteorsCount;
        return dataDict;

    }
}

