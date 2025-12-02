using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;
using UnityEngine;

namespace Core.TicTacToe.Board
{
    public class TicTacToeBoard : MonoBehaviour
    {
        [SerializeField] private BoardVisualBase _boardVisualBase;
        
        private BoardBase _boardBase;

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