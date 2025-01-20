using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.Extensions;
using Runtime.GameplayCoordinator;
using Runtime.MatchManager;
using Runtime.MatchService;
using Runtime.Utilities;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class InitializeMatchOperation : ILoadingOperation
    {
        private const string GAME_SCENE_NAME = "Game_Scene";
        
        private IMatchData _matchData;
        private IBoardData _boardData;
        
        public string Description => "Initializing Match";

        public InitializeMatchOperation(IMatchData matchData, IBoardData boardData)
        {
            _matchData = matchData;
            _boardData = boardData;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10);
            
            SceneContext sceneContext = LoadingExtensions.FindSceneContext(GAME_SCENE_NAME);
            
            MatchInstaller matchInstaller = sceneContext.Container.Resolve<MatchInstaller>();
            
            onProgress?.Invoke(50);
            
            await matchInstaller.Initialize(_matchData, _boardData);
            
            onProgress?.Invoke(100);
        }
    }
}