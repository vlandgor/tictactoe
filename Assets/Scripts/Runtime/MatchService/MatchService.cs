using System;
using Cysharp.Threading.Tasks;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.GameSession;
using Runtime.InputService;
using Runtime.UI.Game;
using Zenject;

namespace Runtime.MatchService
{
    public class MatchService : IMatchService, IDisposable
    {
        private readonly IGameBoard _gameBoard;
        private readonly IInputService _inputService;
        private readonly IBotService _botService;
        private readonly IConfigProvider _configProvider;
        private readonly IGameMediator _gameMediator;
        
        private MatchData _matchData;
        
        private Match _match;
        private TurnManager _turnManager;
        
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        private IPlayer CurrentPlayer => _turnManager.CurrentPlayer; 
        
        public bool IsFinished { get; private set; }
        
        [Inject]
        public MatchService(
            IGameBoard gameBoard, 
            IInputService inputService, 
            IBotService botService,
            IConfigProvider configProvider,
            IGameMediator gameMediator)
        {
            _gameBoard = gameBoard;
            _inputService = inputService;
            _botService = botService;
            _configProvider = configProvider;
            _gameMediator = gameMediator;
        }
        
        public async UniTask Initialize(MatchData matchData)
        {
            _matchData = matchData;
            
            _gameBoard.Initialize();
            StartMatch();
            
            _inputService.OnTileClicked += HandleTileClicked;
        }
        public async UniTask Restart()
        {
            _gameBoard.Clear();
            StartMatch();
        }

        private void InitializePlayers(MatchData matchData)
        {
            
        }
        
        private void HandleTileClicked(Crd crd)
        {
            PlayTurn(crd);
        }

        private void PlayTurn(Crd crd)
        {
            UpdateBoard(crd);
            CheckBoard();
            FinishTurn();
        }
        
        private void StartMatch()
        {
            _turnManager = new TurnManager(_matchData.Player1, _matchData.Player2, _matchData.Player1);
            _match = new Match(GameBoardConfig.BoardSize);
            
            _gameMediator.UpdateTurnLabel(CurrentPlayer);
            _inputService.SetInputEnabled(true);
            
            IsFinished = false;
        }

        private void UpdateBoard(Crd crd)
        {
            if(!_match.PlaceToken(crd, CurrentPlayer))
            {
                return;
            }
            
            _gameBoard.PlaceToken(crd, CurrentPlayer.Mark);
        }
        
        private void CheckBoard()
        {
            if(_match.CheckIfPlayerWon(CurrentPlayer))
            {
                _inputService.SetInputEnabled(false);
                _gameMediator.ShowGameResult(new MatchResult(CurrentPlayer));
                IsFinished = true;
                return;
            }
            if(_match.IsBoardFull())
            {
                _inputService.SetInputEnabled(false);
                _gameMediator.ShowGameResult(new MatchResult(null));
                IsFinished = true;
                return;
            }
        }

        private void FinishTurn()
        {
            if(IsFinished)
                return;
            
            _turnManager.NextTurn(_matchData.Player1, _matchData.Player2);
            _gameMediator.UpdateTurnLabel(CurrentPlayer);
        }
        
        public void Dispose()
        {
            _inputService.OnTileClicked -= HandleTileClicked;
        }
    }
}