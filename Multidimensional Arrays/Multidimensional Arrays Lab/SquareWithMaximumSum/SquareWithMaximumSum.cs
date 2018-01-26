using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SquareWithMaximumSum
{
    static void Main()
    {
        var matrixPrp = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var rows = matrixPrp[0];
        var colms = matrixPrp[1];
        int maxSum = int.MinValue;
       int[] printIndex = new int[2];
       int[,] matrix = new int[rows, colms];
        for (int i = 0; i < rows; i++)
        {
            var row = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            for (int j = 0; j < row.Count; j++)
            {
                matrix[i, j] = row[j];
            }
        }
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0) - 1; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1)-1; colIndex++)
            {
                var currentMatrix = matrix[rowIndex, colIndex] + matrix[rowIndex, colIndex + 1] + matrix[rowIndex + 1, colIndex] + matrix[rowIndex + 1, colIndex + 1];
                if (currentMatrix > maxSum)
                {
                    maxSum = currentMatrix;
                    printIndex[0] = rowIndex;
                    printIndex[1] = colIndex;
                }
            }
        }
        Console.WriteLine(matrix[printIndex[0], printIndex[1]] +" "+ matrix[printIndex[0], printIndex[1] + 1] +"\r\n"+ matrix[printIndex[0] + 1, printIndex[1]] +" " +matrix[printIndex[0] + 1, printIndex[1] + 1]);
        Console.WriteLine(maxSum);
    }
}

