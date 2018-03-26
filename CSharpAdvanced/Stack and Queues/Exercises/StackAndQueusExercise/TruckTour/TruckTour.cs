using System;
using System.Collections.Generic;
using System.Linq;



class TruckTour
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var pumps = new Queue<List<int>>();
        int indexCounter = 0;
        int fuel = 0;
        bool flag = false;
        for (int i = 0; i < n; i++)
        {
            var pump = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            pumps.Enqueue(pump);
        }
        foreach(var pump in pumps)
        {
            int endCounter = 0;
            var pumpsList = pumps.ToList();
            for (int i = indexCounter; i < pumpsList.Count; i++)
            {
                fuel += pumpsList[i][0] - pumpsList[i][1];
                if (fuel>=0)
                {
                    endCounter++;
                }
                else
                {
                    indexCounter++;
                    fuel = 0;
                    break;
                }
                if (endCounter==n)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true) break;
        }
        Console.WriteLine(indexCounter);
    }
}

