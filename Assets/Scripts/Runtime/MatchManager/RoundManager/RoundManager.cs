using System.Collections.Generic;
using Runtime.GamePieces;
using Runtime.GamePlayer;

namespace Runtime.MatchManager
{
    public class RoundManager
    {
        private IPlayer[] players;
        private Queue<PlayerMove> moves = new();

        private IPlayer _firstTurn;
        
        public IPlayer Turn { get; private set; }
        public PieceType TurnType { get; private set; }

        public RoundManager(IMatchData matchData)
        {
            players = matchData.Players;
        }

        public void FirstRound(IPlayer firstTurn)
        {
            _firstTurn = firstTurn;
            Turn = firstTurn;
            TurnType = PieceType.Cross;
        }
        
        public void NextRound()
        {
            Turn = GetOpponent(_firstTurn);
            TurnType = PieceType.Cross;
        }
        
        public void FinishRound(IPlayer winner, out Round round)
        {
            moves.Clear();
            
            round = new Round(winner, moves);
        }
        
        public void NextTurn()
        {
            Turn = GetOpponent(Turn);
            TurnType = TurnType == PieceType.Cross ? PieceType.Circle : PieceType.Cross;
        }

        private IPlayer GetOpponent(IPlayer player)
        {
            int currentIndex = System.Array.IndexOf(players, Turn);
            int opponentIndex = (currentIndex + 1) % players.Length;

            return players[opponentIndex];
        }
    }
}