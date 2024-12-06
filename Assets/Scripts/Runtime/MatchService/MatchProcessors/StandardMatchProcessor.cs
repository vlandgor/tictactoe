using Runtime.GameBoard;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.MatchService.MatchProcessors
{
    public class StandardMatchProcessor : MatchProcessor
    {
        public StandardMatchProcessor(Vector2Int boardSize) : base(boardSize)
        {
            
        }
        
        public override bool PlaceToken(Crd crd, IPlayer player)
        {
            if(CheckIfCellIsTaken(crd))
                return false;
            
            _board[crd.x, crd.y] = player;
            return true;
        }
        
        public override void UndoPlaceToken(Crd crd)
        {
            _board[crd.x, crd.y] = null;
        }
        
        protected override MatchProcessor CreateInstance(Vector2Int boardSize)
        {
            return new StandardMatchProcessor(boardSize);
        }
    }
}