namespace Runtime.GamePieces
{
    public interface IPieceProvider
    {
        public PieceSet GetPieceSet(int index);
        public PieceSet GetRandomPieceSet();
        public Piece GetPiece(int index, PieceType type);
    }
}