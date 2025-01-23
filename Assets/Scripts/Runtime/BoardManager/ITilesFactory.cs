namespace Runtime.BoardManager
{
    public interface ITilesFactory
    {
        public T Get<T>() where T : BoardTile;
    }
}