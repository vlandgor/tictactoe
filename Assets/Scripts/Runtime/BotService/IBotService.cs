using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.BotService
{
    public interface IBotService
    {
        public Crd GetMove(Match match, BotPlayer bot, IPlayer opponent);
    }
}