using System;
using Cysharp.Threading.Tasks;
using Runtime.ConfigProvider;
using Runtime.Marks;
using UnityEngine;
using Zenject;

namespace Runtime.GameBoard
{
    public class GameBoard : MonoBehaviour, IGameBoard
    {
        [SerializeField] private GameTile _tilePrefab;
        [SerializeField] private GameObject _linePrefab;
        
        private GameTile[,] tiles;
        private Mark[,] tokens;
        
        private GameBoardConfig _gameBoardConfig;
        
        private Vector2Int BoardSize => _gameBoardConfig.BoardSize;
        private float BoardTileSize => _gameBoardConfig.BoardTileSize;
        private float BoardLineSize => _gameBoardConfig.BoardLineSize;
        private Vector3 TileOffset => new Vector3( BoardTileSize / 2, BoardTileSize / 2, 0);

        [Inject]
        public void Construct(IConfigProvider configProvider)
        {
            _gameBoardConfig = configProvider.GetConfig<GameBoardConfig>();
        }

        public async UniTask Initialize()
        {
            await InitializeBoard(BoardSize.x, BoardSize.y);
            await InitializeLines(BoardSize.x, BoardSize.y);
        }
        
        public async UniTask Clear()
        {
            foreach (Mark token in tokens)
            {
                if (token != null)
                {
                    Destroy(token.gameObject);
                }
            }
        }
        
        public async UniTask PlaceToken(Crd crd, Mark markPrefab)
        {
            Mark mark = tokens[crd.x, crd.y] = Instantiate(markPrefab, transform);
            mark.transform.localScale = new Vector3(BoardTileSize, BoardTileSize, 1);
            mark.transform.SetPositionAndRotation(
                new Vector3(crd.x * BoardTileSize, crd.y * BoardTileSize, 0) + TileOffset, 
                Quaternion.identity);
        }
        
        private async UniTask InitializeBoard(int width, int height)
        {
            tokens = new Mark[width, height];
            tiles = new GameTile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GameTile tile = tiles[i, j] = Instantiate(_tilePrefab, transform, true);
                    tile.transform.localScale = new Vector3(BoardTileSize, BoardTileSize, 1);
                    tile.transform.SetPositionAndRotation((
                        new Vector3(i * BoardTileSize, j * BoardTileSize, 0) + TileOffset), 
                        Quaternion.identity);
                }
            }
        }
        private async UniTask InitializeLines(int width, int height)
        {
            for (int i = 1; i < width; i++)
            {
                GameObject line = Instantiate(_linePrefab, transform, true);
                line.transform.localScale = new Vector3(BoardLineSize, height * BoardTileSize, 1);
                line.transform.SetPositionAndRotation(
                    new Vector3((i * BoardTileSize) - (BoardLineSize / 2) - (BoardTileSize / 2), (height / 2f * BoardTileSize) - (BoardTileSize / 2), 0) + TileOffset, 
                    Quaternion.identity);
            }

            for (int j = 1; j < height; j++)
            {
                GameObject line = Instantiate(_linePrefab, transform, true);
                line.transform.localScale = new Vector3(width * BoardTileSize, BoardLineSize, 1);
                line.transform.SetPositionAndRotation(
                    new Vector3((width / 2f * BoardTileSize) - (BoardTileSize / 2), (j * BoardTileSize) - (BoardLineSize / 2) - (BoardTileSize / 2), 0) + TileOffset, 
                    Quaternion.identity);
            }
        }
    }
}
