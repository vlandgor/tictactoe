using Cysharp.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;

namespace Runtime.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        public async UniTask SignIn()
        {
            await UnityServices.InitializeAsync();
            if (!Unity.Services.Authentication.AuthenticationService.Instance.IsSignedIn)
            {
                await Unity.Services.Authentication.AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log($"Player signed in with ID: {Unity.Services.Authentication.AuthenticationService.Instance.PlayerId}");
            }
        }
    }
}