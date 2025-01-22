using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.BoardManager
{
    public interface IBoardVisual
    {
        public UniTask GenerateBoardVisual(Vector2Int boardSize, Func<BoardTile> getTile);
    }
}