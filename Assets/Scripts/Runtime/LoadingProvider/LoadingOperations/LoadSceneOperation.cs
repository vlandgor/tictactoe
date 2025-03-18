using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadSceneOperation : ILoadingOperation
    {
        private string _sceneName;
        
        public string Description => "Loading Game_Scene";
        
        public LoadSceneOperation(string sceneName)
        {
            _sceneName = sceneName;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10);

            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
            await loadOperation.ToUniTask();
            
            onProgress?.Invoke(100);
        }
    }
}