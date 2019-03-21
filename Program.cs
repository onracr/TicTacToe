using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static string[,] array2D = new string[,]
        {
            {"_", "_", "_"},
            {"_", "_", "_"},
            {"_", "_", "_"},
        };
    static int counter = 0;

    static void Main(string[] args)
    {
        Game(array2D);
    }

    public static void PrintMatrix(string[,] refArray)
    {
        Console.Clear();
        Console.WriteLine(Environment.NewLine +
        "---------------------Tic Tac Toe Game---------------------" +
        Environment.NewLine);

        for (int i = 0; i < refArray.GetLength(0); i++) {
            Console.Write("\t \t \t");
            for (int j = 0; j < refArray.GetLength(1); j++) {
                Console.Write($" {refArray[i, j]} ");
            }
            Console.Write(Environment.NewLine);
        }
        Console.Write(Environment.NewLine);
    }

    public static void Game(string[,] refArray)
    {
        bool flag = false;

        while (!flag) {
            PrintMatrix(refArray);

            int conditions = WinCondition(refArray);

            if (conditions != -1)
                if (!Restart(conditions))
                    break;

            PlayerTurn(refArray);
            AiTurn(refArray);
        }
    }

    public static int WinCondition(string[,] array2D)
    {
        var ongoingSession = -1;
        var draw = 0;
        var win = 1;
        var lose = 2;
        var emptyTile = 9;

        // Column Check
        for (int i = 0; i < array2D.GetLength(0); i++) {
            for (int j = 0; j < array2D.GetLength(1); j++) {
                if (array2D[j, i] == array2D[j + 1, i] && array2D[j, i] != "_") {
                    if (j == 1) {
                        if (array2D[j + 1, i] == "X")
                            return win;
                        else
                            return lose;
                    }
                }
                else
                    break;
            }
        }
        // Row Check
        for (int i = 0; i < array2D.GetLength(0); i++) {
            for (int j = 0; j < array2D.GetLength(1); j++) {
                if (array2D[i, j] == array2D[i, j + 1] && array2D[i, j] != "_") {
                    if (j == 1) {
                        if (array2D[j + 1, i] == "X")
                            return win;
                        else
                            return lose;
                    }
                }
                else
                    break;
            }
        }

        // Diagonal Check
        if (array2D[0, 0] == array2D[1, 1] && array2D[0, 0] == array2D[2, 2] && array2D[0, 0] != "_")
            return win;
        else if (array2D[2, 0] == array2D[1, 1] && array2D[2, 0] == array2D[0, 2] && array2D[1, 1] != "_")
            return win;

        // Draw Check
        for (int i = 0; i < array2D.GetLength(0); i++) {
            for (int j = 0; j < array2D.GetLength(1); j++)
                if (array2D[i, j] != "_")
                    emptyTile--;
            if (emptyTile == 0)
                return draw;
        }
        return ongoingSession;
    }

    public static bool Restart(int conditions)
    {
        if (conditions == 1)
            Console.WriteLine("You won!");
        else if (conditions == 2)
            Console.WriteLine("You lost!");
        else
            Console.WriteLine("Draw!");

        Console.Write("Play Again? (y/n)  ");
        char input = Convert.ToChar(Console.ReadLine());

        if (input == 'y') {
            ResetGame();
            return true;
        }
        else {
            Console.WriteLine("Good Bye!");
            return false;
        }
    }

    public static void ResetGame()
    {
        string[,] originalArray = new[,]{
            { "_", "_", "_"},
            { "_", "_", "_"},
            { "_", "_", "_"},
        };
        counter = 0;

        for (int i = 0; i < originalArray.GetLength(0); i++) {
            for (int j = 0; j < originalArray.GetLength(1); j++)
                array2D[i, j] = originalArray[i, j];
        }
        PrintMatrix(array2D);
    }

    public static void AiTurn(string[,] array2D)
    {
        bool conditionMet = false;

        while (!conditionMet) {
            Random rand = new Random();
            int aiTurnX = rand.Next(0, 3);
            int aiTurnY = rand.Next(0, 3);

            if (array2D[aiTurnX, aiTurnY] == "_") { // Checking for empty tiles
                array2D[aiTurnX, aiTurnY] = "O";
                conditionMet = true;
                counter++;
            }
            if (counter == 4 || counter == 5)   // Prevents the endless loop 
                conditionMet = true;
        }
        Console.WriteLine("AI's turn...");
        System.Threading.Thread.Sleep(1000);
    }

    public static void PlayerTurn(string[,] refArray)
    {
        int tempX = 0;
        int tempY = 0;
        bool condition = false;

        while (!condition) {
            Console.Write("Please enter the X and Y coordiantes, respectively : ");
            tempX = int.Parse(Console.ReadLine());
            tempY = int.Parse(Console.ReadLine());

            if (refArray[tempX, tempY] == "_") {
                refArray[tempX, tempY] = "X";
                condition = true;
            }
            else
                Console.WriteLine("Those coordinates are taken, Please choose some other ones.");
        }
        PrintMatrix(refArray);
    }
}
