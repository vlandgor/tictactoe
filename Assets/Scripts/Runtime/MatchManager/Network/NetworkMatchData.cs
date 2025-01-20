using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class NetworkMatchData : IMatchData
    {
        public MatchType MatchType { get; }
        public MatchMode MatchMode { get; }
        public IPlayer[] Players { get; }
        
        public NetworkMatchData(MatchType matchType, MatchMode matchMode, IPlayer[] players)
        {
            MatchType = matchType;
            MatchMode = matchMode;
            
            Players = players;
        }
    }
}