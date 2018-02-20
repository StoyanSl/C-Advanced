using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var matrixPpts = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        int rows = matrixPpts[0];
        int cols = matrixPpts[1];

        Console.WriteLine(squareSearching(matrixFilling(rows,cols)));
    }
    private static int squareSearching(char [,] matrixOfChars)
    {
        int squaresCounter = 0;
        for (int rowIndex = 0; rowIndex < matrixOfChars.GetLength(0)-1; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrixOfChars.GetLength(1)-1; colIndex++)
            {
                var currentChar = matrixOfChars[rowIndex, colIndex];
                if (matrixOfChars[rowIndex,colIndex]==currentChar&& 
                    matrixOfChars[rowIndex+1, colIndex] == currentChar&&
                    matrixOfChars[rowIndex, colIndex+1] == currentChar&&
                    matrixOfChars[rowIndex+1, colIndex+1] == currentChar)
                {
                    squaresCounter++;
                }
            }
        }
        return squaresCounter;
    }
    private static char[,] matrixFilling(int rows,int cols)
    {

        char[,] matrixOfChars = new char[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            var row = Console.ReadLine().Trim().Split(' ').Select(char.Parse).ToList();
            
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                matrixOfChars[i, colIndex] = row[colIndex];
                }
            
        }
        return matrixOfChars;
    }
}

