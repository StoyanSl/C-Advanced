using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    public const char king = 'K';
    public const char rook = 'R';
    public const char bishop = 'B';
    public const char queen = 'Q';
    public const char pawn = 'P';
    public const char emptyCell = 'x';
    public const int size = 8;
    static void Main()
    {
        char[][] floor = GetMatrix();

        while (true)
        {
            var input = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (input[0] == "END")
            {
                break;
            }
            floor = ExecuteCommand(floor, input);

        }
    }

    private static char[][] ExecuteCommand(char[][] floor, List<string> input)
    {
        char symbol = input[0][0];
        int symbolRow = int.Parse(input[0][1].ToString());
        int symbolCol = int.Parse(input[0][2].ToString());
        int moveRow = int.Parse(input[1][0].ToString());
        int moveCol = int.Parse(input[1][1].ToString());
        switch (symbol)
        {
            case king:
                floor = executeKingCommand(floor, symbolRow, symbolCol, moveRow, moveCol);
                break;
            case rook:
                floor = executeRookCommand(floor, symbolRow, symbolCol, moveRow, moveCol);
                break;
            case bishop:
                floor = executeBishopCommand(floor, symbolRow, symbolCol, moveRow, moveCol);
                break;
            case queen:
                floor = executeQueenCommand(floor, symbolRow, symbolCol, moveRow, moveCol);
                break;
            case pawn:
                floor = executePawnCommand(floor, symbolRow, symbolCol, moveRow, moveCol);
                break;
            default:
                break;
        }
        return floor;
    }

    private static char[][] executePawnCommand(char[][] floor, int symbolRow, int symbolCol, int moveRow, int moveCol)
    {
        if (floor[symbolRow][symbolCol] != pawn)
        {
            Console.WriteLine("There is no such a piece!");
            return floor;
        }
        if (symbolCol != moveCol || symbolRow != moveRow + 1)
        {
            Console.WriteLine("Invalid move!");
            return floor;
        }
        if (!InMatrix(moveRow, moveCol))
        {
            Console.WriteLine("Move go out of board!");
            return floor;
        }
        floor[symbolRow][symbolCol] = emptyCell;
        floor[moveRow][moveCol] = pawn;
        return floor;
    }

    private static char[][] executeQueenCommand(char[][] floor, int symbolRow, int symbolCol, int moveRow, int moveCol)
    {
        if (floor[symbolRow][symbolCol] != queen)
        {
            Console.WriteLine("There is no such a piece!");
            return floor;
        }
        bool onDiagonal = checkIsOnDiagonals(floor, 0, symbolCol - symbolRow, 0, (symbolCol - symbolRow) + (symbolRow * 2), moveRow, moveCol);
        if (!onDiagonal)
        {
            if (symbolRow != moveRow && symbolCol != moveCol)
            {
                Console.WriteLine("Invalid move!");
                return floor;
            }
           
        }
       
        if (!InMatrix(moveRow, moveCol))
        {
            Console.WriteLine("Move go out of board!");
            return floor;
        }
        floor[symbolRow][symbolCol] = emptyCell;
        floor[moveRow][moveCol] = queen;
        return floor;
    }

    private static char[][] executeBishopCommand(char[][] floor, int symbolRow, int symbolCol, int moveRow, int moveCol)
    {
        if (floor[symbolRow][symbolCol] != bishop)
        {
            Console.WriteLine("There is no such a piece!");
            return floor;
        }
       
        bool onDiagonal = checkIsOnDiagonals(floor, 0,symbolCol-symbolRow,0,(symbolCol-symbolRow)+(symbolRow*2),moveRow,moveCol);
        if (!onDiagonal)
        {
            Console.WriteLine("Invalid move!");
            return floor;
        }

        if (!InMatrix(moveRow, moveCol))
        {
            Console.WriteLine("Move go out of board!");
            return floor;
        }
        floor[symbolRow][symbolCol] = emptyCell;
        floor[moveRow][moveCol] = bishop;
        return floor;
    }

    private static bool checkIsOnDiagonals(char[][] floor, int startRow, int startCol, int secondStartRow, int secondStartCol, int moveRow, int moveCol)
    {

        while (startRow<=8||secondStartRow<=8)
        {
            if (startRow==moveRow&&startCol==moveCol)
            {
                return true;
            }
            startRow++;
            startCol++;
            if (secondStartRow==moveRow&&secondStartCol==moveCol)
            {
                return true;
            }
            secondStartRow++;
            secondStartCol--;
        }
      
        return false;
    }

    private static char[][] executeRookCommand(char[][] floor, int symbolRow, int symbolCol, int moveRow, int moveCol)
    {
        if (floor[symbolRow][symbolCol] != rook)
        {
            Console.WriteLine("There is no such a piece!");
            return floor;
        }
        if (symbolRow != moveRow && symbolCol != moveCol)
        {
            Console.WriteLine("Invalid move!");
            return floor;
        }
        if (!InMatrix(moveRow, moveCol))
        {
            Console.WriteLine("Move go out of board!");
            return floor;
        }
        floor[symbolRow][symbolCol] = emptyCell;
        floor[moveRow][moveCol] = rook;
        return floor;
    }

    private static char[][] executeKingCommand(char[][] floor, int symbolRow, int symbolCol, int moveRow, int moveCol)
    {
        if (floor[symbolRow][symbolCol] != king)
        {
            Console.WriteLine("There is no such a piece!");
            return floor;
        }
        var difRow = Math.Abs(symbolRow - moveRow);
        var difCol = Math.Abs(symbolCol - moveCol);
        if (difCol >= 2 || difRow >= 2)
        {
            Console.WriteLine("Invalid move!");
            return floor;
        }
        if (!InMatrix(moveRow, moveCol))
        {
            Console.WriteLine("Move go out of board!");
            return floor;
        }
        floor[symbolRow][symbolCol] = emptyCell;
        floor[moveRow][moveCol] = king;
        return floor;

    }

    private static bool InMatrix(int symbolRow, int symbolCol)
    {
        if (symbolCol >= 0 && symbolCol <= 7 && symbolRow >= 0 && symbolRow <= 7)
        {
            return true;
        }
        return false;
    }

    private static char[][] GetMatrix()
    {
        char[][] matrix = new char[size][];
        for (int i = 0; i < size; i++)
        {
            var line = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            matrix[i] = line;
        }
        return matrix;
    }
}

