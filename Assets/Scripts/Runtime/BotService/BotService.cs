using Runtime.BotService.Algorithms;
using Runtime.GameBoard;
using Runtime.GameBoard.Boards;
using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.BotService
{
    public class BotService : IBotService
    {
        public Crd GetMove(Board board, BotPlayer bot, IPlayer opponent)
        {
            IBotAlgorithm algorithm = GetAlgorithm(board, bot, opponent);
            
            return algorithm.GetMove();
        }

        private IBotAlgorithm GetAlgorithm(Board board, BotPlayer bot, IPlayer opponent)
        {
            switch (bot.BotLevel)
            {
                case BotLevel.Easy:
                    return new RandomMoveAlgorithm(board);
                case BotLevel.Medium:
                    return new BlockAndWinAlgorithm(board, bot, opponent);
                case BotLevel.Hard:
                    return new MinimaxAlgorithm(board, bot, opponent);
            }
            
            return null;
        }
    }
}
