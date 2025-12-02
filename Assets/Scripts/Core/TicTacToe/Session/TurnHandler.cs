using System;
using Core.TicTacToe.Board.Pieces;

namespace Core.TicTacToe.Session
{
    public class TurnHandler
    {
        public event Action<PieceType> TurnChanged;

        private TurnOrder _order;
        private int _currentPlayerIndex;

        public PieceType ActivePlayer => _order[_currentPlayerIndex];
        public PieceType InactivePlayer => _order[1 - _currentPlayerIndex];

        public TurnHandler()
        {
            _order = new TurnOrder(PieceType.Cross, PieceType.Circle);
            _currentPlayerIndex = 0;
        }

        public void AdvanceTurn()
        {
            _currentPlayerIndex = 1 - _currentPlayerIndex;
            TurnChanged?.Invoke(ActivePlayer);
        }

        public void SetActivePlayer(PieceType type)
        {
            _currentPlayerIndex = 
                (_order.First == type) ? 0 :
                (_order.Second == type) ? 1 :
                throw new ArgumentException($"Unknown piece type: {type}");

            TurnChanged?.Invoke(ActivePlayer);
        }

        public void SetTurnOrder(PieceType first, PieceType second)
        {
            _order = new TurnOrder(first, second);
            _currentPlayerIndex = 0;
            TurnChanged?.Invoke(ActivePlayer);
        }

        public void SwapStartingPlayers()
        {
            _order = _order.Swap();
            _currentPlayerIndex = 0;
            TurnChanged?.Invoke(ActivePlayer);
        }
    }

    public readonly struct TurnOrder
    {
        public readonly PieceType First;
        public readonly PieceType Second;

        public TurnOrder(PieceType first, PieceType second)
        {
            First = first;
            Second = second;
        }

        public PieceType this[int index] =>
            index == 0 ? First : Second;

        public TurnOrder Swap() =>
            new TurnOrder(Second, First);
    }
}