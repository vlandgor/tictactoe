using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Runtime.GameplayCoordinator.GameplayStates;
using Runtime.GamePlayer;
using Runtime.MatchService;
using UnityEngine;
using Zenject;

namespace Runtime.GameplayCoordinator
{
    public class LocalGameplayCoordinator : IGameplayCoordinator
    {
        private DiContainer _container;
        
        private List<GameplayState> _states;
        private GameplayState _currentState;
        
        private Match _match;
        private TurnManager _turnManager;
        
        [Inject]
        public LocalGameplayCoordinator(DiContainer container)
        {
            _container = container;
        }
        
        public async UniTask InitializeMatch(MatchData matchData)
        {
            Debug.Log(matchData.BoardSize);
            _match = new Match(matchData);
            
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
            _states.Add(CreateState<InitializeMatchState>(_match));
            _states.Add(CreateState<FinalizeMatchState>(_match));
            _states.Add(CreateState<StartRoundState>(_match));
            _states.Add(CreateState<EndRoundState>(_match));
        }
        
        private void InitializeTurnManager()
        {
            Dictionary<IPlayer, PlayerTurnState> states = new();
            
            foreach (IPlayer player in _match.MatchData.Players)
            {
                switch (player)
                {
                    case PersonPlayer personPlayer:
                        PersonTurnState personTurnState = CreateState<PersonTurnState>(_match);
                        personTurnState.SetPlayer(personPlayer);
                        states.Add(personPlayer, personTurnState);
                        break;
                    case BotPlayer botPlayer:
                        BotTurnState botTurnState = CreateState<BotTurnState>(_match);
                        botTurnState.SetPlayer(botPlayer);
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
        
        private T CreateState<T>(Match match) where T : GameplayState
        {
            // Resolve the state and set MatchData
            var state = _container.Instantiate<T>();
            state.SetData(match);
            return state;
        }
    }
}