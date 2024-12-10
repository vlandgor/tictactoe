using System;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.GameBoard.Boards
{
    public class FallingBoard : Board
    {
        public event Action<Crd, IPlayer> OnTokenPlaced; 
        public event Action<Crd, Crd> OnTokenMoved;
        
        public FallingBoard(Vector2Int boardSize) : base(boardSize)
        {
        }

        public override bool PlaceToken(Crd crd, IPlayer player)
        {
            if (CheckIfCellIsTaken(crd))
            {
                return false;
            }
            
            _board[crd.x, crd.y] = player;
            OnTokenPlaced?.Invoke(crd, player);
            
            
            for (int i = crd.y; i >= 0; i--)
            {
                if (i == 0 || _board[crd.x, i - 1] != null)
                {
                    _board[crd.x, crd.y] = null;
                    _board[crd.x, i] = player;
                    OnTokenMoved?.Invoke(crd, new Crd(crd.x, i));
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
        
        protected override Board CreateInstance(Vector2Int boardSize)
        {
            return new FallingBoard(boardSize);
        }
    }
}