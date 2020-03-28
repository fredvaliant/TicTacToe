using System;
using System.Linq;

namespace TicTacToe
{
    /// <summary>
    /// Instance of TicTacToe
    /// </summary>
    internal class TicTacToe : IGame
    {
        private string[] inputs = new string[9] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        private int[] indexes = new int[9];
        private int counter;

        /// <summary>
        /// Indexer of the class
        /// </summary>
        /// <param name="position"></param>
        /// <returns>The updated board</returns>
        public String this[Int32 position] => inputs[position];


        /// <summary>
        /// Return who wins the game or cat's game
        /// </summary>
        public String Winner => HasWinner() ? counter % 2 == 1 ? "Player X Won" : "Player O Won" : "Cat's Game!";

        /// <summary>
        /// Set the value for the given position
        /// </summary>
        /// <param name="position"></param>
        /// <returns>True if there is a winner</returns>
        public Boolean Play(int position)
        {
            if (CheckIfPositionExist(position))
            {
                Console.WriteLine($"A player already used position {position+1}. Select other position. ");
            }
            else
            {
                indexes[counter] = position + 1;
                inputs[position] = counter % 2 != 1 ? "X" : "O";
                counter++;
            }

            Console.WriteLine(DrawBoard());
            return GameStatus();
            
        }

        /// <summary>
        /// Provide the status of winner or end of game
        /// </summary>
        /// <returns>True if has winner or end of game else false</returns>
        private bool GameStatus()
        {
            var result = HasWinner();
            if (result || counter == indexes.Length)
            {
                Console.WriteLine("\n-----------------------\n");
                Console.WriteLine(Winner);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// This will display the board
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Updated board</returns>
        private String DrawBoard() => $" {inputs[6]} | {inputs[7]} | {inputs[8]}\n-----------\n {inputs[3]} | {inputs[4]} | {inputs[5]}\n-----------\n {inputs[0]} | {inputs[1]} | {inputs[2]}";

        /// <summary>
        /// Check if given position is already occupy
        /// </summary>
        /// <param name="position"></param>
        /// <returns>True if position is occupy else false</returns>
        private Boolean CheckIfPositionExist(int position) => indexes.Where(x => x == position + 1).Any();

        /// <summary>
        /// This will check if there is a line
        /// </summary>
        /// <param name="index0"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <param name="piece"></param>
        /// <returns>True if its a line else False</returns>
        private Boolean IsLine(int index0, int index1, int index2)
        {
            var piece = inputs[index0 - 1];
            return inputs[index0 - 1] == piece && inputs[index1 - 1] == piece && inputs[index2 - 1] == piece && piece.Trim() != string.Empty;
        }

        /// <summary>
        /// This will check if there's a winner
        /// </summary>
        /// <returns>Returns true if has succeeds in placing three of X/O marks</returns>
        private Boolean HasWinner()
        {
            return IsLine(1, 2, 3) || // Horizontal 
                   IsLine(4, 5, 6) || // Horizontal 
                   IsLine(7, 8, 9) || // Horizontal 
                   IsLine(1, 5, 9) || // Diagonal
                   IsLine(7, 5, 3) || // Diagonal
                   IsLine(1, 4, 7) || // Vertical
                   IsLine(2, 5, 8) || // Vertical
                   IsLine(3, 6, 9);   // Vertical
        }
    }
}