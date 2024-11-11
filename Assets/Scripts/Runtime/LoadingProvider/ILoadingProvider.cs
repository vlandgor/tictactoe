using Cysharp.Threading.Tasks;

namespace Runtime.LoadingProvider
{
    public interface ILoadingProvider
    {
        public UniTask LoadMenu();
        public UniTask LoadGame();
    }
}