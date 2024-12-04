using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.InputService;
using Runtime.MatchService.MatchModes;
using Runtime.MatchService.States;
using Runtime.UI.Game;
using Zenject;

namespace Runtime.MatchService
{
    public class MatchService : ILocalMatchService
    {
        private MatchData _matchData;
        private MatchResult _matchResult;
        private Match _match;
        
        private IMatchState currentState;
        
        private Dictionary<IPlayer, IMatchState> _playerStates = new();
        
        public IGameBoard GameBoard { get; }
        public IInputService InputService { get; }
        public IBotService BotService { get; }
        public IConfigProvider ConfigProvider { get; }
        public IGameMediator GameMediator { get; }
        
        private GameBoardConfig GameBoardConfig => ConfigProvider.GetConfig<GameBoardConfig>();
        public MatchData MatchData => _matchData;
        public MatchResult MatchResult => _matchResult;
        public Match Match => _match;

        [Inject]
        public MatchService(
            IGameBoard gameBoard, 
            IInputService inputService, 
            IBotService botService,
            IConfigProvider configProvider,
            IGameMediator gameMediator)
        {
            GameBoard = gameBoard;
            InputService = inputService;
            BotService = botService;
            ConfigProvider = configProvider;
            GameMediator = gameMediator;
        }
        
        public async UniTask Initialize(MatchData matchData)
        {
            _matchData = matchData;
            _matchResult = new MatchResult(matchData.Players);
            
            InitializeMatch();
            InitializeBoard();
            InitializeStates();
            
            ChangeState(_playerStates.Values.First());
        }
        
        public async UniTask Restart()
        {
            InitializeMatch();
            GameBoard.Clear();
            
            ChangeState(_playerStates.Values.First());
        }

        public void NextTurn()
        {
            ChangeState(GetNextState(currentState));
            
            IMatchState GetNextState(IMatchState currentState)
            {
                foreach (var kvp in _playerStates)
                {
                    if (kvp.Value != currentState)
                    {
                        return kvp.Value;
                    }
                }

                throw new InvalidOperationException("No valid next state found.");
            }
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            foreach (var kvp in _playerStates)
            {
                if (kvp.Key != player)
                {
                    return kvp.Key;
                }
            }

            return null;
        }

        public void ChangeState(IMatchState state)
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }

        private void InitializeMatch()
        {
            switch (_matchData.MatchMode)
            {
                case MatchMode.Standard:
                    _match = new StandardMatch(GameBoardConfig.BoardSize);
                    break;
                case MatchMode.Falling:
                    _match = new FallingMatch(GameBoardConfig.BoardSize);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void InitializeBoard()
        {
            GameBoard.Initialize();
        }
        
        private void InitializeStates()
        {
            _playerStates.Clear();
            foreach (IPlayer player in _matchData.Players)
            {
                _playerStates.Add(player, GetStateForPlayer(player));
            }
            
            IMatchState GetStateForPlayer(IPlayer player)
            {
                return player switch
                {
                    PersonPlayer => new PlayerMoveState(this, player),
                    BotPlayer botPlayer  => new BotMoveState(this, player),
                    _ => throw new InvalidOperationException("Unknown player type")
                };
            }
        }
    }
}