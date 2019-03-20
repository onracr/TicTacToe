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
                Console.Write(" {0} ", refArray[i, j]);
            }
            Console.Write(Environment.NewLine);
        }
        Console.Write(Environment.NewLine);
    }

    public static void Game(string[,] refArray)
    {

        while (true) {
            PrintMatrix(refArray);


            if (WinCondition(refArray)) {
                Console.WriteLine("You Win!");
                Console.Write("Play Again? (y/n)  ");
                char input = Convert.ToChar(Console.ReadLine());
                if (input == 'y') {
                    ResetGame();
                }
                else{
                    Console.WriteLine("Good Bye!");
                    break;
                }
            }

            PlayerTurn(refArray);
            AiTurn(refArray);
        }
    }

    public static bool WinCondition(string[,] array2D)
    {
        for (int i = 0; i < array2D.GetLength(0); i++) {
            for (int j = 1; j < array2D.GetLength(1); j++) {
                if (array2D[0, i] == array2D[j, i] && array2D[0, i] != "_") {
                    if (j == 2)
                        return true;
                }
                else if (array2D[i, 0] == array2D[i, j] && array2D[0, i] != "_") {
                    if (j == 2)
                        return true;
                }
                else
                    break;
            }
        }

        if (array2D[0, 0] == array2D[1, 1] && array2D[0, 0] == array2D[2, 2] && array2D[0, 0] != "_")
            return true;
        else if (array2D[2, 0] == array2D[1, 1] && array2D[2, 0] == array2D[0, 2] && array2D[1, 1] != "_")
            return true;

        return false;
    }

    public static void ResetGame()
    {
        string[,] originalArray = new[,]{
            { "_", "_", "_"},
            { "_", "_", "_"},
            { "_", "_", "_"},
        };

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

            if (array2D[aiTurnX, aiTurnY] != "X" && array2D[aiTurnX, aiTurnY] != "O") {
                array2D[aiTurnX, aiTurnY] = "O";
                conditionMet = true;
            }
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

            if (refArray[tempX, tempY] != "O" && refArray[tempX, tempY] != "X") {
                refArray[tempX, tempY] = "X";
                condition = true;
            }
            else
                Console.WriteLine("Those coordinates are taken, Please choose some other ones.");
            

        }
        PrintMatrix(refArray);
    }

}
