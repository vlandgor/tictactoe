using System;
using Runtime.BoardManager.Local;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class BoardTile : MonoBehaviour
    {
        public event Action<BoardPosition> TileClicked;
        
        private BoardPosition boardPosition;
        
        public void SetCoordinates(BoardPosition boardPosition)
        {
            this.boardPosition = boardPosition;
        }

        private void OnMouseDown()
        {
            TileClicked?.Invoke(boardPosition);
        }
    }
}