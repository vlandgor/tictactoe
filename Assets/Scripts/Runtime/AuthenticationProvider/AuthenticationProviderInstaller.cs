using Cysharp.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
using Zenject;

namespace Runtime.AuthenticationProvider
{
    public class AuthenticationProviderInstaller : MonoInstaller
    {
        public override async void InstallBindings()
        {
            await InitializeUnityServices();
            
            BindAuthentication();
        }

        private async UniTask InitializeUnityServices()
        {
            try
            {
                await UnityServices.InitializeAsync();
                Debug.Log("Unity services initialized successfully.");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to initialize Unity services: {ex.Message}");
                throw;
            }
        }
        
        private void BindAuthentication()
        {
            Container
                .Bind<IAuthenticationProvider>()
                .To<AuthenticationProvider>()
                .AsSingle();
        }
    }
}