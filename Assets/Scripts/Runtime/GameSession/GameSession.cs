using System;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.InputService;
using UnityEngine;
using Zenject;

namespace Runtime.GameSession
{
    public class GameSession : IGameSession, IDisposable
    {
        private GameMode _gameMode;
        private IPlayer _player1;
        private IPlayer _player2;
        
        IGameBoard _gameBoard;
        IInputService _inputService;
        IConfigProvider _configProvider;
        
        private Match _match;
        private IPlayer _turn;
        
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        
        [Inject]
        public GameSession(IGameBoard gameBoard, IInputService inputService, IConfigProvider configProvider)
        {
            _gameBoard = gameBoard;
            _inputService = inputService;
            _configProvider = configProvider; 
            
            _inputService.OnTileClicked += HandleTileClicked;
        }
        
        public void Dispose()
        {
            _inputService.OnTileClicked -= HandleTileClicked;
        }
        
        public void Initialize(GameMode gameMode, IPlayer player1, IPlayer player2)
        {
            _gameMode = gameMode;
            _player1 = player1;
            _player2 = player2;
            
            _turn = _player1;
            _match = new Match(GameBoardConfig.BoardSize);
        }
        
        private void Restart()
        {
            _gameBoard.Clear();
            _match.Restart();
            _turn = _player1;
        }
        
        private void HandleTileClicked(int x, int y)
        {
            Coord coord = new Coord(x, y);
            
            if(!_match.PlaceToken(coord, _turn))
                return;
            
            _gameBoard.PlaceToken(coord, _turn.Token);
            
            if(_match.CheckIfPlayerWon(_turn))
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
            
            ChangeTurn();
        }
        
        private void ChangeTurn()
        {
            _turn = _turn == _player1 ? _player2 : _player1;
        }
    }
}