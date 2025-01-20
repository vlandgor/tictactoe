using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class LocalMatchData : IMatchData
    {
        public MatchType MatchType { get; }
        public MatchMode MatchMode { get; }
        public IPlayer[] Players { get; }
        
        public LocalMatchData(MatchType matchType, MatchMode matchMode, IPlayer[] players)
        {
            MatchType = matchType;
            MatchMode = matchMode;
            
            Players = players;
        }
    }
}