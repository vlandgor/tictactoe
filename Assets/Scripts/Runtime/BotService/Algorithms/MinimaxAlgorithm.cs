using Runtime.GameBoard;

namespace Runtime.BotService.Algorithms
{
    public class MinimaxAlgorithm : IBotAlgorithm
    {
        
        public Crd GetMove()
        {
            int bestScore = int.MinValue;
            Crd bestMove = new Crd();

            // // Iterate through all cells to find the best move
            // for (int x = 0; x < _match.BoardSize.x; x++)
            // {
            //     for (int y = 0; y < _match.BoardSize.y; y++)
            //     {
            //         Crd currentCrd = new Crd(x, y);
            //
            //         if (!_match.CheckIfCellIsTaken(currentCrd))
            //         {
            //             // Simulate placing the bot's token
            //             _match.PlaceToken(currentCrd, _botPlayer);
            //
            //             // Evaluate the move using Minimax
            //             int score = Minimax(_match, depth: 0, isMaximizing: false);
            //
            //             // Undo the move
            //             _match.UndoMove(currentCrd);
            //
            //             // Keep track of the best score and move
            //             if (score > bestScore)
            //             {
            //                 bestScore = score;
            //                 bestMove = currentCrd;
            //             }
            //         }
            //     }
            // }

            return bestMove;
        }
        // private int Minimax(Match match, int depth, bool isMaximizing)
        // {
        //     // Check for terminal states
        //     if (match.CheckIfPlayerWon(_botPlayer))
        //         return 10 - depth; // Prefer faster wins
        //     if (match.CheckIfPlayerWon(_opponentPlayer))
        //         return depth - 10; // Prefer slower losses
        //     if (match.IsBoardFull())
        //         return 0; // Draw
        //
        //     // Maximizing player's turn (Bot)
        //     if (isMaximizing)
        //     {
        //         int bestScore = int.MinValue;
        //
        //         for (int x = 0; x < match.BoardSize.x; x++)
        //         {
        //             for (int y = 0; y < match.BoardSize.y; y++)
        //             {
        //                 Crd currentCrd = new Crd(x, y);
        //
        //                 if (!match.CheckIfCellIsTaken(currentCrd))
        //                 {
        //                     // Simulate the move
        //                     match.PlaceToken(currentCrd, _botPlayer);
        //
        //                     // Recursively evaluate
        //                     int score = Minimax(match, depth + 1, false);
        //
        //                     // Undo the move
        //                     match.UndoMove(currentCrd);
        //
        //                     // Update the best score
        //                     bestScore = Math.Max(bestScore, score);
        //                 }
        //             }
        //         }
        //
        //         return bestScore;
        //     }
        //     // Minimizing player's turn (Opponent)
        //     else
        //     {
        //         int bestScore = int.MaxValue;
        //
        //         for (int x = 0; x < match.BoardSize.x; x++)
        //         {
        //             for (int y = 0; y < match.BoardSize.y; y++)
        //             {
        //                 Crd currentCrd = new Crd(x, y);
        //
        //                 if (!match.CheckIfCellIsTaken(currentCrd))
        //                 {
        //                     // Simulate the move
        //                     match.PlaceToken(currentCrd, _opponentPlayer);
        //
        //                     // Recursively evaluate
        //                     int score = Minimax(match, depth + 1, true);
        //
        //                     // Undo the move
        //                     match.UndoMove(currentCrd);
        //
        //                     // Update the best score
        //                     bestScore = Math.Min(bestScore, score);
        //                 }
        //             }
        //         }
        //
        //         return bestScore;
        //     }
        // }
    }
}