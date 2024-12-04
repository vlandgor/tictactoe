using System;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.MatchService.MatchModes;

namespace Runtime.BotService.Algorithms
{
    public class MinimaxAlgorithm : IBotAlgorithm
    {
        private Match _match;
        private IPlayer _bot;
        private IPlayer _opponent;

        public MinimaxAlgorithm(Match match, IPlayer bot, IPlayer opponent)
        {
            _match = match.Clone<StandardMatch>();
            _bot = bot;
            _opponent = opponent;
        }

        public Crd GetMove()
        {
            int bestScore = int.MinValue;
            Crd bestMove = new Crd();

            // Iterate through all cells to find the best move
            for (int x = 0; x < _match.BoardSize.x; x++)
            {
                for (int y = 0; y < _match.BoardSize.y; y++)
                {
                    Crd currentCrd = new Crd(x, y);

                    if (!_match.CheckIfCellIsTaken(currentCrd))
                    {
                        // Simulate placing the bot's token
                        _match.PlaceToken(currentCrd, _bot);

                        // Evaluate the move using Minimax
                        int score = Minimax(_match, depth: 0, isMaximizing: false);

                        // Undo the move
                        _match.UndoPlaceToken(currentCrd);

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

        private int Minimax(Match match, int depth, bool isMaximizing)
        {
            // Check for terminal states
            if (match.CheckIfPlayerWon(_bot))
                return 10 - depth; // Prefer faster wins for the bot
            if (match.CheckIfPlayerWon(_opponent))
                return depth - 10; // Prefer slower losses
            if (match.IsBoardFull())
                return 0; // Draw

            if (isMaximizing) // Bot's turn
            {
                int bestScore = int.MinValue;

                for (int x = 0; x < match.BoardSize.x; x++)
                {
                    for (int y = 0; y < match.BoardSize.y; y++)
                    {
                        Crd currentCrd = new Crd(x, y);

                        if (!match.CheckIfCellIsTaken(currentCrd))
                        {
                            // Simulate the move
                            match.PlaceToken(currentCrd, _bot);

                            // Recursively evaluate
                            int score = Minimax(match, depth + 1, isMaximizing: false);

                            // Undo the move
                            match.UndoPlaceToken(currentCrd);

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

                for (int x = 0; x < match.BoardSize.x; x++)
                {
                    for (int y = 0; y < match.BoardSize.y; y++)
                    {
                        Crd currentCrd = new Crd(x, y);

                        if (!match.CheckIfCellIsTaken(currentCrd))
                        {
                            // Simulate the move
                            match.PlaceToken(currentCrd, _opponent);

                            // Recursively evaluate
                            int score = Minimax(match, depth + 1, isMaximizing: true);

                            // Undo the move
                            match.UndoPlaceToken(currentCrd);

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
