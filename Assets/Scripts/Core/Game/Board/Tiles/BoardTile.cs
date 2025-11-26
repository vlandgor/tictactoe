using UnityEngine;

namespace Core.Game.Board.Tiles
{
    public class BoardTile : MonoBehaviour
    {
        private BoardPosition _boardPosition;
        public BoardPosition BoardPosition => _boardPosition;
        
        public void SetCoordinates(BoardPosition boardPosition)
        {
            _boardPosition = boardPosition;
        }
    }
}