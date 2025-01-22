using Cysharp.Threading.Tasks;

namespace Runtime.BoardManager
{
    public interface IBoardManager
    {
        public UniTask Initialize(IBoard board, IBoardVisual boardVisual, IBoardData boardData);
    }
}