using Runtime.BotService.Algorithms;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.BotService
{
    public class BotService : IBotService
    {
        public Crd GetMove(Match match, BotPlayer bot, IPlayer opponent)
        {
            IBotAlgorithm algorithm = GetAlgorithm(match, bot, opponent);
            
            return algorithm.GetMove();
        }

        private IBotAlgorithm GetAlgorithm(Match match, BotPlayer bot, IPlayer opponent)
        {
            switch (bot.BotLevel)
            {
                case BotLevel.Easy:
                    return new RandomMoveAlgorithm(match);
                case BotLevel.Medium:
                    return new BlockAndWinAlgorithm(match, bot, opponent);
                case BotLevel.Hard:
                    return new MinimaxAlgorithm(match, bot, opponent);
            }
            
            return null;
        }
    }
}
