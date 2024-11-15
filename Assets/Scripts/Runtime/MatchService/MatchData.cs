using Runtime.GamePlayer;

namespace Runtime.GameSession
{
    public class MatchData
    {
        public GameMode GameMode { get; set; }
        public IPlayer Player1 { get; }
        public IPlayer Player2 { get; }

        public MatchData(GameMode gameMode, IPlayer player1, IPlayer player2)
        {
            GameMode = gameMode;
            Player1 = player1;
            Player2 = player2;
        }
    }
}