using System;

namespace TicTacToe
{
    /// <summary>
    /// Interface for igame
    /// </summary>
    internal interface IGame
    {
        String this[int position] { get; }
        String Winner { get; }
        Boolean Play(int position);
    }
}