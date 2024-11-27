using Runtime.BotService.Algorithms;
using Runtime.MatchService;

namespace Runtime.BotService
{
    public class BotService : IBotService
    {
        private Match _match;
        private IBotAlgorithm _algorithm;

        public void Initialize(Match match, BotLevel botLevel)
        {
            _match = match;

            _algorithm = GetAlgorithm(botLevel);
        }

        private IBotAlgorithm GetAlgorithm(BotLevel botLevel)
        {
            switch (botLevel)
            {
                case BotLevel.Easy:
                    return new RandomMoveAlgorithm();
                case BotLevel.Medium:
                    return new BlockAndWinAlgorithm();
                case BotLevel.Hard:
                    return new MinimaxAlgorithm();
            }
            
            return null;
        }
    }
}
