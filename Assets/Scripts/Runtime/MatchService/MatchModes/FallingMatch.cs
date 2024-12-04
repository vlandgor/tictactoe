using Runtime.GameBoard;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.MatchService.MatchModes
{
    public class FallingMatch : Match
    {
        public FallingMatch(Vector2Int boardSize) : base(boardSize)
        {
        }

        public override bool PlaceToken(Crd crd, IPlayer player)
        {
            if (CheckIfCellIsTaken(crd))
            {
                return false;
            }

            for (int i = crd.y; i >= 0; i--)
            {
                if (i == 0 || _board[crd.x, i - 1] != null)
                {
                    _board[crd.x, i] = player;
                    return true;
                }
            }

            return false;
        }

        public override void UndoPlaceToken(Crd crd)
        {
            for (int i = 0; i < BoardSize.y; i++)
            {
                if (_board[crd.x, i] != null)
                {
                    _board[crd.x, i] = null;
                    return;
                }
            }
        }
        
        protected override Match CreateInstance(Vector2Int boardSize)
        {
            return new FallingMatch(boardSize);
        }
    }
}