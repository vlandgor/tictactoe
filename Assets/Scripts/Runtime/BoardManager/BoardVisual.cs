using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.BoardManager
{
    public abstract class BoardVisual : MonoBehaviour, IBoardVisual
    {
        protected BoardTile[,] tiles;

        public abstract UniTask GenerateBoardVisual(Vector2Int boardSize, Func<BoardTile> getTile);
    }
}