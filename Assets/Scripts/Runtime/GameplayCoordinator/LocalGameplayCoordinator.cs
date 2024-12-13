using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Runtime.GameBoard;
using Runtime.GameplayCoordinator.GameplayStates;
using Runtime.GamePlayer;
using Runtime.MatchService;
using Zenject;

namespace Runtime.GameplayCoordinator
{
    public class LocalGameplayCoordinator : IGameplayCoordinator
    {
        private DiContainer _container;
        private IGameBoard _gameBoard;
        
        private List<GameplayState> _states;
        private GameplayState _currentState;
        
        private Match _match;
        
        private TurnManager _turnManager;
        
        [Inject]
        public LocalGameplayCoordinator(
            DiContainer container,
            IGameBoard gameBoard)
        {
            _container = container;
            _gameBoard = gameBoard;
        }
        
        public async UniTask InitializeMatch(Match match)
        {
            _match = match;
            
            InitializeStates();
            InitializeTurnManager();
            
            await ChangeState<InitializeMatchState>();
        }
        
        public async UniTask FinalizeMatch()
        {
            await ChangeState<FinalizeMatchState>();
        }
        
        public async UniTask RestartRound()
        {
            _gameBoard.ClearTokens();
        }
        
        public async UniTask ChangeState<T>() where T : GameplayState
        {
            _currentState?.Exit();
            _currentState = _states.FirstOrDefault(state => state is T);
            await _currentState.Enter();
        }
        
        public async UniTask ChangeTurn()
        {
            _currentState?.Exit();
            _currentState = _turnManager.ChangeTurn();
            await _currentState.Enter();
        }
        
        private void InitializeStates()
        {
            _states = new List<GameplayState>();
            
            _states.Add(InitializeInitializeMatchState());
            _states.Add(InitializeFinalizeMatchState());
            _states.Add(InitializeStartRoundState());
            _states.Add(InitializeEndRoundState());
        }
        
        private void InitializeTurnManager()
        {
            Dictionary<IPlayer, PlayerTurnState> states = new();
            
            foreach (IPlayer player in _match.MatchData.Players)
            {
                switch (player)
                {
                    case PersonPlayer personPlayer:
                        PersonTurnState personTurnState = InitializePersonTurnState(personPlayer);
                        states.Add(personPlayer, personTurnState);
                        break;
                    case BotPlayer botPlayer:
                        BotTurnState botTurnState = InitializeBotTurnState(botPlayer);
                        states.Add(botPlayer, botTurnState);
                        break;
                }
            }

            foreach (IPlayer player in states.Keys)
            {
                if(player is BotPlayer botPlayer)
                {
                    BotTurnState botTurnState = states[player] as BotTurnState;
                    botTurnState.SetOpponent(states.Keys.First(p => p != botPlayer));
                }
            }
            
            _turnManager = new TurnManager(states);
        }
        
        private InitializeMatchState InitializeInitializeMatchState()
        {
            InitializeMatchState initializeMatchState = CreateState<InitializeMatchState>(_match);
            return initializeMatchState;
        }
        
        private FinalizeMatchState InitializeFinalizeMatchState()
        {
            FinalizeMatchState finalizeMatchState = CreateState<FinalizeMatchState>(_match);
            return finalizeMatchState;
        }
        
        private StartRoundState InitializeStartRoundState()
        {
            StartRoundState startRoundState = CreateState<StartRoundState>(_match);
            return startRoundState;
        }
        
        private EndRoundState InitializeEndRoundState()
        {
            EndRoundState endRoundState = CreateState<EndRoundState>(_match);
            return endRoundState;
        }
        
        private PersonTurnState InitializePersonTurnState(PersonPlayer personPlayer)
        {
            PersonTurnState personTurnState = CreateState<PersonTurnState>(_match);
            personTurnState.SetPlayer(personPlayer);
            return personTurnState;
        }
        
        private BotTurnState InitializeBotTurnState(BotPlayer botPlayer)
        {
            BotTurnState botTurnState = CreateState<BotTurnState>(_match);
            botTurnState.SetPlayer(botPlayer);
            return botTurnState;
        }
        
        private T CreateState<T>(Match match) where T : GameplayState
        {
            // Resolve the state and set MatchData
            var state = _container.Instantiate<T>();
            state.SetData(match);
            return state;
        }
    }
}