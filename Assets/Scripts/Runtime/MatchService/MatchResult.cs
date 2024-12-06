using System.Collections.Generic;
using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class MatchResult
    {
        private Dictionary<int, RoundResult> rounds = new();
        
        public RoundResult LastRound => rounds[rounds.Count - 1];

        public void FinishRound(IPlayer winner)
        {
            rounds.Add(rounds.Count, new RoundResult(rounds.Count, winner));
        }
    }

    public class RoundResult
    {
        public int RoundNumber { get; }
        public IPlayer Winner { get; }
        
        public RoundResult(int roundNumber, IPlayer winner)
        {
            RoundNumber = roundNumber;
            Winner = winner;
        }
    }
}