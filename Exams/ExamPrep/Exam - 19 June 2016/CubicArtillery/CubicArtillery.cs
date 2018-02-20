using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CubicArtillerySecondTry
{
    private static int bunkerCapacity;
    static void Main()
    {
        var bunkers = new Queue<string>();
        var currentBunker = new Queue<int>();
        bunkerCapacity = int.Parse(Console.ReadLine());
        int currentBunkerCapacity = 0;
        while (true)
        {
            var args = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if ((args[0]) == "Bunker")
            {
                break;
            }
            for (int i = 0; i < args.Length; i++)
            {
                int weapon;
                bool hasParsed = int.TryParse(args[i], out weapon);
                if (!hasParsed)
                {
                    var bunker = args[i];
                    bunkers.Enqueue(bunker);
                    continue;
                }
                bool enqueued = false;

                while (bunkers.Count > 1)
                {
                    if (currentBunkerCapacity + weapon <= bunkerCapacity)
                    {
                        currentBunker.Enqueue(weapon);
                        currentBunkerCapacity += weapon;
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
                    currentBunkerCapacity = 0;

                }
                if (!enqueued && bunkers.Count == 1)
                {
                    if (weapon <= bunkerCapacity)
                    {
                        if (currentBunkerCapacity + weapon <= bunkerCapacity)
                        {
                            currentBunker.Enqueue(weapon);
                            currentBunkerCapacity += weapon;
                            continue;
                        }
                        else
                        {
                            while (currentBunkerCapacity + weapon > bunkerCapacity)
                            {

                                currentBunkerCapacity -= currentBunker.Dequeue();
                            }
                            currentBunker.Enqueue(weapon);
                            currentBunkerCapacity += weapon;
                            continue;
                        }
                    }
                }

            }
        }
    }
}

