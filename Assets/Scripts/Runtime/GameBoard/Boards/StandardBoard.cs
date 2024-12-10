using System;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.GameBoard.Boards
{
    public class StandardBoard : Board
    {
        public event Action<Crd, IPlayer> OnTokenPlaced;
        
        public StandardBoard(Vector2Int boardSize) : base(boardSize)
        {
            
        }
        
        public override bool PlaceToken(Crd crd, IPlayer player)
        {
            if(CheckIfCellIsTaken(crd))
                return false;
            
            _board[crd.x, crd.y] = player;
            OnTokenPlaced?.Invoke(crd, player);
            return true;
        }
        
        public override void UndoPlaceToken(Crd crd)
        {
            _board[crd.x, crd.y] = null;
        }
        
        protected override Board CreateInstance(Vector2Int boardSize)
        {
            return new StandardBoard(boardSize);
        }
    }
}