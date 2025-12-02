using System;
using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Utilities;

namespace Core.TicTacToe.Session
{
    public class ScoreTracker
    {
        public event Action<PieceType, int> ScoreUpdated;

        private PiecePair<int> _scores;
        private readonly int _winningScore;

        public ScoreTracker(int winningScore)
        {
            if (winningScore <= 0)
                throw new ArgumentException("Winning score must be greater than zero.", nameof(winningScore));

            _winningScore = winningScore;
            
            _scores = new PiecePair<int>(0, 0);
        }

        public void IncrementScore(PieceType type, int amount = 1)
        {
            _scores.Ref(type) += amount;
            ScoreUpdated?.Invoke(type, _scores.Cross);
        }

        public int GetScore(PieceType type)
        {
            return _scores.Get(type);
        }

        public void ResetScores()
        {
            _scores = new PiecePair<int>(0, 0);
            ScoreUpdated?.Invoke(PieceType.Cross, 0);
            ScoreUpdated?.Invoke(PieceType.Circle, 0);
        }

        public bool TryGetWinner(out PieceType winner)
        {
            if (_scores.Cross >= _winningScore)
            {
                winner = PieceType.Cross;
                return true;
            }

            if (_scores.Circle >= _winningScore)
            {
                winner = PieceType.Circle;
                return true;
            }

            winner = PieceType.None;
            return false;
        }
    }
}
