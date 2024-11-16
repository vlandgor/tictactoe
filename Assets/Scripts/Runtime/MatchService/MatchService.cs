using System;
using Cysharp.Threading.Tasks;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.GameSession;
using Runtime.InputService;
using Runtime.UI.Game.Presenters;
using UnityEngine;
using Zenject;

namespace Runtime.MatchService
{
    public class MatchService : IMatchService, IDisposable
    {
        private readonly IGameBoard _gameBoard;
        private readonly IInputService _inputService;
        private readonly IConfigProvider _configProvider;
        
        private readonly GameHudPresenter _gameHudPresenter;
        private readonly GameResultPresenter _gameResultPresenter;
        
        private MatchData _matchData;
        
        private Match _match;
        private TurnManager _turnManager;
        
        public bool IsFinished { get; private set; }
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        private IPlayer CurrentPlayer => _turnManager.CurrentPlayer; 
        
        [Inject]
        public MatchService(
            IGameBoard gameBoard, 
            IInputService inputService, 
            IConfigProvider configProvider,
            GameHudPresenter gameHudPresenter,
            GameResultPresenter gameResultPresenter)
        {
            _gameBoard = gameBoard;
            _inputService = inputService;
            _configProvider = configProvider; 
            _gameHudPresenter = gameHudPresenter;
            _gameResultPresenter = gameResultPresenter;
        }
        
        public async UniTask Initialize(MatchData matchData)
        {
            _matchData = matchData;
            
            _gameBoard.Initialize();
            
            _turnManager = new TurnManager(_matchData.Player1);
            _match = new Match(GameBoardConfig.BoardSize);
            
            _gameHudPresenter.UpdateTurnLabel(CurrentPlayer);
            
            _inputService.OnTileClicked += HandleTileClicked;
        }
        
        private void Restart()
        {
            _gameBoard.Clear();
            _match.Restart();
            _turnManager = new TurnManager(_matchData.Player1);
        }
        
        private void HandleTileClicked(Crd crd)
        {
            UpdateBoard(crd);
            CheckBoard();
            
            if(IsFinished)
                return;
            
            NextTurn();
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
                _gameResultPresenter.ShowResult(new MatchResult(CurrentPlayer));
                IsFinished = true;
                return;
            }
            
            if(_match.IsBoardFull())
            {
                _inputService.SetInputEnabled(false);
                _gameResultPresenter.ShowResult(new MatchResult(null));
                IsFinished = true;
                return;
            }
        }

        private void NextTurn()
        {
            _turnManager.NextTurn(_matchData.Player1, _matchData.Player2);
            _gameHudPresenter.UpdateTurnLabel(CurrentPlayer);
        }
        
        public void Dispose()
        {
            _inputService.OnTileClicked -= HandleTileClicked;
        }
    }
}