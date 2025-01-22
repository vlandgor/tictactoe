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
                    BoardTile tile = tiles[x, y] = getTile();
                    tile.transform.position = new Vector3(x, 0, y);
                    tile.SetCoordinates(new Vector2Int(x, y));
                }
            }
            
            await UniTask.Yield();
        }
    }
}