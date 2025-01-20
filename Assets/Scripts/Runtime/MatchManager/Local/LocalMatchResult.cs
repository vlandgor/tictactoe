using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class LocalMatchResult : IMatchResult
    {
        public IPlayer Winner { get; private set; }
        public Round[] Rounds { get; }
        
        public LocalMatchResult(int rounds)
        {
            Rounds = new Round[rounds];
        }
        
        public void AddRound(int roundIndex, Round round)
        {
            Rounds[roundIndex] = round;
        }
        
        public void SetWinner(IPlayer winner)
        {
            Winner = winner;
        }
    }
}