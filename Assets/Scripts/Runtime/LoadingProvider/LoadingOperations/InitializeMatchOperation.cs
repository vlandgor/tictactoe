using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.Extensions;
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
            
            Debug.Log("Initializing Board...");
            
            IBoardManager boardManager = sceneContext.Container.ResolveId<IBoardManager>(MatchType.Local);
            
            await boardManager.Initialize(_boardData);
            
            Debug.Log("Board Initialized");
            
            Debug.Log("Initializing Match...");
            
            IMatchManager matchManager = sceneContext.Container.ResolveId<IMatchManager>(MatchType.Local);
            matchManager.Initialize(_matchData);
            
            Debug.Log("Match Initialized");
            
            onProgress?.Invoke(100);
        }
    }
}