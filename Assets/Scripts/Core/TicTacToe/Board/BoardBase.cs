using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;
using UnityEngine;

namespace Core.TicTacToe.Board
{
    public class BoardBase
    {
        protected IBoardData boardData;
        protected PieceType[,] _board;
        
        protected BoardSize BoardSize => boardData.BoardSize;
        
        private int WinLength => Mathf.Min(BoardSize.width, BoardSize.height);

        public void CreateBoard(IBoardData boardData)
        {
            this.boardData = boardData;
            _board = new PieceType[BoardSize.width, BoardSize.height];
            
            for (int x = 0; x < BoardSize.width; x++)
            {
                for (int y = 0; y < BoardSize.height; y++)
                {
                    _board[x, y] = PieceType.None;
                }
            }
        }
        
        public void ClearBoard()
        {
            for (int x = 0; x < BoardSize.width; x++)
            {
                for (int y = 0; y < BoardSize.height; y++)
                {
                    _board[x, y] = PieceType.None;
                }
            }
        }

        public bool IsTileAvailable(BoardPosition boardPosition)
        {
            if (_board[boardPosition.x, boardPosition.y] == PieceType.None)
                return true;

            return false;
        }

        public void PlacePiece(PieceType pieceType, BoardTile boardTile)
        {
            _board[boardTile.BoardPosition.x, boardTile.BoardPosition.y] = pieceType;
        }

        public bool CheckForWinner(out WinnerInfo info)
        {
            // Rows
            for (int y = 0; y < 3; y++)
            {
                if (_board[0, y] != PieceType.None &&
                    _board[0, y] == _board[1, y] &&
                    _board[1, y] == _board[2, y])
                {
                    info = new WinnerInfo(_board[0, y], new BoardPosition(0, y), new BoardPosition(2, y));
                    return true;
                }
            }

            // Columns
            for (int x = 0; x < 3; x++)
            {
                if (_board[x, 0] != PieceType.None &&
                    _board[x, 0] == _board[x, 1] &&
                    _board[x, 1] == _board[x, 2])
                {
                    info = new WinnerInfo(_board[x, 0], new BoardPosition(x, 0), new BoardPosition(x, 2));
                    return true;
                }
            }

            // Diagonal 1
            if (_board[0, 0] != PieceType.None &&
                _board[0, 0] == _board[1, 1] &&
                _board[1, 1] == _board[2, 2])
            {
                info = new WinnerInfo(_board[0, 0], new BoardPosition(0, 0), new BoardPosition(2, 2));
                return true;
            }

            // Diagonal 2
            if (_board[2, 0] != PieceType.None &&
                _board[2, 0] == _board[1, 1] &&
                _board[1, 1] == _board[0, 2])
            {
                info = new WinnerInfo(_board[2, 0], new BoardPosition(2, 0), new BoardPosition(0, 2));
                return true;
            }

            info = default;
            return false;
        }
        
        private bool CheckLine(int startX, int startY, int stepX, int stepY, out PieceType winner)
        {
            PieceType first = _board[startX, startY];
            if (first == PieceType.None)
            {
                winner = PieceType.None;
                return false;
            }

            for (int i = 1; i < WinLength; i++)
            {
                int x = startX + i * stepX;
                int y = startY + i * stepY;

                if (_board[x, y] != first)
                {
                    winner = PieceType.None;
                    return false;
                }
            }

            winner = first;
            return true;
        }

        public bool CheckForDraw(out bool draw)
        {
            for (int x = 0; x < BoardSize.width; x++)
            {
                for (int y = 0; y < BoardSize.height; y++)
                {
                    if (_board[x, y] == PieceType.None)
                    {
                        draw = false;
                        return false;
                    }
                }
            }

            draw = true;
            return true;
        }
    }
    
    public struct WinnerInfo
    {
        public PieceType Winner;
        public BoardPosition Start;
        public BoardPosition End;

        public WinnerInfo(PieceType winner, BoardPosition start, BoardPosition end)
        {
            Winner = winner;
            Start = start;
            End = end;
        }
    }
}