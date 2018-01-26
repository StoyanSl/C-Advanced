using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RecursiveFibbonaci
{
    
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var fibonacci = new long[n];

        Console.WriteLine(GetFibonacci(n - 1,fibonacci));
    }

    private static long GetFibonacci(int n,long[] fibonacci)
    {
        if (n < 2)
        {
            return 1;
        }

        if (fibonacci[n] == 0)
        {
            fibonacci[n] = GetFibonacci(n - 1, fibonacci) + GetFibonacci(n - 2,fibonacci);
        }
        return fibonacci[n];
        }
    }
