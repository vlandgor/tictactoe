using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class MatchData
    {
        public MatchType MatchType { get; }
        public MatchMode MatchMode { get; } 
        public IPlayer[] Players { get; }
        public bool IsRanked { get; }

        public MatchData(MatchType matchType, MatchMode matchMode, IPlayer[] players, bool isRanked)
        {
            MatchType = matchType;
            MatchMode = matchMode;
            Players = players;
            IsRanked = isRanked;
        }
    }
}