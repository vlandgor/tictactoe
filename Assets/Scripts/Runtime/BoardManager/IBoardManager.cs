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
        public event Action<BoardPosition> OnMoveRequested; 
        
        public UniTask Initialize(IBoardData boardData);
        public UniTask PlacePiece(IPlayer player, BoardPosition boardPosition, PieceType pieceType);
        public void CheckBoard(out IPlayer winner, out bool draw);
        public UniTask ClearBoard();
    }
}