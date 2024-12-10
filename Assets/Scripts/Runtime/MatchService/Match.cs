using Runtime.GamePlayer;
using Runtime.MatchService.MatchProcessors;

namespace Runtime.MatchService
{
    public class Match
    {
        public MatchData MatchData { get; private set; }
        public MatchResult MatchResult { get; private set; }
        public MatchProcessor MatchProcessor { get; private set; }
        
        public Match(MatchData matchData)
        {
            MatchData = matchData;
            MatchResult = new MatchResult();

            switch (matchData.MatchMode)
            {
                case MatchMode.Standard:
                    MatchProcessor = new StandardMatchProcessor(matchData.BoardSize);
                    break;
                case MatchMode.Falling:
                    MatchProcessor = new FallingMatchProcessor(matchData.BoardSize);
                    break;
            }
        }
        
        public void EndRound(IPlayer winner)
        {
            MatchResult.FinishRound(winner);
            MatchProcessor.Reset();
        }
    }
}