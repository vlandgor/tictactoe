using System.Collections.Generic;
using Runtime.GamePlayer;

namespace Runtime.MatchService
{
    public class MatchResult
    {
        private Dictionary<IPlayer, int> _scores = new();
        private int drawCount = 0;
        
        public MatchResult(IPlayer[] players)
        {
            foreach (var player in players)
            {
                _scores.Add(player, 0);
            }
        }
        
        public void AddScore(IPlayer player)
        {
            _scores[player]++;
        }
        
        public void AddDraw()
        {
            drawCount++;
        }
    }

    public class RoundResult
    {
        public MatchType Type { get; }   
        public IPlayer Winner { get; }
        
        public RoundResult(MatchType type, IPlayer winner)
        {
            Type = type;
            Winner = winner;
        }
    }
}