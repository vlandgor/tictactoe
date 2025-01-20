using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public interface IMatchData
    {
        public MatchType MatchType { get; }
        public MatchMode MatchMode { get; }
        public IPlayer[] Players { get; }
    }
}