using Runtime.BotService.Algorithms;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.MatchService.MatchProcessors;

namespace Runtime.BotService
{
    public class BotService : IBotService
    {
        public Crd GetMove(MatchProcessor matchProcessor, BotPlayer bot, IPlayer opponent)
        {
            IBotAlgorithm algorithm = GetAlgorithm(matchProcessor, bot, opponent);
            
            return algorithm.GetMove();
        }

        private IBotAlgorithm GetAlgorithm(MatchProcessor matchProcessor, BotPlayer bot, IPlayer opponent)
        {
            switch (bot.BotLevel)
            {
                case BotLevel.Easy:
                    return new RandomMoveAlgorithm(matchProcessor);
                case BotLevel.Medium:
                    return new BlockAndWinAlgorithm(matchProcessor, bot, opponent);
                case BotLevel.Hard:
                    return new MinimaxAlgorithm(matchProcessor, bot, opponent);
            }
            
            return null;
        }
    }
}
