using System;
using Cysharp.Threading.Tasks;
using Runtime.UI;
using Runtime.UI.MainMenu.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadMenuOperation : ILoadingOperation
    {
        private const string MENU_SCENE_NAME = "Menu_Scene";
        
        public string Description => "Loading Menu";
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10f);
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(MENU_SCENE_NAME, LoadSceneMode.Single);
            await loadOperation.ToUniTask();
            onProgress?.Invoke(100f);
        }
    }
}