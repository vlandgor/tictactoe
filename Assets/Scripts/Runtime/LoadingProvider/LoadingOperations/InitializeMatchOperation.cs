using System;
using Cysharp.Threading.Tasks;
using Runtime.GameplayCoordinator;
using Runtime.MatchService;
using Runtime.Utilities;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class InitializeMatchOperation : ILoadingOperation
    {
        private const string GAME_SCENE_NAME = "Game_Scene";
        
        private Match _match;
        
        public string Description => "Initializing Match";

        public InitializeMatchOperation(Match match)
        {
            _match = match;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10);
            
            SceneContext sceneContext = LoadingExtensions.FindSceneContext(GAME_SCENE_NAME);
            IGameplayCoordinator gameplayCoordinator = sceneContext.Container.Resolve<IGameplayCoordinator>();
            
            onProgress?.Invoke(50);
            
            await gameplayCoordinator.InitializeMatch(_match);
            
            onProgress?.Invoke(100);
        }
    }
}