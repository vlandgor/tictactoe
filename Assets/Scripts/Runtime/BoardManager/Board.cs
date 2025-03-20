using Cysharp.Threading.Tasks;
using Runtime.BoardManager.Local;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.BoardManager
{
    public abstract class Board : IBoard
    {
        protected IBoardData boardData;
        
        protected IPlayer[,] board;
        
        public Vector2Int BoardSize => boardData.Size;

        public async UniTask Initialize(IBoardData boardData)
        {
            this.boardData = boardData;
            
            CreateBoard();
        }

        public bool ValidateInput(BoardPosition boardPosition)
        {
            if (board[boardPosition.x, boardPosition.y] == null)
                return true;

            return false;
        }

        public void PlacePiece(IPlayer player, BoardPosition boardPosition)
        {
            board[boardPosition.x, boardPosition.y] = player;
        }

        public abstract bool CheckForWinner(out IPlayer winner);
        public abstract bool CheckForDraw(out bool draw);
        
        private void CreateBoard()
        {
            board = new IPlayer[BoardSize.x, BoardSize.y];
            
            for (int x = 0; x < BoardSize.x; x++)
            {
                for (int y = 0; y < BoardSize.y; y++)
                {
                    board[x, y] = null;
                }
            }
        }
        public void ClearBoard()
        {
            for (int x = 0; x < BoardSize.x; x++)
            {
                for (int y = 0; y < BoardSize.y; y++)
                {
                    board[x, y] = null;
                }
            }
        }
    }
}