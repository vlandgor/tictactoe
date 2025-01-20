using System.Collections.Generic;
using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class RoundManager : IRoundManager
    {
        private IPlayer[] players;
        private Round[] rounds;
        
        private Queue<PlayerMove> moves;
        
        public IPlayer Turn { get; private set; }
        public int Round { get; private set; }

        public RoundManager(IPlayer[] players, int rounds)
        {
            this.players = players;
            this.rounds = new Round[rounds];
            
            moves = new Queue<PlayerMove>();
        }
        
        public void FinishRound(IPlayer winner)
        {
            rounds[Round] = new Round(winner, moves);
            
            moves.Clear();
            Round++;
        }
    }
}