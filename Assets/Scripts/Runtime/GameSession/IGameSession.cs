using Runtime.GamePlayer;

namespace Runtime.GameSession
{
    public interface IGameSession
    {
        public void Initialize(GameMode gameMode, IPlayer player1, IPlayer player2);
    }
}