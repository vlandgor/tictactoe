using Runtime.GameBoard.Boards;
using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class Match
    {
        public MatchData MatchData { get; private set; }
        public MatchResult MatchResult { get; private set; }
        public Board Board { get; private set; }
        
        public Match(MatchData matchData)
        {
            MatchData = matchData;
            MatchResult = new MatchResult();

            switch (matchData.MatchMode)
            {
                case MatchMode.Standard:
                    Board = new StandardBoard(matchData.BoardSize);
                    break;
                case MatchMode.Falling:
                    Board = new FallingBoard(matchData.BoardSize);
                    break;
            }
        }
        
        public void EndRound(IPlayer winner)
        {
            MatchResult.FinishRound(winner);
            Board.Reset();
        }
    }
}