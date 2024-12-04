using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class MatchData
    {
        public MatchType MatchType { get; set; }
        public IPlayer Player1 { get; }
        public IPlayer Player2 { get; }

        public MatchData(MatchType matchType, IPlayer player1, IPlayer player2)
        {
            MatchType = matchType;
            Player1 = player1;
            Player2 = player2;
        }
    }
}