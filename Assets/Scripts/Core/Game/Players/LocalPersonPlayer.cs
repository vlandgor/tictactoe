using System;
using Core.Game.Input;
using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;

namespace Core.Game.Players
{
    public class LocalPersonPlayer : IGamePlayer, IDisposable
    {
        public event Action<PieceType, BoardTile> PerformMove;
        
        private PieceType _pieceType;
        private GameInput _gameInput;
        
        public LocalPersonPlayer(PieceType pieceType, GameInput gameInput)
        {
            _gameInput = gameInput;
            _pieceType = pieceType;

            _gameInput.TileClicked += GameInput_TileClicked;
        }

        public void Dispose()
        {
            _gameInput.TileClicked -= GameInput_TileClicked;
        }

        private void GameInput_TileClicked(BoardTile boardTile)
        {
            PerformMove?.Invoke(_pieceType, boardTile);
        }
    }
}