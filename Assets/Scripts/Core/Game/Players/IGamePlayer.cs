using System;
using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;

namespace Core.Game.Players
{
    public interface IGamePlayer
    {
        public event Action<PieceType, BoardTile> PerformMove;
    }
}