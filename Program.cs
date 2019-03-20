using System;

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

    public static void Game(string[,] array2D)
    {
        int tempX = 0;
        int tempY = 0;
        int counter = 0;
        bool condition = true;

        while (condition) {
            PrintMatrix(array2D);

            if (counter == 3) {
                if (WinCondition(array2D))
                    Console.WriteLine("You Win!");
                else {
                    Console.WriteLine("Nobody Wins!");
                }
                condition = false;
            }

            Console.Write(@"Where do you want to put your X : ");
            tempX = int.Parse(Console.ReadLine());
            tempY = int.Parse(Console.ReadLine());
            array2D[tempX, tempY] = "X";
            counter++;

            if (tempX == -1 || tempY == -1) break;
            
            AiController(array2D);
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

        if (array2D[0, 0] == array2D[1, 1] && array2D[0, 0] == array2D[2, 2])
            return true;
        else if (array2D[2, 0] == array2D[1, 1] && array2D[2, 0] == array2D[0, 2])
            return true;

        return false;
    }

    public static void AiController(string[,] array2D)
    {
        bool conditionMet = false;

        while (!conditionMet) {
            Random rand = new Random();
            int aiTurnX = rand.Next(0, 3);
            int aiTurnY = rand.Next(0, 3);

            if (array2D[aiTurnX, aiTurnY] != "X") {
                array2D[aiTurnX, aiTurnY] = "O";
                conditionMet = true;
            }
        }
    }
}
