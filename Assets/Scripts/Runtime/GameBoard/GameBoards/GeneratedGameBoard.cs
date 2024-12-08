using Cysharp.Threading.Tasks;
using Runtime.ConfigProvider;
using Runtime.GameBoard.BoardRenderers;
using Runtime.MatchService;
using Runtime.Tokens;
using UnityEngine;
using Zenject;

namespace Runtime.GameBoard.GameBoards
{
    public class GeneratedGameBoard : MonoBehaviour, IGameBoard
    {
        [SerializeField] private TokensFactory _tokensFactory;
        
        [Space]
        [SerializeField] private BoardTile _tilePrefab;
        [SerializeField] private BoardLine _linePrefab;
        
        private BoardTile[,] tiles;
        
        private GameBoardConfig _gameBoardConfig;
        private BoardRenderer _boardRenderer;
        
        private Vector2Int BoardSize => _gameBoardConfig.BoardSize;
        private float BoardTileSize => _gameBoardConfig.BoardTileSize;
        private float BoardLineSize => _gameBoardConfig.BoardLineSize;
        private Vector3 TileOffset => new Vector3( BoardTileSize / 2, BoardTileSize / 2, 0);

        [Inject]
        public void Construct(IConfigProvider configProvider)
        {
            _gameBoardConfig = configProvider.GetConfig<GameBoardConfig>();
        }

        public async UniTask Initialize(MatchMode matchMode)
        {
            await GenerateBoard();
            await SetBoardRenderer(matchMode);
        }
        
        public async UniTask PlaceToken(Crd crd, Token tokenPrefab)
        {
            await _boardRenderer.PlaceToken(crd, tokenPrefab);
        }
        
        public async UniTask ClearTokens()
        {
            await _boardRenderer.ClearTokens();
        }

        private async UniTask GenerateBoard()
        {
            await RenderCells();
            await RenderLines();
        }
        private async UniTask RenderCells()
        {
            tiles = new BoardTile[BoardSize.x, BoardSize.y];
            for (int i = 0; i < BoardSize.x; i++)
            {
                for (int j = 0; j < BoardSize.y; j++)
                {
                    BoardTile tile = tiles[i, j] = Instantiate(_tilePrefab, transform, true);
                    tile.transform.localScale = new Vector3(BoardTileSize, BoardTileSize, 1);
                    tile.transform.SetPositionAndRotation((
                            new Vector3(i * BoardTileSize, j * BoardTileSize, 0) + TileOffset), 
                        Quaternion.identity);
                }
            }
        }
        private async UniTask RenderLines()
        {
            for (int i = 1; i < BoardSize.x; i++)
            {
                BoardLine line = Instantiate(_linePrefab, transform, true);
                line.transform.localScale = new Vector3(BoardLineSize, BoardSize.y * BoardTileSize, 1);
                line.transform.SetPositionAndRotation(
                    new Vector3((i * BoardTileSize) - (BoardLineSize / 2) - (BoardTileSize / 2), (BoardSize.y / 2f * BoardTileSize) - (BoardTileSize / 2), 0) + TileOffset, 
                    Quaternion.identity);
            }

            for (int j = 1; j < BoardSize.y; j++)
            {
                BoardLine line = Instantiate(_linePrefab, transform, true);
                line.transform.localScale = new Vector3(BoardSize.x * BoardTileSize, BoardLineSize, 1);
                line.transform.SetPositionAndRotation(
                    new Vector3((BoardSize.x / 2f * BoardTileSize) - (BoardTileSize / 2), (j * BoardTileSize) - (BoardLineSize / 2) - (BoardTileSize / 2), 0) + TileOffset, 
                    Quaternion.identity);
            }
        }
        
        private async UniTask SetBoardRenderer(MatchMode matchMode)
        {
            switch (matchMode)
            {
                case MatchMode.Standard:
                    _boardRenderer = new StandardBoardRenderer(_tokensFactory, _gameBoardConfig);
                    break;
                case MatchMode.Falling:
                    _boardRenderer = new FallingBoardRenderer(_tokensFactory, _gameBoardConfig);
                    break;
            }
        }
    }
}
