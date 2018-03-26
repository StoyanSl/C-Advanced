using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class KeyRevolver
{
    static void Main()
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarrel = int.Parse(Console.ReadLine());
        Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        int initalBulletsCount = bullets.Count();
        int intelegenceValue = int.Parse(Console.ReadLine());
        int currentGunBarrel = gunBarrel;
        while (bullets.Count!=0&&locks.Count!=0)
        {
            if (currentGunBarrel == 0)
            {
                Console.WriteLine("Reloading!");
                currentGunBarrel = gunBarrel;
            }
            if (bullets.Peek()>locks.Peek())
            {
                bullets.Pop();
                Console.WriteLine("Ping!");
                currentGunBarrel--;
                continue;
            }
            if (bullets.Peek()<=locks.Peek())
            {
                bullets.Pop();
                currentGunBarrel--;
                locks.Dequeue();
                Console.WriteLine("Bang!");
                continue;
            }
        }
        if (currentGunBarrel == 0&&bullets.Count>=1)
        {
            Console.WriteLine("Reloading!");
            currentGunBarrel = gunBarrel;
        }
        if (bullets.Count>=1)
        {
            int bulletsLeft = initalBulletsCount - bullets.Count();
            int earned = intelegenceValue - (bulletsLeft * bulletPrice);
            Console.WriteLine($"{bullets.Count()} bullets left. Earned ${earned}");
        }
        else if (bullets.Count()==0&&locks.Count>=1)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
        }
        else if (bullets.Count() == 0 && locks.Count ==0)
        {
            int bulletsLeft = initalBulletsCount - bullets.Count();
            int earned = intelegenceValue - (bulletsLeft * bulletPrice);
            Console.WriteLine($"{bullets.Count()} bullets left. Earned ${earned}");
        }
    }
}

