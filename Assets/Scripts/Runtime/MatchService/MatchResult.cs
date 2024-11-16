using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class MatchResult
    {
        public IPlayer Winner { get; }
        
        public MatchResult(IPlayer winner)
        {
            Winner = winner;
        }
    }
}