using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MaximalSum
{
    static void Main()
    {
        var matrixPpts = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        int rows = matrixPpts[0];
        int cols = matrixPpts[1];
        squareSumming(matrixFilling(rows, cols));

    }
    private static void squareSumming(int[,] matrixOfInts)
    {
        int MaxSum = int.MinValue;
        int currentSum = 0;
        int[] coordinates = new int[2] {0,0};
        for (int rowIndex = 0; rowIndex < matrixOfInts.GetLength(0) - 2; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrixOfInts.GetLength(1) - 2; colIndex++)
            {
                currentSum = sumer(rowIndex, colIndex, matrixOfInts);
                if (MaxSum<currentSum)
                {
                    MaxSum = currentSum;
                    coordinates[0] = rowIndex;
                    coordinates[1] = colIndex;
                }
            }
        }
        Console.WriteLine("Sum = "+MaxSum);
        for (int rowIndex = coordinates[0]; rowIndex < coordinates[0]+3; rowIndex++)
        {
            for (int colIndex = coordinates[1]; colIndex < coordinates[1]+3; colIndex++)
            {
                Console.Write(matrixOfInts[rowIndex,colIndex]+" ");
            }
            Console.WriteLine();
        }

    }
     private static int sumer(int row,int col,int[,] matrixOfInts)
    {
        int sum = 0;
        for (int rowIndex = row; rowIndex < row+3; rowIndex++)
        {   
            for (int colIndex = col; colIndex < col+3; colIndex++)
            {
                sum += matrixOfInts[rowIndex, colIndex];
            }
        }
        return sum;
    }
    private static int[,] matrixFilling(int rows, int cols)
    {

        int[,] matrixOfInts = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            var row = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                matrixOfInts[i, colIndex] = row[colIndex];
            }

        }
        return matrixOfInts;
    }
}

