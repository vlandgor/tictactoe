using Cysharp.Threading.Tasks;

namespace Runtime.BoardManager
{
    public interface IBoardManager
    {
        public UniTask Initialize(IBoardData boardData);
    }
}