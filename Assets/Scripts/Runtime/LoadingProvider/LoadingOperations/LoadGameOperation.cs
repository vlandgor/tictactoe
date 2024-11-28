using System;
using Cysharp.Threading.Tasks;
using Runtime.MatchService;
using Runtime.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadGameOperation : ILoadingOperation
    {
        private const string GAME_SCENE_NAME = "Game_Scene";
        
        public string Description => "Loading Game";
        
        private MatchData _matchData;
        
        public LoadGameOperation(MatchData matchData)
        {
            _matchData = matchData;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10);

            await LoadSceneAsync(GAME_SCENE_NAME);
            onProgress?.Invoke(50);

            await InitializeMatchService();
            onProgress?.Invoke(100);
        }
        
        private async UniTask LoadSceneAsync(string sceneName)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            await loadOperation.ToUniTask();
        }
        
        private async UniTask InitializeMatchService()
        {
            Debug.Log("Looking for SceneContext in the scene...");
            SceneContext sceneContext = FindSceneContext(SceneManager.GetSceneByName(GAME_SCENE_NAME));
            Debug.Log("SceneContext found: " + sceneContext);
            
            if (sceneContext != null)
            {
                Debug.Log("Initializing MatchService...");
                IMatchService matchService = sceneContext.Container.Resolve<IMatchService>();
                Debug.Log("MatchService found in the scene.");
                
                await matchService.Initialize(_matchData);
            }
            else
            {
                Debug.LogWarning("SceneContext not found in the scene.");
            }
        }
        
        private SceneContext FindSceneContext(Scene scene)
        {
            // Search for the SceneContext in the loaded scene
            foreach (var rootObject in scene.GetRootGameObjects())
            {
                var sceneContext = rootObject.GetComponent<SceneContext>();
                if (sceneContext != null)
                {
                    return sceneContext;
                }
            }
            return null;
        }
    }
}