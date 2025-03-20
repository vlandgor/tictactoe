using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.BoardManager.Local;
using UnityEngine;

namespace Runtime.GameModes.ClassicMode.Board
{
    public class ClassicBoardVisual : BoardVisual
    {
        private ClassicBoardData ClassicBoardData => _boardData as ClassicBoardData;

        protected override async UniTask GenerateBoardVisual()
        {
            tiles = new BoardTile[ClassicBoardData.Size.x, ClassicBoardData.Size.y];
            
            for (int x = 0; x < ClassicBoardData.Size.x; x++)
            {
                for (int y = 0; y < ClassicBoardData.Size.y; y++)
                {
                    BoardTile tile = tiles[x, y] = _tilesFactory.Get<ClassicBoardTile>();
                    tile.transform.position = new Vector3(x, 0, y);
                    tile.SetCoordinates(new BoardPosition(x, y));
                }
            }
            
            await UniTask.Yield();
        }
    }
}