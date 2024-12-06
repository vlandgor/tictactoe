using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.MatchService
{
    public class MatchData
    {
        public MatchType MatchType { get; }
        public MatchMode MatchMode { get; } 
        public IPlayer[] Players { get; }
        public bool IsRanked { get; }
        public Vector2Int BoardSize { get; }

        public MatchData(MatchType matchType, MatchMode matchMode, IPlayer[] players, bool isRanked, Vector2Int boardSize)
        {
            MatchType = matchType;
            MatchMode = matchMode;
            Players = players;
            IsRanked = isRanked;
            BoardSize = boardSize;
        }
    }
}