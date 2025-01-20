using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.GameModes.ClassicMode.Board
{
    public class ClassicBoardVisual : MonoBehaviour
    {
        private BoardTile[,] tiles;
        
        public async UniTask GenerateBoardVisual(Vector2Int boardSize)
        {
            tiles = new BoardTile[boardSize.x, boardSize.y];
            
            for (int x = 0; x < boardSize.x; x++)
            {
                for (int y = 0; y < boardSize.y; y++)
                {
                    // tiles[x, y] = localTilesFactory.Get<ClassicBoardTile>();
                    // tiles[x, y].transform.position = new Vector3(x, 0, y);
                }
            }
            
            await UniTask.Yield();
        }
    }
}