using Runtime.GameBoard;
using Runtime.GameBoard.Boards;
using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.BotService
{
    public interface IBotService
    {
        public Crd GetMove(Board board, BotPlayer bot, IPlayer opponent);
    }
}