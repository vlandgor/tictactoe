using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;
using UnityEngine;

namespace Core.TicTacToe.Board
{
    public class BoardBase
    {
        protected IBoardData boardData;
        protected PieceType[,] board;
        
        protected BoardSize BoardSize => boardData.BoardSize;
        
        private int WinLength => Mathf.Min(BoardSize.width, BoardSize.height);

        public void CreateBoard(IBoardData boardData)
        {
            this.boardData = boardData;
            board = new PieceType[BoardSize.width, BoardSize.height];
            
            for (int x = 0; x < BoardSize.width; x++)
            {
                for (int y = 0; y < BoardSize.height; y++)
                {
                    board[x, y] = PieceType.None;
                }
            }
        }
        
        public void ClearBoard()
        {
            for (int x = 0; x < BoardSize.width; x++)
            {
                for (int y = 0; y < BoardSize.height; y++)
                {
                    board[x, y] = PieceType.None;
                }
            }
        }

        public bool IsTileAvailable(BoardPosition boardPosition)
        {
            if (board[boardPosition.x, boardPosition.y] == PieceType.None)
                return true;

            return false;
        }

        public void PlacePiece(PieceType pieceType, BoardTile boardTile)
        {
            board[boardTile.BoardPosition.x, boardTile.BoardPosition.y] = pieceType;
        }

        public bool CheckForWinner(out PieceType winner)
        {
            // Check rows
            for (int y = 0; y < BoardSize.height; y++)
            {
                for (int x = 0; x <= BoardSize.width - WinLength; x++)
                {
                    if (CheckLine(x, y, 1, 0, out winner))
                        return true;
                }
            }

            // Check columns
            for (int x = 0; x < BoardSize.width; x++)
            {
                for (int y = 0; y <= BoardSize.height - WinLength; y++)
                {
                    if (CheckLine(x, y, 0, 1, out winner))
                        return true;
                }
            }

            // Check diagonals (top-left to bottom-right)
            for (int x = 0; x <= BoardSize.width - WinLength; x++)
            {
                for (int y = 0; y <= BoardSize.height - WinLength; y++)
                {
                    if (CheckLine(x, y, 1, 1, out winner))
                        return true;
                }
            }

            // Check diagonals (bottom-left to top-right)
            for (int x = 0; x <= BoardSize.width - WinLength; x++)
            {
                for (int y = WinLength - 1; y < BoardSize.height; y++)
                {
                    if (CheckLine(x, y, 1, -1, out winner))
                        return true;
                }
            }

            winner = PieceType.None;
            return false;
        }
        
        private bool CheckLine(int startX, int startY, int stepX, int stepY, out PieceType winner)
        {
            PieceType first = board[startX, startY];
            if (first == PieceType.None)
            {
                winner = PieceType.None;
                return false;
            }

            for (int i = 1; i < WinLength; i++)
            {
                int x = startX + i * stepX;
                int y = startY + i * stepY;

                if (board[x, y] != first)
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
                    if (board[x, y] == PieceType.None)
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
}