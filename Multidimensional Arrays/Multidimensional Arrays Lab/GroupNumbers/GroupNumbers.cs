using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GroupNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
       
        int[] indexesArr = new int[] { 0,0,0};
        int[] lenghtsArr = new int[3];
        foreach(var num in nums)
        {
            var reminder = num % 3;
            switch (reminder)
            {
                case 0:
                    lenghtsArr[0]++;
                    break;
                case 1:
                    lenghtsArr[1]++;
                    break;
                case 2:
                    lenghtsArr[2]++;
                    break;
                case -1:
                    lenghtsArr[1]++;
                    break;
                case -2:
                    lenghtsArr[2]++;
                    break;
            }
            
        }
        int[][] matrix = new int[][] {
            new int[lenghtsArr[0]],
            new int[lenghtsArr[1]],
            new int[lenghtsArr[2]]
        };
        for (int i = 0; i < nums.Count; i++)
        {
            var reminder = nums[i] % 3;
            switch(reminder)
            {
                case 0:
                    matrix[0][indexesArr[0]] = nums[i];
                    indexesArr[0]++;
                    break;
                case 1:
                    matrix[1][indexesArr[1]] = nums[i];
                    indexesArr[1]++;
                    break;
                case 2:
                    matrix[2][indexesArr[2]] = nums[i];
                    indexesArr[2]++;
                    break;
                case -1:
                    matrix[1][indexesArr[1]] = nums[i];
                    indexesArr[1]++;
                    break;
                case -2:
                    matrix[2][indexesArr[2]] = nums[i];
                    indexesArr[2]++;
                    break;
            }
        }
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
            {
                Console.Write(matrix[rowIndex][colIndex]+" ");
            }
            Console.WriteLine();
        }
    }
}

