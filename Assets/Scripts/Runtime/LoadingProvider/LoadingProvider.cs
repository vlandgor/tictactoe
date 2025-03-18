using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.LoadingProvider.LoadingOperations;
using Runtime.Logger;
using Runtime.MatchManager;
using UnityEngine;
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
            DLogger.Message(DSenders.Application).WithText($"Loading App...").Log();
            
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new AuthenticationOperation());
            loadingOperation.Enqueue(new LoadSceneOperation(MENU_SCENE_NAME));
            loadingOperation.Enqueue(new InitializePlayerOperation());
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
        
        public async UniTask LoadMenu()
        {
            DLogger.Message(DSenders.Application).WithText($"Loading Menu...").Log();
            
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadSceneOperation(MENU_SCENE_NAME));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
        }
        
        public async UniTask LoadMatch(IMatchData matchData, IBoardData boardData)
        {
            DLogger.Message(DSenders.Application).WithText($"Loading Match...").Log();
            
            Queue<ILoadingOperation> loadingOperation = new Queue<ILoadingOperation>();
            loadingOperation.Enqueue(new LoadSceneOperation(GAME_SCENE_NAME));
            loadingOperation.Enqueue(new InitializeMatchOperation(matchData, boardData));
            
            await _loadingCurtain.ShowCurtain();
            await _loadingCurtain.Load(loadingOperation);
            await _loadingCurtain.HideCurtain();
            
            DLogger.Message(DSenders.Application).WithText($"Match Loaded").Log();
        }
    }
}