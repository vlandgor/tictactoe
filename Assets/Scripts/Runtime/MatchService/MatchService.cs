using System;
using Cysharp.Threading.Tasks;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GameSession;
using Runtime.InputService;
using Runtime.UI.GameHud.Presenters;
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
        
        private MatchData _matchData;
        
        private Match _match;
        private TurnManager _turnManager;
        
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        
        [Inject]
        public MatchService(
            IGameBoard gameBoard, 
            IInputService inputService, 
            IConfigProvider configProvider,
            GameHudPresenter gameHudPresenter)
        {
            _gameBoard = gameBoard;
            _inputService = inputService;
            _configProvider = configProvider; 
            _gameHudPresenter = gameHudPresenter;
        }
        
        public async UniTask Initialize(MatchData matchData)
        {
            _matchData = matchData;
            
            _gameBoard.Initialize();
            
            _turnManager = new TurnManager(_matchData.Player1);
            _match = new Match(GameBoardConfig.BoardSize);
            
            _inputService.OnTileClicked += HandleTileClicked;
            _turnManager.OnTurnChanged += _gameHudPresenter.UpdateTurnLabel;
        }
        
        private void Restart()
        {
            _gameBoard.Clear();
            _match.Restart();
            _turnManager = new TurnManager(_matchData.Player1);
        }
        
        private void HandleTileClicked(int x, int y)
        {
            Coord coord = new Coord(x, y);
            
            if(!_match.PlaceToken(coord, _turnManager.CurrentPlayer))
                return;
            
            _gameBoard.PlaceToken(coord, _turnManager.CurrentPlayer.Mark);
            
            if(_match.CheckIfPlayerWon(_turnManager.CurrentPlayer))
            {
                Debug.Log("Player won!");
                Restart();
                return;
            }
            
            if(_match.IsBoardFull())
            {
                Debug.Log("Draw!");
                Restart();
                return;
            }
            
            _turnManager.NextTurn(_matchData.Player1, _matchData.Player2);
        }
        
        public void Dispose()
        {
            _inputService.OnTileClicked -= HandleTileClicked;
            _turnManager.OnTurnChanged -= _gameHudPresenter.UpdateTurnLabel;
        }
    }
}