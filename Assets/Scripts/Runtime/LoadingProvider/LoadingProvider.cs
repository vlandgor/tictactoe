using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.LoadingProvider.LoadingOperations;
using Runtime.UI;
using Zenject;

namespace Runtime.LoadingProvider
{
    public class LoadingProvider : ILoadingProvider
    {
        private ILoadingCurtain _loadingCurtain;
        private IUIManager _uiManager;
        
        [Inject]
        public LoadingProvider(ILoadingCurtain loadingCurtain, IUIManager uiManager)
        {
            _loadingCurtain = loadingCurtain;
            _uiManager = uiManager;
        }
        
        public async UniTask LoadMenu()
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadMenuOperation(_uiManager));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
        
        public async UniTask LoadGame()
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadGameOperation(_uiManager));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
    }
}