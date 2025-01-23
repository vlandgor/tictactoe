using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.MatchManager;

namespace Runtime.LoadingProvider
{
    public interface ILoadingProvider
    {
        public UniTask LoadApp();
        public UniTask LoadMenu();
        public UniTask LoadGame(IMatchData matchData, IBoardData boardData);
    }
}