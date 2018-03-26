using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RubiksMatrix
{
    private static int[,] originalMatrix;
    private static int rows;
    private static int columns;
    static void Main()
    {
        var args = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        int[,] modifiedMatrix = StoringDataToMatrix(args);
        modifiedMatrix = executingCommands(modifiedMatrix);
        printingRearangeCommands(modifiedMatrix);
    }

    private static void printingRearangeCommands(int[,] modifiedMatrix)
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < columns; colIndex++)
            {
                var originalValue = originalMatrix[rowIndex, colIndex];
                if (modifiedMatrix[rowIndex, colIndex] == originalValue)
                {
                    Console.WriteLine("No swap required");
                    continue;
                }

                for (int searchRow = 0; searchRow < rows; searchRow++)
                {
                    bool hasMatch = false;
                    for (int searchCol = 0; searchCol < columns; searchCol++)
                    {
                        if (modifiedMatrix[searchRow, searchCol] == originalValue)
                        {
                            hasMatch = true;
                            var swap = modifiedMatrix[rowIndex, colIndex];
                            modifiedMatrix[rowIndex, colIndex] =originalValue;
                            modifiedMatrix[searchRow, searchCol] = swap;
                            Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({searchRow}, {searchCol})");
                            break;
                        }
                    }
                    if (hasMatch==true)
                    {
                        break;
                    }
                }
            }
        }
    }

    private static int[,] executingCommands(int[,] modifiedMatrix)
    {
        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int commandLine = 0; commandLine < numberOfCommands; commandLine++)
        {
            var args = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int rotateRowCol = int.Parse(args[0]);
            string command = args[1];
            int countOfMoves = int.Parse(args[2]);
            if (command == "up" || command == "down")
            {
                modifiedMatrix = rotateColumn(modifiedMatrix, rotateRowCol, countOfMoves, command);
            }
            else if (command == "right" || command == "left")
            {
                modifiedMatrix = rotateRow(modifiedMatrix, rotateRowCol, countOfMoves, command);
            }
        }
        return modifiedMatrix;
    }
    private static int[,] rotateRow(int[,] modifiedMatrix, int rotateRowCol, int countOfMoves, string command)
    {
        int[,] matrixCopy = CopyMatrix(modifiedMatrix);
        countOfMoves = countOfMoves % columns;
        if (command == "left")
        {
            countOfMoves *= -1;
        }
        for (int columnIndex = 0; columnIndex < columns; columnIndex++)
        {
            var moveColumn = (columnIndex + countOfMoves) % columns;
            while (moveColumn < 0)
            {
                moveColumn += columns;
            }
            modifiedMatrix[rotateRowCol, moveColumn] = matrixCopy[rotateRowCol, columnIndex];
        }
        return modifiedMatrix;

    }

    

    private static int[,] rotateColumn(int[,] modifiedMatrix, int rotateRowCol, int countOfMoves, string command)
    {
        int[,] matrixCopy = CopyMatrix(modifiedMatrix);
        countOfMoves = countOfMoves % rows;
        if (command == "up")
        {
            countOfMoves *= -1;
        }
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            var moveRow = (rowIndex + countOfMoves) % rows;
            while (moveRow < 0)
            {
                moveRow += rows;
            }
            modifiedMatrix[moveRow, rotateRowCol] = matrixCopy[rowIndex, rotateRowCol];
        }
        return modifiedMatrix;

    }

    private static int[,] CopyMatrix(int[,] modifiedMatrix)
    {
        int[,] CopyMatrix = new int[rows, columns];
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < columns; colIndex++)
            {
                CopyMatrix[rowIndex, colIndex] = modifiedMatrix[rowIndex, colIndex];
            }
        }
        return CopyMatrix;
    }
    private static int[,] StoringDataToMatrix(List<int> args)
    {
        rows = args[0];
        columns = args[1];
        int[,] modifiedMatrix = new int[rows, columns];
        originalMatrix = new int[rows, columns];
        int counter = 1;
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columns; columnIndex++)
            {
                modifiedMatrix[rowIndex, columnIndex] = counter;
                originalMatrix[rowIndex, columnIndex] = counter;
                counter++;
            }
        }

        return modifiedMatrix;
    }
}

