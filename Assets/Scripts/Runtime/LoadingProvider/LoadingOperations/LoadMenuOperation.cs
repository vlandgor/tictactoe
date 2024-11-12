using System;
using Cysharp.Threading.Tasks;
using Runtime.UI;
using Runtime.UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadMenuOperation : ILoadingOperation
    {
        private const string MENU_SCENE_NAME = "Menu_Scene";
        private const string BOOT_SCENE_NAME = "Boot_Scene";
        
        private IUIManager _uiManager;
        
        public string Description => "Loading Menu";

        [Inject]
        public LoadMenuOperation(IUIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10f);
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(MENU_SCENE_NAME, LoadSceneMode.Additive);
            await loadOperation.ToUniTask();
            onProgress?.Invoke(50f);

            await _uiManager.ShowScreen<MainMenuScreen>();
            onProgress?.Invoke(75f);
            
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(BOOT_SCENE_NAME);
            await unloadOperation.ToUniTask();
            onProgress?.Invoke(100f);
        }
    }
}