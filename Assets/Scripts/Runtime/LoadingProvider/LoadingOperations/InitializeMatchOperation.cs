using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.Extensions;
using Runtime.Logger;
using Runtime.MatchManager;
using UnityEngine;
using Zenject;
using MatchType = Runtime.MatchManager.MatchType;

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
            
            IBoardManager boardManager = sceneContext.Container.ResolveId<IBoardManager>(_matchData.MatchType);
            await boardManager.Initialize(_boardData);
            
            IMatchManager matchManager = sceneContext.Container.ResolveId<IMatchManager>(_matchData.MatchType);
            await matchManager.Initialize(_matchData);
            
            onProgress?.Invoke(100);
        }
    }
}