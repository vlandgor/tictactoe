using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadMenuOperation : ILoadingOperation
    {
        private const string MENU_SCENE_NAME = "Menu_Scene";
        private const string BOOT_SCENE_NAME = "Boot_Scene";
        
        public string Description => "Loading Menu";
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10f);
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(MENU_SCENE_NAME, LoadSceneMode.Additive);
            await loadOperation.ToUniTask();
            onProgress?.Invoke(50f);
            
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(BOOT_SCENE_NAME);
            await unloadOperation.ToUniTask();
            onProgress?.Invoke(100f);
        }
    }
}