using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class TurnManager
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public IPlayer CurrentPlayer { get; private set; }

        public TurnManager(IPlayer player1, IPlayer player2, IPlayer startingPlayer)
        {
            CurrentPlayer = startingPlayer;
        }

        public void NextTurn(IPlayer player1, IPlayer player2)
        {
            CurrentPlayer = CurrentPlayer == player1 ? player2 : player1;
        }
    }
}