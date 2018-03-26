using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sneaking
{
    public static int n;
    public static int cols;
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        char[][] matrix = new char[n][];
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Trim().ToCharArray();
            matrix[i] = line;
        }
        cols = matrix[0].Length;
        int[] samCoordinates = GetSamCoordinates(matrix);
        var commands = Console.ReadLine();
        bool deadSam = false;
        bool nikoladzeFound = false;
        
        for (int i = 0; i < commands.Length; i++)
        {
          
            matrix = moveEnemies(matrix);
            if (!deadSam)
            {
                deadSam = CheckToLeft(matrix, samCoordinates, deadSam);
            }
            if (nikoladzeFound||deadSam)
            {
                break;
            }
            if (!deadSam)
            {
                deadSam = CheckToRight(matrix, samCoordinates, deadSam);
                
            }
            if (nikoladzeFound || deadSam)
            {
                break;
            }
            if (!deadSam)
            {
                switch (commands[i])
                {
                    case 'U':
                        matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                        matrix = MoveSam(samCoordinates[0] - 1, samCoordinates[1], matrix);
                        samCoordinates[0]--;
                        break;
                    case 'D':
                        matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                        matrix = MoveSam(samCoordinates[0] + 1, samCoordinates[1], matrix);
                        samCoordinates[0]++;
                        break;
                    case 'L':
                        matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                        matrix = MoveSam(samCoordinates[0], samCoordinates[1] - 1, matrix);
                        samCoordinates[1]--;
                        break;
                    case 'R':
                        matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                        matrix = MoveSam(samCoordinates[0] , samCoordinates[1] + 1, matrix);
                        samCoordinates[1]++;
                        break;
                    case 'W':
                        break;

                }
            }
            if (!deadSam)
            {
                
                nikoladzeFound = CheckForNikoladze(matrix, samCoordinates, nikoladzeFound);
            }
            if (nikoladzeFound || deadSam)
            {
                break;
            }
            if (!deadSam)
            {
                nikoladzeFound = CheckForNikoladze(matrix, samCoordinates, nikoladzeFound);
            }
            if (nikoladzeFound || deadSam)
            {
                break;
            }
        }
        if (n==2)
        {
            nikoladzeFound = true;
            deadSam = false;
        }
        if (deadSam)
        {
            Console.WriteLine($"Sam died at {samCoordinates[0]}, {samCoordinates[1]} ");
            matrix[samCoordinates[0]][samCoordinates[1]] = 'X';
            PrintMatrix(matrix);
            nikoladzeFound = false;
        }
        if (nikoladzeFound)
        {
            Console.WriteLine("Nikoladze killed!");
            for (int i = 0; i < cols; i++)
            {
                if (matrix[samCoordinates[0]][i]!='N')
                {
                    continue;
                }
                if (matrix[samCoordinates[0]][i] == 'N')
                {
                    matrix[samCoordinates[0]][i] = 'X';
                    PrintMatrix(matrix);
                }
                break;
            }
        }
       
    }

    private static bool CheckForNikoladze(char[][] matrix, int[] samCoordinates, bool nikoladzeFound)
    {
        for (int colIndex = 0; colIndex < cols; colIndex++)
        {
            if (matrix[samCoordinates[0]][colIndex] != 'N')
            {
                continue;
            }
            nikoladzeFound = true;
            break;
        }
        return nikoladzeFound;
    }

    private static bool CheckToRight(char[][] matrix, int[] samCoordinates, bool deadSam)
    {
        for (int colIndex = samCoordinates[1]; colIndex < cols; colIndex++)
        {
            if (matrix[samCoordinates[0]][colIndex] != 'd')
            {
                continue;
            }
            deadSam = true;
            break;
        }

        return deadSam;
    }

    private static bool CheckToLeft(char[][] matrix, int[] samCoordinates, bool deadSam)
    {
        for (int colIndex = 0; colIndex < samCoordinates[1]; colIndex++)
        {
            if (matrix[samCoordinates[0]][colIndex] != 'b')
            {
                continue;
            }
            deadSam = true;
            break;
        }

        return deadSam;
    }

    private static void PrintMatrix(char[][] matrix)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <cols; j++)
            {
                Console.Write(matrix[i][j]);
            }
            Console.WriteLine();
        }
     
    }

    private static char[][] MoveSam(int row, int col, char[][] matrix)
    {
        matrix[row][col] = 'S';
        return matrix;

    }



    private static int[] GetSamCoordinates(char[][] matrix)
    {
        int[] coordinates = new int[2];
        bool brake=false;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] != 'S')
                {
                    continue;
                }
                coordinates[0] = i;
                coordinates[1] = j;
                brake = true;
                break;

            }
            if (brake)
            {
                break;
            }
        }
        return coordinates;
    }

    private static char[][] moveEnemies(char[][] matrix)
    {
        for (int rowIndex = 0; rowIndex < n; rowIndex++)
        {
            bool movedOut = false;
            for (int colIndex = 0; colIndex < cols;  colIndex++)
            {
               
                if (movedOut || matrix[rowIndex][colIndex] == '.' || matrix[rowIndex][colIndex] == 'N' || matrix[rowIndex][colIndex] == 'S')
                {
                    continue;
                }
                if (matrix[rowIndex][colIndex] == 'b')
                {
                    if (InMatrix(rowIndex, colIndex + 1))
                    {
                        matrix[rowIndex][colIndex] = '.';
                        matrix[rowIndex][colIndex + 1] = 'b';
                        movedOut = true;
                        continue;
                    }
                    matrix[rowIndex][colIndex] = 'd';
                    movedOut = true;
                    continue;
                }
                if (matrix[rowIndex][colIndex] == 'd')
                {
                    if (InMatrix(rowIndex, colIndex - 1))
                    {
                        matrix[rowIndex][colIndex] = '.';
                        matrix[rowIndex][colIndex - 1] = 'd';
                        movedOut = true;
                        continue;
                    }
                    matrix[rowIndex][colIndex] = 'b';
                    movedOut = true;
                    continue;
                }
            }
        }
        return matrix;
    }

    private static bool InMatrix(int row, int col)
    {
        bool isInMatrix = row >= 0 && row < n && col >= 0 && col < cols;
        return isInMatrix;
    }
}

