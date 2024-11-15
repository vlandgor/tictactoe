using System;
using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class TurnManager
    {
        private IPlayer _currentPlayer;

        public IPlayer CurrentPlayer => _currentPlayer;
        public event Action<IPlayer> OnTurnChanged;

        public TurnManager(IPlayer startingPlayer)
        {
            _currentPlayer = startingPlayer;
        }

        public void NextTurn(IPlayer player1, IPlayer player2)
        {
            _currentPlayer = _currentPlayer == player1 ? player2 : player1;
            OnTurnChanged?.Invoke(_currentPlayer);
        }
    }
}