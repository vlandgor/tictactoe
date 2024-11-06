using Cysharp.Threading.Tasks;
using Runtime.ConfigProvider;
using UnityEngine;
using Zenject;

namespace Runtime.GameBoard
{
    public class GameBoard : MonoBehaviour, IGameBoard
    {
        [SerializeField] private GameTile tilePrefab;
        [SerializeField] private GameObject linePrefab;
        
        private GameTile[,] tiles;
        
        private GameBoardConfig _gameBoardConfig;
        
        private float BoardTileSize => _gameBoardConfig.BoardTileSize;
        private float BoardLineSize => _gameBoardConfig.BoardLineSize;
        private Vector3 BoardOffset => new Vector3( BoardTileSize / 2, BoardTileSize / 2, 0);

        [Inject]
        public void Construct(IConfigProvider configProvider)
        {
            _gameBoardConfig = configProvider.GetConfig<GameBoardConfig>();
        }
        
        public async void Initialize(int width, int height)
        {
            await InitializeBoard(width, height);
            await InitializeLines(width, height);
        }
        
        private async UniTask InitializeBoard(int width, int height)
        {
            tiles = new GameTile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GameTile tile = tiles[i, j] = Instantiate(tilePrefab, transform, true);
                    tile.transform.localScale = new Vector3(BoardTileSize, BoardTileSize, 1);
                    tile.transform.SetPositionAndRotation(new Vector3(i * BoardTileSize, j * BoardTileSize, 0) + BoardOffset, Quaternion.identity);
                }
            }
        }
        private async UniTask InitializeLines(int width, int height)
        {
            for (int i = 1; i < width; i++)
            {
                GameObject line = Instantiate(linePrefab, transform, true);
                line.transform.localScale = new Vector3(BoardLineSize, height * BoardTileSize, 1);
                line.transform.SetPositionAndRotation(
                    new Vector3((i * BoardTileSize) - (BoardLineSize / 2) - (BoardTileSize / 2), (height / 2f * BoardTileSize) - (BoardTileSize / 2), 0) + BoardOffset, 
                    Quaternion.identity);
            }

            for (int j = 1; j < height; j++)
            {
                GameObject line = Instantiate(linePrefab, transform, true);
                line.transform.localScale = new Vector3(width * BoardTileSize, BoardLineSize, 1);
                line.transform.SetPositionAndRotation(
                    new Vector3((width / 2f * BoardTileSize) - (BoardTileSize / 2), (j * BoardTileSize) - (BoardLineSize / 2) - (BoardTileSize / 2), 0) + BoardOffset, 
                    Quaternion.identity);
            }
        }
    }
}
