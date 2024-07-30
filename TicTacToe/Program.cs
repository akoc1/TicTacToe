#nullable disable

namespace TicTacToe
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string[] grid = SetGrid();
            string p1 = "X", p2 = "O";
            string turn = p1, winner = null;
            bool gameOver = false, isTie = false;
            int moveCount = 0;

            grid = SetGrid();

            while (gameOver == false)
            {
                ShowHelperGrid(grid);

                grid.MakeMove(turn);

                turn = ChangeTurn(turn);

                if (IsWinning(grid, p1))
                {
                    winner = p1;
                    gameOver = true;
                }

                if (IsWinning(grid, p2))
                {
                    winner = p2;
                    gameOver = true;
                }

                moveCount++;

                if (moveCount == 9 && winner == null)
                {
                    gameOver = true;
                    isTie = true;
                }

                Console.Clear();
            }

            if (isTie == true)
                Console.WriteLine($"Tie!");
            else
                Console.WriteLine($"Winner: {winner}");

            ShowGrid(grid);

            Console.ReadLine();
        }

        private static string[] SetGrid()
        {
            string[] output = new string[9];

            for (int i = 0; i < 9; i++)
            {
                output[i] = null;
            }

            return output;
        }
        private static string[] MakeMove(this string[] grid, string player)
        {
            int location = GetNumber($"{player} pick a location: ");

            if (grid[location] == null)
                grid[location] = player;
            else
            {
                while (grid[location] != null)
                {
                    ShowHelperGrid(grid);

                    location = GetNumber("Location is not empty! Enter a new location: ");
                }

                grid[location] = player;
            }

            return grid;
        }
        private static void ShowGrid(string[] grid)
        {
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                    Console.WriteLine();

                if (grid[i] != null)
                    Console.Write($"{grid[i]} ");
                else
                    Console.Write($"* ");
            }
        }
        private static void ShowHelperGrid(string[] grid)
        {
            string[] helperGrid = new string[9];
            int gridSize = grid.Length;

            for (int i = 0; i < gridSize; i++)
            {
                if (grid[i] == null)
                    helperGrid[i] = $"{i + 1} ";
                else
                    helperGrid[i] = $"{grid[i]} ";
            }

            ShowGrid(helperGrid);

            Console.WriteLine("\n");

            Console.WriteLine("-------");

            Console.WriteLine();
        }
        private static bool IsWinning(string[] grid, string player)
        {
            if (grid[0] == player && grid[1] == player && grid[2] == player ||
                grid[3] == player && grid[4] == player && grid[5] == player ||
                grid[6] == player && grid[7] == player && grid[8] == player ||
                grid[0] == player && grid[3] == player && grid[6] == player ||
                grid[1] == player && grid[4] == player && grid[7] == player ||
                grid[2] == player && grid[5] == player && grid[8] == player ||
                grid[0] == player && grid[4] == player && grid[8] == player ||
                grid[2] == player && grid[4] == player && grid[6] == player
                )
                return true;

            return false;
        }
        private static string ChangeTurn(string currentTurn)
        {
            return currentTurn == "X" ? "O" : "X";
        }
        private static string GetString(string message)
        {
            Console.Write($"{message} ");

            string output = Console.ReadLine();

            return output;
        }
        private static int GetNumber(string message)
        {
            bool isConversionSuccessful = false;
            int number = 0;

            string s = GetString(message);

            isConversionSuccessful = int.TryParse(s, out number);

            while (isConversionSuccessful == false || (number <= 0 || number >= 10))
            {
                Console.Write("Invalid number! Try again: ");

                s = Console.ReadLine();

                isConversionSuccessful = int.TryParse(s, out number);
            }

            return number - 1;
        }
    }
}
