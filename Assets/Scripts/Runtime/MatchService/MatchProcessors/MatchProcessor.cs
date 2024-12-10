using Runtime.GameBoard;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.MatchService.MatchProcessors
{
    public abstract class MatchProcessor
    {
        protected IPlayer[,] _board;
        
        public Vector2Int BoardSize { get; }
        
        public MatchProcessor(Vector2Int boardSize)
        {
            BoardSize = boardSize;
            GenerateBoard(boardSize);
        }
        

        public abstract bool PlaceToken(Crd crd, IPlayer player);
        public abstract void UndoPlaceToken(Crd crd);

        public void Reset()
        {
            GenerateBoard(BoardSize);
        }
        
        public virtual bool CheckIfPlayerWon(IPlayer player)
        {
            for (int i = 0; i < BoardSize.x; i++)
            {
                if (CheckRow(i, player) || CheckColumn(i, player))
                    return true;
            }
            
            if (CheckDiagonal(player) || CheckAntiDiagonal(player))
                return true;

            return false;
        }
        
        public virtual bool IsBoardFull()
        {
            for (int i = 0; i < BoardSize.x; i++)
            {
                for (int j = 0; j < BoardSize.y; j++)
                {
                    if (_board[i, j] == null)
                        return false;
                }
            }
            return true;
        }
        
        public virtual bool CheckIfCellIsTaken(Crd crd)
        {
            if(_board[crd.x, crd.y] != null)
                return true;

            return false;
        }
        
        public T Clone<T>() where T : MatchProcessor
        {
            T clonedMatch = (T)CreateInstance(BoardSize);
            for (int i = 0; i < BoardSize.x; i++)
            {
                for (int j = 0; j < BoardSize.y; j++)
                {
                    clonedMatch._board[i, j] = _board[i, j];
                }
            }
            return clonedMatch;
        }
        
        protected abstract MatchProcessor CreateInstance(Vector2Int boardSize);
        
        protected void GenerateBoard(Vector2Int boardSize)
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
        
        protected bool CheckRow(int row, IPlayer player)
        {
            for (int col = 0; col < BoardSize.x; col++)
            {
                if (_board[row, col] != player)
                    return false;
            }
            return true;
        }
        protected bool CheckColumn(int col, IPlayer player)
        {
            for (int row = 0; row < BoardSize.x; row++)
            {
                if (_board[row, col] != player)
                    return false;
            }
            return true;
        }
        protected bool CheckDiagonal(IPlayer player)
        {
            for (int i = 0; i < BoardSize.x; i++)
            {
                if (_board[i, i] != player)
                    return false;
            }
            return true;
        }
        protected bool CheckAntiDiagonal(IPlayer player)
        {
            for (int i = 0; i < BoardSize.x; i++)
            {
                if (_board[i, BoardSize.x - i - 1] != player)
                    return false;
            }
            return true;
        }
    }
}