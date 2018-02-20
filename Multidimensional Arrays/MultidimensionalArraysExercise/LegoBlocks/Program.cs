using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] firstBlock = GetBlocks(n);
        int[][] secondBlock = GetBlocks(n);
        int[][] combinedBlock = CombineBlocks(firstBlock, secondBlock);
        CheckCombinedBlock(combinedBlock);
    }

    private static void CheckCombinedBlock(int[][] combinedBlock)
    {
        bool perfectlyFit = true;
        int counter = 0;
       
            for (int rowIndex = 0; rowIndex < combinedBlock.GetLength(0) - 1; rowIndex++)
            {
                if (combinedBlock[rowIndex].Length != combinedBlock[rowIndex + 1].Length)
                {
                    perfectlyFit = false;

                }
            }
            for (int rowIndex = 0; rowIndex < combinedBlock.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < combinedBlock[rowIndex].Length; colIndex++)
                {
                    counter++;
                }
            }
        
        if (perfectlyFit)
        {
            PrintBlock(combinedBlock);
        }
        else
        {
            Console.WriteLine($"The total number of cells is: {counter}");
        }


    }

    private static void PrintBlock(int[][] combinedBlock)
    {
        for (int rowIndex = 0; rowIndex < combinedBlock.GetLength(0); rowIndex++)
        {
            Console.WriteLine($"[{string.Join(", ", combinedBlock[rowIndex])}]");
        }
    }

    private static int[][] CombineBlocks(int[][] firstBlock, int[][] secondBlock)
    {
        var combinedBlockOfLists = new List<List<int>>();
        var combinedBlock = new int[secondBlock.GetLength(0)][];
        for (int rowIndex = 0; rowIndex < secondBlock.GetLength(0); rowIndex++)
        {
            var reversedRow = secondBlock[rowIndex].ToList();
            reversedRow.Reverse();
            var row = firstBlock[rowIndex].ToList();
            combinedBlockOfLists.Add(row);
            combinedBlockOfLists[rowIndex].AddRange(reversedRow);
        }
        for (int rowIndex = 0; rowIndex < combinedBlock.GetLength(0); rowIndex++)
        {
            combinedBlock[rowIndex] = combinedBlockOfLists[rowIndex].ToArray();
        }
        return combinedBlock;
    }

    private static int[][] GetBlocks(int n)
    {
        int[][] matrix = new int[n][];
        for (int rowIndex = 0; rowIndex < n; rowIndex++)
        {
            var columnsData = Console.ReadLine().Trim().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix[rowIndex] = columnsData;
        }
        return matrix;
    }
}
