using System.Collections.Generic;
using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class Round
    {
        public IPlayer winner;
        public Queue<PlayerMove> moves;

        public Round(IPlayer winner, Queue<PlayerMove> moves)
        {
            this.winner = winner;
            this.moves = moves;
        }
    }
}