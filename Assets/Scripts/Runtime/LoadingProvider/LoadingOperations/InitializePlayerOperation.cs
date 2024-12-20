using System;
using Cysharp.Threading.Tasks;
using Runtime.Extensions;
using Runtime.UI.Menu;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class InitializePlayerOperation : ILoadingOperation
    {
        private const string MENU_SCENE_NAME = "Menu_Scene";
        
        public string Description => "Initialize Player";

        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10);
            
            SceneContext sceneContext = LoadingExtensions.FindSceneContext(MENU_SCENE_NAME);
            
            IMenuMediator menuMediator = sceneContext.Container.Resolve<IMenuMediator>();
            
            string name = await Unity.Services.Authentication.AuthenticationService.Instance.GetPlayerNameAsync();
            menuMediator.SetPlayerInfo(name);
            
            onProgress?.Invoke(100);
        }
    }
}