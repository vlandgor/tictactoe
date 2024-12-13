using Cysharp.Threading.Tasks;
using Runtime.MatchService;

namespace Runtime.LoadingProvider
{
    public interface ILoadingProvider
    {
        public UniTask LoadApp();
        public UniTask LoadMenu();
        public UniTask LoadGame(Match match);
    }
}