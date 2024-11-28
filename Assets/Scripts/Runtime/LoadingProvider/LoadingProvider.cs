using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.LoadingProvider.LoadingOperations;
using Runtime.MatchService;
using Runtime.UI;
using Zenject;

namespace Runtime.LoadingProvider
{
    public class LoadingProvider : ILoadingProvider
    {
        private ILoadingCurtain _loadingCurtain;
        
        [Inject]
        public LoadingProvider(ILoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }
        
        public async UniTask LoadMenu()
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadMenuOperation());
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
        
        public async UniTask LoadGame(MatchData matchData)
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadGameOperation(matchData));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
    }
}