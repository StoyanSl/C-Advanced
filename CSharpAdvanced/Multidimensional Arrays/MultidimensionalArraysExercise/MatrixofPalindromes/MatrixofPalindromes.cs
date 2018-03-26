using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MatrixofPalindromes
{
    static void Main()
    {
        matrixPrinting(matrixCreation());
    }

    private static void matrixPrinting(string[][] matrixOfPalindromes)
    {
        foreach (var row in matrixOfPalindromes)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    private static string[][] matrixCreation()
    {
        var matrixPpts = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        int rows = matrixPpts[0];
        int cols = matrixPpts[1];
        string[][] matrixOfPalindromes = new string[rows][];
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            matrixOfPalindromes[rowIndex] = new string[cols];
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                var firstChar = alphabet[rowIndex];
                var secondChar = alphabet[rowIndex + colIndex];
                var palindrome = new StringBuilder();
                matrixOfPalindromes[rowIndex][colIndex] =
                    palindrome
                    .Append(firstChar)
                    .Append(secondChar)
                    .Append(firstChar)
                    .ToString();
            }
        }

        return matrixOfPalindromes;
    }
}

