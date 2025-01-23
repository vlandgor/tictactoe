using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.BoardManager
{
    public abstract class BoardVisual : MonoBehaviour, IBoardVisual
    {
        [SerializeField] private GameObject piece;
        
        public event Action<Vector2Int> OnTileClicked;
        
        protected IBoardData _boardData;
        protected ITilesFactory _tilesFactory;
        
        protected BoardTile[,] tiles;
        
        public virtual async UniTask Initialize(IBoardData boardData)
        {
            _boardData = boardData;

            
            await GenerateBoardVisual();

            foreach (BoardTile tile in tiles)
            {
                tile.TileClicked += HandleTileClicked;
            }
        }

        private void OnDestroy()
        {
            foreach (BoardTile tile in tiles)
            {
                tile.TileClicked -= HandleTileClicked;
            }
        }

        public void SetFactories(ITilesFactory tilesFactory)
        {
            _tilesFactory = tilesFactory;
        }

        public async UniTask PlacePiece(int setIndex, Vector2Int coordinate)
        {
            Debug.Log("Place Piece");
        }
        
        protected abstract UniTask GenerateBoardVisual();
        
        private void HandleTileClicked(Vector2Int coordinate)
        {
            Debug.Log($"Tile Clicked");
            OnTileClicked?.Invoke(coordinate);
        }
    }
}