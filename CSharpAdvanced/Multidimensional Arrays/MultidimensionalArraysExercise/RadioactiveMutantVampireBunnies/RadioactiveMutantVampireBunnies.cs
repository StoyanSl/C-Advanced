using System;
using System.Linq;

class RadioactiveMutantVampireBunnies
{
    private static char player = 'P';
    private static char bunny='B';
    private static char emptySpace = '.';
    private static char newBunny = 'b';

    private static char left = 'L';
    private static char right = 'R';
    private static char up= 'U';
    private static char down = 'D';

    private static bool alive = true;
    private static bool OutOfLiar = false;
    private static int playerRow;
    private static int playerCol;
    private static int rows;
    private static int cols;
    static void Main()
    {
        char[][] matrix = GetMatrix();
        matrix=EscapingLiar(matrix);
        printOutput(matrix);
        if (alive)
        {
            Console.WriteLine($"won: {playerRow} {playerCol}");
        }
        else
        {
            Console.WriteLine($"dead: {playerRow} {playerCol}");
        }
    }
    
    private static char[][] EscapingLiar(char[][] matrix)
    {
        var commands = Console.ReadLine().ToCharArray().ToList();
        for (int moves = 0; moves < commands.Count; moves++)
        {
            matrix = ExecuteMove(commands[moves], matrix);
            matrix = BunniesMultiplication(matrix);
            if (!alive||OutOfLiar)
            {
                break;
            }
        }
        return matrix;
    }

    private static char[][] ExecuteMove(char command, char[][] matrix)
    {
        if (command==up)
        {
            int newRowPosition = playerRow - 1;
            int newColPosition = playerCol;
            matrix = MovePlayer( newRowPosition,newColPosition,matrix);
          
        }
        else if(command==down)
        {
            int newRowPosition = playerRow + 1;
            int newColPosition = playerCol;
            matrix = MovePlayer( newRowPosition, newColPosition, matrix);
        }
        else if (command == left)
        {
            int newRowPosition = playerRow ;
            int newColPosition = playerCol-1;
            matrix = MovePlayer( newRowPosition, newColPosition, matrix);
        }
        else if (command == right)
        {
            int newRowPosition = playerRow;
            int newColPosition = playerCol+1;
            matrix = MovePlayer(newRowPosition, newColPosition, matrix);
        }
        return matrix;
    }

    private static char[][] MovePlayer(int newRowPosition, int newColPosition, char[][] matrix)
    {
        if (!InMatrix(newRowPosition, newColPosition))
        {
            matrix[playerRow][playerCol] = emptySpace;
            OutOfLiar = true;
            return matrix;
        }
        if (matrix[newRowPosition][newColPosition] == emptySpace)
        {
            matrix[playerRow][playerCol] = emptySpace;
            matrix[newRowPosition][newColPosition] = player;
            playerRow = newRowPosition;
            playerCol = newColPosition;
            return matrix;
        }
        if (matrix[newRowPosition][newColPosition] == bunny)
        {
            playerRow = newRowPosition;
            playerCol = newColPosition;
            alive = false;
        }
        return matrix;
    }

    private static char[][] BunniesMultiplication(char[][] matrix)
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                if (matrix[rowIndex][colIndex]!=bunny)
                {
                    continue;
                }
                    matrix = AddBunny(matrix, rowIndex + 1, colIndex);
                    matrix = AddBunny(matrix, rowIndex - 1, colIndex);
                    matrix = AddBunny(matrix, rowIndex, colIndex + 1);
                    matrix = AddBunny(matrix, rowIndex, colIndex - 1);
            }
        }
        matrix = NewBunniesToOldBunies(matrix);

        return matrix;
    }

    private static char[][] AddBunny(char[][] matrix, int rowIndex, int colIndex)
    {
        if (InMatrix(rowIndex, colIndex))
        {
            if (matrix[rowIndex][colIndex] == player)
            {
                alive = false;
            }
            if (matrix[rowIndex][colIndex] != bunny)
            {
                matrix[rowIndex][colIndex] = newBunny;
            }

        }
        return matrix;
    }

    private static char[][] NewBunniesToOldBunies(char[][] matrix)
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                if (matrix[rowIndex][colIndex]!=newBunny)
                {
                    continue;
                }
                matrix[rowIndex][colIndex] = bunny;
            }
        }
        return matrix;
    }

    private static bool InMatrix(int rowIndex, int colIndex)
    {
        if (rowIndex >= 0 && rowIndex < rows && colIndex >= 0 && colIndex < cols)
        {
            return true;
        }
        return false;
    }

    private static char[][] GetMatrix()
    {

        var args = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        rows = args[0];
        cols = args[1];
        char[][] matrix = new char[rows][];
        for (int lines = 0; lines < rows; lines++)
        {
            var row = Console.ReadLine().ToCharArray();
            matrix[lines] = row;
        }
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                if (matrix[rowIndex][colIndex]!=player)
                {
                    continue;
                }
                playerRow = rowIndex;
                playerCol = colIndex;
            }
        }
        return matrix;
    }

    private static void printOutput(char[][] matrix)
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                Console.Write(matrix[rowIndex][colIndex]);
            }
            Console.WriteLine();
        }
    }
}

