using System;
using Cysharp.Threading.Tasks;
using Runtime.Extensions;
using Runtime.UI.Boot;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class AuthenticationOperation : ILoadingOperation
    {
        private const string BOOT_SCENE_NAME = "Boot_Scene";
        
        public string Description => "Authentication";
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10);
            
            SceneContext sceneContext = LoadingExtensions.FindSceneContext(BOOT_SCENE_NAME);
            IBootMediator bootMediator = sceneContext.Container.Resolve<IBootMediator>();
            
            onProgress?.Invoke(50);
            
            bootMediator.ShowAuthentication();
            
            onProgress?.Invoke(100);
        }
    }
}