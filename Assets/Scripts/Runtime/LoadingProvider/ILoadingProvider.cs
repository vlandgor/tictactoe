using Cysharp.Threading.Tasks;
using Runtime.GameSession;

namespace Runtime.LoadingProvider
{
    public interface ILoadingProvider
    {
        public UniTask LoadApp();
        public UniTask LoadMenu();
        public UniTask LoadGame(MatchData matchData);
    }
}