using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;
using UnityEngine;

using UAS = Unity.Services.Authentication.AuthenticationService;

namespace Runtime.Authentication
{
    public class UnityAuthenticationProvider : IAuthenticationProvider, IDisposable
    {
        private TaskCompletionSource<bool> _signInTaskCompletionSource;
        
        public UnityAuthenticationProvider(TaskCompletionSource<bool> signInTaskCompletionSource)
        {
            _signInTaskCompletionSource = signInTaskCompletionSource;
            PlayerAccountService.Instance.SignedIn += HandleSignInWithUnityAsync;
        }
        
        public void Dispose()
        {
            PlayerAccountService.Instance.SignedIn -= HandleSignInWithUnityAsync;
        }
        
        public async UniTask SignIn()
        {
            await PlayerAccountService.Instance.StartSignInAsync();
        }

        public async UniTask SignOut()
        {
            PlayerAccountService.Instance.SignOut();
        }
        
        private async void HandleSignInWithUnityAsync()
        {
            try
            {
                await UAS.Instance.SignInWithUnityAsync(PlayerAccountService.Instance.AccessToken);
                
                string name = await UAS.Instance.GetPlayerNameAsync();
                Debug.Log($"Name : {name}");
                
                _signInTaskCompletionSource.SetResult(true);
                Debug.Log("Sign-in with Unity successful.");
            }
            catch (AuthenticationException ex)
            {
                Debug.LogError($"AuthenticationException: {ex.Message}");
            }
            catch (RequestFailedException ex)
            {
                Debug.LogError($"RequestFailedException: {ex.Message}");
            }
        }
    }
}