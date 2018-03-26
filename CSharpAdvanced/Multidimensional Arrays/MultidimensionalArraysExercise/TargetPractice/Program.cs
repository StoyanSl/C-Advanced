using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    private static int rows;
    private static int cols;
    private static char emptyCell = ' ';
    static void Main()
    {
        char[,] matrix = Getmatrix();
        matrix = ShootOnMatrix(matrix);
        matrix = RearangingMatrix(matrix);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static char[,] RearangingMatrix(char[,] matrix)
    {
        for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
        {
            var colElements = new List<char>();
            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                if (matrix[rowIndex, colIndex] != emptyCell)
                {
                    colElements.Add(matrix[rowIndex, colIndex]);
                }

            }
            int endIndexer = 0;
            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                if (endIndexer<colElements.Count)
                {
                    matrix[rowIndex, colIndex] = colElements[endIndexer];
                    endIndexer++;
                }
                else
                {
                    matrix[rowIndex, colIndex] = emptyCell;
                }
            }
        }
        return matrix;
    }

    private static char[,] ShootOnMatrix(char[,] matrix)
    {
        var args = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        int shotRow = args[0];
        int shotCol = args[1];
        int radius = args[2];
        for (int rowIndex = shotRow - radius; rowIndex <= shotRow + radius; rowIndex++)
        {
            for (int colIndex = shotCol - radius; colIndex <= shotCol + radius; colIndex++)
            {
                if (!withinMatrix(rowIndex, colIndex))
                {
                    continue;
                }
                if (withinImpactRadiusRange(matrix, rowIndex, colIndex, shotRow, shotCol, radius))
                {
                    matrix[rowIndex, colIndex] = emptyCell;
                }
            }
        }
        return matrix;
    }

    private static bool withinImpactRadiusRange(char[,] matrix, int rowIndex, int colIndex, int shotRow, int shotCol, int radius)
    {
        var distance = Math.Sqrt(Math.Pow(shotRow - rowIndex, 2) + Math.Pow(shotCol - colIndex, 2));
        if (distance <= radius)
        {
            return true;
        }
        return false;
    }

    private static bool withinMatrix(int rowIndex, int colIndex)
    {
        if ((colIndex >= 0 && colIndex < cols) && (rowIndex >= 0 && rowIndex < rows))
        {
            return true;
        }
        return false;
    }

    private static char[,] Getmatrix()
    {
        var args = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        var stringSnake = Console.ReadLine();
        rows = args[0];
        cols = args[1];
        int stringSnakeIndex = 0;
        var direction = false;
        char[,] matrix = new char[rows, cols];
        for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
        {
            while (stringSnake.Length < cols * rows)
            {
                stringSnake += stringSnake;
            }
            if (!direction)
            {
                for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                {
                    char character = stringSnake[stringSnakeIndex];
                    matrix[rowIndex, colIndex] = character;
                    stringSnakeIndex++;
                }
                direction = true;
            }
            else if (direction)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    char character = stringSnake[stringSnakeIndex];
                    matrix[rowIndex, colIndex] = character;
                    stringSnakeIndex++;
                }
                direction = false;
            }

        }
        return matrix;
    }
}

