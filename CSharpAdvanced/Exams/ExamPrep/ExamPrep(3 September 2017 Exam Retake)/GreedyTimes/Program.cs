using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    private static long bagCapacity;
    static void Main()
    {
        var goldDict = new Dictionary<string, long>();
        var gemDict = new Dictionary<string, long>();
        var cashDict = new Dictionary<string, long>();
        bagCapacity = long.Parse(Console.ReadLine());
        var args = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        for (int i = 0; i < args.Count - 1; i += 2)
        {
            var itemName = args[i];
            if (itemName.ToLower() == "gold")
            {
                var itemCapacity = long.Parse(args[i + 1]);
                if (bagCapacity >= itemCapacity)
                {
                    bagCapacity -= itemCapacity;
                    if (!goldDict.ContainsKey("Gold"))
                    {
                        goldDict.Add("Gold", itemCapacity);
                        continue;
                    }
                    goldDict["Gold"] += itemCapacity;
                    continue;
                }
                continue;
            }
            if (itemName.ToLower().EndsWith("gem")&&itemName.Count()>=4)
            {
                var itemCapacity = long.Parse(args[i + 1]);
                if (goldDict.Keys.Count == 0)
                {
                    continue;
                }
                if (bagCapacity >= itemCapacity)
                {
                
                    if (gemDict.Values.Sum() + itemCapacity <= goldDict["Gold"])
                    {
                        bagCapacity -= itemCapacity;
                        if (!gemDict.ContainsKey(itemName))
                        {
                            gemDict.Add(itemName, itemCapacity);

                            continue;
                        }
                        gemDict[itemName] += itemCapacity;
                        continue;
                    }
                }
                continue;
            }
            if (itemName.Count() == 3)
            {
                var itemCapacity = long.Parse(args[i + 1]);
                if (gemDict.Keys.Count == 0)
                {
                    continue;
                }
                if (bagCapacity >= itemCapacity)
                {
                    if (cashDict.Values.Sum() + itemCapacity <= gemDict.Values.Sum())
                    {
                        bagCapacity -= itemCapacity;
                        if (!cashDict.ContainsKey(itemName))
                        {
                            cashDict.Add(itemName, itemCapacity);

                            continue;
                        }
                        cashDict[itemName] += itemCapacity;
                        continue;
                    }
                    continue;
                }
            }
        }
        
        PrintOutput(goldDict,"Gold");
        PrintOutput(gemDict, "Gem");
        PrintOutput(cashDict, "Cash");


    }

    private static void PrintOutput(Dictionary<string, long> dict,string Type)
    {
        if (Type=="Gold"&&dict.Keys.Count()>=1)
        {
            Console.WriteLine($"<Gold> ${dict.Values.Sum()}");
        }
        else if(Type=="Gem"&&dict.Keys.Count() >= 1)
        {
            Console.WriteLine($"<Gem> ${dict.Values.Sum()}");
        }
        else if(Type=="Cash"&&dict.Keys.Count() >= 1)
        {
            Console.WriteLine($"<Cash> ${dict.Values.Sum()}");
        }
        foreach (var item in dict.OrderByDescending(x=>x.Key).ThenBy(v=>v.Value))
        {
            Console.WriteLine($"##{item.Key} - {item.Value}");
        }
     
    }
}

