using Cysharp.Threading.Tasks;

namespace Runtime.BoardManager
{
    public interface IBoard
    {
        public UniTask Initialize(IBoardData boardData);
    }
}