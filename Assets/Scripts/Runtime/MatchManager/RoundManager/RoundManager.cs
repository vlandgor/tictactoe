using System.Collections.Generic;
using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class RoundManager
    {
        private IPlayer[] players;
        private Queue<PlayerMove> moves = new();
        
        public IPlayer Turn { get; private set; }

        public RoundManager(IMatchData matchData)
        {
            players = matchData.Players;
        }

        public void NextTurn()
        {
            int currentIndex = System.Array.IndexOf(players, Turn);
            int nextIndex = (currentIndex + 1) % players.Length;

            Turn = players[nextIndex];
        }

        public void StartRound(IPlayer first)
        {
            Turn = first;
        }
        
        public Round FinishRound(IPlayer winner)
        {
            moves.Clear();
            
            return new Round(winner, moves);
        }
    }
}