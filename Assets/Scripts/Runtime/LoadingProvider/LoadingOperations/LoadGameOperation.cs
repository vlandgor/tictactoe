using System;
using Cysharp.Threading.Tasks;
using Runtime.UI;
using Runtime.UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadGameOperation : ILoadingOperation
    {
        private const string BOOT_SCENE_NAME = "Game_Scene";
        private const string MENU_SCENE_NAME = "Menu_Scene";
        
        private IUIManager _uiManager;
        
        public string Description => "Loading Game";
        
        public LoadGameOperation(IUIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10f);
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(BOOT_SCENE_NAME, LoadSceneMode.Additive);
            await loadOperation.ToUniTask();
            onProgress?.Invoke(50f);

            await _uiManager.ShowScreen<GameHudScreen>();
            onProgress?.Invoke(75f);
            
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(MENU_SCENE_NAME);
            await unloadOperation.ToUniTask();
            onProgress?.Invoke(100f);
        }
    }
}