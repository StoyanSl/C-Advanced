using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicRube
{
    class Program
    {
        public static int n;
        static void Main()
        {
            
            n= int.Parse(Console.ReadLine());
            long totalcount =0;
            long totalSum = 0;
            int[,,] threeDMatrix = new int[n,n,n];
            while (true)
            {
                var input = Console.ReadLine();
                if (input=="Analyze")
                {
                    break;
                }
                var tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstD = tokens[0];
                int secondD = tokens[1];
                int thirdD = tokens[2];
                int swap = tokens[3];
                if (InMatrix(firstD,secondD,thirdD))
                {
                    if (threeDMatrix[firstD,secondD,thirdD]==0)
                    {
                        threeDMatrix[firstD, secondD, thirdD] = swap;
                       
                    }
                   
                }

            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (threeDMatrix[i,j,k]==0)
                        {
                            totalcount += 1;
                        }
                        totalSum += threeDMatrix[i, j, k];
                    }
                                        
                }
            }
            Console.WriteLine(totalSum);
            Console.WriteLine(totalcount);
        }

        private static bool InMatrix(int firstD, int secondD, int thirdD)
        {
            if (firstD>=0&&firstD<n)
            {
                if (secondD >= 0 && secondD < n)
                {
                    if (thirdD >= 0 && thirdD < n)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
