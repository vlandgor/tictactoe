using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager.Local;
using Runtime.GamePieces;
using UnityEngine;

namespace Runtime.BoardManager
{
    public abstract class BoardVisual : MonoBehaviour, IBoardVisual
    {
        public event Action<BoardPosition> OnTileClicked;
        
        protected IBoardData _boardData;
        protected ITilesFactory _tilesFactory;
        protected IPiecesFactory _piecesFactory;
        
        protected BoardTile[,] tiles;
        protected Piece[,] pieces;
        
        public virtual async UniTask Initialize(IBoardData boardData)
        {
            _boardData = boardData;

            tiles = new BoardTile[boardData.Size.x, boardData.Size.y];
            pieces = new Piece[boardData.Size.x, boardData.Size.y];

            
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

        public void SetFactories(ITilesFactory tilesFactory, IPiecesFactory piecesFactory)
        {
            _tilesFactory = tilesFactory;
            _piecesFactory = piecesFactory;
        }

        public async UniTask PlacePiece(Piece piecePrefab, BoardPosition boardPosition)
        {
            Piece piece = _piecesFactory.Get(piecePrefab);
            piece.transform.position = new Vector3(boardPosition.x, 0, boardPosition.y);
            pieces[boardPosition.x, boardPosition.y] = piece;
        }

        public async UniTask ClearBoard()
        {
            if (pieces != null)
            {
                foreach (Piece piece in pieces)
                {
                    if (piece != null)
                    {
                        Destroy(piece.gameObject);
                    }
                }
            }

            pieces = new Piece[_boardData.Size.x, _boardData.Size.y];
        }
        
        protected abstract UniTask GenerateBoardVisual();
        
        private void HandleTileClicked(BoardPosition boardPosition)
        {
            OnTileClicked?.Invoke(boardPosition);
        }
    }
}