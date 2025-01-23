namespace Runtime.GamePieces
{
    public interface IPiecesFactory
    {
        public T Get<T>(T prefab) where T : Piece;
    }
}