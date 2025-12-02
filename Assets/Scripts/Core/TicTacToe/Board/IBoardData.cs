using UnityEngine;

namespace Core.TicTacToe.Board
{
    public interface IBoardData
    {
        public BoardSize BoardSize { get; }
    }
}