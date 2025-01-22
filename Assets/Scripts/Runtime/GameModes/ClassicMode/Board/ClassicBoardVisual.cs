using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using UnityEngine;

namespace Runtime.GameModes.ClassicMode.Board
{
    public class ClassicBoardVisual : BoardVisual
    {
        public override async UniTask GenerateBoardVisual(Vector2Int boardSize, Func<BoardTile> getTile)
        {
            tiles = new BoardTile[boardSize.x, boardSize.y];
            
            for (int x = 0; x < boardSize.x; x++)
            {
                for (int y = 0; y < boardSize.y; y++)
                {
                    tiles[x, y] = getTile();
                    tiles[x, y].transform.position = new Vector3(x, 0, y);
                }
            }
            
            await UniTask.Yield();
        }
    }
}