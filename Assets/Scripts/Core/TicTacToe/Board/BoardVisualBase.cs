using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;
using UnityEngine;

namespace Core.TicTacToe.Board
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
        protected GameObject _winningLine;
        
        protected BoardTile[,] tiles;
        protected BoardPiece[,] pieces;

        public virtual void Initialize(IBoardData boardData)
        {
            _boardData = boardData;
            _offset = new Vector2(-_boardData.BoardSize.width / 2f, -_boardData.BoardSize.height / 2f);

            tiles = new BoardTile[boardData.BoardSize.width, boardData.BoardSize.height];
            pieces = new BoardPiece[boardData.BoardSize.width, boardData.BoardSize.height];

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

            pieces = new BoardPiece[_boardData.BoardSize.width, _boardData.BoardSize.height];
        }

        protected virtual void GenerateBoard()
        {
            GenerateLines();
            GenerateTiles();
        }
        
        protected virtual void GenerateTiles()
        {
            for (int x = 0; x < _boardData.BoardSize.width; x++)
            {
                for (int y = 0; y < _boardData.BoardSize.height; y++)
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
            for (int x = 1; x < _boardData.BoardSize.width; x++)
            {
                GameObject line = Instantiate(_linePrefab, _linesParent);
                line.transform.localScale = new Vector3(LINE_THICKNESS, _boardData.BoardSize.height, 1f);
                line.transform.position = new Vector3(_offset.x + x, _offset.y + _boardData.BoardSize.height / 2f, 0f);
            }

            // Horizontal Lines
            for (int y = 1; y < _boardData.BoardSize.height; y++)
            {
                GameObject line = Instantiate(_linePrefab, _linesParent);
                line.transform.localScale = new Vector3(_boardData.BoardSize.width, LINE_THICKNESS, 1f);
                line.transform.position = new Vector3(_offset.x + _boardData.BoardSize.width / 2f, _offset.y + y, 0f);
            }
        }
        
        public void DrawWinningLine(WinnerInfo info)
        {
            if (_winningLine != null)
                Destroy(_winningLine);

            Vector3 start = GetWorldPosition(info.Start);
            Vector3 end = GetWorldPosition(info.End);
            Vector3 dir = (end - start).normalized;
            float halfCell = 0.25f;

            start -= dir * halfCell;
            end   += dir * halfCell;

            _winningLine = Instantiate(_linePrefab, _linesParent);

            Vector3 center = (start + end) * 0.5f;
            _winningLine.transform.position = center;

            float length = Vector3.Distance(start, end);

            _winningLine.transform.localScale = new Vector3(
                length,
                LINE_THICKNESS,
                1f
            );

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            _winningLine.transform.rotation = Quaternion.Euler(0, 0, angle);
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