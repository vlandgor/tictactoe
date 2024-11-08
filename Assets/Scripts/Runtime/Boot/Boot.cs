using Runtime.BoardTokens;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.GameSession;
using Runtime.InputService;
using UnityEngine;
using Zenject;

namespace Runtime.Boot
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private TokenStorage _tokenStorage;
        
        private IGameBoard _gameBoard;
        private IGameSession _gameSession;
        
        private GameBoardConfig _gameBoardConfig;
        
        [Inject]
        public void Construct(IGameBoard gameBoard, IConfigProvider configProvider, IGameSession gameSession)
        {
            _gameBoard = gameBoard;
            _gameSession = gameSession;
            
            _gameBoardConfig = configProvider.GetConfig<GameBoardConfig>();
        }
        
        private async void Start()
        {
            await _gameBoard.Initialize(_gameBoardConfig.BoardSize.x, _gameBoardConfig.BoardSize.y);
            InitializeGameSession();
        }

        private void InitializeGameSession()
        {
            IPlayer player = new PersonPlayer(_tokenStorage.tokens[0]);
            IPlayer aiPlayer = new PersonPlayer(_tokenStorage.tokens[1]);
            
            _gameSession.Initialize(GameMode.PvP, player, aiPlayer);
        }
    }
}