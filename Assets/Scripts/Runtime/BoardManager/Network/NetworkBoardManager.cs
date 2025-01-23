using System;
using Cysharp.Threading.Tasks;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class NetworkBoardManager : MonoBehaviour, IBoardManager
    {
        public event Action<Vector2Int> OnTileClicked;

        public async UniTask Initialize(IBoardData boardData)
        {
            
        }

        public async UniTask PlacePiece(IPlayer player, Vector2Int coordinate)
        {
            
        }
    }
}