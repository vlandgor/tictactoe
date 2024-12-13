using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.LoadingProvider.LoadingOperations;
using Runtime.MatchService;
using Zenject;

namespace Runtime.LoadingProvider
{
    public class LoadingProvider : ILoadingProvider
    {
        private const string MENU_SCENE_NAME = "Menu_Scene";
        private const string GAME_SCENE_NAME = "Game_Scene";
        
        private ILoadingCurtain _loadingCurtain;
        
        [Inject]
        public LoadingProvider(ILoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }

        public async UniTask LoadApp()
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadSceneOperation(MENU_SCENE_NAME));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
        
        public async UniTask LoadMenu()
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadSceneOperation(MENU_SCENE_NAME));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
        
        public async UniTask LoadGame(Match match)
        {
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadSceneOperation(GAME_SCENE_NAME));
            loadingOperation.Enqueue(new GenerateGameBoardOperation(match.Board));
            loadingOperation.Enqueue(new InitializeMatchOperation(match));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
    }
}