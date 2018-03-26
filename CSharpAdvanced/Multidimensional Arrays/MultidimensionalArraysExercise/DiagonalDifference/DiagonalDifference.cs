using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DiagonalDifference
{
    public static void Main()
    {
       var nRows = int.Parse(Console.ReadLine());
       calculatingDiagonals( matrixFilling(nRows),nRows);

    }
    private static void calculatingDiagonals(int[,] matrixOfIntegers,int nRows)
    {
        int colindex = nRows - 1;
        int sumOfFirstDiagonal = 0;
        int sumOFSecondDiagonal = 0;
        for (int rowIndex = 0; rowIndex < nRows; rowIndex++)
        {
            sumOfFirstDiagonal += matrixOfIntegers[rowIndex, rowIndex];
        }
        for (int rowIndex = 0; rowIndex < nRows; rowIndex++)
        {
            sumOFSecondDiagonal += matrixOfIntegers[rowIndex, colindex];
            colindex--;
        }
        Console.WriteLine(Math.Abs(sumOfFirstDiagonal-sumOFSecondDiagonal));
    }
    private static int[,] matrixFilling(int nRows)
    {
       
        int[,] matrixOfIntegers = new int[nRows, nRows];
        for (int i = 0; i < nRows; i++)
        {
            var row = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            for (int colIndex = 0; colIndex < nRows; colIndex++)
            {
                matrixOfIntegers[i, colIndex] = row[colIndex];
            }
        }
        return matrixOfIntegers;
    }
}

