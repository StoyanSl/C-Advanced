using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    public static char knight = 'K';
    public static char emptySquare = '0';
    public static int rows;
    public static int removedKnightsCounter = 0;
    static void Main()
    {
        char[][] chessBoard = GetMatrix();
        if (rows>=2)
        {
            FindAndRemoveKnights(chessBoard);
            Console.WriteLine(removedKnightsCounter);

        }
        else
        {
            Console.WriteLine(0);
        }
    }
    private static void FindAndRemoveKnights(char[][] chessBoard)
    {
        bool removesRequired = false;
        while (!removesRequired)
        {
            int[] coordinatesToRemove = FindKnightCoordinates(chessBoard);
            chessBoard = RemoveKnight(coordinatesToRemove,chessBoard);
            removesRequired = AnyCollisionsLeft(chessBoard);
        }
    }

    private static bool AnyCollisionsLeft(char[][]chessBoard)
    {
        int counter=0;
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < rows; colIndex++)
            {
                if (chessBoard[rowIndex][colIndex]!=knight)
                {
                    continue;
                }
                counter = GetNumberOfCollisions(chessBoard, rowIndex, colIndex);
                if (counter>0)
                {
                    break;
                }
            }
            if (counter > 0)
            {
                break;
            }
        }
        if (counter == 0)
        {
            return true;
        }
        return false;
    }

    private static char[][] RemoveKnight(int[] coordinatesToRemove,char[][] chessBoard)
    {
        chessBoard[coordinatesToRemove[0]][coordinatesToRemove[1]] = emptySquare;
        removedKnightsCounter++;
        return chessBoard;
    }

    private static int[] FindKnightCoordinates(char[][] chessBoard)
    {
        int[] coordinates = new int[2];
        int collisionCounter = int.MinValue;
        int currentCollisionCount;
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < rows; colIndex++)
            {
               
                if (chessBoard[rowIndex][colIndex]!=knight)
                {
                    continue;
                }
                currentCollisionCount = GetNumberOfCollisions(chessBoard, rowIndex, colIndex);
                if (collisionCounter<currentCollisionCount)
                {
                    collisionCounter = currentCollisionCount;
                    coordinates[0] = rowIndex;
                    coordinates[1] = colIndex;
                }
                
            }
        }
        return coordinates;
    }

    private static int GetNumberOfCollisions(char[][] chessBoard, int rowIndex, int colIndex)
    {
        int counter = 0;
        if (InMatrix(rowIndex + 2,colIndex  + 1))
        {
            if (chessBoard[rowIndex+2][colIndex+1]==knight)
            {
                counter++;
            }
        }
        if (InMatrix(rowIndex + 2, colIndex - 1))
        {
            if (chessBoard[rowIndex + 2][colIndex - 1] == knight)
            {
                counter++;
            }
        }
        if (InMatrix(rowIndex - 2, colIndex - 1))
        {
            if (chessBoard[rowIndex - 2][colIndex -1] == knight)
            {
                counter++;
            }
        }
        if (InMatrix(rowIndex - 2, colIndex + 1))
        {
            if (chessBoard[rowIndex -2][colIndex + 1] == knight)
            {
                counter++;
            }
        }   
        if (InMatrix(rowIndex - 1, colIndex + 2))
        {
            if (chessBoard[rowIndex -1][colIndex +2] == knight)
            {
                counter++;
            }
        }
        if (InMatrix(rowIndex - 1, colIndex - 2))
        {
            if (chessBoard[rowIndex -1][colIndex -2] == knight)
            {
                counter++;
            }
        }
        if (InMatrix(rowIndex + 1, colIndex + 2))
        {
            if (chessBoard[rowIndex + 1][colIndex + 2] == knight)
            {
                counter++;
            }
        }
        if (InMatrix(rowIndex + 1, colIndex - 2))
        {
            if (chessBoard[rowIndex + 1][colIndex -2] == knight)
            {
                counter++;
            }
        }
        return counter;
    }
    private static bool InMatrix(int rowIndex, int colIndex)
    {
        if (rowIndex >= 0 && rowIndex < rows && colIndex >= 0 && colIndex < rows)
        {
            return true;
        }
        return false;
    }
    private static char[][] GetMatrix()
    {
        
        rows = int.Parse(Console.ReadLine());
        char[][] chessBoard = new char[rows][];
        for (int lines = 0; lines < rows; lines++)
        {
           var line= Console.ReadLine().ToCharArray();
            chessBoard[lines] = line;
        }
        return chessBoard;
    }
}

