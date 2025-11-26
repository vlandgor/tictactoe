using Core.Game.Board.Pieces;
using Core.Game.Board.Tiles;
using UnityEngine;

namespace Core.Game.Board
{
public class BoardVisualBase : MonoBehaviour
    {
        private const float BORDER_THICKNESS = 0.05f;
        private const float LINE_THICKNESS = 0.02f;
        
        [SerializeField] protected TilesFactory _tilesFactory;
        [SerializeField] protected PiecesFactory _piecesFactory;

        [Space]
        [SerializeField] private GameObject _linePrefab;
        
        [Space] 
        [SerializeField] protected Transform _linesParent;
        [SerializeField] protected Transform _tilesParent;
        [SerializeField] protected Transform _piecesParent;
        
        protected IBoardData _boardData;
        protected Vector2 _offset;
        
        protected BoardTile[,] tiles;
        protected BoardPiece[,] pieces;

        public virtual void Initialize(IBoardData boardData)
        {
            _boardData = boardData;
            _offset = new Vector2(-_boardData.Size.x / 2f, -_boardData.Size.y / 2f);

            tiles = new BoardTile[boardData.Size.x, boardData.Size.y];
            pieces = new BoardPiece[boardData.Size.x, boardData.Size.y];

            GenerateBoard();
        }

        public void PlacePiece(PieceType pieceType, BoardTile boardTile)
        {
            BoardPiece piece = _piecesFactory.Get(pieceType);
            piece.transform.SetParent(_piecesParent);
            piece.transform.position = GetWorldPosition(boardTile.BoardPosition);
            pieces[boardTile.BoardPosition.x, boardTile.BoardPosition.y] = piece;
        }

        public void ClearBoard()
        {
            if (pieces != null)
            {
                foreach (BoardPiece piece in pieces)
                {
                    if (piece != null)
                    {
                        Destroy(piece.gameObject);
                    }
                }
            }

            pieces = new BoardPiece[_boardData.Size.x, _boardData.Size.y];
        }

        protected virtual void GenerateBoard()
        {
            GenerateLines();
            GenerateTiles();
        }
        
        protected virtual void GenerateTiles()
        {
            for (int x = 0; x < _boardData.Size.x; x++)
            {
                for (int y = 0; y < _boardData.Size.y; y++)
                {
                    BoardTile tile = tiles[x, y] = CreateTile(new BoardPosition(x, y));
                    tile.transform.SetParent(_tilesParent);
                    tile.transform.position = GetWorldPosition(new BoardPosition(x, y));
                    tile.SetCoordinates(new BoardPosition(x, y));
                }
            }
        }
        
        protected virtual void GenerateLines()
        {
            // Vertical Lines
            for (int x = 1; x < _boardData.Size.x; x++)
            {
                GameObject line = Instantiate(_linePrefab, _linesParent);
                line.transform.localScale = new Vector3(LINE_THICKNESS, _boardData.Size.y, 1f);
                line.transform.position = new Vector3(_offset.x + x, _offset.y + _boardData.Size.y / 2f, 0f);
            }

            // Horizontal Lines
            for (int y = 1; y < _boardData.Size.y; y++)
            {
                GameObject line = Instantiate(_linePrefab, _linesParent);
                line.transform.localScale = new Vector3(_boardData.Size.x, LINE_THICKNESS, 1f);
                line.transform.position = new Vector3(_offset.x + _boardData.Size.x / 2f, _offset.y + y, 0f);
            }
        }
        
        protected BoardTile CreateTile(BoardPosition position)
        {
            return _tilesFactory.Get();
        }

        protected Vector3 GetWorldPosition(BoardPosition boardPosition)
        {
            return new Vector3(_offset.x + boardPosition.x + 0.5f, _offset.y + boardPosition.y + 0.5f, 0f);
        }
    }
}