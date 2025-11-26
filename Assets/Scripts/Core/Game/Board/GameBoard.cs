using System;
using Core.Game.Board.Pieces;
using Core.Game.Board.Tiles;
using UnityEngine;

namespace Core.Game.Board
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField] private BoardVisualBase _boardVisualBase;
        
        private BoardBase _boardBase;

        private void Start()
        {
            IBoardData boardData = new BoardData(new Vector2Int(3, 3));
            Initialize(boardData);
        }

        public void Initialize(IBoardData boardData)
        {
            _boardBase = new BoardBase();
            
            _boardBase.CreateBoard(boardData);
            
            _boardVisualBase.Initialize(boardData);
        }

        public void PlacePiece(PieceType pieceType, BoardTile boardTile)
        {
            _boardBase.PlacePiece(pieceType, boardTile);
            _boardVisualBase.PlacePiece(pieceType, boardTile);
        }
        
        public bool TryGetWinnerOrDraw(out PieceType winner)
        {
            _boardBase.CheckForWinner(out winner);
            _boardBase.CheckForDraw(out bool draw);

            return winner != PieceType.None || draw;
        }

        public void ClearBoard()
        {
            _boardBase.ClearBoard();
            _boardVisualBase.ClearBoard();
        }

        public bool IsTileAvailable(BoardTile boardTile, PieceType pieceType)
        {
            return _boardBase.IsTileAvailable(boardTile.BoardPosition);
        }
    }
}