using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class CubicArtillerySecondTry
{
    private static int bunkerCapacity;
    static void Main()
    {
        var bunkers = new Queue<string>();
        var currentBunker = new Queue<int>();
      
        bunkerCapacity = int.Parse(Console.ReadLine());
        int currentBunkerFreeCapacity = bunkerCapacity;
        var input = Console.ReadLine();
        
        while (input!="Bunker Revision")
        {
            var args = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in args)
            {
                int weapon;
                bool hasParsed = int.TryParse(item, out weapon);
                if (!hasParsed)
                {
                    var bunker = item;
                    bunkers.Enqueue(bunker);
                    continue;
                }
                bool enqueued = false;
                
                while (bunkers.Count>1)
                {
                    if (currentBunkerFreeCapacity >= weapon)
                    {
                        currentBunker.Enqueue(weapon);
                        currentBunkerFreeCapacity -= weapon;
                        enqueued = true;
                        break; 
                    }
                    if (currentBunker.Count == 0)
                    {
                        Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                    }
                    else
                    {
                        Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", currentBunker)}");
                    }
                    currentBunker.Clear();
                    currentBunkerFreeCapacity = bunkerCapacity;
                   
                }
                if (!enqueued&&bunkers.Count==1)
                {
                    if (weapon <= bunkerCapacity)
                    {
                        if (currentBunkerFreeCapacity>=weapon)
                        {
                            currentBunker.Enqueue(weapon);
                            currentBunkerFreeCapacity -= weapon;
                            continue;
                        }
                        else
                        {
                            while (currentBunkerFreeCapacity<weapon)
                            {
                                currentBunkerFreeCapacity += currentBunker.Dequeue();
                            }
                            currentBunker.Enqueue(weapon);
                            currentBunkerFreeCapacity -= weapon;
                            continue;
                        }
                    }
                }
                
            }
            input = Console.ReadLine();
        }
    }
}

