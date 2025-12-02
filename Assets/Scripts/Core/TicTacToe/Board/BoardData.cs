using UnityEngine;

namespace Core.TicTacToe.Board
{
    public class BoardData : IBoardData
    {
        public BoardSize BoardSize { get; }

        public BoardData(BoardSize boardSize)
        {
            BoardSize = boardSize;
        }
    }
}