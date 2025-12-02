using Core.TicTacToe.Board.Pieces;

namespace Core.TicTacToe.Utilities
{
    public class PiecePair<T>
    {
        public T Cross;
        public T Circle;

        public PiecePair(T cross, T circle)
        {
            Cross = cross;
            Circle = circle;
        }

        public T Get(PieceType type) =>
            type == PieceType.Cross ? Cross : Circle;
        
        public ref T Ref(PieceType type)
            => ref (type == PieceType.Cross ? ref Cross : ref Circle);
    }
}