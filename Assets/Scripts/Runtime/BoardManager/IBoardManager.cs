using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager.Local;
using Runtime.GamePieces;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.BoardManager
{
    public interface IBoardManager
    {
        public event Action<BoardPosition> OnTileClicked; 
        public event Action<IPlayer> OnWinnerDetected;
        public event Action OnDrawDetected;
        
        public UniTask Initialize(IBoardData boardData);
        public UniTask PlacePiece(IPlayer player, BoardPosition boardPosition, PieceType pieceType, Action piecePlaced);
        public UniTask ClearBoard();
    }
}