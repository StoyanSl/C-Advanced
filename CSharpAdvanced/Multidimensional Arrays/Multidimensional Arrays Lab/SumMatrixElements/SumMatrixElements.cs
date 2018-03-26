using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SumMatrixElements
{
    static void Main()
    {
        var matrixPrp = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var rows = matrixPrp[0];
        var colms = matrixPrp[1];
        int sum = 0;
        var matrix = new int[rows, colms];
        for (int i = 0; i < rows; i++)
        {
            var row = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            for (int j = 0; j < row.Count; j++)
            {
                matrix[i, j] = row[j];
                sum += matrix[i,j];
            }
        }
        Console.WriteLine(rows);
        Console.WriteLine(colms);
        Console.WriteLine(sum);
    }
}
