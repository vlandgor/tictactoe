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
            
            Debug.Log("Initializing Match...");
            
            IMatchManager matchManager = sceneContext.Container.ResolveId<IMatchManager>(MatchType.Local);
            matchManager.Initialize(_matchData);
            
            Debug.Log("Match Initialized");
            
            Debug.Log("Initializing Board...");
            
            IBoard board = sceneContext.Container.ResolveId<IBoard>(MatchMode.Classic);
            IBoardVisual boardVisual = sceneContext.Container.ResolveId<IBoardVisual>(MatchMode.Classic);
            IBoardManager boardManager = sceneContext.Container.ResolveId<IBoardManager>(MatchType.Local);
            boardManager.Initialize(board, boardVisual, _boardData);
            
            Debug.Log("Board Initialized");
            
            onProgress?.Invoke(100);
        }
    }
}