using System;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.MatchService.MatchProcessors;

namespace Runtime.BotService.Algorithms
{
    public class MinimaxAlgorithm : IBotAlgorithm
    {
        private MatchProcessor _matchProcessor;
        private IPlayer _bot;
        private IPlayer _opponent;

        public MinimaxAlgorithm(MatchProcessor matchProcessor, IPlayer bot, IPlayer opponent)
        {
            _matchProcessor = matchProcessor.Clone<StandardMatchProcessor>();
            _bot = bot;
            _opponent = opponent;
        }

        public Crd GetMove()
        {
            int bestScore = int.MinValue;
            Crd bestMove = new Crd();

            // Iterate through all cells to find the best move
            for (int x = 0; x < _matchProcessor.BoardSize.x; x++)
            {
                for (int y = 0; y < _matchProcessor.BoardSize.y; y++)
                {
                    Crd currentCrd = new Crd(x, y);

                    if (!_matchProcessor.CheckIfCellIsTaken(currentCrd))
                    {
                        // Simulate placing the bot's token
                        _matchProcessor.PlaceToken(currentCrd, _bot);

                        // Evaluate the move using Minimax
                        int score = Minimax(_matchProcessor, depth: 0, isMaximizing: false);

                        // Undo the move
                        _matchProcessor.UndoPlaceToken(currentCrd);

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

        private int Minimax(MatchProcessor matchProcessor, int depth, bool isMaximizing)
        {
            // Check for terminal states
            if (matchProcessor.CheckIfPlayerWon(_bot))
                return 10 - depth; // Prefer faster wins for the bot
            if (matchProcessor.CheckIfPlayerWon(_opponent))
                return depth - 10; // Prefer slower losses
            if (matchProcessor.IsBoardFull())
                return 0; // Draw

            if (isMaximizing) // Bot's turn
            {
                int bestScore = int.MinValue;

                for (int x = 0; x < matchProcessor.BoardSize.x; x++)
                {
                    for (int y = 0; y < matchProcessor.BoardSize.y; y++)
                    {
                        Crd currentCrd = new Crd(x, y);

                        if (!matchProcessor.CheckIfCellIsTaken(currentCrd))
                        {
                            // Simulate the move
                            matchProcessor.PlaceToken(currentCrd, _bot);

                            // Recursively evaluate
                            int score = Minimax(matchProcessor, depth + 1, isMaximizing: false);

                            // Undo the move
                            matchProcessor.UndoPlaceToken(currentCrd);

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

                for (int x = 0; x < matchProcessor.BoardSize.x; x++)
                {
                    for (int y = 0; y < matchProcessor.BoardSize.y; y++)
                    {
                        Crd currentCrd = new Crd(x, y);

                        if (!matchProcessor.CheckIfCellIsTaken(currentCrd))
                        {
                            // Simulate the move
                            matchProcessor.PlaceToken(currentCrd, _opponent);

                            // Recursively evaluate
                            int score = Minimax(matchProcessor, depth + 1, isMaximizing: true);

                            // Undo the move
                            matchProcessor.UndoPlaceToken(currentCrd);

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
