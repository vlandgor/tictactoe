using System;
using Cysharp.Threading.Tasks;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.InputService;
using Runtime.MatchService.States;
using Runtime.UI.Game;
using Zenject;

namespace Runtime.MatchService
{
    public class MatchService : ILocalMatchService
    {
        private MatchData _matchData;
        private Match _match;
        
        private IMatchState currentState;
        private IMatchState _player1MoveState;
        private IMatchState _player2MoveState;
        
        public IGameBoard GameBoard { get; }
        public IInputService InputService { get; }
        public IBotService BotService { get; }
        public IConfigProvider ConfigProvider { get; }
        public IGameMediator GameMediator { get; }
        
        private GameBoardConfig GameBoardConfig => ConfigProvider.GetConfig<GameBoardConfig>();
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
            
            InitializeMatch();
            InitializeBoard();
            InitializeStates();
            
            ChangeState(_player1MoveState);
        }
        
        public async UniTask Restart()
        {
            InitializeMatch();
            GameBoard.Clear();
            
            ChangeState(_player1MoveState);
        }

        public void ChangeTurn()
        {
            if(currentState == _player1MoveState)
            {
                ChangeState(_player2MoveState);
            }
            else if(currentState == _player2MoveState)
            {
                ChangeState(_player1MoveState);
            }
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            return player == _matchData.Player1 ? _matchData.Player2 : _matchData.Player1;
        }

        public void ChangeState(IMatchState state)
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }

        private void InitializeMatch()
        {
            _match = new Match(GameBoardConfig.BoardSize);
        }

        private void InitializeBoard()
        {
            GameBoard.Initialize();
        }
        
        private void InitializeStates()
        {
            _player1MoveState = GetStateForPlayer(_matchData.Player1);
            _player2MoveState = GetStateForPlayer(_matchData.Player2);
            
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