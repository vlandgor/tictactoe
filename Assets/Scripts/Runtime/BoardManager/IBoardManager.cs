using System;
using Cysharp.Threading.Tasks;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.BoardManager
{
    public interface IBoardManager
    {
        public event Action<Vector2Int> OnTileClicked; 
        public event Action<IPlayer> OnWinnerDetected;
        public event Action OnDrawDetected;
        
        public UniTask Initialize(IBoardData boardData);
        public UniTask PlacePiece(IPlayer player, Vector2Int coordinate, Action piecePlaced);
        public UniTask ClearBoard();
    }
}