using System;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class BoardTile : MonoBehaviour
    {
        public event Action<Vector2Int> TileClicked;
        
        private Vector2Int coordinates;
        
        public void SetCoordinates(Vector2Int coordinates)
        {
            this.coordinates = coordinates;
        }

        private void OnMouseDown()
        {
            TileClicked?.Invoke(coordinates);
            Debug.Log($"Tile: {coordinates} was clicked");
        }
    }
}