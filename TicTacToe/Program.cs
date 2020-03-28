using System;

namespace TicTacToe
{
    /// <summary>
    /// Instance of the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Constant value for GameSeparator
        /// </summary>
        const string GameSeparator = "\n-----------------------\n";

        /// <summary>
        /// Main method of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var keepPlaying = true;
            
            while (keepPlaying)
            {
                var game = new TicTacToe();
                var winStatus = false;
                DisplayWelcome();
                while (!winStatus)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (!Char.IsNumber(keyInfo.KeyChar) || int.Parse(keyInfo.KeyChar.ToString()) == 0) { Console.WriteLine("Use only number 1-9."); }
                    else
                    {
                        var position = int.Parse(keyInfo.KeyChar.ToString()) - 1;
                        winStatus = game.Play(position);
                        Console.WriteLine(GameSeparator);
                    }
                }
                keepPlaying = PlayAgain();
            }
            Console.Read();
        }

        /// <summary>
        /// This will display welcome message and how to play
        /// </summary>
        private static void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(GameSeparator);
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Use 1-9 number/numpad");
            Console.WriteLine(" 7 | 8 | 9 ");
            Console.WriteLine("-----------");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("-----------");
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("Enjoy!!!");
            Console.WriteLine(GameSeparator);
            Console.ResetColor();
        }

        /// <summary>
        /// Display if players want to play again
        /// </summary>
        /// <returns>True if wants to play again else False</returns>
        private static bool PlayAgain()
        {
            Console.WriteLine(GameSeparator);
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            var choice = VerifyAnswer("Select your option (1=Yes or 2=No) and click Enter ", 1, 2);

            Console.Clear();
            if (choice == 1) return true;

            Console.WriteLine("Thanks for playing!");
            Console.ReadLine();
            return false;
        }

        /// <summary>
        /// Verify answer if valid to play again
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>True if yes else false</returns>
        private static int VerifyAnswer(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                int.TryParse(Console.ReadLine(), out int choice);

                if (choice >= min && choice <= max)
                {
                    return choice;
                }
            }
        }
    }
}
