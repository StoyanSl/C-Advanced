using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var nRows = int.Parse(Console.ReadLine());
        long[][] triangle = new long[nRows][];
        long currentWidth = 1;
        for (int height = 0; height < nRows; height++)
        {
            triangle[height] = new long[currentWidth];
            long[] currentRow = triangle[height];
            currentRow[0] = 1;
            currentRow[currentRow.Length-1] = 1;
            currentWidth++;
            if (currentRow.Length>2)
            {
                for (int i = 1; i < currentRow.Length-1; i++)
                {
                    long[] previousRow = triangle[height - 1];
                    long sum = previousRow[i - 1] + previousRow[i];
                    currentRow[i] = sum;
                }
            }
        }
        for (int rowIndex = 0; rowIndex < triangle.Length; rowIndex++)
        {
            for (int colIndex = 0; colIndex < triangle[rowIndex].Length; colIndex++)
            {
                Console.Write(triangle[rowIndex][colIndex]+" ");
            }
            Console.WriteLine();
        }
    }
}

