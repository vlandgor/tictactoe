using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.MatchService.MatchProcessors;

namespace Runtime.BotService
{
    public interface IBotService
    {
        public Crd GetMove(MatchProcessor matchProcessor, BotPlayer bot, IPlayer opponent);
    }
}