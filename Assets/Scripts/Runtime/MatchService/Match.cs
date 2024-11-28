using Runtime.GameBoard;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.MatchService
{
    public class Match
    {
        private IPlayer[,] _board;
        private Vector2Int _boardSize;
        
        public IPlayer[,] Board => _board;
        public Vector2Int BoardSize => _boardSize;
        
        public Match(Vector2Int boardSize)
        {
            _boardSize = boardSize;
            GenerateBoard(boardSize);
        }
        
        public bool PlaceToken(Crd crd, IPlayer player)
        {
            if(CheckIfCellIsTaken(crd))
                return false;
            
            _board[crd.x, crd.y] = player;
            return true;
        }
        
        public void UndoPlaceToken(Crd crd)
        {
            _board[crd.x, crd.y] = null;
        }
        
        public void Restart()
        {
            for (int i = 0; i < _boardSize.x; i++)
            {
                for (int j = 0; j < _boardSize.y; j++)
                {
                    _board[i, j] = null;
                }
            }
        }
        
        public bool CheckIfPlayerWon(IPlayer player)
        {
            for (int i = 0; i < _boardSize.x; i++)
            {
                if (CheckRow(i, player) || CheckColumn(i, player))
                    return true;
            }
            
            if (CheckDiagonal(player) || CheckAntiDiagonal(player))
                return true;

            return false;
        }
        
        public bool IsBoardFull()
        {
            for (int i = 0; i < _boardSize.x; i++)
            {
                for (int j = 0; j < _boardSize.y; j++)
                {
                    if (_board[i, j] == null)
                        return false;
                }
            }
            return true;
        }
        
        public bool CheckIfCellIsTaken(Crd crd)
        {
            if(_board[crd.x, crd.y] != null)
                return true;

            return false;
        }
        
        public Match Clone()
        {
            var clonedMatch = new Match(_boardSize);
            for (int i = 0; i < _boardSize.x; i++)
            {
                for (int j = 0; j < _boardSize.y; j++)
                {
                    clonedMatch._board[i, j] = _board[i, j];
                }
            }
            return clonedMatch;
        }
        
        private void GenerateBoard(Vector2Int boardSize)
        {
            _board = new IPlayer[boardSize.x, boardSize.y];
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = null;
                }
            }
        }
        
        private bool CheckRow(int row, IPlayer player)
        {
            for (int col = 0; col < _boardSize.x; col++)
            {
                if (_board[row, col] != player)
                    return false;
            }
            return true;
        }

        private bool CheckColumn(int col, IPlayer player)
        {
            for (int row = 0; row < _boardSize.x; row++)
            {
                if (_board[row, col] != player)
                    return false;
            }
            return true;
        }

        private bool CheckDiagonal(IPlayer player)
        {
            for (int i = 0; i < _boardSize.x; i++)
            {
                if (_board[i, i] != player)
                    return false;
            }
            return true;
        }

        private bool CheckAntiDiagonal(IPlayer player)
        {
            for (int i = 0; i < _boardSize.x; i++)
            {
                if (_board[i, _boardSize.x - i - 1] != player)
                    return false;
            }
            return true;
        }
    }
}