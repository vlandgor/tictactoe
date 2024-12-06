using System.Collections.Generic;
using System.Linq;
using Runtime.GameplayCoordinator.GameplayStates;
using Runtime.GamePlayer;

namespace Runtime.GameplayCoordinator
{
    public class TurnManager
    {
        private Dictionary<IPlayer, PlayerTurnState> _states;
        
        public IPlayer CurrentTurn { get; private set; }

        public TurnManager(Dictionary<IPlayer, PlayerTurnState> states)
        { 
            _states = states;
        }
        
        public void SetTurn(IPlayer player)
        {
            CurrentTurn = player;
        }
        
        public PlayerTurnState ChangeTurn()
        {
            if(CurrentTurn == null)
            {
                CurrentTurn = _states.Keys.First();
                return _states[CurrentTurn];
            }
                
            CurrentTurn = CurrentTurn == _states.Keys.First() ? _states.Keys.Last() : _states.Keys.First();
            
            return _states[CurrentTurn];
        }
    }
}