using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class MatchResult
    {
        public MatchType Mode { get; }   
        public IPlayer Winner { get; }
        
        public MatchResult(MatchType matchType, IPlayer winner)
        {
            Mode = matchType;
            Winner = winner;
        }
    }
}