using Runtime.GamePlayer;

namespace Runtime.GameModes.ClassicMode.Board
{
    public class ClassicBoard : BoardManager.Board
    {
        public override bool CheckForWinner(out IPlayer winner)
        {
            // Check rows, columns, and diagonals for a winning line
            for (int i = 0; i < BoardSize.x; i++)
            {
                // Check row
                if (board[i, 0] != null &&
                    board[i, 0] == board[i, 1] &&
                    board[i, 1] == board[i, 2])
                {
                    winner = board[i, 0];
                    return true;
                }

                // Check column
                if (board[0, i] != null &&
                    board[0, i] == board[1, i] &&
                    board[1, i] == board[2, i])
                {
                    winner = board[0, i];
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] != null &&
                board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2])
            {
                winner = board[0, 0];
                return true;
            }

            if (board[0, 2] != null &&
                board[0, 2] == board[1, 1] &&
                board[1, 1] == board[2, 0])
            {
                winner = board[0, 2];
                return true;
            }

            // No winner
            winner = null;
            return false;
        }
        public override bool CheckForDraw()
        {
            // Check if all cells are filled and there is no winner
            for (int x = 0; x < BoardSize.x; x++)
            {
                for (int y = 0; y < BoardSize.y; y++)
                {
                    if (board[x, y] == null)
                    {
                        return false; // Empty cell found, not a draw
                    }
                }
            }

            // If no winner and all cells are filled, it's a draw
            return true;
        }
    }
}