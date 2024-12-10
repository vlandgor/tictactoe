using System;
using Runtime.GameBoard;
using Runtime.GameBoard.Boards;
using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.BotService.Algorithms
{
    public class MinimaxAlgorithm : IBotAlgorithm
    {
        private Board _board;
        private IPlayer _bot;
        private IPlayer _opponent;

        public MinimaxAlgorithm(Board board, IPlayer bot, IPlayer opponent)
        {
            _board = board.Clone<StandardBoard>();
            _bot = bot;
            _opponent = opponent;
        }

        public Crd GetMove()
        {
            int bestScore = int.MinValue;
            Crd bestMove = new Crd();

            // Iterate through all cells to find the best move
            for (int x = 0; x < _board.BoardSize.x; x++)
            {
                for (int y = 0; y < _board.BoardSize.y; y++)
                {
                    Crd currentCrd = new Crd(x, y);

                    if (!_board.CheckIfCellIsTaken(currentCrd))
                    {
                        // Simulate placing the bot's token
                        _board.PlaceToken(currentCrd, _bot);

                        // Evaluate the move using Minimax
                        int score = Minimax(_board, depth: 0, isMaximizing: false);

                        // Undo the move
                        _board.UndoPlaceToken(currentCrd);

                        // Update the best score and move
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = currentCrd;
                        }
                    }
                }
            }

            return bestMove;
        }

        private int Minimax(Board board, int depth, bool isMaximizing)
        {
            // Check for terminal states
            if (board.CheckIfPlayerWon(_bot))
                return 10 - depth; // Prefer faster wins for the bot
            if (board.CheckIfPlayerWon(_opponent))
                return depth - 10; // Prefer slower losses
            if (board.IsBoardFull())
                return 0; // Draw

            if (isMaximizing) // Bot's turn
            {
                int bestScore = int.MinValue;

                for (int x = 0; x < board.BoardSize.x; x++)
                {
                    for (int y = 0; y < board.BoardSize.y; y++)
                    {
                        Crd currentCrd = new Crd(x, y);

                        if (!board.CheckIfCellIsTaken(currentCrd))
                        {
                            // Simulate the move
                            board.PlaceToken(currentCrd, _bot);

                            // Recursively evaluate
                            int score = Minimax(board, depth + 1, isMaximizing: false);

                            // Undo the move
                            board.UndoPlaceToken(currentCrd);

                            // Update the best score
                            bestScore = Math.Max(bestScore, score);
                        }
                    }
                }

                return bestScore;
            }
            else // Opponent's turn
            {
                int bestScore = int.MaxValue;

                for (int x = 0; x < board.BoardSize.x; x++)
                {
                    for (int y = 0; y < board.BoardSize.y; y++)
                    {
                        Crd currentCrd = new Crd(x, y);

                        if (!board.CheckIfCellIsTaken(currentCrd))
                        {
                            // Simulate the move
                            board.PlaceToken(currentCrd, _opponent);

                            // Recursively evaluate
                            int score = Minimax(board, depth + 1, isMaximizing: true);

                            // Undo the move
                            board.UndoPlaceToken(currentCrd);

                            // Update the best score
                            bestScore = Math.Min(bestScore, score);
                        }
                    }
                }

                return bestScore;
            }
        }
    }
}
