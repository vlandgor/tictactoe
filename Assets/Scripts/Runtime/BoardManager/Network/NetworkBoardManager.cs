using System;
using Cysharp.Threading.Tasks;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class NetworkBoardManager : MonoBehaviour, IBoardManager
    {
        public event Action<Vector2Int> OnTileClicked;
        public event Action<IPlayer> OnWinnerDetected;
        public event Action OnDrawDetected;

        public async UniTask Initialize(IBoardData boardData)
        {
            
        }

        public UniTask PlacePiece(IPlayer player, Vector2Int coordinate, Action piecePlaced)
        {
            throw new NotImplementedException();
        }

        public async UniTask ClearBoard()
        {
            
        }
    }
}