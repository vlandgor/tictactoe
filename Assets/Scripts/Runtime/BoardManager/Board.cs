using Cysharp.Threading.Tasks;
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

        public bool ValidateInput(Vector2Int coordinate)
        {
            if (board[coordinate.x, coordinate.y] == null)
                return true;

            return false;
        }

        public void PlacePiece(IPlayer player, Vector2Int coordinate)
        {
            board[coordinate.x, coordinate.y] = player;
        }

        public abstract bool CheckForWinner(out IPlayer winner);
        public abstract bool CheckForDraw();
        
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