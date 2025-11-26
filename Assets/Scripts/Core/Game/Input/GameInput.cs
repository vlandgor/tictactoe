using System;
using Core.Game.Board.Tiles;
using Core.Game.Camera;
using UnityEngine;

namespace Core.Game.Input
{
    public class GameInput : MonoBehaviour
    {
        public event Action<BoardTile> TileClicked;
        
        [SerializeField] private GameCamera _gameCamera;

        public bool Locked { get; set; } 

        private void Update()
        {
            if (Locked) return; 

            if (UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    BoardTile clickedTile = GetBoardTileFromTouchInput(touch.position); 
                    if (clickedTile != null)
                    {
                        TileClicked?.Invoke(clickedTile); 
                        Debug.Log($"BoardTile: {clickedTile.BoardPosition}");
                    }
                }
            }
            else if (UnityEngine.Input.GetMouseButtonDown(0)) 
            {
                BoardTile clickedTile = GetBoardTileFromMouseInput(UnityEngine.Input.mousePosition);
                if (clickedTile != null)
                {
                    TileClicked?.Invoke(clickedTile); 
                    Debug.Log($"BoardTile: {clickedTile.BoardPosition}");
                }
            }
        }
        
        private BoardTile GetBoardTileFromMouseInput(Vector3 screenPosition) 
        {
            Vector2 worldPoint = _gameCamera.Camera.ScreenToWorldPoint(screenPosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero); 

            if (hit.collider != null) 
            {
                BoardTile tile = hit.collider.GetComponent<BoardTile>();
                if (tile != null)
                {
                    return tile; 
                }
            }
            
            return null; 
        }
        
        private BoardTile GetBoardTileFromTouchInput(Vector2 screenPosition) 
        {
            return GetBoardTileFromMouseInput(new Vector3(screenPosition.x, screenPosition.y, 0));
        }
    }
}